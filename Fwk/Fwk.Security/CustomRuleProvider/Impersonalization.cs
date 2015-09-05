using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Principal;
using System.Runtime.InteropServices;

namespace Fwk.Security
{
    /// <summary>
    /// Perform windows context Impersonation
    /// </summary>
    internal class Impersonation
    {
        #region Definiciones WIN32


        public const int LOGON32_LOGON_INTERACTIVE = 2;
        public const int LOGON32_PROVIDER_DEFAULT = 0;



        [DllImport("advapi32.dll")]
        public static extern int LogonUserA(String lpszUserName, String lpszDomain, String lpszPassword, int dwLogonType, int dwLogonProvider, ref IntPtr phToken);

        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int DuplicateToken(IntPtr hToken, int impersonationLevel, ref IntPtr hNewToken);

        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool RevertToSelf();

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern bool CloseHandle(IntPtr handle);

        #endregion

        #region Propiedades

        string _UserName;
        string _Domain;
        string _Password;

        WindowsImpersonationContext impersonationContext;


        #endregion


        /// <summary>
        /// Constructor de la clase Impersonate
        /// Por defecto impersonaliza para realizar cambio de contraseña
        /// </summary>       
        /// <param name="userName">Dominio del usuario a impersonalizar</param>
        /// <param name="password">password</param>
        /// <param name="domain">Dominio ej Pelsoft</param>
        public Impersonation(string userName, string password, string domain)
        {

            _UserName = userName;
            _Password = password;
            _Domain = domain;



        }

        /// <summary>
        /// Lleva a cabo la impersonalizacion
        /// </summary>
        public void Impersonate()
        {
            // si no se introdujo ningun password nuevo,
            // se utiliza uno por defecto obtenido de la configuracion            

            WindowsIdentity tempWindowsIdentity;
            IntPtr token = IntPtr.Zero;
            IntPtr tokenDuplicate = IntPtr.Zero;
            try
            {
                if (RevertToSelf())
                {
                    if (LogonUserA(_UserName, _Domain, _Password, LOGON32_LOGON_INTERACTIVE, LOGON32_PROVIDER_DEFAULT, ref token) != 0)
                    {
                        if (DuplicateToken(token, 2, ref tokenDuplicate) != 0)
                        {
                            tempWindowsIdentity = new WindowsIdentity(tokenDuplicate);
                            impersonationContext = tempWindowsIdentity.Impersonate();
                            if (impersonationContext != null)
                            {
                                CloseHandle(token);
                                CloseHandle(tokenDuplicate);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Undo a la impersonalizacion
                UnImpersonate();
                // Ahora se encuentra activo el usuario anterior
                throw ex;
            }

            if (token != IntPtr.Zero)
                CloseHandle(token);
            if (tokenDuplicate != IntPtr.Zero)
                CloseHandle(tokenDuplicate);

        }

        
        /// <summary>
        /// Termina la sesion y retorna a la anterior
        /// </summary>
        public void UnImpersonate()
        {
            // Termina la session con el usuario impersonalizado y retorna al anterior
            if (impersonationContext != null)
                impersonationContext.Undo();

        }

    }
}
