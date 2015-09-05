using System;
using Microsoft.Win32;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient; 
using System.Data; 
using System.Xml;
using System.Text ;
using Fwk.HelperFunctions;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Linq;
namespace Fwk.DataBase 
{
	/// <summary>
	/// Descripción breve de SetDataBase.
	/// </summary>
	internal class DataBaseServer
	{
	

		#region Miembros Privados


        private const string symmProvider = "CnnCryptProvider";
		private  SqlConnection _Cnn = new SqlConnection ();


        private CnnString _CurrentCnnString = null;

        public CnnString CurrentCnnString
        {
            get { return _CurrentCnnString; }
            set { _CurrentCnnString = value; }
        }
      

        public CnnStringList CnnStringList
        {
            get { return _DataBaseConnections.Connections; }
           
        }


        private DataBaseConnections _DataBaseConnections = new DataBaseConnections();
		

        private DataTable _SQLServerInfo = null;

        private int _ServerVersion = 0;

		
		#endregion

        /// <summary>
        /// Constructor que llama InitializeConfig(), el cual Permite leer nuevamente el archivo de configuracion 
        /// donde esta el acceso a la BD para recargar la coneccion.-
        /// </summary>
		private  DataBaseServer()
		{
           
			InitializeConfig();
			
		}
        /// <summary>
        /// Constructor que llama InitializeConfig(), el cual Permite leer nuevamente el archivo de configuracion 
        /// donde esta el acceso a la BD para recargar la coneccion.-
        /// </summary>
        public DataBaseServer(bool pInitializeConfig)
        {
            if (pInitializeConfig)
                InitializeConfig();

        }

        public CnnString CreateConnection()
        {

            _CurrentCnnString = new CnnString();

            _DataBaseConnections.Connections.Add(_CurrentCnnString);

            return _CurrentCnnString;
        }

		#region [Propiedades]


        public int ServerVersion
        {
            get
            {

                if (_SQLServerInfo == null)
                    SetServerInfo();

                if (_ServerVersion == 0)
                {
                    System.Data.DataRow[] oRows = _SQLServerInfo.Select("Name = 'FileVersion'");
                    _ServerVersion = Convert.ToInt32(oRows[0]["Character_Value"].ToString().Trim().Substring(0, 4));
                }

                return _ServerVersion;


            }

        }


        /// <summary>
        /// Cadena de coneccion actual
        /// </summary>
        public CnnString CnnString
        {
            get { return _CurrentCnnString; }
        }
		
        /// <summary>
        /// SqlConnection
        /// </summary>
		internal  SqlConnection Cnn
		{
			get { return _Cnn;}
		}

		#endregion

