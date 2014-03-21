using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ffxivlib;

namespace PrecisionRep
{
    public partial class PreciRepMainForm : Form
    {
        FFXIVLIB lib;
        Chatlog chatlog;
        RepPerson MyRepPerson;
        Entity[] Entities;
        List<RepPerson> RepPersonList;
        ChatlogParser chatlogparser;

        List<EntitiesSnap> EntitySnapList;

        public PreciRepMainForm()
        {
            InitializeComponent();

            RepPersonList = new List<RepPerson>();
        }

        /// <summary>
        /// バックグランドウォーカー
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            InitalizeRep();
            while (!backgroundWorker1.CancellationPending)
            {
                UpdateRep();
                DateTime now = DateTime.Now;
                EntitySnapList.Insert(0,new EntitiesSnap(now, GetEntities()));
                for (int i = EntitySnapList.Count - 1; i > 0; i--)
                {
                    if (EntitySnapList[i].timestamp.AddSeconds(3) < now)
                    {
                        EntitySnapList.RemoveAt(i);
                    }
                }
                System.Threading.Thread.Sleep(300);
            }
        }
        /// <summary>
        /// REPの初期化
        /// </summary>
        private void InitalizeRep()
        {
                lib = new FFXIVLIB();
            chatlog = lib.GetChatlog();
            RepPersonList.Clear();
            Entities = GetEntities();
            EntitySnapList = new List<EntitiesSnap>();
            EntitySnapList.Add(new EntitiesSnap(DateTime.Now, Entities));
            chatlogparser = new ChatlogParser();

            //自分
            Entity myself = Entities[0];
            MyRepPerson = new RepPerson(myself, PersonType.MySelf);
            RepPersonList.Add(MyRepPerson);
            chatlogparser.AddDDPerson(MyRepPerson.ddperson);

            //PTメンバー
            for (int i = 0; i < 8; i++)
            {
                PartyMember pm = lib.GetPartyMemberInfo(i);
                if (pm != null)
                {
                    if (pm.Name == MyRepPerson.name) continue;
                    if (RepPersonList.Count(obj => obj.name == pm.Name) > 0) continue;
                    foreach (Entity ent in Entities.Where(obj=>obj.Name==pm.Name))
                    {
                        if (ent.Name == pm.Name)
                        {
                            RepPerson repperson = new RepPerson(ent, PersonType.PTMember);
                            RepPersonList.Add(repperson);
                            chatlogparser.AddDDPerson(repperson.ddperson);
                            break;
                        }
                    }
                }
            }
            //chatlog clear
            chatlog.GetChatLogLines();
        }

        private bool HasEnemies()
        {
            List<Entity> PTMemberList = new List<Entity>();
            Entity ct = lib.GetCurrentTarget();

            //PTメンバー
            for (int i = 0; i < 8; i++)
            {
                PartyMember pm = lib.GetPartyMemberInfo(i);                
                if (pm != null&& pm.PlayerID!=0)
                {
                    if (Entities.Count(obj => obj.TargetId == pm.PlayerID)>0) return true;
                }
            }

            if (Entities.Length > 0)
            {
                Entity myself = Entities[0];
                if (myself.PCId != 0)
                {
                    if (Entities.Count(obj => obj.TargetId == myself.PCId) > 0) return true;
                }
            }

            return false;
        }

