using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ffxivlib;
namespace AutofireApp
{
    class Program
    {
        static bool cancel = false;
        static List<Entity> enemylist = new List<Entity>();
        static List<Entity> memberlist = new List<Entity>();
        static List<Entity> enemyTargetMelist = new List<Entity>();
        static Entity me;
        static bool hasBLM;
        static Entity enBLM;
        static FFXIVLIB lib;

        private static void UpdateEntityList()
        {
            hasBLM = false;
            List<string> ptmenberlist = new List<string>();
            for (int i = 0; i < 4; i++)
            {
                PartyMember pm = lib.GetPartyMemberInfo(i);
                if (pm.Job == JOB.BLM)
                {
                    hasBLM = true;
                }
                ptmenberlist.Add(pm.Structure.Name);
                var list = lib.GetEntityByName(pm.Structure.Name);
                if (list.Count() > 0)
                    memberlist.Add(lib.GetEntityByName(pm.Structure.Name).ToArray()[0]);
            }
            foreach (Entity ent in lib.GetEntityByType(TYPE.Player))
            {
                if (!ptmenberlist.Contains(ent.Structure.Name))
                {
                    Console.WriteLine("{0} {1} {2}", ent.Structure.Name,
                        ent.Job, ent.Address.ToString("X"));
                    enemylist.Add(ent);
                }
            }
            foreach (Entity en in enemylist)
            {
                if (en.Job == JOB.WHM || en.Job == JOB.SCH)
                {
                    lib.SetFocusTarget(en);
                    lib.SetPreviousTarget(en);
                }
            }
        }

        private static bool IsAlive(Entity[] ents)
        {
            foreach (Entity ent in ents)
            {
                if (ent.CurrentHP > 0)
                {
                    return true;
                }
            }
            return false;
        }

        static void Main(string[] args)
        {
            lib = new FFXIVLIB();

        start:
            cancel = false;

            enemylist = new List<Entity>();
            memberlist = new List<Entity>();
            enemyTargetMelist = new List<Entity>();

            Player p = lib.GetPlayerInfo();
            Console.WriteLine(p.Zone);

            UpdateEntityList();

            Entity ct = lib.GetEntityInfo(0);
            if (ct != null)
            {
                Console.WriteLine("{0} {1} {2} {3}", ct.Name, ct.X, ct.Y, ct.Z);
            }
            me = lib.GetEntityInfo(0);
            System.Threading.ThreadStart ts = new System.Threading.ThreadStart(roopBRD);

            if (me.Job == JOB.ARC || me.Job == JOB.BRD)
            {
                ts = new System.Threading.ThreadStart(roopBRD);
            }
            else if (me.Job == JOB.DRG)
            {
                ts = new System.Threading.ThreadStart(roopDRG);
            }
            else
            {
                ts = new System.Threading.ThreadStart(roopSCH);
            }
            System.Threading.Thread th = new System.Threading.Thread(ts);
            th.Start();

            Console.ReadLine();
                cancel = true;
                while (th.IsAlive) System.Threading.Thread.Sleep(100);
            Console.WriteLine("stoped.");
            Console.ReadLine();
            Console.WriteLine("restarted");

                goto start;
        }

        private static void roopDRG()
        {
            while (!cancel)
            {
                Entity me = lib.GetEntityInfo(0);
                if (me == null)
                    continue;

                if (me.CurrentHP == 0)
                {
                    System.Threading.Thread.Sleep(3000);
                    continue;
                }
                int minHP = int.MaxValue;
                Entity minEnt = null;
                //更新
                for (int i = 0; i < enemylist.Count; i++)
                {
                    enemylist[i] = lib.UpdateEntityInfo(enemylist[i]);
                    if (minHP > enemylist[i].CurrentHP && enemylist[i].CurrentHP > 0)
                    {
                        if (!HasBuff(enemylist[i], 3) && !HasBuff(enemylist[i], 13)
          && !HasBuff(enemylist[i], 15) && !HasBuff(enemylist[i], 16))
                        {
                            minHP = enemylist[i].CurrentHP;
                            minEnt = enemylist[i];
                        }
                    }
                }
                if (minEnt != null && minEnt.GetDistanceTo(me)<30)
                {
                    lib.SetCurrentTarget(minEnt);
                }
            }
        }

