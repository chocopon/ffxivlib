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
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 60)]
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

        public IEnumerable<Recast> GetRecasts()
        {
            ActionInfo actioninfo = GetActionInfo();
            Player player = GetPlayerInfo();
            var recastList = new List<Recast>();
            int[] actionIDs =  GetRecastActionIDs(player.Job);
            for(int i=0;i<actionIDs.Length;i++)
            {
                RECAST r = actioninfo.Recasts[i];
                recastList.Add(new Recast(actionIDs[i],r.ElapsedTime,r.RecastTime));
            }
            for (int i = 0; i < actioninfo.Additionals.Length; i++)
            {
                int additional = (int)actioninfo.Additionals[i];
                if (additional == 0) continue;
                RECAST r = actioninfo.Recasts[i+40];
                recastList.Add(new Recast(additional, r.ElapsedTime, r.RecastTime));
            }

            RECAST sprint = actioninfo.Recasts[55];
            recastList.Add(new Recast(3, sprint.ElapsedTime, sprint.RecastTime));
            RECAST _return = actioninfo.Recasts[56];
            recastList.Add(new Recast(6, _return.ElapsedTime, _return.RecastTime));

            return recastList;
        }

        public Recast GetGCD()
        {
            ActionInfo actioninfo = GetActionInfo();
            RECAST gcd =actioninfo.Recasts[57];
            return new Recast(0, gcd.ElapsedTime, gcd.RecastTime);
        }

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

    public class Recast
    {
        #region Properties
        public int ActionID{get;private set;}
        public float ElapsedTime{get;private set;}
        public float RecastTime{get;private set;}
        #endregion        

        #region Constractor
        internal Recast(int actionId,float elapsedtime, float recasttime)
        {
            ActionID = actionId;
            ElapsedTime = elapsedtime;
            RecastTime = recasttime;
        }
#endregion

    }
}

public static partial class Constants
{
    #region Array size

    internal const uint RECAST_ARRAY_SIZE = 60;

    #endregion

    #region Pointer paths
    internal static readonly List<int> ACTIONPTR = new List<int>
    {
        0xE4FAF0,//2.16
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
        "バーサク",//マーシーとバーサクは反対になっている？
        "マーシーストローク",    
        "スリル・オブ・バトル",
        "ホルムギャング",
        "ヴェンジェンス",
        "ディフェンダー",
        "アンチェインド",
        "ウォークライ",
    };