        /// <summary>
        /// REP更新
        /// </summary>
        private void UpdateRep()
        {
            DateTime time = DateTime.Now;
            if (chatlog.IsNewLine())
            {
                foreach (Chatlog.Entry ent in chatlog.GetChatLogLines())
                {
                    object res = null;
                    FFXIVLog log = FFXIVLog.ParseSingleLog(ent.Raw);
                    //フィルタ
                    if (log.LogTypeHexString == "003C") continue;//エラーログ

                    //解析用
                    PreciRepDataSet.ParsingReportRow row = preciRepDataSet1.ParsingReport.NewParsingReportRow();
                    row.ID = preciRepDataSet1.ParsingReport.Count;
                    preciRepDataSet1.ParsingReport.AddParsingReportRow(row);
                    row.DateTime = time;
                    row.LogHex = log.LogTypeHexString;
                    row.LogBody = log.LogBodyReplaceTabCode;
                    if(log.LogType >= 0x08 && log.LogType <= 0x0b)
                    {
                        row.LogType = "myself";
                    }
                    else if(log.LogType >= 0x10 && log.LogType <= 0x13)
                    {
                        row.LogType = "ptmember";
                    }
                    else{
                        row.LogType="others";
                    }

                    EntitiesSnap entsnap = EntitySnapList[0];
                    for (int i = 1; i < EntitySnapList.Count; i++)
                    {
                        if (EntitySnapList[i].timestamp.AddSeconds(1.0) < time)
                        {
                            entsnap = EntitySnapList[i];
                            break;
                        }
                    }

                    chatlogparser.Parse(time, log, entsnap.Entities,out res);
                    if (res != null)
                    {
                        Parsing(res, row);
                    }
                    ////自分
                    //if (row.LogType == "myself")
                    //{
                    //    if (MyRepPerson.UpdateDDByChatlog(time, log, out res))
                    //    {
                    //        Parsing(res, row);
                    //        goto next;
                    //    }
                    //    goto next;
                    //}


                    //foreach (RepPerson person in RepPersonList)
                    //{
                    //    if (person.LastDDAction != null && !person.LastDDAction.Area)
                    //    {//単発攻撃のアクション
                    //        if (person.UpdateDDByChatlog(time, log, out res))
                    //        {
                    //            Parsing(res, row);
                    //            goto next;
                    //        }
                    //    }
                    //}

                    //foreach (RepPerson person in RepPersonList)
                    //{
                    //    if (person.LastDDAction != null && person.LastDDAction.Area)
                    //    {//範囲攻撃
                    //        if (person.UpdateDDByChatlog(time, log, out res))
                    //        {
                    //            Parsing(res, row);
                    //            goto next;
                    //        }
                    //    }
                    //}
                    //foreach (RepPerson person in RepPersonList)
                    //{
                    //    if (person.UpdateDDByChatlog(time, log, out res))
                    //    {
                    //        Parsing(res, row);
                    //        goto next;
                    //    }
                    //}
                    //foreach (RepPerson person in RepPersonList)
                    //{
                    //    if (person.LastDDAction != null && !person.LastDDAction.Area)
                    //    {//単発攻撃のアクションに強制追加
                    //        if (person.UpdateDDByChatlog(time, log, out res, true))
                    //        {
                    //            Parsing(res, row);
                    //            goto next;
                    //        }
                    //    }
                    //}


                next:
                    continue;
                }
            }

            //ログは遅れるので
            Entities = GetEntities();
            foreach (RepPerson person in RepPersonList)
            {
                person.UpdateBuff(time,  Entities);
            }
        }

        private void Parsing(object res, PreciRepDataSet.ParsingReportRow row)
        {
            Entity src=null, dest=null;
            #region SrcName, RepType
            if (res is ActionDone)
            {
                var result = (ActionDone)res;
                row.SrcName = result.Src.Name;
                row.RepType = "Action Done";
                src = result.Src;
            }
            else if (res is AutoAttackDD)
            {
                var result = (AutoAttackDD)res;
                row.SrcName = result.Src.Name;
                row.RepType = "AA HIT";
                row.Num = result.damage;
                src = result.Src;
                dest = result.Dest;
            }
            else if (res is AutoAttackMiss)
            {
                var result = (AutoAttackMiss)res;
                row.SrcName = result.Src.Name;
                row.RepType = "AA MISS";
                src = result.Src;
                dest = result.Dest;
            }
            else if (res is ActionDD)
            {
                var result = (ActionDD)res;
                row.SrcName = result.Src.Name;
                row.RepType = "Action HIT";
                row.Num = result.damage;
                src = result.Src;
                dest = result.Dest;
            }
            else if (res is ActionMiss)
            {
                var result = (ActionMiss)res;
                row.SrcName = result.Src.Name;
                row.RepType = "Action MISS";
                src = result.Src;
                dest = result.Dest;
            }
            else if (res is AddDamage)
            {
                var result = (AddDamage)res;
                row.SrcName = result.Src.Name;
                row.RepType = "Add Damage";
                src = result.Src;
                row.Num = result.damage;
                dest = result.Dest;
            }
            #endregion

            #region src dest buff
            if (src != null)
            {
                StringBuilder sb = new StringBuilder();
                foreach (BUFF b in src.Buffs.Where(obj=>obj.BuffID>0))
                {
                    string buffname = ResourceParser.GetBuffName(b.BuffID);
                    sb.AppendFormat("{0},", buffname);
                }
                row.SrcBuffs = sb.ToString().TrimEnd(new char[] { ',' });
            }
            if (dest != null)
            {
                StringBuilder sb = new StringBuilder();
                foreach (BUFF b in dest.Buffs.Where(obj => obj.BuffID > 0))
                {
                    string buffname = ResourceParser.GetBuffName(b.BuffID);
                    if (String.IsNullOrEmpty(buffname))
                    {
                        buffname = b.BuffID.ToString();
                    }
                    sb.AppendFormat("{0},", buffname);
                }
                row.DestBuffs = sb.ToString().TrimEnd(new char[] { ',' });
            }
            #endregion
        }
        