        private static void roopSCH()
        {

            while (!cancel)
            {
                me = lib.GetEntityInfo(0);
                if (me == null)
                    return;

                if (me.CurrentHP == 0)
                {
                    System.Threading.Thread.Sleep(1000);
                    continue;
                }

                enemyTargetMelist.Clear();
                enBLM = null;
                for (int i = 0; i < enemylist.Count; i++)
                {
                    Entity en = lib.UpdateEntityInfo(enemylist[i]);
                    enemylist[i] = en;
                    if (en.TargetId == me.PCId)
                    {
                        enemyTargetMelist.Add(en);
                    }
                    if (en.Job == JOB.BLM)
                    {
                        enBLM = en;
                    }
                }

                for (int i = 0; i < memberlist.Count; i++)
                {
                    Entity en = lib.UpdateEntityInfo(memberlist[i]);
                    memberlist[i] = en;
                }

                foreach (Entity ent in enemylist)
                {
                    if (ent.Job != JOB.WHM || ent.Job != JOB.SCH)
                    {
                        continue;
                    }
                }

                CruiseInfo ci = lib.GetCruiseInfo();



                if (IsRecast("エーテルフロー") && !HasBuff(me, 304))
                {
                    lib.SendKey((IntPtr)SendKeyInput.VKKeys.KEY_0);
                }

                ////緊急ヒール
                //if (HealPTMember(70))
                //    continue;

                //詠唱中
                if (me.IsCasting)
                    continue;

                //迅速堅実
                if (HasBuff(me, 160) || HasBuff(me, 167))
                    continue;

                //ＧＤＣ中
                if (lib.GetGCD().ElapsedTime > 0)
                    continue;

                if (enBLM != null&& enBLM.CurrentHP>0)
                {
                    lib.SetPreviousTarget(enBLM);
                    //lib.SendKey((IntPtr)SendKeyInput.VKKeys.KEY_1);
                }
                //foreach (Entity en in enemylist)
                //{
                //    if (en.GetDistanceTo(me) < 20 && en.IsCasting && !HasBuff(en, 160) && !HasBuff(en, 396))//396=専心
                //    {
                //        lib.SetPreviousTarget(en);
                //        //if (!hasBLM)
                //        //{
                //        //    lib.SendKey((IntPtr)SendKeyInput.VKKeys.KEY_1);
                //        //}
                //    }
                //}

                //移動中
                DateTime d = DateTime.Now;
                if (ci.Moving)
                {
                    foreach (Entity en in enemylist)
                    {
                        if (en.TargetId == me.PCId && en.GetDistanceTo(me) < 15)
                        {
                            if (!HasBuff(en, 3) && !HasBuff(en, 13)
                                && !HasBuff(en, 15) && !HasBuff(en, 16))
                            {//ルインラをぶっぱなす
                                lib.SetPreviousTarget(en);
                                //if (!hasBLM)
                                //{
                                //    lib.SendKey((IntPtr)SendKeyInput.VKKeys.KEY_1);
                                //    System.Threading.Thread.Sleep(500);
                                //}
                            }
                        }
                    }
                }
            }
        }

        private static void roopBRD()
        {

            while (!cancel)
            {
                Entity me = lib.GetEntityInfo(0);
                if (me == null)
                    continue;

                if (me.CurrentHP == 0)
                {
                    System.Threading.Thread.Sleep(3000);
                    continue;
                }
                //更新
                for (int i = 0; i < enemylist.Count; i++)
                {
                    enemylist[i] = lib.UpdateEntityInfo(enemylist[i]);
                }

                //睡眠詠唱
                for (int i = 0; i < enemylist.Count; i++)
                {
                    Entity en = enemylist[i];
                    if (en.IsCasting && en.GetDistanceTo(me) < 20)
                    {
                        lib.SetPreviousTarget(en);
                            lib.SendKey((IntPtr)SendKeyInput.VKKeys.KEY_0);
                    }
                }

                Entity ent = lib.GetCurrentTarget();
                if (ent != null)
                {

                    if (!HasBuff(me, 130) || HasBuff(me, 122))
                    {//ストレートショット
                        lib.SendKey((IntPtr)SendKeyInput.VKKeys.KEY_2);
                    }
                    else if (!HasBuff(ent, 124, me) && ent.CurrentHP > 500 && ent.Structure.Name != "炎獄の楔" && !ent.Structure.Name.Contains("ジェイル"))
                    {//ベノムバイト
                        lib.SendKey((IntPtr)SendKeyInput.VKKeys.KEY_4);
                    }
                    else if (!HasBuff(ent, 129, me) && ent.CurrentHP > 500 && ent.Structure.Name != "炎獄の楔" && !ent.Structure.Name.Contains("ジェイル"))
                    {//ウィンドバイト
                        lib.SendKey((IntPtr)SendKeyInput.VKKeys.KEY_3);
                    }
                    else
                    {
                        lib.SendKey((IntPtr)SendKeyInput.VKKeys.KEY_1);
                    }
                }
            next:
                System.Threading.Thread.Sleep(100);
            }
        }