    public static int[] MRDWARRecastActionIDs = new int[] {
32,
33,
34,
38,
36,
40,
43,
44,
48,
50,
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
77,
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
118,
114,//バラード
116,//パイオン
112,
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

/*
10	202	ランパート	0	1	/ac ランパート <me>	v
12	212	コンバレセンス	1	1	/ac コンバレセンス <me>	v
13	213	アウェアネス	2	1	/ac アウェアネス <me>	v
17	201	センチネル	3	1	/ac センチネル <me>	v
18	215	挑発	4	1	/ac 挑発 <me>	v
19	203	鋼の意志	5	1	/ac 鋼の意志 <me>	v
20	216	ファイト・オア・フライト	6	1	/ac ファイト・オア・フライト <me>	v
22	217	ブルワーク	7	1	/ac ブルワーク <me>	v
23	211	サークル・オブ・ドゥーム	8	1	/ac サークル・オブ・ドゥーム <me>	v
27	3001	かばう	9	13	/ac かばう <me>	
29	3003	スピリッツウィズイン	10	13	/ac スピリッツウィズイン <me>	v
30	3002	インビンシブル	11	13	/ac インビンシブル <me>	v
32	402	フォーサイト	0	3	/ac フォーサイト <me>	v
33	406	フラクチャー	1	3	/ac フラクチャー <me>	v
34	401	ブラッドバス	2	3	/ac ブラッドバス <me>	v
36	415	マーシーストローク	3	3	/ac マーシーストローク <me>	
38	409	バーサク	4	3	/ac バーサク <me>	v
40	413	スリル・オブ・バトル	5	3	/ac スリル・オブ・バトル <me>	v
43	416	ホルムギャング	6	3	/ac ホルムギャング <me>	v
44	417	ヴェンジェンス	7	3	/ac ヴェンジェンス <me>	v
48	3201	ディフェンダー	9	15	/ac ディフェンダー <me>	v
52	3205	ウォークライ	10	15	/ac ウォークライ <me>	v
55	302	フェザーステップ	0	2	/ac フェザーステップ <me>	
57	301	内丹	1	2	/ac 内丹 <me>	
59	312	発勁	2	2	/ac 発勁 <me>	
60	306	金剛の構え	3	2	/ac 金剛の構え <me>	
63	305	紅蓮の構え	4	14	/ac 紅蓮の構え <me>	
64	3105	鉄山靠	5	2	/ac 鉄山靠 <me>	
65	316	マントラ	6	2	/ac マントラ <me>	
67	307	空鳴拳	7	2	/ac 空鳴拳 <me>	
69	317	踏鳴	8	2	/ac 踏鳴 <me>	
73	3102	疾風の構え	9	2	/ac 疾風の構え <me>	
77	501	キーンフラーリ	0	4	/ac キーンフラーリ <me>	v
80	502	気合	1	4	/ac 気合 <me>	v
82	505	足払い	2	4	/ac 足払い <me>	v
83	504	ライフサージ	3	4	/ac ライフサージ <me>	v
85	509	捨身	4	4	/ac 捨身 <me>	v
92	3301	ジャンプ	5	16	/ac ジャンプ <me>	v
93	503	竜槍	6	16	/ac 竜槍 <me>	v
94	3302	イルーシブジャンプ	7	16	/ac イルーシブジャンプ <me>	v
95	3305	スパインダイブ	8	16	/ac スパインダイブ <me>	v
96	3303	ドラゴンダイブ	9	16	/ac ドラゴンダイブ <me>	v
99	604	ホークアイ	0	5	/ac ホークアイ <me>	v
101	602	猛者の撃	1	5	/ac 猛者の撃 <me>	v
102	618	フレイミングアロー	2	5	/ac フレイミングアロー <me>	v
103	614	ミザリーエンド	3	5	/ac ミザリーエンド <me>	
104	601	静者の撃	4	5	/ac 静者の撃 <me>	v
107	603	乱れ撃ち	5	5	/ac 乱れ撃ち <me>	v
108	606	影縫い	6	5	/ac 影縫い <me>	v
109	619	ブラントアロー	7	5	/ac ブラントアロー <me>	v
110	611	ブラッドレッター	8	5	/ac ブラッドレッター <me>	v
112	616	リペリングショット	9	5	/ac リペリングショット <me>	v
118	3401	バトルボイス	10	17	/ac バトルボイス <me>	v
122	713	クルセードスタンス	0	6	/ac クルセードスタンス <me>	v
130	715	女神の加護	1	6	/ac 女神の加護 <me>	v
134	716	アクアオーラ	2	6	/ac アクアオーラ <me>	v
136	3501	神速魔	3	18	/ac 神速魔 <me>	v
138	3505	ディヴァインシール	4	18	/ac ディヴァインシール <me>	v
140	3502	ベネディクション	5	18	/ac ベネディクション <me>	v
143	810	堅実魔	0	7	/ac 堅実魔 <me>	v
149	816	トランス	1	7	/ac トランス <me>	v
150	811	迅速魔	2	7	/ac 迅速魔 <me>	v
151	814	レサージー	3	7	/ac レサージー <me>	v
155	817	エーテリアルステップ	4	7	/ac エーテリアルステップ <me>	
157	813	マバリア	5	7	/ac マバリア <me>	v
158	3601	コンバート	6	19	/ac コンバート <me>	v
160	3604	アポカタスタシス	7	19	/ac アポカタスタシス <me>	
161	3605	ウォール	8	19	/ac ウォール <me>	v
166	910	エーテルフロー	0	2A	/ac エーテルフロー <me>	
169	913	ウイルス	1	2A	/ac ウイルス <me>	
174	907	ベイン	2	2A	/ac ベイン <me>	
175	912	アイ・フォー・アイ	3	2A	/ac アイ・フォー・アイ <me>	
176	909	ラウズ	4	2A	/ac ラウズ <me>	
181	3701	ミアズマバースト	5	2B	/ac ミアズマバースト <me>	
183	3704	スパー	6	2B	/ac スパー <me>	
184	3702	エンキンドル	7	2B	/ac エンキンドル <me>	

 */