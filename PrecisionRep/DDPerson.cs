using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using ffxivlib;

namespace PrecisionRep
{
    public class DDPerson
    {
        Regex destRegex = new Regex(@"([^\s⇒！]+\s?[^\s]+)に");
        Regex srcRegex = new Regex(@"(\w.+)の");
        Regex numRegex = new Regex(@"(?<num>\d+)ダメージ|(?<num>\d+)\((?<rate>[+-]\d+)%\)ダメージ");
        Regex actionRegex = new Regex(@"「(.+)」");

        public string Name;
        public PersonType PersonType;
        public int CID;
        public int Job;

        public List<AutoAttackDD> _AAList = new List<AutoAttackDD>();
        public List<ActionDone> _ActionList = new List<ActionDone>();
        public List<ActionDD> _ActionDDList = new List<ActionDD>();
        public List<AutoAttackMiss> _AAMissList = new List<AutoAttackMiss>();
        public List<ActionMiss> _ActionMissList = new List<ActionMiss>();
        public List<AddDamage> _AddedDmgList = new List<AddDamage>();

        /// <summary>
        /// ひとつのアクションのログ
        /// </summary>
        public List<string> actionLogList = new List<string>();

        public DDAction lastDDAction;
        /// <summary>
        /// 範囲の敵ｓ
        /// </summary>
        public List<Entity> DestEntList = new List<Entity>();
        List<ActionDD> lastActionDDList = new List<ActionDD>();
        public bool addedopen;

        private void OpenAction(string action)
        {
            int id = ResourceParser.GetActionID(action);
            lastDDAction = DDAction.GetDDAction(id);
            DestEntList.Clear();
        }

        private void CloseAction()
        {
            lastDDAction = null;
        }

        DateTime _LastTime;

        public DateTime GetLastTime()
        {
            return _LastTime;
        }

        public AutoAttackDD[] GetAutoAttackDDs()
        {
            return _AAList.ToArray();
        }

        public ActionDone[] GetActionDones()
        {
            return _ActionList.ToArray();
        }


        public ActionDD[] GetActionDDs()
        {
            return _ActionDDList.ToArray();
        }

        /// <summary>
        /// 全ての追加効果ダメージを取得する
        /// </summary>
        /// <returns></returns>
        public AddDamage[] GetAddDamages()
        {
            return _AddedDmgList.ToArray();
        }

        public int GetTotalAddDamages()
        {
            int sum = 0;
            foreach (AddDamage add in GetAddDamages())
            {
                sum += add.damage;
            }
            return sum;
        }

