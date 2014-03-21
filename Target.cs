using System;
using System.Runtime.InteropServices;

namespace ffxivlib
{
    public class Target : BaseObject<Target.TARGET>
    {
        #region Constructor

        public Target(TARGET structure, IntPtr address)
            : base(structure, address)
        {
            Initialize();
        }

        #endregion

        #region Properties

        public int CurrentTarget { get; set; }

        public int MouseoverTarget { get; set; }

        public int FocusTarget { get; set; }

        public int PreviousTarget { get; set; }

        public int CurrentTargetID { get; set; }

        #endregion

        #region Unmanaged structure

        [StructLayout(LayoutKind.Explicit, Pack = 1)]
        public struct TARGET
        {
            [MarshalAs(UnmanagedType.I4)] [FieldOffset(0)] public int CurrentTarget;
            [MarshalAs(UnmanagedType.I4)] [FieldOffset(0x18)] public int MouseoverTarget;
            [MarshalAs(UnmanagedType.I4)] [FieldOffset(0x48)] public int FocusTarget;
            [MarshalAs(UnmanagedType.I4)] [FieldOffset(0x54)] public int PreviousTarget;
            [MarshalAs(UnmanagedType.I4)] [FieldOffset(0x68)] public int CurrentTargetID;
        }

        #endregion
    }

    public partial class FFXIVLIB
    {
        #region Public methods

        /// <summary>
        ///     This function retrieves the target array
        /// </summary>
        /// <returns>Target object</returns>
        public Target GetTargets()
        {
            IntPtr pointer = _mr.ResolvePointerPath(Constants.TARGETPTR);
            var t = new Target(_mr.CreateStructFromAddress<Target.TARGET>(pointer), pointer);
            return t;
        }

        /// <summary>
        ///     This function retrieves the previous target
        /// </summary>
        /// <returns>Entity object or null</returns>
        public Entity GetPreviousTarget()
        {
            IntPtr pointer = _mr.ResolvePointerPath(Constants.TARGETPTR);
            var t = new Target(_mr.CreateStructFromAddress<Target.TARGET>(pointer), pointer);
                    Entity.ENTITYINFO en = _mr.CreateStructFromAddress<Entity.ENTITYINFO>((IntPtr) t.PreviousTarget);
                    if (!Equals(en, default(Entity.ENTITYINFO)))
                    {
                        Entity e = new Entity(en, (IntPtr)t.PreviousTarget);
                        return e;
                    }
            return null;
        }

        /// <summary>
        ///     This function retrieves the current Mouseover target
        /// </summary>
        /// <returns>Entity object or null</returns>
        public Entity GetMouseoverTarget()
        {
            IntPtr pointer = _mr.ResolvePointerPath(Constants.TARGETPTR);
            var t = new Target(_mr.CreateStructFromAddress<Target.TARGET>(pointer), pointer);
            Entity.ENTITYINFO en = _mr.CreateStructFromAddress<Entity.ENTITYINFO>((IntPtr)t.MouseoverTarget);
            if (!Equals(en, default(Entity.ENTITYINFO)))
            {
                Entity e = new Entity(en, (IntPtr)t.MouseoverTarget);
                return e;
            }
            return null;
        }

        /// <summary>
        ///     This function retrieves the current target
        /// </summary>
        /// <returns>Entity object or null</returns>
        public Entity GetCurrentTarget()
        {
            IntPtr pointer = _mr.ResolvePointerPath(Constants.TARGETPTR);
            var t = new Target(_mr.CreateStructFromAddress<Target.TARGET>(pointer), pointer);
            Entity.ENTITYINFO en = _mr.CreateStructFromAddress<Entity.ENTITYINFO>((IntPtr)t.CurrentTarget);
            if (!Equals(en, default(Entity.ENTITYINFO)))
            {
                Entity e = new Entity(en, (IntPtr)t.CurrentTarget);
                return e;
            }
            return null;
        }

        /// <summary>
        ///     This function retrieves the focus target
        /// </summary>
        /// <returns>Entity object or null</returns>
        public Entity GetFocusTarget()
        {
            IntPtr pointer = _mr.ResolvePointerPath(Constants.TARGETPTR);
            var t = new Target(_mr.CreateStructFromAddress<Target.TARGET>(pointer), pointer);
            Entity.ENTITYINFO en = _mr.CreateStructFromAddress<Entity.ENTITYINFO>((IntPtr)t.FocusTarget);
            if (!Equals(en, default(Entity.ENTITYINFO)))
            {
                Entity e = new Entity(en, (IntPtr)t.FocusTarget);
                return e;
            }
            return null;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="ent"></param>
        /// <returns></returns>
        public void SetCurrentTarget(Entity ent)
        {
            Target t = GetTargets();
            t.Modify("CurrentTarget",(int)ent.Address);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ent"></param>
        /// <returns></returns>
        public void SetFocusTarget(Entity ent)
        {
            Target t = GetTargets();
            t.Modify("FocusTarget", (int)ent.Address);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ent"></param>
        /// <returns></returns>
        public void SetPreviousTarget(Entity ent)
        {
            Target t = GetTargets();
            t.Modify("PreviousTarget",(int) ent.Address);
        }

        #endregion
    }
}