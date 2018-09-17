using System;
using System.Net;
using Fwk.Bases;
using System.Management;

namespace Fwk.HelperFunctions
{
	/// <summary>
	/// Funciones que obtienen datos del Sistema Operativo.
	/// </summary>
	public class EnvironmentFunctions
	{
        static char _Dot;
        static System.Globalization.NumberFormatInfo _NumberFormatInfo = null;
        static char _Coma;

        /// <summary>
        /// Valor constante que reoprecenta el separador '.'
        /// </summary>
        public static char Dot
        {
            get { return EnvironmentFunctions._Dot; }
            set { EnvironmentFunctions._Dot = value; }
        }
        
        /// <summary>
        /// /// Valor constante que reoprecenta el separador ','
        /// </summary>
        public static char Coma
        {
            get { return EnvironmentFunctions._Coma; }
            set { EnvironmentFunctions._Coma = value; }
        }

        /// <summary>
        /// Indica el separador decimal actual
        /// </summary>
        public static char NumberDecimalSeparator
        {
            get { return Convert.ToChar(_NumberFormatInfo.NumberDecimalSeparator); }
        }

        /// <summary>
        /// Indica el separador miles.-
        /// </summary>
        public static char NumberGroupSeparator
        {
            get { return Convert.ToChar(_NumberFormatInfo.NumberGroupSeparator); }
        }

        static EnvironmentFunctions()
        {
            System.Globalization.CultureInfo ci = System.Globalization.CultureInfo.InstalledUICulture;
            _NumberFormatInfo = (System.Globalization.NumberFormatInfo)ci.NumberFormat.Clone();
            _Dot = Convert.ToChar(".");
            _Coma = Convert.ToChar(",");
        }
        public static Boolean IsValidDecimalSeparator(string value)
        {
            return _NumberFormatInfo.NumberDecimalSeparator == value;
        }
	

        /// <summary>
        /// Determina si una aplicacione se encuentra en tiempo de diceño o no.
        /// </summary>
        /// <returns>Boolean</returns>
        /// <Author>Marcelo Oviedo</Author>
        public static Boolean IsInDesigntime()
        {
            return (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime ) ? true:false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string GetMachineIp()
        {
            IPHostEntry ipEntry = Dns.GetHostEntry(Dns.GetHostName());
            System.Net.IPEndPoint Address = new IPEndPoint(ipEntry.AddressList[0], 0);
            return ipEntry.AddressList[1].ToString();
        }

        /// <summary>
        /// Obtiene el numero de serio del disco maestro. 
        /// Para Windows 7 obtiene SerialNumber del disco c:
        /// PAra windows xp obtiene VolumeSerialNumber del disco c:
        /// </summary>
        /// <returns></returns>
        public static String GetDriverSerealNumber()
        {
            OSVersion version = GetOSVersion();
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("select Index,SerialNumber from Win32_DiskDrive where Index = 0");

            OSVersion v = GetOSVersion();
            if (v == OSVersion.Windows_7)
            {
                searcher = new ManagementObjectSearcher("select Index,SerialNumber from Win32_DiskDrive where Index = 0");
                foreach (ManagementObject share in searcher.Get())
                {
                    //if (Convert.ToInt32(share["Index"]).Equals(0))
                    //{
                    return share["SerialNumber"].ToString();
                    //}
                }
            }
            if (v == OSVersion.Windows_XP)
            {
                searcher = new ManagementObjectSearcher("select Name,VolumeSerialNumber from Win32_LogicalDisk ");

                foreach (ManagementObject partion in searcher.Get())
                {
                    if (partion["Name"].Equals("C:"))
                        return partion["VolumeSerialNumber"].ToString();
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// Obtiene la version del sistema operativo .-
        /// </summary>
        /// <returns>enumeracion <see cref="OSVersion"/></returns>
        public static OSVersion GetOSVersion()
        {
            int _MajorVersion = Environment.OSVersion.Version.Major;
            switch (_MajorVersion)
            {
                case 5: return OSVersion.Windows_XP;
                case 6:
                    {
                        switch (Environment.OSVersion.Version.Minor)
                        {
                            case 0: return OSVersion.Windows_Vista;
                            case 1: return OSVersion.Windows_7;
                            default: return OSVersion.Windows_Vista_and_above;
                        }

                    }
                default: return OSVersion.Unknown;
            }
        }
	}

    
}