        public int GetAddDamageCount()
        {
            return _AddedDmgList.Count;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public AutoAttackMiss[] GetAutoAttackMissies()
        {
            return _AAMissList.ToArray();
        }

        public ActionMiss[] GetActionMissies()
        {
            return _ActionMissList.ToArray();
        }

        public int GetTotalDamage()
        {
            return GetTotalActionDD()+GetTotalAutoAttackD()+GetTotalAddDamages();
        }

        public int GetTotalAutoAttackD()
        {
            int sum = 0;
            foreach (AutoAttackDD aa in GetAutoAttackDDs())
            {
                sum += aa.damage;
            }
            return sum;
        }

        public int GetAACount()
        {
            return _AAList.Count;
        }

        public int GetActionDDCount()
        {
            return _ActionDDList.Count;
        }

        public int GetActionCount()
        {
            return _ActionDDList.Count;
        }
        //public int GetLimitBreakDamage()
        //{
        //    foreach(ActionDD a in GetActionDDs().Where(obj=>obj.)
        //}
        /// <summary>
        /// アクションによるダメージ総計
        /// </summary>
        /// <returns></returns>
        public int GetTotalActionDD()
        {
            int sum = 0;
            foreach (ActionDD dd in GetActionDDs())
            {
                sum += dd.damage;
            }
            return sum;
        }

        public DDPerson(string name, PersonType ptype, int cid, int job)
        {
            Name = name;
            PersonType = ptype;
            CID = cid;
            Job = job;
        }

        #region addlist
        public AutoAttackDD AddAutoAttack(DateTime time, Entity dest,Entity src, int dmg, bool crit)
        {
            var res = new AutoAttackDD(time, dest, src, dmg, crit);
            _AAList.Add(res);
            _LastTime = time;
            return res;
        }

        public ActionDone AddActionDone(DateTime time, Entity src, string action)
        {
            var res = new ActionDone(time, src, action);
            _ActionList.Add(res);
            _LastTime = time;
            return res;
        }

        public ActionDD AddActionDD(DateTime time, string action,Entity dest,Entity src, int dmg, int dmgrate,bool crit)
        {
            var res = new ActionDD(time, action, dest, src, dmg,dmgrate, crit);
            _ActionDDList.Add(res);
            _LastTime = time;
            return res;
        }
        public AddDamage AddAddDamage(DateTime time, string buffname, Entity dest, Entity src, int dmg, bool crit)
        {
            var res = new AddDamage(time, buffname, dest, src, dmg, crit);
            _AddedDmgList.Add(res);
            _LastTime = time;
            return res;
        }


        public AutoAttackMiss AddAAMiss(DateTime time,Entity dest,Entity src, bool ineffective)
        {
            var res = new AutoAttackMiss(time, dest, src, ineffective);
            _AAMissList.Add(res);
            _LastTime = time;
            return res;
        }
        public ActionMiss AddActioMiss(DateTime time, Entity dest, Entity src, bool ineffective)
        {
            var res = new ActionMiss(time, dest, src, ineffective);
            _ActionMissList.Add(res);
            _LastTime = time;
            return res;
        }
        #endregion


        private Entity[] FindEntityAt(float x, float y,float range, Entity[] entities)
        {
            List<Entity> list = new List<Entity>();
            foreach (Entity ent in entities.Where(obj=>obj.CurrentHP>0))
            {
                double dist = Math.Sqrt((x - ent.X) * (x - ent.X) + (y - ent.Y) * (y - ent.Y));
                if (dist < range)
                {
                    list.Add(ent);
                }
            }
            return list.ToArray();
        }

        private Entity FindEntityByName(string name, Entity[] entities,int count=0)
        {
            if (String.IsNullOrEmpty(name))
                return null;
            int c = 0;
            Entity entity = null;
            foreach (Entity ent in entities.Where(ent => ent.Name == name))
            {
                entity = ent;
                if (count == c++)
                {
                    return entity;
                }
            }
            return entity;
        }

        private Entity FindEntityByID(int id, Entity[] entities)
        {
            Entity entity = null;
            foreach (Entity ent in entities.Where(ent => ent.NPCId == id||ent.PCId==id))
            {
                entity = ent;
                return entity;
            }
            return entity;
        }

        public bool Storage(int logtype, int logactiontype, string logbody, DateTime time, Entity[] Entiies, out object res, bool force = false)
        {
            res = null;
            #region ログタイプによる判定
            //自分のログか
            bool myself = logtype >= 0x08 && logtype <= 0x0B;
            //メンバーのログか
            bool ptmember = logtype >= 0x10 && logtype <= 0x13;
            if (!ptmember && !myself)
            {
                return false;
            }
            //if (!ptmember && !myself)
            //{
            //    return false;
            //}
            //if (PersonType == PrecisionRep.PersonType.MySelf && !myself)
            //{
            //    return false;
            //}

            //if (PersonType == PrecisionRep.PersonType.PTMember && !ptmember)
            //{
            //    return false;
            //}
            #endregion

            #region パーシング
            Match srcMatch = srcRegex.Match(logbody);
            Match destMatch = destRegex.Match(logbody);
            Match numMatch = numRegex.Match(logbody);
            Match actionMatch = actionRegex.Match(logbody);

            string src = srcMatch.Groups[1].Value;
            string dest = destMatch.Groups[1].Value;
            Entity srcEnt = FindEntityByName(Name, Entiies);
            if (srcEnt == null) return false;

            Entity desEnt = null;
            desEnt = FindEntityByID(srcEnt.TargetId, Entiies);

            int num = 0;
            int numrate = 0;
            if (numMatch.Success)
            {
                num = Convert.ToInt32(numMatch.Groups["num"].Value);
                if (numMatch.Groups["rate"].Value != "")
                {
                    numrate = Convert.ToInt32(numMatch.Groups["rate"].Value.Replace("+", ""));
                }
            }
            string action = actionMatch.Groups[1].Value;

            bool crit = logbody.Contains("クリティカル");
            bool ineffective = logbody.Contains("は無効化");

            #endregion

            #region 攻撃(AA)
            if (logbody.Contains("攻撃"))
            {//Auto attack
                if (src != Name)
                    return false;

                if (logactiontype == 0x29 || logactiontype == 0xA9)//ダメージ
                {
                    if (desEnt == null)
                    {
                        Console.WriteLine("対象のEntityがnull");
                        return false;
                    }
                    res = AddAutoAttack(time, desEnt, srcEnt, num, crit);
                    //追加効果　忠義の剣状態ならOPEN
                    addedopen = srcEnt.Buffs.Count(obj => obj.BuffID == 78) > 0;
                    return true;
                }
                else if (logactiontype == 0xAA)//ミス
                {
                    res = AddAAMiss(time, desEnt, srcEnt, ineffective);
                    addedopen = false;
                    return true;
                }
                return false;
            }
            #endregion

            #region アクションDone
            if (logactiontype == 0x2B)
            {//アクション DONE
                if (src != Name)
                    return false;
                res = AddActionDone(time, srcEnt, action);
                OpenAction(action);
                return true;
            }
            #endregion

            #region ダメージ
            if ((logactiontype == 0x29 || logactiontype == 0xA9))
            {//ダメージ
                float dmgbase = CalcDamageBase();

                if (addedopen)
                {//追加効果
                    //忠義の剣
                    var chuugi = new AddDamage(time, "忠義の剣", desEnt, srcEnt, num, crit);
                    float critrate = crit ? 1.5F : 1.0F;
                    float buffeffect = chuugi.GetBuffsEffectRate();
                    float dmg = critrate * 50 * dmgbase * buffeffect;
                    float zure = Math.Abs(dmg - num) / dmg;
                    if (zure < 0.3)
                    {
                        res = AddAddDamage(time, "忠義の剣", desEnt, srcEnt, num, crit);
                    }
                    addedopen = false;
                    return true;
                }
                else if (lastDDAction != null)
                {
                    #region アクションHIT
                    //ダメージの予測計算
                    ActionDD dd = new ActionDD(time, lastDDAction.ActionName, desEnt, srcEnt, num, numrate, crit);
                    float buffeffect = dd.GetBuffsEffectRate();
                    float critrate = dd.IsCritical ? 1.5F : 1.0F;
                    float dmg = critrate * lastDDAction.PowerMin * dmgbase * buffeffect;
                    float zure = Math.Abs(dmg - num) / dmg;

                    ActionDD newdd = AddActionDD(time, lastDDAction.ActionName, desEnt, srcEnt, num, numrate, crit);
                    if (!lastDDAction.Area)
                    {
                        CloseAction();
                    }
                    res = newdd;
                    return true;
                    #endregion
                }
            }
            #endregion

            #region アクションMISS
            if (logactiontype == 0xAA)
            {
                if (desEnt != null && lastDDAction != null)
                {
                    res = AddActioMiss(time, desEnt, srcEnt, ineffective);
                    if (!lastDDAction.Area)
                    {
                        CloseAction();
                    }
                    return true;
                }
                return false;
            }
            #endregion

            return false;


        }

        public bool Storage_old(int logtype,int logactiontype,string logbody, DateTime time,Entity[] Entiies,out object res, bool force = false)
        {
            res = null;

            //自分のログか
            bool myself = logtype >= 0x08 && logtype <= 0x0B;
            //メンバーのログか
            bool ptmember = logtype >= 0x10 && logtype <= 0x13;

            if (!ptmember && !myself)
            {
                return false;
            }
            if (PersonType == PrecisionRep.PersonType.MySelf && !myself)
            {
                return false;
            }

            if (PersonType == PrecisionRep.PersonType.PTMember && !ptmember)
            {
                return false;
            }

            Match srcMatch = srcRegex.Match(logbody);
            Match destMatch = destRegex.Match(logbody);
            Match numMatch = numRegex.Match(logbody);
            Match actionMatch = actionRegex.Match(logbody);

            string src = srcMatch.Groups[1].Value;
            string dest = destMatch.Groups[1].Value;
            Entity srcEnt = FindEntityByName(Name, Entiies);
            if (srcEnt == null) return false;

            Entity desEnt = null;
            desEnt = FindEntityByID(srcEnt.TargetId, Entiies);

            int num = 0;
            int numrate = 0;
            if (numMatch.Success)
            {
                num = Convert.ToInt32(numMatch.Groups["num"].Value);
                if (numMatch.Groups["rate"].Value != "")
                {
                    numrate = Convert.ToInt32(numMatch.Groups["rate"].Value.Replace("+", ""));
                }
            }
            string action = actionMatch.Groups[1].Value;

            bool crit = logbody.Contains("クリティカル");
            bool ineffective = logbody.Contains("は無効化");

            if (logactiontype == 0x2B)
            {//アクション DONE
                if (src != Name)
                    return false;
                res = AddActionDone(time, srcEnt, action);
                OpenAction(action);
                return true;
            }
            if (desEnt == null) return false;

            if (logbody.Contains("攻撃"))
            {//Auto attack
                if (src != Name)
                    return false;

                if (logactiontype == 0x29 || logactiontype == 0xA9)//ダメージ
                {
                    if (desEnt == null)
                    {
                        Console.WriteLine("対象のEntityがnull");
                        return false;
                    }
                    res = AddAutoAttack(time, desEnt, srcEnt, num, crit);
                    //追加効果　忠義の剣状態ならOPEN
                    addedopen = srcEnt.Buffs.Count(obj => obj.BuffID == 78) > 0;
                    return true;
                }
                else if (logactiontype == 0xAA)//ミス
                {
                    res = AddAAMiss(time,desEnt, srcEnt, ineffective);
                    addedopen = false;
                    return true;
                }
                return false;
            }

            if (logactiontype == 0x29 || logactiontype == 0xA9)
            {//ダメージ
                if (lastDDAction!=null && desEnt != null)
                {
                    //ダメージ範囲の計算
                    float dmgbase = CalcDamageBase();
                    ActionDD dd = new ActionDD(time, lastDDAction.ActionName, desEnt, srcEnt, num, numrate, crit);
                    float critrate = dd.IsCritical ? 1.5F : 1.0F;
                    float buffeffect = dd.GetBuffsEffectRate();
                    float dmg = critrate * lastDDAction.PowerMin * dmgbase * buffeffect;
                    float zure = Math.Abs(dmg - num) / dmg;

                    if (myself)
                    {//間違いない
                        #region 自分のアクション
                        ActionDD newdd = AddActionDD(time, lastDDAction.ActionName, desEnt, srcEnt, num, numrate, crit);
                        CloseAction();
                        res = newdd;
                        return true;
                        #endregion
                    }
                    else if (ptmember && force)
                    {
                        #region 強制追加
                        ActionDD newdd = AddActionDD(time, lastDDAction.ActionName, desEnt, srcEnt, num, numrate, crit);
                        CloseAction();
                        res = newdd;
                        return true;
                        #endregion
                    }
                    else if (lastDDAction.Area) 
                    {
                        #region 範囲アクションの場合
                        if (zure < 0.15)
                        {//ダメージ値が許容範囲内なら
                            Entity[] desEnts = new Entity[0];
                            List<Entity> list = new List<Entity>();
                            list.AddRange(FindEntityAt(desEnt.X, desEnt.Y, 5, Entiies).Where(obj => obj.Name == dest && obj.NPCId != desEnt.NPCId).ToArray());
                            if (desEnt.Name == dest)
                            {//同じ名前なら
                                list.Insert(0, desEnt);
                            }
                            desEnts = list.ToArray();

                            int count = lastActionDDList.Count(obj => obj.Dest.Name == dest);
                            if (count < desEnts.Length)
                            {
                                ActionDD newdd = AddActionDD(time, lastDDAction.ActionName, desEnts[count], srcEnt, num, numrate, crit);
                                lastActionDDList.Add(newdd);
                                res = newdd;
                                return true;
                            }

                        }
                        else
                        {
                            Console.WriteLine("除外する");
                        }
                        #endregion
                    }
                    else if (zure < 0.15)
                    {
                        #region 単体アクションの場合
                        ActionDD newdd = AddActionDD(time, lastDDAction.ActionName, desEnt, srcEnt, num, numrate, crit);
                        CloseAction();
                        res = newdd;
                        return true;
                        #endregion
                    }
                    else
                    {
                        Console.WriteLine("除外する");
                    }
                }
                if (srcEnt.Buffs.Count(obj => obj.BuffID == 78) > 0)
                {//忠義の剣
                    if (addedopen&& GetAutoAttackDDs().Count(obj => obj.timestamp > time.AddSeconds(-1)) > 0)
                    {
                        res = AddAddDamage(time,"忠義の剣", desEnt, srcEnt, num, crit);
                    }
                    addedopen = false;
                    return true;
                }
                if(srcEnt.Buffs.Count(obj=>obj.BuffID==89)>0)
                {//ヴェンジェンスによる反撃ダメージ
                   res = AddAddDamage(time, "ヴェンジェンス", desEnt, srcEnt, num, crit);
                   return true;
                }
                return false;
            }
            if (logactiontype == 0xAA)
            {
                if (desEnt!=null && lastDDAction!=null)
                {
                    res = AddActioMiss(time, desEnt,srcEnt, ineffective);
                    if (!lastDDAction.Area)
                    {
                        CloseAction();
                    }
                    return true;
                }
                return false;
            }


            return false;
        }

        /// <summary>
        /// 威力１バフなし状態でのダメージを算出
        /// </summary>
        /// <returns></returns>
        public float CalcDamageBase()
        {
            List<float> blist = new List<float>();
            foreach (ActionDD dd in GetActionDDs())
            {
                DDAction ddaction = DDAction.GetDDAction(dd.actionName);
                if (ddaction != null && ddaction.actionID!=29)//ウィズイン除外
                {
                    float critrate = dd.IsCritical ? 1.5F : 1.0F;
                    float buffeffect = dd.GetBuffsEffectRate();
                    float power = dd.damagerate > 0 ? ddaction.PowerMax : ddaction.PowerMin;
                    float rate = dd.damage / power / buffeffect / critrate;
                    blist.Add(rate);
                }
            }

            if (blist.Count == 0)
            {
                if (Job == (int)JOB.SMN || Job == (int)JOB.THM || Job == (int)JOB.BLM)
                {
                    return 2.0F;
                }
                if (Job == (int)JOB.GLD || Job==(int)JOB.PLD ||Job== (int)JOB.MRD ||Job== (int)JOB.WAR)
                {
                    return 1.0F;
                }
                return 1.5F;
            }
            blist.Sort();
            return blist[blist.Count / 2];

        }
    }

