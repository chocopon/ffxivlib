﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace ffxivlib
{
    public class Entity : BaseObject<Entity.ENTITYINFO>
    {
        #region Constructor

        public Entity(ENTITYINFO structure, IntPtr address)
            : base(structure, address)
        {
            Initialize();
            Name = base.Structure.Name;
        }

        #endregion

        #region Properties

        public int GatheringType { get; set; }

        public string Name { get; set; }

        public int PCId { get; set; }

        public int NPCId { get; set; }

        public int PetMasterID { get; set; }

        public TYPE MobType { get; set; }

        public CURRENTTARGET CurrentTarget { get; set; }

        public byte Distance { get; set; }

        public byte GatheringStatus { get; set; }

        public float X { get; set; }

        public float Z { get; set; }

        public float Y { get; set; }

        public float Heading { get; set; }

        public float HitCircleA { get; set; }
        public float HitCircleB { get; set; }
        public float HitCircleC { get; set; }
        public float HitCircleR { get; set; }

        public byte GatheringInvisible { get; set; }
        public byte Invisible { get; set; }
        public byte Unclickable { get; set; }

        public int ModelID { get; set; }

        public ENTITYSTATUS PlayerStatus { get; set; }

        public bool IsGM { get; set; }

        public byte Icon { get; set; }

        public STATUS IsEngaged { get; set; }

        public float AoE_X { get; set; }
        public float AoE_Z { get; set; }
        public float AoE_Y { get; set; }

        public int TargetId { get; set; }

        public byte GrandCompany { get; set; }

        public byte GrandCompanyRank { get; set; }

        public byte Title { get; set; }

        public JOB Job { get; set; }

        public byte Level { get; set; }

        public int CurrentHP { get; set; }

        public int MaxHP { get; set; }

        public int CurrentMP { get; set; }

        public int MaxMP { get; set; }

        public short CurrentTP { get; set; }

        public short CurrentGP { get; set; }

        public short MaxGP { get; set; }

        public short CurrentCP { get; set; }

        public short MaxCP { get; set; }

        public byte Race { get; set; }

        public SEX Sex { get; set; }

        public byte Aggro { get; set; }

        public BUFF[] Buffs { get; set; }

        public bool IsCasting { get; set; }

        public short CastingSpellId { get; set; }

        public float CastingProgress { get; set; }

        public float CastingTime { get; set; }

        #endregion

        #region Extra properties

        public int CastingPercentage
        {
            get
            {
                if (IsCasting && CastingTime > 0)
                    return (int)((CastingProgress / CastingTime) * 100);
                return 0;
            }
        }

        #endregion

        #region Unmanaged structure

        [StructLayout(LayoutKind.Explicit, Pack = 1)]
        public struct ENTITYINFO
        {
            [MarshalAs(UnmanagedType.I4)] [FieldOffset(0x0)] public int GatheringType;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)] [FieldOffset(0x30)]
            public byte[] name_data;
            // Not exactly PC ID...
            [MarshalAs(UnmanagedType.I4)] [FieldOffset(0x74)] public int PCId;
            [MarshalAs(UnmanagedType.I4)] [FieldOffset(0x78)] public int NPCId;
            [MarshalAs(UnmanagedType.I4)] [FieldOffset(0x84)] public int PetMasterID;
            [MarshalAs(UnmanagedType.I1)] [FieldOffset(0x8A)] public TYPE MobType;
            [MarshalAs(UnmanagedType.I1)] [FieldOffset(0x8C)] public CURRENTTARGET CurrentTarget;
            [MarshalAs(UnmanagedType.I1)] [FieldOffset(0x8D)] public byte Distance;
            [MarshalAs(UnmanagedType.I1)] [FieldOffset(0x8E)] public byte GatheringStatus;
            [MarshalAs(UnmanagedType.R4)] [FieldOffset(0xA0)] public float X;
            [MarshalAs(UnmanagedType.R4)] [FieldOffset(0xA4)] public float Z;
            [MarshalAs(UnmanagedType.R4)] [FieldOffset(0xA8)] public float Y;
            [MarshalAs(UnmanagedType.R4)] [FieldOffset(0xB0)] public float Heading;
            [MarshalAs(UnmanagedType.R4)] [FieldOffset(0xB4)] public float HitCircleA;
            [MarshalAs(UnmanagedType.R4)] [FieldOffset(0xB8)] public float HitCircleB;
            [MarshalAs(UnmanagedType.R4)] [FieldOffset(0xBC)] public float HitCircleC;
            [MarshalAs(UnmanagedType.R4)] [FieldOffset(0xC0)] public float HitCircleR;
            [MarshalAs(UnmanagedType.I1)] [FieldOffset(0x11C)] public byte GatheringInvisible;
            [MarshalAs(UnmanagedType.I1)] [FieldOffset(0x11D)] public byte Invisible;
            [MarshalAs(UnmanagedType.I1)] [FieldOffset(0x11E)] public byte Unclickable;
            [MarshalAs(UnmanagedType.I4)] [FieldOffset(0x174)] public int ModelID;
            [MarshalAs(UnmanagedType.I1)] [FieldOffset(0x18C)] public ENTITYSTATUS PlayerStatus;
            [MarshalAs(UnmanagedType.I1)] [FieldOffset(0x189)] public bool IsGM;
            [MarshalAs(UnmanagedType.I1)] [FieldOffset(0x194)] public ICON Icon;
            [MarshalAs(UnmanagedType.I1)] [FieldOffset(0x19E)] public STATUS IsEngaged;
            [MarshalAs(UnmanagedType.R4)] [FieldOffset(0x4F0)] public float AoE_X;
            [MarshalAs(UnmanagedType.R4)] [FieldOffset(0x4F4)] public float AoE_Z;
            [MarshalAs(UnmanagedType.R4)] [FieldOffset(0x4F8)] public float AoE_Y;
            [MarshalAs(UnmanagedType.I4)] [FieldOffset(0xAA8)] public int TargetId;
            [MarshalAs(UnmanagedType.I1)] [FieldOffset(0x1832)] public byte GrandCompany;
            [MarshalAs(UnmanagedType.I1)] [FieldOffset(0x1833)] public byte GrandCompanyRank;
            [MarshalAs(UnmanagedType.I1)] [FieldOffset(0x1836)] public byte Title;
            [MarshalAs(UnmanagedType.I1)] [FieldOffset(0x1830)] public JOB Job;
            [MarshalAs(UnmanagedType.I1)] [FieldOffset(0x1831)] public byte Level;
            [MarshalAs(UnmanagedType.I4)] [FieldOffset(0x1838)] public int CurrentHP;
            [MarshalAs(UnmanagedType.I4)] [FieldOffset(0x183C)] public int MaxHP;
            [MarshalAs(UnmanagedType.I4)] [FieldOffset(0x1840)] public int CurrentMP;
            [MarshalAs(UnmanagedType.I4)] [FieldOffset(0x1844)] public int MaxMP;
            [MarshalAs(UnmanagedType.I2)] [FieldOffset(0x1848)] public short CurrentTP;
            [MarshalAs(UnmanagedType.I2)] [FieldOffset(0x184A)] public short CurrentGP;
            [MarshalAs(UnmanagedType.I2)] [FieldOffset(0x184C)] public short MaxGP;
            [MarshalAs(UnmanagedType.I2)] [FieldOffset(0x184E)] public short CurrentCP;
            [MarshalAs(UnmanagedType.I2)] [FieldOffset(0x1850)] public short MaxCP;
            [MarshalAs(UnmanagedType.I1)] [FieldOffset(0x2E58)] public byte Race;
            [MarshalAs(UnmanagedType.I1)] [FieldOffset(0x2E59)] public SEX Sex;
            [MarshalAs(UnmanagedType.I1)] [FieldOffset(0x3012)] public byte Aggro;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 24)] [FieldOffset(0x31B8)] public BUFF[] Buffs;
            [MarshalAs(UnmanagedType.I1)] [FieldOffset(0x3330)] public bool IsCasting;
            [MarshalAs(UnmanagedType.I2)] [FieldOffset(0x3334)] public short CastingSpellId;
            [MarshalAs(UnmanagedType.R4)] [FieldOffset(0x3364)] public float CastingProgress;
            [MarshalAs(UnmanagedType.R4)] [FieldOffset(0x3368)] public float CastingTime;
            /// <summary>
            /// Support for Multibye languages
            /// </summary>
            public string Name
            {
                get
                {
                    if (name_data[0] == 0)
                        return "";
                    bool end = false;
                    for (int i = 1; i < name_data.Length; i++)
                    {
                        if (end)
                        {
                            name_data[i] = 0;
                            continue;
                        }
                        if (name_data[i] == 0)
                        {
                            end = true;
                        }
                    }

                    return System.Text.Encoding.UTF8.GetString(name_data).TrimEnd(new char[] { '\0' });
                }
            }
        };

        #endregion

        #region Public methods

        /// <summary>
        /// Returns the distance between current Entity and a given Entity
        /// </summary>
        /// <param name="other">Entity to compare to</param>
        /// <returns>Distance</returns>
        public float GetDistanceTo(Entity other)
        {
            float fDistX = Math.Abs(Structure.X - other.Structure.X);
            float fDistY = Math.Abs(Structure.Y - other.Structure.Y);
            float fDistZ = Math.Abs(Structure.Z - other.Structure.Z);
            return (float) Math.Sqrt((fDistX*fDistX) + (fDistY*fDistY) + (fDistZ*fDistZ));
        }

        /// <summary>
        /// Returns the distance between current Entity and a given Entity
        /// </summary>
        /// <param name="other">Entity to compare to</param>
        /// <returns>Distance</returns>
        public float GetDistanceToWithoutZ(Entity other)
        {
            float fDistX = Math.Abs(Structure.X - other.Structure.X);
            float fDistY = Math.Abs(Structure.Y - other.Structure.Y);
            return (float)Math.Sqrt((fDistX * fDistX) + (fDistY * fDistY));
        }

        #endregion
    }

    public partial class FFXIVLIB
    {
        #region Public methods

        /// <summary>
        ///     This function build an Entity object according to the position in the Entity array
        ///     You may effectively loop by yourself on this function.
        /// </summary>
        /// <param name="id">Position in the Entity Array, use Constants.ENTITY_ARRAY_SIZE as your max (exclusive)</param>
        /// <returns>Entity object or null</returns>
        /// <exception cref="System.IndexOutOfRangeException">Out of range</exception>
        public Entity GetEntityById(int id)
        {
            if (id >= Constants.ENTITY_ARRAY_SIZE)
                throw new IndexOutOfRangeException();
            IntPtr pointer = IntPtr.Add(_mr.GetArrayStart(Constants.PCPTR), id*0x4);
            IntPtr address = _mr.ResolvePointer(pointer);
            if (address == IntPtr.Zero) return null;
            Entity.ENTITYINFO en = _mr.CreateStructFromAddress<Entity.ENTITYINFO>(address);
            if (!Equals(en, default(Entity.ENTITYINFO)))
                {
                    Entity e = new Entity(en, address);
                    return e;
                }
            return null;
        }

        /// <summary>
        /// Deprecated, use getEntityById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Entity GetEntityInfo(int id)
        {
            return GetEntityById(id);
        }

        /// <summary>
        ///     This function attempts to retrieve a list of Entity by its name in the Entity array
        ///     This is potentially a costly call as we build a complete list to look for the Entity.
        /// This doesn't include Gathering nodes at the moment. To be fixed.
        /// </summary>
        /// <param name="name">Name of the Entity to be retrieved</param>
        /// <returns>Enumerable list of Entity object or</returns>
        public IEnumerable<Entity> GetEntityByName(string name)
        {
            IntPtr pointer = _mr.GetArrayStart(Constants.PCPTR);
            var entityList = new List<Entity>();
            for (int i = 0; i < Constants.ENTITY_ARRAY_SIZE; i++)
                {
                    IntPtr address = _mr.ResolvePointer(pointer + (i*0x4));
                if(address == IntPtr.Zero)continue;
                    Entity.ENTITYINFO en = _mr.CreateStructFromAddress<Entity.ENTITYINFO>(address);
                    if (!Equals(en, default(Entity.ENTITYINFO)))
                        {
                            Entity e = new Entity(en, address);
                            entityList.Add(e);
                        }
                }
            var results = entityList.Where(obj => obj.Structure.Name == name);
            return results;
        }

        /// <summary>
        /// Retrieves a list of Entity corresponding to the given TYPE
        /// Needs to be refactored.
        /// </summary>
        /// <param name="type">Type of entity</param>
        /// <returns>Enumerable list of Entity objects</returns>
        public IEnumerable<Entity> GetEntityByType(TYPE type)
        {
            var pointerPath = Constants.PCPTR;
            uint arraySize = Constants.ENTITY_ARRAY_SIZE;
            if (type == TYPE.Gathering)
                {
                    pointerPath = Constants.GATHERINGPTR;
                    arraySize = Constants.GATHERING_ARRAY_SIZE;
                }
            if (type == TYPE.NPC)
            {
                pointerPath = Constants.NPCPTR;
                arraySize = Constants.NPC_ARRAY_SIZE;
            }
            IntPtr pointer = _mr.GetArrayStart(pointerPath);
            var entityList = new List<Entity>();
            for (int i = 0; i < arraySize; i++)
                {
                    IntPtr address = _mr.ResolvePointer(pointer + (i*0x4));
                    if (address == IntPtr.Zero) continue;
                    Entity.ENTITYINFO en = _mr.CreateStructFromAddress<Entity.ENTITYINFO>(address);
                    if (!Equals(en, default(Entity.ENTITYINFO)))
                        {
                            Entity e = new Entity(en, address);
                            entityList.Add(e);
                        }
                }
            var results = entityList.Where(e => e.Structure.MobType == type);
            return results;
        }

        /// <summary>
        /// This function updates the latest information an entity
        /// </summary>
        /// <param name="ent"></param>
        /// <returns></returns>
        public Entity UpdateEntityInfo(Entity ent)
        {
            IntPtr address = ent.Address;
            if (address == IntPtr.Zero)
                return null;

            try
            {
                Entity e = new Entity(_mr.CreateStructFromAddress<Entity.ENTITYINFO>(address), address);
                return e;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Entity GetEntityByPCID(int id)
        {
            if (id == 0) return null;

            var pointerPath = Constants.PCPTR;
            uint arraySize = Constants.ENTITY_ARRAY_SIZE;
            IntPtr pointer = _mr.GetArrayStart(pointerPath);
            for (int i = 0; i < arraySize; i++)
            {
                IntPtr address =  _mr.ResolvePointer( pointer + (i * 0x4));
                if (address == IntPtr.Zero) continue;
                try
                {
                    Entity ent = new Entity(_mr.CreateStructFromAddress<Entity.ENTITYINFO>(address), address);
                    if (ent.PCId == id || ent.NPCId == id)
                    {
                        return ent;
                    }
                }
                catch (Exception)
                {
                    // No Entity at this position
                }
            }
            return null;
        }
        #endregion
    }
}
