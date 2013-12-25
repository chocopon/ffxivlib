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
        public float Unkown { get; set; }
        #endregion

        #region Unmanaged structure

        [StructLayout(LayoutKind.Explicit, Pack = 1)]
        public struct RECAST
        {
            [MarshalAs(UnmanagedType.I1)][FieldOffset(0)]public bool IsRecast;
            [MarshalAs(UnmanagedType.R4)][FieldOffset(0x04)]public float Unkown;
            [MarshalAs(UnmanagedType.R4)][FieldOffset(0x08)]public float ElapsedTime;
            [MarshalAs(UnmanagedType.R4)][FieldOffset(0x0C)]public float RecastTime;
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
            IntPtr address = IntPtr.Add(_mr.GetArrayStart(Constants.RECASTPTR), id * 0x14);
            Recast.RECAST recast = _mr.CreateStructFromAddress<Recast.RECAST>(address);
            return new Recast(recast, address);
        }

        #endregion
    }
}
/*
BASE 012F0000
02322540 デジョン
02322150 ランパート

 * ESI 01F62050
ESI + EDX*4 +10C

ランパート 0
コンバレセンス 1
アウェアネス 2
センチネル 3
挑発 4
鋼の意思 5
ファイトオアフライト 6
ブルワーク 7
サークルオブドゥーム 8
かばう 9
ウィズイン A
インビンシブル B
スプリント 37
フラッシュ　39 GCD

01F62050

EDX = EAX+EAX*4=EAX*5
EAX
 */


public static partial class Constants
{
    #region Array size
    
    internal const uint RECAST_ARRAY_SIZE = 60;

    #endregion

    #region Pointer paths
    internal static readonly List<int> RECASTPTR = new List<int>
    {
        0x01032050,
        0x100
    };
    #endregion
}

