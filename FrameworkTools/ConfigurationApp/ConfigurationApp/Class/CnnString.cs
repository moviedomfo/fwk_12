//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Text;
//using ConfigurationApp.Common;
//namespace ConfigurationApp
//{
//    /// <summary>
//    /// Clase que reprecenta una conexión
//    /// Data Source=pcpde0369\SQLEXPRESS;Initial Catalog=Gastos;Integrated Security=True
//    /// Data Source=pcpde0369\SQLEXPRESS;Initial Catalog=Gastos;User ID=sa
//    /// </summary>
//    public class CnnString
//    {
//        private string _Name;
//        private Boolean _WindowsAutentification;
//        private string _DataSource;
//        private string _InitialCatalog;
//        private string _User;
//        private string _Password;

//        public CnnString()
//        {
            
//        }

//        public CnnString(String pName, String pConnectionString)
//        {
//            _Name = pName;
//            ParceCnnString(pConnectionString);
            
//        }
//        [Description("Establece si la conexión admitira autorización integrada (true) o no (false)")]
//        public bool WindowsAutentification
//        {
//            get { return _WindowsAutentification; }
//            set { _WindowsAutentification = value; }
//        }

//        [Description("Nombre de server de datos")]
//        public string DataSource
//        {
//            get { return _DataSource; }
//            set { _DataSource = value; }
//        }

//        [Description("Nombre usuario de sql server. Este atributo se setea solo en el caso de una conexión con seguridad de SQL Server")]
//        public string User
//        {
//            get { return _User; }
//            set { _User = value; }
//        }
//        [Description("Nombre de la base de datos")]
//        public string InitialCatalog
//        {
//            get { return _InitialCatalog; }
//            set { _InitialCatalog = value; }
//        }

//        [Description("Nombre de la cadena de conexión")]
//        public string Name
//        {
//            get { return _Name; }
//            set { _Name = value; }
//        }
//        [Description("Password de la cadena de conexión")]
//        public string Password
//        {
//            get { return _Password; }
//            set { _Password = value; }
//        }
        
//        /// <summary>
//        /// Retorna la cadena de conexión
//        /// </summary>
//        /// <returns></returns>
//        [Description("Retorna la cadena de conexión")]
//        public override string ToString()
//        {
           
//            StringBuilder str = new StringBuilder();

//            if (_WindowsAutentification)
//            {
//                str.Append(TemplateProvider.GetStandarsDataConfigurationValue("WindowsAutCnnString"));
//            }
//            else
//            {
//                str.Append(TemplateProvider.GetStandarsDataConfigurationValue("SQLWindowsAutCnnString"));
//                str.Replace("[User]", _User);
//                str.Replace("[Password]", _Password);
//            }
//            str.Replace("[ServerName]", _DataSource);
//            str.Replace("[DatabaseName]", _InitialCatalog);

           
//            return str.ToString();
//        }

//        /// <summary>
//        /// Setea los miembros de la clase desde una cadena de conexión
//        /// </summary>
//        /// <param name="connectionString"></param>
//        private void ParceCnnString(String pConnectionString)
//        {
            
//            List<string> list = new List<string>(pConnectionString.Split(';'));
//            _InitialCatalog = GetValue(list, "Initial Catalog");
//            if (_InitialCatalog.Length == 0)
//                _InitialCatalog = GetValue(list, "Database");

//            _DataSource = GetValue(list, "Data Source");
//            if (_DataSource.Length == 0)
//                _DataSource = GetValue(list, "Server");

//            _User = GetValue(list, "User ID");
//            if (_User.Length == 0)
//                _User = GetValue(list, "User");

//            _Password = GetValue(list, "Password");
//            if (_Password.Length == 0)
//                _Password = GetValue(list, "pwd");

//            String wIntegratedSecurity = GetValue(list, "Integrated Security");
//            if (wIntegratedSecurity.Trim().ToLower() == "true" || wIntegratedSecurity.Trim().ToLower() == "SSPI")
//                _WindowsAutentification = true;
//            else
//                _WindowsAutentification = false;





//        }


//        /// <summary>
//        /// Obtiene un valor o parametro de cadena de conexión 
//        /// Ej: Data Source=10.10.65.12\SQLEXPRESS;
//        /// Ej: Server = =10.10.65.12\SQLEXPRESS;
//        /// </summary>
//        /// <param name="pCnnStringList"></param>
//        /// <param name="pValueName"></param>
//        /// <returns></returns>
//        private string GetValue(List<string> pCnnStringList, String pValueName)
//        {
//            String[] val = null;
//            foreach (String s in pCnnStringList)
//            {
//                if (s.Contains(pValueName))
//                {
//                    val = s.Split('=');
//                    if (String.Equals (val[0].Trim().ToLower() , pValueName.Trim().ToLower())) 
//                       return val[1].Trim();
//                    else 
//                        return val[0].Trim();
//                }
//            }
//            return String.Empty;
//        }
//    }
//}
