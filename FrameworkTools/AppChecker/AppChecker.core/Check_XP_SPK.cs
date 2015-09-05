using System;
using System.Collections.Generic;

using System.Text;
using System.Runtime.InteropServices;
using AppChecker.core.Properties;

namespace AppChecker.core
{
    public class Check_XP_SPK : CheckerBase
    {
        public override void Run()
        {
            OnStartEvent("Start: checking XP SPK ");

            OnMessageEvent(GetServicePack(),null, Resources.apply);
            OnFinalizeEvent("", Resources.stop);
        }

        [DllImport("kernel32.Dll")]
        public static extern short GetVersionEx(ref OSVERSIONINFO o);
        string GetServicePack()
        {
            OSVERSIONINFO os = new OSVERSIONINFO();
            os.dwOSVersionInfoSize = Marshal.SizeOf(typeof(OSVERSIONINFO));
            GetVersionEx(ref os);
            if (os.szCSDVersion == "")
                return "        No Service Pack installed";
            else
                return "        " + os.szCSDVersion;
        }
    }


    [StructLayout(LayoutKind.Sequential)]
    public struct OSVERSIONINFO
    {
        public int dwOSVersionInfoSize;
        public int dwMajorVersion;
        public int dwMinorVersion;
        public int dwBuildNumber;
        public int dwPlatformId;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string szCSDVersion;
    }
}