    public class AutoAttackDD
    {
        public DateTime timestamp;
        public Entity Dest;
        public Entity Src;
        public int damage;
        public bool IsCritical;

        public AutoAttackDD(DateTime time, Entity dest,Entity src, int dmg, bool crit)
        {
            timestamp = time;
            damage = dmg;
            Dest = dest;
            Src = src;
            IsCritical = crit;
        }

        public float GetBuffsEffectRate()
        {
            return (1.0F+GetSrcBuffsEffectRateAdd() + GetDestBuffsEffectRateAdd())
                *GetSrcBuffsEffectRateMul()*GetDestBuffsEffectRateMul();
        }

        public float GetSrcBuffsEffectRateAdd()
        {
            float rateadd = 0;
            foreach (BUFF b in Src.Buffs.Where(obj => obj.BuffID > 0))
            {
                BuffEffect be = BuffEffectProvider.GetBuffEffect(b.BuffID);
                rateadd += be.GetSrcAddRate((int)Src.Job, Src.Level);
            }
            return rateadd;
        }

        public float GetDestBuffsEffectRateAdd()
        {
            float rateadd = 0;
            foreach (BUFF b in Dest.Buffs.Where(obj => obj.BuffID > 0))
            {
                BuffEffect be = BuffEffectProvider.GetBuffEffect(b.BuffID);
                rateadd +=  be.GetDestAddRate((int)Src.Job, Src.Level);
            }
            return rateadd;
        }

