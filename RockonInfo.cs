using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace ffxivlib
{
    public class RockonInfo : BaseObject<RockonInfo.ROCKONINFO>
    {
        #region Constructor

        public RockonInfo(ROCKONINFO structure, IntPtr address)
            : base(structure, address)
        {
            Initialize();
        }
        #endregion

        #region Properties
        public bool Rockon { get; set; }
        #endregion

        #region Unmanaged structure

        [StructLayout(LayoutKind.Explicit, Pack = 1)]
        public struct ROCKONINFO
        {
            [MarshalAs(UnmanagedType.I1)]
            [FieldOffset(0x0)]
            public bool Rockon;
        };
        #endregion

        #region Public methods

        #endregion
    }
    public partial class FFXIVLIB
    {
        #region Public methods

        /// <summary>
        ///     This function retrieves the rockon info
        /// </summary>
        /// <returns>Target object</returns>
        public RockonInfo GetRockonInfo()
        {
            IntPtr address = _mr.ResolvePointerPath(Constants.ROCKONPTR);
            var r = new RockonInfo(_mr.CreateStructFromAddress<RockonInfo.ROCKONINFO>(address), address);
            return r;
        }
        #endregion
    }

}

public static partial class Constants
{
    internal static readonly List<int> ROCKONPTR = new List<int>
    {
        0x1071730,
        0x93
    };
}
