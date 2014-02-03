using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
namespace ffxivlib
{
    public class CruiseInfo : BaseObject<CruiseInfo.CRUISEINFO>
    {
        #region Constructor

        public CruiseInfo(CRUISEINFO structure, IntPtr address)
            : base(structure, address)
        {
            Initialize();
        }
        #endregion

        #region Properties
        public bool Moving { get; set; }
        public bool Steering { get; set; }
        public bool Unknown { get; set; }
        public bool Auto { get; set; }
        public bool Follow { get; set; }
        #endregion

        #region Unmanaged structure

        [StructLayout(LayoutKind.Explicit, Pack = 1)]
        public struct CRUISEINFO
        {
            [MarshalAs(UnmanagedType.I1)][FieldOffset(0x0)]public bool Moving;
            [MarshalAs(UnmanagedType.I1)][FieldOffset(0x1)]public bool Steering;
            [MarshalAs(UnmanagedType.I1)][FieldOffset(0x2)]public bool Unknown;
            [MarshalAs(UnmanagedType.I1)][FieldOffset(0x3)]public bool Auto;
            [MarshalAs(UnmanagedType.I1)][FieldOffset(0x4)]public bool Follow;
        };
        #endregion

        #region Public methods

        #endregion
    }
    public partial class FFXIVLIB
    {
        #region Public methods

        /// <summary>
        ///     This function retrieves the croise info
        /// </summary>
        /// <returns>Target object</returns>
        public CruiseInfo GetCruiseInfo()
        {
            IntPtr address = _mr.ResolvePointerPath(Constants.CRUISEPTR);
            var c = new CruiseInfo(_mr.CreateStructFromAddress<CruiseInfo.CRUISEINFO>(address), address);
            return c;
        }       
        #endregion
    }
}
    public static partial class Constants
    {
        #region Pointer paths
        internal static readonly List<int> CRUISEPTR = new List<int>
        {
        0x11C2204,
        //        0x100
        #endregion
        };
    }