        public float GetSrcBuffsEffectRateMul()
        {
            float ratemul = 1.0F;
            foreach (BUFF b in Src.Buffs.Where(obj => obj.BuffID > 0))
            {
                BuffEffect be = BuffEffectProvider.GetBuffEffect(b.BuffID);
                ratemul*= be.GetSrcMulRate((int)Src.Job, Src.Level);
            }
            return ratemul;
        }

        public float GetDestBuffsEffectRateMul()
        {
            float ratemul = 1.0F;
            foreach (BUFF b in Dest.Buffs.Where(obj => obj.BuffID > 0))
            {
                BuffEffect be = BuffEffectProvider.GetBuffEffect(b.BuffID);
                ratemul *= be.GetDestMulRate((int)Src.Job, Src.Level);
            }
            return ratemul;
        }
    }

    public class ActionDone
    {
        public DateTime timestamp;
        public Entity Src;
        public string actionname;

        public ActionDone(DateTime time, Entity src,string action)
        {
            timestamp = time;
            Src = src;
            actionname = action;
        }
    }

    public class ActionDD
    {
        public string actionName;
        public DateTime timestamp;
        public Entity Dest;
        public Entity Src;
        public int damage;
        public int damagerate;
        public bool IsCritical;
        public ActionDD(DateTime time, string action,Entity dest,Entity src, int dmg,int dmgrate, bool crit)
        {
            timestamp = time;
            actionName = action;
            Dest = dest;
            Src = src;
            damage = dmg;
            damagerate = dmgrate;
            IsCritical = crit;
        }

