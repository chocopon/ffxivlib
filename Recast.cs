using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
namespace ffxivlib
{
    public class Recast : BaseObject<Recast.RECAST>
    {
        #region Constructor

        public Recast(RECAST structure, IntPtr address)
            : base(structure, address)
        {
            Initialize();
        }

        #endregion

        #region Properties

        public bool IsRecast { get; set; }
        public float ElapsedTime { get; set; }
        public float RecastTime { get; set; }

        #endregion

        #region Unmanaged structure

        [StructLayout(LayoutKind.Explicit, Pack = 1)]
        public struct RECAST
        {
            [MarshalAs(UnmanagedType.I4)]
            [FieldOffset(0)]
            public bool IsRecast;
            [MarshalAs(UnmanagedType.R4)]
            [FieldOffset(0x08)]
            public float ElapsedTime;
            [MarshalAs(UnmanagedType.R4)]
            [FieldOffset(0x0C)]
            public float RecastTime;
        }

        #endregion
    }

    public partial class FFXIVLIB
    {
        #region Public methods

        public Recast GetRecast(int id)
        {
            if (id >= Constants.RECAST_ARRAY_SIZE)
                throw new IndexOutOfRangeException();
            IntPtr address = IntPtr.Add(_mr.GetArrayStart(Constants.RECASTPTR), id * 0x10);
            Recast.RECAST recast = _mr.CreateStructFromAddress<Recast.RECAST>(address);
            return new Recast(recast, address);
        }

        #endregion
    }
}




public static partial class Constants
{
    #region Array size
    
    internal const uint RECAST_ARRAY_SIZE = 100;

    #endregion

    #region Pointer paths
    internal static readonly List<int> RECASTPTR = new List<int>
    {
        0x011C1208,//デバッグ調査中 debug
        0x0
    };
    #endregion
}