		#region TestConnection
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
		public System.Boolean TestConnection()
		{
			try
			{
				ConnectDatabase();
				
				return true;
			}
            catch (Exception ex)
            {
                throw new DataBaseExeption(ex, _CurrentCnnString);
            }
		}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pCnnString"></param>
        /// <returns></returns>
        public static bool TestConnection(CnnString pCnnString)
        {
            using (SqlConnection wCnn = new SqlConnection(pCnnString.ToString()))
            {
                try
                {

                    wCnn.Open();

                    wCnn.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    throw new DataBaseExeption(ex, pCnnString);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pServerName"></param>
        /// <param name="pUserName"></param>
        /// <param name="pPassword"></param>
        /// <param name="pWindowsAutChecked"></param>
        /// <returns></returns>
		public static bool TestConnection (string pServerName, string pUserName, string pPassword, bool pWindowsAutChecked)
		{
		    CnnString cnn = GetCnnStringToMaster(pServerName, pUserName, pPassword, pWindowsAutChecked);

            return TestConnection(cnn);
		}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pServerName"></param>
        /// <param name="pUserName"></param>
        /// <param name="pPassword"></param>
        /// <param name="pWindowsAutChecked"></param>
        /// <returns></returns>
        private static CnnString GetCnnStringToMaster(string pServerName, string pUserName, string pPassword, bool pWindowsAutChecked)
        {
            CnnString _CnnStringToMapper = new CnnString();
            _CnnStringToMapper.DataSource = pServerName;
            _CnnStringToMapper.InitialCatalog = "master";
            _CnnStringToMapper.User = pUserName;
            _CnnStringToMapper.Password = pPassword;
            _CnnStringToMapper.WindowsAutentification = pWindowsAutChecked;
            return _CnnStringToMapper;
        }

        private static CnnString GetCnnStringToMaster(CnnString pCnnString)
        {
            CnnString _CnnStringToTest = new CnnString();

            _CnnStringToTest.DataSource = pCnnString.DataSource;
            _CnnStringToTest.InitialCatalog = "master";
            _CnnStringToTest.User = pCnnString.User;
            _CnnStringToTest.Password = pCnnString.Password;
            _CnnStringToTest.WindowsAutentification = pCnnString.WindowsAutentification;
            return _CnnStringToTest;
        }


	    /// <summary>
		/// Permite leer nuevamente el archivo de configuracion donde esta el acceso a la BD para recargar la coneccion.-
		/// </summary>
		public  void InitializeConfig()
		{

            try
            {
                _DataBaseConnections.Load();
                if(_DataBaseConnections.Connections.Count > 0)
                    _CurrentCnnString = _DataBaseConnections.Connections[0];
               
            }

            catch (FileNotFoundException)
            {
                string msg = "No se encuentra el archivo de configuracion de base de datos:";
                throw new System.Exception(msg);
            }
            catch (System.Security.Cryptography.CryptographicException e)
            {

                _CurrentCnnString.Password = String.Empty;
                throw new DataBaseExeption(e, _CurrentCnnString);
            }
            catch (Exception)
            {
                string msg = "Verifique que el archivo de configuracion tiene seteado el archivo de conecciones a la base de datos.-";
                throw new System.Exception(msg);
            }
        
		}
			
		
		#endregion
		
		#region --[Save Settings]--

		

        /// <summary>
        /// Almacena la configuracion con los datos que se pasan como parametros.-
        /// </summary>
        /// <param name="pCnnString">Coneccion</param>
        ///<param name="pAppend">Agrega nuevo elemento</param>
        public bool SaveSetting(CnnString pCnnString)
		{
            bool isNew = false;
            if (_DataBaseConnections.Connections.Any<CnnString>(c => c.Name.Equals(pCnnString.Name, StringComparison.OrdinalIgnoreCase)))
            {
                //modifico la configuracion .-
                CnnString cnn = _DataBaseConnections.Connections.First<CnnString>(c => c.Name.Equals(pCnnString.Name, StringComparison.OrdinalIgnoreCase));

                if (cnn.Name != null)
                {
                    cnn.Password = pCnnString.Password;
                    cnn.DataSource = pCnnString.DataSource;
                    cnn.User = pCnnString.User;
                    cnn.WindowsAutentification = pCnnString.WindowsAutentification;
                    cnn.InitialCatalog = pCnnString.InitialCatalog;
                }
                isNew =false;
            }
            else
            {
                
                //Almaceno la configuracion .-
                _DataBaseConnections.Connections.Add(pCnnString);
                isNew = true;
            }



        
            _CurrentCnnString = pCnnString;
            _DataBaseConnections.Save();
            return isNew;
			
		}

		/// <summary>
		/// Almacena la configuracion cun los datos preceteados en el objeto DataBaseServer;
		/// </summary>
		/// <param name="pWindowsAutChecked">Determina si la configuracion debe alamacenartce en un App.config o en un archivo xml externo</param>
		public  void SaveSetting(bool pWindowsAutChecked)
		{
            _CurrentCnnString.WindowsAutentification = pWindowsAutChecked;
            _DataBaseConnections.Save();
            
			
		}

    
		#endregion

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
		public  DataTable GetDataBases()
		{
            CnnString cnn = GetCnnStringToMaster(_CurrentCnnString);
            using (SqlConnection wCnn = new SqlConnection(cnn.ToString()))
            using (SqlCommand wCmd = new SqlCommand())
            {
                try
                {

                    wCnn.Open();
                    wCmd.Connection = wCnn;
                    wCmd.CommandType = CommandType.StoredProcedure;
                    wCmd.CommandText = "sp_databases";

                    DataSet wDs = new DataSet();
                    SqlDataAdapter wDa = new SqlDataAdapter(wCmd);

                    wDa.Fill(wDs);
                    wCnn.Close();
                    return wDs.Tables[0];
                }
                catch (SqlException ex)
                {
                    throw ex;

                }
            }
		}



        public void ConnectDatabase()
        {
            InitializeConfig();
            using (SqlConnection wCnn = new SqlConnection(_CurrentCnnString.ToString()))
            {
                try
                {
                    wCnn.Open();
                    
                    wCnn.Close();
                }
                catch (SqlException e)
                {
                    throw e;
                }
            }
        }



        public void SetServerInfo()
        {

            using (SqlConnection wCnn = new SqlConnection(_CurrentCnnString.ToString()))
            using (SqlCommand wCmd = new SqlCommand())
            {
                try
                {
                    wCnn.Open();
                    wCmd.Connection = wCnn;
                    DataSet wDs = new DataSet();

                    wCmd.CommandType = CommandType.Text;
                    wCmd.CommandText = "exec master..xp_msver ";
                    SqlDataAdapter wDa = new SqlDataAdapter(wCmd);

                    wDa.Fill(wDs);
                    wCnn.Close();

                    _SQLServerInfo = wDs.Tables[0];

                    //--------------[Columns]--------
                    //ProductName
                    //ProductVersion
                    //Language
                    //Platform
                    //Comments
                    //CompanyName
                    //FileDescription
                    //FileVersion
                    //InternalName
                    //LegalCopyright
                    //LegalTrademarks
                    //OriginalFilename
                    //PrivateBuild
                    //SpecialBuild
                    //WindowsVersion
                    //ProcessorCount
                    //ProcessorActiveMask
                    //ProcessorType
                    //PhysicalMemory
                    //Product ID
                }
                catch (SqlException ex)
                {
                    throw ex;

                }
            }
        }

       
	}
}

