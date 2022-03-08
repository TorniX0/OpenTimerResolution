using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Principal;

namespace OpenTimerResolution
{
    public static class MemoryCleaner
    {
        #region Methods
        
        /// <summary>
        /// Clears the standby cache.
        /// </summary>
        internal static void ClearStandbyCache()
        {
            SetIncreasePrivilege("SeProfileSingleProcessPrivilege");

            int iSize = Marshal.SizeOf(ClearStandbyPageList);

            GCHandle gch = GCHandle.Alloc(ClearStandbyPageList, GCHandleType.Pinned);
            NtStatus result = NtSetSystemInformation(SysMemoryListInfo, gch.AddrOfPinnedObject(), iSize);
            gch.Free();

            if (result != NtStatus.SUCCESS)
            {
                MessageBox.Show(string.Concat("Error code: ", result.ToString()), "OpenTimerResolution", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            cleanCounter++;
        }

        /// <summary>
        /// Returns the standby cache in MB.
        /// </summary>
        internal static long GetStandbyCache()
        {
            PERFORMANCE_INFORMATION pCounter = new();

            bool result = GetPerformanceInfo(out pCounter, Marshal.SizeOf(pCounter));

            if (result == true)
                return pCounter.SystemCache.ToInt64() * pCounter.PageSize.ToInt64() / 1048576L;
            else
                return 0;
        }

        /// <summary>
        /// Returns the total physical memory in MB.
        /// </summary>
        internal static long GetTotalMemory()
        {
            PERFORMANCE_INFORMATION pCounter = new();

            bool result = GetPerformanceInfo(out pCounter, Marshal.SizeOf(pCounter));

            if (result == true)
                return pCounter.PhysicalTotal.ToInt64() * pCounter.PageSize.ToInt64() / 1048576L;
            else
                return 0;
        }

        /// <summary>
        /// Returns the available physical memory in MB.
        /// </summary>
        internal static long GetAvailableMemory()
        {
            PERFORMANCE_INFORMATION pCounter = new();

            bool result = GetPerformanceInfo(out pCounter, Marshal.SizeOf(pCounter));

            if (result == true)
                return pCounter.PhysicalAvailable.ToInt64() * pCounter.PageSize.ToInt64() / 1048576L;
            else
                return 0;
        }

        /// <summary>
        /// Returns the free memory in MB.
        /// (Available physical memory subtracted by the standby cache memory)
        /// </summary>
        internal static long GetFreeMemory()
        {
            return GetAvailableMemory() - GetStandbyCache();
        }
        
        /// <summary>
        /// Function to increase the privilege of the process.
        /// </summary>
        /// <param name="privilegeName">The name of the privilege needed.</param>
        private static bool SetIncreasePrivilege(string privilegeName)
        {
            using WindowsIdentity current = WindowsIdentity.GetCurrent(TokenAccessLevels.Query | TokenAccessLevels.AdjustPrivileges);

            TokPriv1Luid newst;
            newst.Count = 1;
            newst.Luid = 0L;
            newst.Attr = SE_PRIVILEGE_ENABLED;

            //Retrieves the LUID used on a specified system to locally represent the specified privilege name
            if (!LookupPrivilegeValue(null, privilegeName, ref newst.Luid))
                throw new Exception("Error in LookupPrivilegeValue: ", new Win32Exception(Marshal.GetLastWin32Error()));

            //Enables or disables privileges in a specified access token
            int num = AdjustTokenPrivileges(current.Token, false, ref newst, 0, IntPtr.Zero, IntPtr.Zero) ? 1 : 0;
            if (num == 0)
                throw new Exception("Error in AdjustTokenPrivileges: ", new Win32Exception(Marshal.GetLastWin32Error()));
            return num != 0;
        }

        #endregion

        #region Definitions

        /// <summary>
        /// The LookupPrivilegeValue function retrieves the locally unique identifier (LUID) used on a specified system to locally represent the specified privilege name.
        /// </summary>
        /// <param name="host">A pointer to a null-terminated string that specifies the name of the system on which the privilege name is retrieved.
        /// If a null string is specified, the function attempts to find the privilege name on the local system.</param>
        /// <param name="name">A pointer to a null-terminated string that specifies the name of the privilege, as defined in the Winnt.h header file.
        /// For example, this parameter could specify the constant, SE_SECURITY_NAME, or its corresponding string, "SeSecurityPrivilege".</param>
        /// <param name="pluid">A pointer to a variable that receives the LUID by which the privilege is known on the system specified by the "host" parameter.</param>
        [DllImport("advapi32.dll", SetLastError = true)]
        private static extern bool LookupPrivilegeValue(string host, string name, ref long pluid);

        /// <summary>
        /// The AdjustTokenPrivileges function enables or disables privileges in the specified access token.
        /// </summary>
        /// <param name="tokenHandle">A handle to the access token that contains the privileges to be modified. The handle must have TOKEN_ADJUST_PRIVILEGES access to the token.
        /// If the prevState parameter is not NULL, the handle must also have TOKEN_QUERY access.</param>
        /// <param name="disableAll">Specifies whether the function disables all of the token's privileges. If this value is TRUE, the function disables all privileges and ignores the newState parameter.
        /// If it is FALSE, the function modifies privileges based on the information pointed to by the newState parameter.</param>
        /// <param name="newState">A pointer to a TOKEN_PRIVILEGES structure that specifies an array of privileges and their attributes.
        /// If the disableAll parameter is FALSE, the AdjustTokenPrivileges function enables, disables, or removes these privileges for the token.
        /// The following table describes the action taken by the AdjustTokenPrivileges function, based on the privilege attribute.
        /// If disableAll is TRUE, the function ignores this parameter.</param>
        /// <param name="bufLen">Specifies the size, in bytes, of the buffer pointed to by the prevState parameter. This parameter can be zero if the prevState parameter is NULL.</param>
        /// <param name="prevState">A pointer to a buffer that the function fills with a TOKEN_PRIVILEGES structure that contains the previous state of any privileges that the function modifies.
        /// That is, if a privilege has been modified by this function, the privilege and its previous state are contained in the TOKEN_PRIVILEGES structure referenced by prevState.
        /// If the PrivilegeCount member of TOKEN_PRIVILEGES is zero, then no privileges have been changed by this function. This parameter can be NULL.
        /// If you specify a buffer that is too small to receive the complete list of modified privileges, the function fails and does not adjust any privileges.
        /// In this case, the function sets the variable pointed to by the retLen parameter to the number of bytes required to hold the complete list of modified privileges.</param>
        /// <param name="retLen">A pointer to a variable that receives the required size, in bytes, of the buffer pointed to by the prevState parameter.
        /// This parameter can be NULL if PreviousState is NULL.</param>
        [DllImport("advapi32.dll", SetLastError = true)]
        private static extern bool AdjustTokenPrivileges(IntPtr tokenHandle, bool disableAll, ref TokPriv1Luid newState, int bufLen, IntPtr prevState, IntPtr retLen);

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        private struct TokPriv1Luid
        {
            public int Count;
            public long Luid;
            public int Attr;
        }

        /// <summary>
        /// NtSetSystemInformation is used to set some unaccessable KernelMode variables. (There's not too much documentation about this function).
        /// </summary>
        /// <param name="SystemInformationClass">The system info class.</param>
        /// <param name="SystemInfo">The system info pointer.</param>
        /// <param name="SystemInfoLength">The length of the SystemInfo parameter.</param>
        [DllImport("ntdll.dll", SetLastError = true)]
        private static extern NtStatus NtSetSystemInformation(int SystemInfoClass, IntPtr SystemInfo, int SystemInfoLength);

        [StructLayout(LayoutKind.Sequential)]
        private struct PERFORMANCE_INFORMATION
        {
            public int cb;
            public IntPtr CommitTotal;
            public IntPtr CommitLimit;
            public IntPtr CommitPeak;
            public IntPtr PhysicalTotal;
            public IntPtr PhysicalAvailable;
            public IntPtr SystemCache;
            public IntPtr KernelTotal;
            public IntPtr KernelPaged;
            public IntPtr KernelNonpaged;
            public IntPtr PageSize;
            public int HandleCount;
            public int ProcessCount;
            public int ThreadCount;
        }


        /// <summary>
        /// GetPerformanceInfo retrieves the performance values contained in the PERFORMANCE_INFORMATION structure.
        /// </summary>
        /// <param name="pPerformanceInformation">A pointer to a PERFORMANCE_INFORMATION structure that receives the performance information.</param>
        /// <param name="cb">The size of the PERFORMANCE_INFORMATION structure, in bytes.</param>
        [DllImport("psapi.dll", SetLastError = true)]
        private static extern bool GetPerformanceInfo(out PERFORMANCE_INFORMATION pPerformanceInformation, int cb);

        private const int SysMemoryListInfo = 80;
        private const int SE_PRIVILEGE_ENABLED = 2;
        private const int ClearStandbyPageList = 4;
        internal static long cleanCounter = 0;

        #endregion
    }
}
