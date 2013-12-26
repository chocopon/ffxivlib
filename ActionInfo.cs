using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace ffxivlib
{
    public class ActionInfo : BaseObject<ActionInfo.ACTIONINFO>
    {
        #region Constructor

        public ActionInfo(ACTIONINFO structure, IntPtr address)
            : base(structure, address)
        {
            Initialize();
        }

        #endregion

        #region Properties

        public RECAST[] Recasts { get; set; }

        public uint[] Additionals { get; set; }

        #endregion

        #region Unmanaged structure

        [StructLayout(LayoutKind.Explicit, Pack = 1)]
        public struct ACTIONINFO
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
            [FieldOffset(0xD8)]
            public UInt32[] Additionals;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 57)]
            [FieldOffset(0x100)]
            public RECAST[] Recasts;         
        };

        #endregion

        #region Public methods

        #endregion

    }

    public partial class FFXIVLIB
    {
        #region Public methods

        public int[] GetRecastActionIDs(JOB job)
        {
            if (job == JOB.GLD || job == JOB.PLD)
            {
                return Constants.GLDPLDRecastActionIDs;
            }
            if (job == JOB.MRD || job == JOB.WAR)
            {
                return Constants.MRDWARRecastActionIDs;
            }
            if (job == JOB.PGL || job == JOB.MNK)
            {
                return Constants.PGLMNKRecastActionIDs;
            }
            if (job == JOB.LNC || job == JOB.DRG)
            {
                return Constants.LNCDRGRecastActionIDs;
            }
            if (job == JOB.ARC || job == JOB.BRD)
            {
                return Constants.ARCBRDRecastActionIDs;
            }
            if (job == JOB.CNJ || job == JOB.WHM)
            {
                return Constants.CNJWHMRecastActionIDs;
            }
            if (job == JOB.THM || job == JOB.BLM)
            {
                return Constants.THMBLMRecastActionIDs;
            }
            if (job == JOB.ACN || job == JOB.SMN || job == JOB.SCH)
            {
                return Constants.ACNSMNSCHRecastActionIDs;
            }
            return new int[0];
        }

        /// <summary>
        /// This function retrieves the action information. For example, Recasts, Set of Additionals.
        /// </summary>
        /// <returns></returns>
        public ActionInfo GetActionInfo()
        {
            IntPtr address = _mr.ResolvePointerPath(Constants.ACTIONPTR);
            var t = new ActionInfo(_mr.CreateStructFromAddress<ActionInfo.ACTIONINFO>(address), address);
            return t;
        }

        #endregion
    }
}

public static partial class Constants
{
    #region Array size

    internal const uint RECAST_ARRAY_SIZE = 57;

    #endregion

    #region Pointer paths
    internal static readonly List<int> ACTIONPTR = new List<int>
    {
        0x01032050,
//        0x100
    };
    #endregion

    public static string[] GLDPLDRecastActions = new string[] {
        "ランパート",
        "コンバレセンス",
"アウェアネス",
"センチネル",
"挑発",
"鋼の意志",
"ファイト・オア・フライト",
"ブルワーク",
"サークル・オブ・ドゥーム",
"かばう",
"スピリッツウィズイン",
"インビンシブル",
    };

    public static int[] GLDPLDRecastActionIDs = new int[] {
10,
12,
13,
17,
18,
19,
20,
22,
23,
27,
29,
30,
    };

    public static string[] MRDWARRecastActions = new string[] {
        "フォーサイト",
        "フラクチャー",
        "ブラッドバス",
        "マーシーストローク",    
        "バーサク",
        "スリル・オブ・バトル",
        "ホルムギャング",
        "ヴェンジェンス",
        "ディフェンダー",
        "ウォークライ",
    };

    public static int[] MRDWARRecastActionIDs = new int[] {
32,
33,
34,
36,
38,
40,
43,
44,
48,
52,
    };

    
    public static string[] PGLMNKRecastActions = new string[] {
        "フェザーステップ",
"内丹",
"発勁",
"金剛の構え",
"紅蓮の構え",
"鉄山靠",
"マントラ",
"空鳴拳",
"踏鳴",
"疾風の構え",
    };

    public static int[] PGLMNKRecastActionIDs = new int[] {
55,
57,
59,
60,
63,
64,
65,
67,
69,
73,
    };

    public static string[] LNCDRGRecastActions = new string[] {
        "キーンフラーリ",
"気合",
"足払い",
"ライフサージ",
"捨身",
"ジャンプ",
"竜槍",
"イルーシブジャンプ",
"スパインダイブ",
"ドラゴンダイブ",
    };

    public static int[] LNCDRGRecastActionIDs = new int[] {
80,
82,
83,
85,
92,
93,
94,
95,
96,
    };

    public static string[] ARCBRDRecastActions = new string[] {
        "ホークアイ",
"猛者の撃",
"フレイミングアロー",
"ミザリーエンド",
"静者の撃",
"乱れ撃ち",
"影縫い",
"ブラントアロー",
"ブラッドレッター",
"リペリングショット",
"バトルボイス",

    };
    public static int[] ARCBRDRecastActionIDs = new int[] {
99,
101,
102,
103,
104,
107,
108,
109,
110,
112,
118,
    };

    public static string[] CNJWHMRecastActions = new string[] {
        "クルセードスタンス",
"女神の加護",
"アクアオーラ",
"神速魔",
"ディヴァインシール",
"ベネディクション",

    };

    public static int[] CNJWHMRecastActionIDs = new int[] {
122,
130,
134,
136,
138,
140,
    };


    public static string[] THMBLMRecastActions = new string[] {
        "堅実魔",
"トランス",
"迅速魔",
"レサージー",
"エーテリアルステップ",
"マバリア",
"コンバート",
"アポカタスタシス",
"ウォール",

    };


    public static int[] THMBLMRecastActionIDs = new int[] {
143,
149,
150,
151,
155,
157,
158,
160,
161,
    };

    public static string[] ACNSMNSCHRecastActions = new string[] {
        "エーテルフロー",
"エナジードレイン",
"ウイルス",
"ベイン",
"アイ・フォー・アイ",
"ラウズ",
"ミアズマバースト",
"スパー",
"エンキンドル",
    };

    public static int[] ACNSMNSCHRecastActionIDs = new int[] {
166,
167,
169,
174,
175,
176,
181,
183,
184,
    };

}