        public float GetBuffsEffectRate()
        {
            return (1.0F+ GetSrcBuffsEffectRateAdd() + GetDestBuffsEffectRateAdd())
                * GetSrcBuffsEffectRateMul() * GetDestBuffsEffectRateMul();
        }

        public float GetSrcBuffsEffectRateAdd()
        {
            float rateadd = 0;
            float sprate = 0;
            #region 黒魔道士
            if (actionName == "ファイア" || actionName == "ファイラ" || actionName == "ファイガ" || actionName == "フレア")
            {
                foreach (BUFF b in Src.Buffs.Where(obj => obj.BuffID >= 173 && obj.BuffID <= 178))
                {
                    if (b.BuffID == 173)
                    {//アストラルファイアI
                        sprate = 0.4F;
                    }
                    else if (b.BuffID == 174)
                    {//アストラルファイアII
                        sprate = 0.6F;
                    }
                    else if (b.BuffID == 175)
                    {//アストラルファイアIII
                        sprate = 0.8F;
                    }
                    else if (b.BuffID == 176)
                    {//アンブラルブリザードI
                        sprate = -0.1F;
                    }
                    else if (b.BuffID == 177)
                    {//アンブラルブリザードII
                        sprate = -0.2F;
                    }
                    else if (b.BuffID == 178)
                    {//アンブラルブリザードIII
                        sprate = -0.3F;
                    }
                }
            }
            if (actionName == "サンダー" || actionName == "サンダラ" || actionName == "サンダガ")
            {
                if (Src.Buffs.Count(obj => obj.BuffID == 164) > 0)
                {
                    sprate = 4.5F;
                }
            }
            #endregion
            #region 竜騎士
            if (actionName == "ジャンプ" || actionName == "スパンダイブ")
            {
                foreach (BUFF b in Src.Buffs.Where(obj => obj.BuffID >= 120))
                {//竜槍
                    sprate = 0.5F;
                }
            }
            #endregion
            foreach (BUFF b in Src.Buffs.Where(obj=>obj.BuffID>0))
            {
                BuffEffect be = BuffEffectProvider.GetBuffEffect(b.BuffID);
                if (actionName == "スチールサイクロン")
                {//ディフェンダー分無視
                    rateadd += 0.25F;
                }
                rateadd += be.GetSrcAddRate((int)Src.Job, Src.Level);
            }
            return rateadd+sprate;
        }

