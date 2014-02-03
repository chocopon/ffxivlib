using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ffxivlib;

namespace AutofireApp
{
    public class SCH
    {
        static bool cancel = false;
        static List<Entity> enemylist = new List<Entity>();
        static List<Entity> memberlist = new List<Entity>();
        static FFXIVLIB lib;

        public static void Run()
        {
            lib = new FFXIVLIB();
            Player p = lib.GetPlayerInfo();
            Console.WriteLine(p.Zone);

            List<string> ptmenberlist = new List<string>();
            for (int i = 0; i < 4; i++)
            {
                PartyMember pm = lib.GetPartyMemberInfo(i);
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
            Entity ct = lib.GetCurrentTarget();
            if (ct != null)
            {
                Console.WriteLine(ct.Name);
            }
            roopSCH();
        }
        private static void roopSCH()
        {

            while (!cancel)
            {
                Entity me = lib.GetEntityInfo(0);
                if (me == null)
                    return;

                if (me.CurrentHP == 0)
                {
                    System.Threading.Thread.Sleep(1000);
                    continue;
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

                ////とどめ
                //foreach (Entity _en in enemylist)
                //{
                //    Entity en = lib.UpdateEntityInfo(_en);
                //    if (en.CurrentHP > 0 && 100 * en.CurrentHP / en.MaxHP < 30 && en.GetDistanceTo(me) < 20
                //        && lib.GetGCD().ElapsedTime == 0)
                //    {
                //        if (!HasBuff(en, 179))//バイオ
                //        {
                //            lib.SetPreviousTarget(en);
                //            lib.SendKey((IntPtr)SendKeyInput.VKKeys.CONTROL, false, 0);
                //            lib.SendKey((IntPtr)SendKeyInput.VKKeys.KEY_1);
                //            lib.SendKey((IntPtr)SendKeyInput.VKKeys.CONTROL, true, 0);
                //            Console.WriteLine("とどめのバイオ-" + en.Structure.Name);
                //        }
                //        else//ルインラ
                //        {
                //            lib.SetPreviousTarget(en);
                //            lib.SendKey((IntPtr)SendKeyInput.VKKeys.CONTROL, false, 0);
                //            lib.SendKey((IntPtr)SendKeyInput.VKKeys.KEY_2);
                //            lib.SendKey((IntPtr)SendKeyInput.VKKeys.CONTROL, true, 0);
                //            Console.WriteLine("とどめのルインラ-" + en.Structure.Name);
                //        }
                //    }
                //}

                //詠唱妨害
                //foreach (Entity _en in enemylist)
                //{
                //    Entity en = lib.UpdateEntityInfo(_en);
                //    if (en.IsCasting && en.GetDistanceTo(me) < 20 && lib.GetGCD().ElapsedTime == 0)
                //    {
                //        string spell = ResourceParser.GetActionName(en.CastingSpellId);
                //        lib.SetPreviousTarget(en);
                //        lib.SendKey((IntPtr)SendKeyInput.VKKeys.CONTROL, false, 0);
                //        lib.SendKey((IntPtr)SendKeyInput.VKKeys.KEY_2);
                //        lib.SendKey((IntPtr)SendKeyInput.VKKeys.CONTROL, true, 0);
                //        Console.WriteLine("詠唱妨害>" + spell + "-" + en.Structure.Name);
                //       // goto roop;
                //    }
                //}

                //if(HealPTMember(70))
                //    continue;

                //バイオ撒き
                DateTime d = DateTime.Now;
                if (ci.Moving)
                {
                    //スプリント
                    if (IsRecast("スプリント"))
                    {
                        lib.SendKey((IntPtr)222);//^key
                    }

                    bool cast = false;
                    //    foreach (Entity _en in enemylist)
                    //    {
                    //        Entity en = lib.UpdateEntityInfo(_en);
                    //        if (en.CurrentHP > 0 && en.GetDistanceTo(me) < 7)
                    //        {
                    //            if (HasBuff(en, 3) || HasBuff(en, 13))
                    //            {//スリプルバインドの敵が近くにいる
                    //                goto next1;
                    //            }
                    //            if (!HasBuff(en, 188))
                    //            {
                    //                Console.WriteLine("ミアズラ");
                    //                cast = true;
                    //            }
                    //        }
                    //    }
                    //    if (cast&& lib.GetGCD().ElapsedTime == 0)
                    //    {
                    //        lib.SendKey((IntPtr)SendKeyInput.VKKeys.KEY_1);
                    //        Console.WriteLine("ミアズラ");
                    //    }

                    //next1:

                    //foreach (Entity _en in enemylist)
                    //{
                    //    Entity en = lib.UpdateEntityInfo(_en);
                    //    if (en.CurrentHP > 0 && en.GetDistanceTo(me) < 20 && lib.GetGCD().ElapsedTime == 0)
                    //    {
                    //        if (!HasBuff(en, 179) && !HasBuff(en, 3) && !HasBuff(en, 13))//バイオ
                    //       {
                    //            lib.SetPreviousTarget(en);
                    //            lib.SendKey((IntPtr)SendKeyInput.VKKeys.CONTROL, false, 0);
                    //            lib.SendKey((IntPtr)SendKeyInput.VKKeys.KEY_1);
                    //            lib.SendKey((IntPtr)SendKeyInput.VKKeys.CONTROL, true, 0);
                    //            Console.WriteLine("バイオ撒き-" + en.Structure.Name);
                    //        }

                    //        if (!HasBuff(en, 3) && !HasBuff(en, 13))
                    //        {//スリプルとバインドが入っていない
                    //            lib.SetPreviousTarget(en);
                    //            lib.SendKey((IntPtr)SendKeyInput.VKKeys.CONTROL, false, 0);
                    //            lib.SendKey((IntPtr)SendKeyInput.VKKeys.KEY_2);
                    //            lib.SendKey((IntPtr)SendKeyInput.VKKeys.CONTROL, true, 0);
                    //            Console.WriteLine("ルインラ撒き-" + en.Structure.Name);
                    //        }

                    //    }
                    //}
                }
            roop:
                System.Threading.Thread.Sleep(1000);
            }
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
    }
}
