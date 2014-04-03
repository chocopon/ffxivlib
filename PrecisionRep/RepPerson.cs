using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ffxivlib;

namespace PrecisionRep
{
    public class RepPerson
    {
        public string name;
        public DDPerson ddperson;
        public BuffPerson buffperson;

        List<EntitiesSnap> EntitiesSnapList;

        /// <summary>
        /// 最後にしようしたダメージの発生するアクション
        /// </summary>
        public DDAction LastDDAction
        {
            get
            {
                return ddperson.lastDDAction;
            }
        }

        private void AddEntitisSnap(DateTime time, Entity[] ents)
        {
            EntitiesSnapList.Insert(0, (new EntitiesSnap(time, ents)));
            for(int i=EntitiesSnapList.Count-1;i>=0;i--)
            {
                if (EntitiesSnapList[i].timestamp < time.AddSeconds(-5))
                {
                    EntitiesSnapList.RemoveAt(i);
                }
            }
        }

        public EntitiesSnap FindEntitiesSnap(DateTime time)
        {
            foreach (EntitiesSnap snap in EntitiesSnapList)
            {
                if (snap.timestamp < time.AddSeconds(-1))
                {
                    return snap;
                }
            }
            return null;
        }


       
        //public RepPerson(Entity ent, PersonType persontype)
        //{
        //    this.name = ent.Name;
        //    PersonType t = persontype;
        //    if(t!= PersonType.MySelf&& t!= PersonType.PTMember)
        //    {
        //        throw new Exception("自身かパーティメンバーしか実装してないっす");
        //    }
        //    ddperson = new DDPerson(name, t,(int)ent.Job);
        //    buffperson = new BuffPerson(name);
        //    EntitiesSnapList = new List<EntitiesSnap>();
        //}

        public RepPerson(string name, PersonType persontype,JOB job)
        {
            if (persontype != PersonType.MySelf && persontype != PersonType.PTMember && persontype!= PersonType.Pet)
            {
                throw new Exception("自身かパーティメンバーかペットで実装してあるっす");
            }
            this.name = name;
            ddperson = new DDPerson(name, persontype, (int)job);
            buffperson = new BuffPerson(name);
            EntitiesSnapList = new List<EntitiesSnap>();
        }

        /// <summary>
        /// バフ状態からDoTを更新
        /// </summary>
        /// <param name="time"></param>
        /// <param name="entities"></param>
        public void UpdateBuff(DateTime time,Entity[] entities)
        {
            AddEntitisSnap(time, entities);
            buffperson.UpdateBuffList(entities, time);
            buffperson.UpdateAoE(entities, time);
        }

        public int GetAADamage()
        {
            return ddperson.GetTotalAutoAttackD();
        }

        public int GetActionDamage()
        {
            return ddperson.GetTotalActionDD();
        }

        public int GetAddDamage()
        {
            return ddperson.GetTotalAddDamages();
        }

        public int GetLimitBreakDamage()
        {
            ActionDD[] lbs = ddperson.GetActionDDs().Where(obj => 
                obj.actionName == "ブレイバー" ||
                obj.actionName == "ブレードダンス" ||
                obj.actionName == "ファイナルヘヴン" ||
                obj.actionName == "スカイシャード" ||
                obj.actionName == "プチメテオ" ||
                obj.actionName == "メテオ").ToArray();
            int sum = 0;
            foreach (ActionDD lb in lbs)
            {
                sum += lb.damage;
            }
            return sum;
        }

        public int GetMissCount()
        {
            int aamiss = ddperson.GetAutoAttackMissies().Count(obj => obj.Invulnerable == false);
            int ddmiss = ddperson.GetActionMissies().Count(obj => obj.Invulnerable == false);
            return aamiss + ddmiss; 
        }

        public int GetDoTCount()
        {
            return buffperson.bufflist.Count(obj => obj.DotBuff != null);
        }

        public int GetHitCount()
        {
            return ddperson.GetAACount() + ddperson.GetActionDDCount();
        }

        public int GetAACount()
        {
            return ddperson.GetAACount();
        }

        public int GetActionDDCount()
        {
            return ddperson.GetActionDDCount();
        }

        public int GetAddDamageCount()
        {
            return ddperson.GetAddDamageCount();
        }

        public int GetCritCount()
        {
            int aacrit = ddperson.GetAutoAttackDDs().Count(obj => obj.IsCritical);
            int ddcrit = ddperson.GetActionDDs().Count(obj => obj.IsCritical);
            int addcrit = ddperson.GetAddDamages().Count(obj => obj.IsCritical);
            return aacrit + ddcrit + addcrit;
        }

        /// <summary>
        /// クリティカル率　追加効果をふくむ
        /// </summary>
        /// <returns></returns>
        public float GetCritRate()
        {
            float hitcount = GetAACount() + GetActionDDCount() + GetAddDamageCount();
            float critcount = GetCritCount();
            if (hitcount == 0) return 0;
            return critcount / hitcount;
        }

        public float GetTotalDmg(DateTime time)
        {
            int aadmg = GetAADamage();
            int dddmg = GetActionDamage();
            int adddmg = GetAddDamage();
            int dotdmg = GetDoTDamage(time);
            return aadmg + dddmg + dotdmg;
        }

        public float GetDPS(DateTime _time)
        {
            if(ddperson.GetActionDDCount()==0)
                return 0;

            DateTime ddtime = ddperson.GetLastTime();
            DateTime dottime = buffperson.GetLastTime(_time);
            DateTime time = ddtime > dottime ? ddtime : dottime;

            float secs =(float)(time - ddperson.GetActionDDs()[0].timestamp).TotalSeconds;
            if (secs <= 0)
            {
                return 0;
            }
            float totaldmg = GetTotalDmg(time);
            return totaldmg / secs;
        }

        /// <summary>
        /// 直接攻撃のHIT率
        /// </summary>
        /// <returns></returns>
        public float GetHitRate()
        {
            float hitcount = GetHitCount();
            float misscount = GetMissCount();
            if(hitcount+misscount==0)return 0;
            return hitcount / (hitcount + misscount);
        }

        /// <summary>
        /// DOTダメージ ダメージベース（中間値）を算出してDOT威力との掛け算
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public int GetDoTDamage(DateTime time)
        {
            float _critrate = GetCritRate();
            float critrate = _critrate>0.1F?_critrate:0.1F;//10%以下の場合は10%に
            float noncritdmg = CalcDamageBase()*(buffperson.GetTotalDoTPower(time)+buffperson.GetTotalAoEPower()) ;
            float critdmg = 1.5F * noncritdmg * critrate;
            float normaldmg = noncritdmg * (1 - critrate);
            return (int)(critdmg + normaldmg);
        }

        /// <summary>
        /// 威力１バフなし状態でのダメージを算出
        /// </summary>
        /// <returns></returns>
        public float CalcDamageBase()
        {
            return ddperson.CalcDamageBase();
        }

    }

}
