using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.DirectoryServices;
using Fwk.Configuration;
using System.Runtime.InteropServices;
using System.Collections.Specialized;
using System.DirectoryServices.Protocols;
using System.DirectoryServices.ActiveDirectory;
using Fwk.Exceptions;
using System.DirectoryServices.AccountManagement;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using Microsoft.Win32.SafeHandles;
using System.Security;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
namespace Fwk.Security.ActiveDirectory
{
    /// <summary>
    /// Wrapper base de para interactuar con Servicios de Directorio
    /// 
    /// </summary>
    public class DirectoryServicesBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lpszUsername"></param>
        /// <param name="lpszDomain"></param>
        /// <param name="lpszPassword"></param>
        /// <param name="dwLogonType"></param>
        /// <param name="dwLogonProvider"></param>
        /// <param name="phToken"></param>
        /// <returns></returns>
        [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern bool LogonUser(String lpszUsername, String lpszDomain, String lpszPassword,
            int dwLogonType, int dwLogonProvider, out SafeTokenHandle phToken);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public extern static bool CloseHandle(IntPtr handle);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [DllImport("Kernel32.dll")]
        public static extern int GetLastError();

        #region Properties
        /// <summary>
        /// 
        /// </summary>
        protected DirectoryEntry _directoryEntrySearchRoot;
        /// <summary>
        /// 
        /// </summary>
        protected string _LDAPPath;
        /// <summary>
        /// Domain DC name
        /// </summary>
        protected string _LDAPDomain;
        /// <summary>
        /// 
        /// </summary>
        protected string _LDAPUser;
        /// <summary>
        /// 
        /// </summary>
        protected string _LDAPPassword;

        /// <summary>
        /// Domain name ej Pelsoft-ar
        /// </summary>
        protected string _LDAPDomainName;
        /// <summary>
        /// Domain name ej Pelsoft-ar
        /// </summary>
        public string LDAPDomainName
        {
            get { return _LDAPDomainName; }

        }
        /// <summary>
        ///Ej: 
        ///LDAP://domain/DC=xxx,DC=com
        ///LDAP://CORRSF71NT13.Datacom.org/DC=Datacom,DC=org
        ///LDAP://Pc1.alcoDatacom.com.ar/OU=Datacom Sabattini,dc=alcoDatacom,dc=com,dc=ar
        /// </summary>
        public String LDAPPath
        {
            get
            {
                return _LDAPPath;
            }

        }


        /// <summary>
        ///LDAPUser property
        /// </summary>
        public String LDAPUser
        {
            get
            {
                return _LDAPUser;
            }

        }

        /// <summary>
        /// LDAPPassword property
        ///This property is reading the LDAP Password from the config file.
        /// </summary>
        public String LDAPPassword
        {
            get
            {
                return _LDAPPassword;
            }

        }


        /// <summary>
        /// Dominio
        /// </summary>
        public String LDAPDomain
        {
            get
            {
                return _LDAPDomain;
            }

        }
        #endregion


        /// <summary>
        /// 
        /// </summary>
        /// <param name="memberOf"></param>
        /// <returns></returns>
        public static List<string> GetGroupFromMemberOf(string memberOf)
        {
            int i = 0;
            string[] propAux;
            List<String> list = new List<String>();
            foreach (string prop in memberOf.Split(','))
            {
                propAux = prop.Split('=');

                if (propAux[0].CompareTo("CN") == 0)
                {
                    list.Add(propAux[1]);
                    i++;
                }

            }
            return list;
        }

        /// <summary>
        /// Busca la lista de dominios en una base de datos
        /// </summary>
        /// <param name="cnnStringName">Nombre de la cadena de coneccion configurada</param>
        /// <returns>Lista de DomainsUrl</returns>
        public static List<DomainUrlInfo> DomainsUrl_GetList(string cnnStringName)
        {
            return DomainsUrl_GetList2(System.Configuration.ConfigurationManager.ConnectionStrings[cnnStringName].ConnectionString);
        }
        /// <summary>
        /// Busca la lista de dominios en una base de datos.- A diferencia de DomainsUrl_GetList. Este metodo recive como parametro 
        /// la cadena de coneccion y no su nombre de App.config
        /// </summary>
        /// <param name="cnnString">Cadena de coneccion</param>
        /// <returns>Lista de DomainsUrl</returns>
        public static List<DomainUrlInfo> DomainsUrl_GetList2(string cnnString)
        {
            
            List<DomainUrlInfo> wDomainUrlInfoList = new List<DomainUrlInfo>();
            try
            {
                using (SqlDomainURLDataContext dc = new SqlDomainURLDataContext(cnnString))
                {
                    IEnumerable<DomainUrlInfo> liste = from s in dc.DomainsUrls
                                                select new DomainUrlInfo
                                                    {
                                                        DomainName = s.DomainName,
                                                        LDAPPath = s.LDAPPath,
                                                        Id = s.DomainID,
                                                        SiteName = s.SiteName,
                                                        DomainDN = s.DomainDN
                                                    };

                    return liste.ToList<DomainUrlInfo>();
                }
            }
            catch (Exception ex)
            {
                Fwk.Exceptions.TechnicalException te = new Fwk.Exceptions.TechnicalException("Error al intentar obtener la lista de dominios desde la base de datos: ", ex);
                LDAPHelper.SetError(te);
                te.ErrorId = "15004";
                throw te;
            }
        }
        
        
        /// <summary>
        /// Retorna todos los DolmainUrl por medio de un sp usp_GetDomainsUrl_All que lee de bd encriptada
        /// </summary>
        /// <param name="cnnStringName">Nombre de la cadena de cnn</param>
        /// <returns></returns>
        public static List<DomainUrlInfo> DomainsUrl_Get_FromSp_all(string cnnStringName)
        {
            String wApplicationId = String.Empty;
            Database dataBase = null;
            DbCommand cmd = null;
            DomainUrlInfo wDomainUrlInfo = null;
            List<DomainUrlInfo> list = new List<DomainUrlInfo>();
            try
            {
                dataBase = DatabaseFactory.CreateDatabase(cnnStringName);
                cmd = dataBase.GetStoredProcCommand("dbo.usp_GetDomainsUrl_All");

                


                using (IDataReader dr = dataBase.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        wDomainUrlInfo = new DomainUrlInfo();
                        wDomainUrlInfo.DomainDN = dr["DomainDN"].ToString();
                        wDomainUrlInfo.DomainName = dr["DomainName"].ToString();

                        wDomainUrlInfo.LDAPPath = dr["LDAPPath"].ToString();

                        wDomainUrlInfo.Pwd = dr["Pwd"].ToString();
                        wDomainUrlInfo.SiteName = dr["SiteName"].ToString();
                        wDomainUrlInfo.Usr = dr["Usr"].ToString();
                        list.Add(wDomainUrlInfo);
                    }
                    
                }

                return list;


            }
            catch (Exception ex)
            {
                Fwk.Exceptions.TechnicalException te = new Fwk.Exceptions.TechnicalException("Error al intentar obtener los datos del dominio desde la base de datos: ", ex);
                LDAPHelper.SetError(te);
                te.ErrorId = "15004";
                throw te;
            }
        }
        /// <summary>
        /// Retorna DolmainUrl por medio de un sp usp_GetDomainsUrl_ByDomainName que lee de bd encriptada
        /// </summary>
        /// <param name="cnnStringName">Nombre de la cadena de cnn</param>
        /// <param name="domainName">ej Allus-Ar</param>
        /// <returns></returns>
        public static DomainUrlInfo DomainsUrl_Get_FromSp(string cnnStringName, string domainName)
        {
            String wApplicationId = String.Empty;
            Database dataBase = null;
            DbCommand cmd = null;
            DomainUrlInfo wDomainUrlInfo = null;
            try
            {
                dataBase = DatabaseFactory.CreateDatabase(cnnStringName);
                 cmd = dataBase.GetStoredProcCommand("dbo.usp_GetDomainsUrl_ByDomainName");

                // ApplicationName
                 dataBase.AddInParameter(cmd, "pDomainName", System.Data.DbType.String, domainName);



                using (IDataReader dr = dataBase.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        wDomainUrlInfo = new DomainUrlInfo();
                        wDomainUrlInfo.DomainDN = dr["DomainDN"].ToString();
                        wDomainUrlInfo.DomainName = dr["DomainName"].ToString();
              
                        wDomainUrlInfo.LDAPPath = dr["LDAPPath"].ToString();
                         
                        wDomainUrlInfo.Pwd = dr["Pwd"].ToString();
                        wDomainUrlInfo.SiteName = dr["SiteName"].ToString();
                        wDomainUrlInfo.Usr = dr["Usr"].ToString();
                    }
                }

                return wDomainUrlInfo;


            }
            catch (Exception ex)
            {
                Fwk.Exceptions.TechnicalException te = new Fwk.Exceptions.TechnicalException("Error al intentar obtener los datos del dominio desde la base de datos: ", ex);
                LDAPHelper.SetError(te);
                te.ErrorId = "15004";
                throw te;
            }
        }
        /// <summary>
        /// Establece los valores basicos de error producido en el componente ADWrapper
        /// </summary>
        /// <param name="te"></param>
        protected static void SetError(Fwk.Exceptions.TechnicalException te)
        {
            te.Namespace = typeof(ADWrapper).Namespace;
            te.Source = "Fwk active directory component";
            te.UserName = Environment.UserName;
            te.UserName = Environment.MachineName;
        }
    }
    /// <summary>
    /// Proporciona una clase base para implementaciones de identificadores Win32 seguros en las que el valor 0 ó -1 indica un identificador no válido.
    /// </summary>
    public sealed class SafeTokenHandle : SafeHandleZeroOrMinusOneIsInvalid
    {
        private SafeTokenHandle()
            : base(true)
        {
        }

        [DllImport("kernel32.dll")]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
        [SuppressUnmanagedCodeSecurity]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool CloseHandle(IntPtr handle);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override bool ReleaseHandle()
        {
            return CloseHandle(handle);
        }
    }
}