        private static bool HealPTMember(int rate)
        {
            Entity me = lib.GetEntityInfo(0);
            for (int i = 0; i < memberlist.Count; i++)
            {
                memberlist[i] = lib.UpdateEntityInfo(memberlist[i]);
            }
            memberlist.Sort((a, b) => a.CurrentHP - b.CurrentHP);
            foreach (Entity p in memberlist)
            {
                if (p.CurrentHP == 0) continue;
                if (100 * p.CurrentHP / p.MaxHP < rate)
                {
                    return true;
                    //回復が必要

                    if (HasBuff(me, 304))
                    {
                        lib.SendKey((IntPtr)SendKeyInput.VKKeys.CONTROL, false, 0);
                        lib.SendKey((IntPtr)SendKeyInput.VKKeys.KEY_0);
                        lib.SendKey((IntPtr)SendKeyInput.VKKeys.CONTROL, true, 0);
                        Console.WriteLine("{0} 生命活性法", p.Structure.Name);
                        return true;
                    }
                    else if (HasBuff(p, 297))
                    {
                        lib.SendKey((IntPtr)SendKeyInput.VKKeys.CONTROL, false, 0);
                        lib.SendKey((IntPtr)SendKeyInput.VKKeys.KEY_9);
                        lib.SendKey((IntPtr)SendKeyInput.VKKeys.CONTROL, true, 0);
                        Console.WriteLine("{0} フィジク", p.Structure.Name);
                        return true;
                    }
                    else
                    {
                        lib.SendKey((IntPtr)SendKeyInput.VKKeys.CONTROL, false, 0);
                        lib.SendKey((IntPtr)SendKeyInput.VKKeys.KEY_8);
                        lib.SendKey((IntPtr)SendKeyInput.VKKeys.CONTROL, true, 0);
                        Console.WriteLine("{0} 鼓舞", p.Structure.Name);
                        return true;
                    }
                }
            }
            return false;

        }

        private static bool IsRecast(string action)
        {
            foreach (Recast r in lib.GetRecasts())
            {
                if (action == ResourceParser.GetActionName(r.ActionID))
                {
                    return r.ElapsedTime == 0;
                }
            }
            return false;
        }
        private static bool HasBuff(PartyMember p, int buffid)
        {
            return HasBuff(p.Buffs, buffid);
        }

        private static bool HasBuff(Entity ent, int buffid)
        {
            return HasBuff(ent.Buffs, buffid);
        }
        private static bool HasBuff(BUFF[] Buffs, int buffid)
        {
            foreach (BUFF b in Buffs)
            {
                if (b.BuffID == buffid) return true;
            }
            return false;
        }

        /// <summary>
        /// 狙ってくる敵にウイルス
        /// </summary>
        private void Virus()
        {
            foreach (Entity ent in enemylist)
            {
                if (ent.Job != JOB.WHM || ent.Job != JOB.SCH)
                {
                    continue;
                }
                if (ent.TargetId == me.PCId)
                {

                }
            }
        }
        /// <summary>
        /// バフがあるか
        /// </summary>
        /// <param name="ent"></param>
        /// <param name="buffid"></param>
        /// <param name="providor"></param>
        /// <returns></returns>
        private static bool HasBuff(Entity ent, int buffid, Entity providor=null)
        {
            foreach (BUFF buff in ent.Buffs)
            {
                if (buff.BuffID == buffid)
                {
                    if (providor != null)
                    {
                        if (buff.BuffProvider == providor.PCId)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