        public float GetDestBuffsEffectRateAdd()
        {
            float rateadd = 0;
            foreach (BUFF b in Dest.Buffs.Where(obj => obj.BuffID > 0))
            {
                BuffEffect be = BuffEffectProvider.GetBuffEffect(b.BuffID);
                rateadd += be.GetDestAddRate((int)Src.Job, Src.Level);
            }
            return rateadd;
        }

        public float GetSrcBuffsEffectRateMul()
        {
            float ratemul = 1.0F;
            foreach (BUFF b in Src.Buffs.Where(obj => obj.BuffID > 0))
            {
                BuffEffect be = BuffEffectProvider.GetBuffEffect(b.BuffID);
                ratemul *= be.GetSrcMulRate((int)Src.Job, Src.Level);
            }
            return ratemul;
        }

        public float GetDestBuffsEffectRateMul()
        {
            float ratemul = 1.0F;
            foreach (BUFF b in Dest.Buffs.Where(obj => obj.BuffID > 0))
            {
                BuffEffect be = BuffEffectProvider.GetBuffEffect(b.BuffID);
                ratemul *= be.GetDestMulRate((int)Src.Job, Src.Level);
            }
            return ratemul;
        }
    }

    /// <summary>
    /// 追加効果
    /// </summary>
    public class AddDamage
    {
        public DateTime timestamp;
        public Entity Dest;
        public Entity Src;
        public string Buffname;
        public int damage;
        public bool IsCritical;

