﻿using System;
using System.Collections.Generic;

public static partial class Constants
{
    // ReSharper disable InconsistentNaming
    internal const string PROCESS_NAME = "ffxiv";

    #region Pointer paths
    // Simple representation of pointer paths, do not add base module, last member will be expected to be the offset so may have to add extra 0 at the end if you dont need it
    internal static readonly List<int> PCPTR = new List<int>
        {
           0xF643E4, //2.2
            0x0
        };

    internal static readonly List<int> GATHERINGPTR = new List<int>
        {
            0xF5D908,//2.2
            0x0
        };

    internal static readonly List<int> NPCPTR = new List<int>()
    {
        0xF5D9A8,//2.2
        0x0
    };
    
    internal static readonly List<int> PARTYPTR = new List<int>
        {
            0x4816C,//2.2
            0x10
        };

    internal static readonly List<int> TARGETPTR = new List<int>
        {
            0xE3C038//2.2
        };

    internal static readonly List<int> PLAYERPTR = new List<int>
        {
            0x34D600,//2.2
            0x0
        };

    internal static readonly List<int> CHATPTR = new List<int>
        {
            0xE38420,//2.2
            0x18,
            0x200//2.2
        };
    internal static readonly List<int> INVENTORYPTR = new List<int>
        {
            0x1194C48,
            0
        };

    internal static readonly List<int> SERVERPTR = new List<int>
    {
        0x1074A10,//2.15
        0x34,
        0x4F4,
        0x5A6
    };

    internal static readonly List<int> ZONEPTR = new List<int>
    {
        0x8AF5C,
        0x0
    };

    internal static readonly List<int> SUBZONEPTR = new List<int>
    {
        0x8AF5C,
        0x4
    };

    internal static readonly List<int> PTCOUNTPTR = new List<int>
    {
        0xF86B8C,//2.2
    };

    #endregion

    #region Array size

    internal const uint CHATLOG_ARRAY_SIZE = 1000;
    internal const uint ENTITY_ARRAY_SIZE = 100;
    internal const uint PARTY_MEMBER_ARRAY_SIZE = 8;
    internal const uint GATHERING_ARRAY_SIZE = 40;
    internal const uint NPC_ARRAY_SIZE = 60;

    #endregion

    #region Chat related

    internal const int TIMESTAMP_SIZE = 8;
    internal const int CHATCODE_SIZE = 4;

    #endregion

    #region ResourceParser related

    /// <summary>
    /// Some parameters can be overriden BEFORE instanciating FFXIVLIB.
    /// </summary>
    public class ResourceParser
    {
        public static string RESOURCES_FOLDER = "Resources";
        /// <summary>
        /// Valid values : ja, fr, en, de
        /// </summary>
        public static string RESOURCES_LANGUAGE = "ja";//for japanese
        internal const string BUFF_FILE = "Buffs.xml";
        internal const string ITEM_FILE = "Item.xml";
        internal const string TITLE_FILE = "Title.xml";
        internal const string JOB_FILE = "ClassJob.xml";
        internal const string GRAND_COMPANY_FILE = "GrandCompany.xml";
        internal const string GRAND_COMPANY_RANK_FILE = "GCRankUldahMaleText.xml";
        internal const string AUTOTRANSLATE_FILE = "Autotranslate.xml";
        internal const string ZONE_FILE = "PlaceName.xml";
        internal const string QUEST_FILE = "Quest.xml";
        internal const string ACTION_FILE = "Action.xml";
    }

    #endregion
    // ReSharper restore InconsistentNaming
}