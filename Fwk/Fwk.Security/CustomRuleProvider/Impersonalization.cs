using System;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Security.Permissions;
using Microsoft.Win32.SafeHandles;
using System.Runtime.ConstrainedExecution;
using System.Security;
using Fwk.Security.ActiveDirectory;

namespace Fwk.Security
{
    /// <summary>
    /// Perform windows context Impersonation
    /// </summary>
    public class Impersonation_2
    {
        #region Definiciones WIN32

        const int LOGON32_PROVIDER_DEFAULT = 0;
        //This parameter causes LogonUser to create a primary token.
        const int LOGON32_LOGON_INTERACTIVE = 2;

   [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
    public static extern bool LogonUser(String lpszUsername, String lpszDomain, String lpszPassword,
        int dwLogonType, int dwLogonProvider, out SafeTokenHandle phToken);

    [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
    public extern static bool CloseHandle(IntPtr handle);

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
        public Impersonation_2(string userName, string password, string domain)
        {

            _UserName = userName;
            _Password = password;
            _Domain = domain;



        } 
        SafeTokenHandle safeTokenHandle;

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
                // Call LogonUser to obtain a handle to an access token.
                bool returnValue = LogonUser(_UserName, _Domain, _Password,
                    LOGON32_LOGON_INTERACTIVE, LOGON32_PROVIDER_DEFAULT,
                    out safeTokenHandle);

                if (false == returnValue)
                {
                    int ret = Marshal.GetLastWin32Error();
                    throw new Fwk.Exceptions.TechnicalException(String.Format("Fwk Impersonate Error :LogonUser failed with error code : {0}", ret));
                }
                //using (safeTokenHandle)
                //{
                //    Console.WriteLine("Did LogonUser Succeed? " + (returnValue ? "Yes" : "No"));
                //    Console.WriteLine("Value of Windows NT token: " + safeTokenHandle);

                //    // Check the identity.
                //    Console.WriteLine("Before impersonation: "   + WindowsIdentity.GetCurrent().Name);
                //    // Use the token handle returned by LogonUser.
                //    using (WindowsIdentity newId = new WindowsIdentity(safeTokenHandle.DangerousGetHandle()))
                //    {
                //        using (WindowsImpersonationContext impersonatedUser = newId.Impersonate())
                //        {

                //            // Check the identity.
                //            Console.WriteLine("After impersonation: "   + WindowsIdentity.GetCurrent().Name);
                //        }
                //    }
                //    // Releasing the context object stops the impersonation
                //    // Check the identity.
                //    Console.WriteLine("After closing the context: " + WindowsIdentity.GetCurrent().Name);
                //}
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
    /// <summary>
    /// Perform windows context Impersonation
    /// </summary>
    public class Impersonation
    {
        #region Definiciones WIN32


        public const int LOGON32_LOGON_INTERACTIVE = 2;
        public const int LOGON32_PROVIDER_DEFAULT = 0;



        [DllImport("advapi32.dll")]
        public static extern int LogonUserA(String lpszUserName, String lpszDomain, String lpszPassword, int dwLogonType, int dwLogonProvider, ref IntPtr phToken);

        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int DuplicateToken(IntPtr hToken, int impersonationLevel, ref IntPtr hNewToken);
        //[DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        //public extern static bool DuplicateToken(IntPtr ExistingTokenHandle,           int SECURITY_IMPERSONATION_LEVEL, ref IntPtr DuplicateTokenHandle);
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