        public AddDamage(DateTime time,string buffname, Entity dest, Entity src, int dmg, bool crit)
        {
            timestamp = time;
            Buffname = buffname;
            damage = dmg;
            Dest = dest;
            Src = src;
            IsCritical = crit;
        }

        public float GetBuffsEffectRate()
        {
            return (1.0F + GetSrcBuffsEffectRateAdd() + GetDestBuffsEffectRateAdd())
                * GetSrcBuffsEffectRateMul() * GetDestBuffsEffectRateMul();
        }

        public float GetSrcBuffsEffectRateAdd()
        {
            float rateadd = 0;
            foreach (BUFF b in Src.Buffs.Where(obj => obj.BuffID > 0))
            {
                BuffEffect be = BuffEffectProvider.GetBuffEffect(b.BuffID);
                rateadd += be.GetSrcAddRate((int)Src.Job, Src.Level);
            }
            return rateadd;
        }

        public float GetDestBuffsEffectRateAdd()
        {
            float rateadd = 0;
            foreach (BUFF b in Dest.Buffs.Where(obj => obj.BuffID > 0))
            {
                BuffEffect be = BuffEffectProvider.GetBuffEffect(b.BuffID);
                rateadd += be.GetDestAddRate((int)Src.Job, Src.Level);
            }
            return rateadd;
        }

        public float GetSrcBuffsEffectRateMul()
        {
            float ratemul = 1.0F;
            foreach (BUFF b in Src.Buffs.Where(obj => obj.BuffID > 0))
            {
                BuffEffect be = BuffEffectProvider.GetBuffEffect(b.BuffID);
                ratemul *= be.GetSrcMulRate((int)Src.Job, Src.Level);
            }
            return ratemul;
        }

        public float GetDestBuffsEffectRateMul()
        {
            float ratemul = 1.0F;
            foreach (BUFF b in Dest.Buffs.Where(obj => obj.BuffID > 0))
            {
                BuffEffect be = BuffEffectProvider.GetBuffEffect(b.BuffID);
                ratemul *= be.GetDestMulRate((int)Src.Job, Src.Level);
            }
            return ratemul;
        }
    }
    public class AutoAttackMiss
    {
        public DateTime timestamp;
        public Entity Dest;
        public Entity Src;
        public bool Invulnerable;

        public AutoAttackMiss(DateTime time, Entity dest,Entity src, bool ineffective)
        {
            timestamp = time;
            Dest = dest;
            Src = src;
            Invulnerable = ineffective;
        }
    }

    public class ActionMiss
    {
        public bool Invulnerable;
        public DateTime timestamp;
        public Entity Dest;
        public Entity Src;

        public ActionMiss(DateTime time, Entity dest,Entity src, bool ineffective)
        {
            timestamp = time;
            Dest = dest;
            Src = src;
            Invulnerable = ineffective;
        }
    }

    public enum PersonType
    {
        MySelf,
        PTMember,
        Ally,
        Other,
        Enemy
    }

}
