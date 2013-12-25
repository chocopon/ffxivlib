using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
namespace ffxivlib
{
    public class Additional : BaseObject<Additional.ADDITIONAL>
    {
        #region Constructor

        public Additional(ADDITIONAL structure, IntPtr address)
            : base(structure, address)
        {
            Initialize();
        }

        #endregion

        #region Properties

        public UInt32[] Actions { get; set; }
        
        #endregion

        #region Unmanaged structure

        [StructLayout(LayoutKind.Explicit, Pack = 1)]
        public struct ADDITIONAL
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
            [FieldOffset(0x0)]
            public UInt32[] Actions;
        }

        #endregion
    }

    public partial class FFXIVLIB
    {
        #region Public methods

        public Additional GetAdditonals()
        {
            IntPtr pointer = _mr.GetArrayStart(Constants.ADDITIONALTPTR);
            var t = new Additional(_mr.CreateStructFromAddress<Additional.ADDITIONAL>(pointer), pointer);
            return t;
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

    internal const uint ADDITIONAL_ARRAY_SIZE = 10;

    #endregion

    #region Pointer paths
    internal static readonly List<int> ADDITIONALTPTR = new List<int>
    {
        0x01032050,
        0xD8
    };
    #endregion
}