        private Entity[] GetEntities()
        {
            List<Entity> entlist = new List<Entity>();
            for (int i = 0; i < 100; i++)
            {
                Entity ent = lib.GetEntityInfo(i);
                if (ent == null) continue;
                entlist.Add(ent);
            }
            return entlist.ToArray();
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            preciRepDataSet1.Clear();
            preciRepDataSet2.Clear();
            while (backgroundWorker1.IsBusy)
            {
                backgroundWorker1.CancelAsync();
                toolStripStatusLabel1.Text = "停止中";
                Application.DoEvents();
            }
            backgroundWorker1.RunWorkerAsync();
            toolStripStatusLabel1.Text = "開始";
            timer1.Start();
        }

        /// <summary>
        /// 表示更新用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;

            //ロケーション情報表示
            if (Entities.Length > 0)
            {
                LocationLabel.Text = String.Format("({0},{1},{2})", Entities[0].X, Entities[0].Y,Entities[0].Z);
            }

            //ターゲット情報表示
            Entity cTarget = lib.GetCurrentTarget();
            if (cTarget != null && cTarget.CurrentHP>0)
            {
                CurrentTargetLabel.Text = String.Format("{0} {1}/{2}({3:0.00}%) {4:0.000} {5:0.000}", cTarget.Name, cTarget.CurrentHP,cTarget.MaxHP, 100*(float)cTarget.CurrentHP / (float)cTarget.MaxHP,cTarget.GetDistanceTo(Entities[0]),cTarget.HitCircleR);
            }
            else
            {
                CurrentTargetLabel.Text = "none";
            }

            Entity fTarget = lib.GetFocusTarget();
            if (fTarget != null)
            {
                FocusTargetLabel.Text = String.Format("{0} {1}/{2}({3:0.00}%)", fTarget.Name, fTarget.CurrentHP,fTarget.MaxHP,100* (float)fTarget.CurrentHP / (float)fTarget.MaxHP);
            }
            else
            {
                FocusTargetLabel.Text = "none";
            }

            //データ更新
            foreach (RepPerson person in RepPersonList)
            {
                PreciRepDataSet.RepEssentialRow row = preciRepDataSet1.RepEssential.FindByPlayerName(person.name);
                if (row == null)
                {
                    row = preciRepDataSet1.RepEssential.NewRepEssentialRow();
                    row.PlayerName = person.name;
                    preciRepDataSet1.RepEssential.AddRepEssentialRow(row);
                }
                try
                {
                    //データ更新
                    row.Job = ((JOB)System.Enum.Parse(typeof(JOB), person.ddperson.Job.ToString())).ToString();
                    row.AADamage = person.GetAADamage();
                    row.DDamage = person.GetActionDamage();
                    row.DotDamage = person.GetDoTDamage(time);
                    row.AddDamage = person.GetAddDamage();
                    row.LimitBreak = person.GetLimitBreakDamage();
                    row.TotalDamage = row.AADamage + row.DDamage + row.DotDamage;
                    row.DDCount = person.GetActionDDCount();
                    row.AACount = person.GetAACount();
                    row.DoTCount = person.GetDoTCount();
                    row.HitCount = person.GetHitCount();
                    row.CritCount = person.GetCritCount();
                    row.MissCount = person.GetMissCount();
                    row.HitRate = 100 * person.GetHitRate();
                    row.CritRate = 100 * person.GetCritRate();
                    row.DamageBase = person.CalcDamageBase();
                    row.DPS = person.GetDPS(time);
                }
                catch (Exception _e)
                {
                    MessageBox.Show(_e.Message);
                }
                //if (HasEnemies())
                //{
                //    row.DPS = person.GetDPS(time);
                //}
            }
        }

        private void PreciRepMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            backgroundWorker1.CancelAsync();
        }

        private void PreciRepMainForm_Load(object sender, EventArgs e)
        {
            ResetButton_Click(this, null);
        }

        /// <summary>
        /// 何らかの理由で停止
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)(() => toolStripStatusLabel1.Text = "停止"));
            }
            else
            {
                toolStripStatusLabel1.Text = "Repは停止しました。または開始できませんでした。";
            }
        }

        private void RefreshLogButton_Click(object sender, EventArgs e)
        {
            preciRepDataSet2.ParsingReport.Merge(preciRepDataSet1.ParsingReport);
        }

        private void OpenTestFileButton_Click(object sender, EventArgs e)
        {
            if (openTestFileDialog.ShowDialog() == DialogResult.OK)
            {
                TestFileBox.Text = openTestFileDialog.FileName;
                Properties.Settings.Default.Save();
            }
        }

        private void TestButton_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    DDPerson person = new DDPerson("
            //    string text = System.IO.File.ReadAllText(TestFileBox.Text);
            //    string[] lines = text.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            //    foreach (string line in lines)
            //    {
            //        string[] items = line.Split('\t');
            //        int logtype = Convert.ToInt32(items[4].Substring(0, 2), 16);
            //        int actiontype = Convert.ToInt32(items[4].Substring(2, 2), 16);                  
            //    }
            //}
            //catch (Exception _e)
            //{
            //    MessageBox.Show(_e.Message);
            //}
        }

    }
}
