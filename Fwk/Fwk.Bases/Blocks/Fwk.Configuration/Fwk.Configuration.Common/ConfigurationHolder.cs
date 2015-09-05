//using System;
//using System.Data;
//using System.Runtime.Remoting;
//using System.Runtime.Remoting.Lifetime;
//using System.Xml;
//using System.Text;
//using System.Collections;
//using System.Configuration;
//using Fwk.Bases.Properties;
//using Fwk.HelperFunctions;
//using System.Linq;

//namespace Fwk.Configuration.Common
//{


//    /// <summary>
//    /// Summary description for ConfigurationHolder.
//    /// </summary>
//    public class ConfigurationHolder : MarshalByRefObject
//    {

//        private ConfigurationRepository _ConfigData;

//        /// <summary>
//        /// Constructor por defecto
//        /// </summary>
//        public ConfigurationHolder()
//        {
//        }

//        /// <summary>
//        /// Redefinición de InitializeLifetimeService para configuración personalizada.
//        /// </summary>
//        /// <returns>Object</returns>
//        public override Object InitializeLifetimeService()
//        {
//            ILease wlease = (ILease)base.InitializeLifetimeService();

//            if (wlease.CurrentState == LeaseState.Initial)
//            {
//                //int wSecs = Convert.ToInt32(ConfigurationManager.DefaultProvider.LifeTime);


//                //wlease.InitialLeaseTime = TimeSpan.FromSeconds(wSecs);
//                //wlease.RenewOnCallTime = TimeSpan.FromSeconds(wSecs);
//            }

//            return wlease;

//        }


//        /// <summary>
//        /// Devuelve un grupo de un BaseConfigFile
//        /// </summary>
//        /// <param name="pBaseConfigFileName">Nombre del archivo</param>
//        /// <param name="pGroupName">Nombre del grupo</param>
//        /// <returns>Group</returns>
//        public Group GetGroup(string pBaseConfigFileName, string pGroupName)
//        {

//            ConfigurationFile wConfigurationFile = this.GetConfig(pBaseConfigFileName);

//            if (!wConfigurationFile.BaseConfigFile)
//            {
//                throw new Exception("El archivo solicitado no es un archivo de configuración válido.");
//            }

//            Group wGroup = wConfigurationFile.Groups.GetFirstByName(pGroupName);
//            if (wGroup != null)
//            {
//                throw new Exception(string.Concat(new String[] { "No se encuentra el grupo ", pGroupName, " en el archivo de configuración: ", pBaseConfigFileName }));
//            }
//            return wGroup;
//        }

//        /// <summary>
//        /// Devuelve una propidedad de un grupo de un BaseConfigFile
//        /// </summary>
//        /// <param name="pBaseConfigFileName">Nombre de archivo</param>
//        /// <param name="pGroupName">Nombre de grupo</param>
//        /// <param name="pPropertyName">Nombre de propiedad</param>
//        /// <returns>string</returns>
//        public string GetProperty(string pBaseConfigFileName, string pGroupName, string pPropertyName)
//        {
//            ConfigurationFile wConfigurationFile = this.GetConfig(pBaseConfigFileName);

//            if (!wConfigurationFile.BaseConfigFile)
//            {
//                throw new Exception("El archivo solicitado no es un archivo de configuración válido.");
//            }

//            Group wGroup = wConfigurationFile.Groups.GetFirstByName(pGroupName);
//            if (wGroup == null)
//            {
//                throw new Exception(string.Concat(new String[] { "No se encuentra el grupo ", pGroupName, " en el archivo de configuración: ", pBaseConfigFileName }));
//            }
//            Key wKey = wGroup.Keys.GetFirstByName(pPropertyName);
//            if (wKey == null)
//            {
//                throw new Exception(string.Concat(new String[] { "No se encuentra la propiedad ", pPropertyName, " en el grupo: ", pGroupName, " del archivo de configuración: ", pBaseConfigFileName }));
//            }

//            return wKey.Value.Text;

//        }


//        /// <summary>
//        /// Devuelve el contenido completo de un archivo de configuración
//        /// dado el nombre de archivo.
//        /// </summary>
//        /// <param name="pFileName">Nombre de archivo</param>
//        /// <returns>ConfigurationFile</returns>
//        public ConfigurationFile GetConfig(string pFileName)
//        {
//            string wFileContent = string.Empty;
//            bool wIsNewFile = false;

//            if (_ConfigData == null)
//            {
//                _ConfigData = new ConfigurationRepository();
//            }

//            ConfigurationFile wConfigurationFile = _ConfigData.GetConfigurationFile(pFileName);

//            if (wConfigurationFile == null)
//            {
//                wConfigurationFile = new ConfigurationFile();
//                wIsNewFile = true;
//            }

//            if (wConfigurationFile.CheckFileStatus() != Helper.FileStatus.Ok)
//            {
//                this.SetConfigurationFile(wConfigurationFile, pFileName);
//                if (wIsNewFile)
//                {
//                    _ConfigData.AddConfigurationFile(wConfigurationFile);
//                }
//            }
//            return wConfigurationFile;
//        }


//        /// <summary>
//        /// Compara version del archivo especificado para determinar
//        /// si es necesario actualizar.
//        /// </summary>
//        /// <param name="pFileName">Nombre de archivo</param>
//        /// <param name="pClientVersion">Version del archivo en el cliente</param>
//        /// <returns>FileStatus</returns>
//        public Helper.FileStatus GetFileVersionStatus(string pFileName, string pClientVersion)
//        {
//            ConfigurationWebService.ConfigurationService wService = new ConfigurationWebService.ConfigurationService();
//            Helper.FileStatus wStatus = (Helper.FileStatus)wService.GetFileVersionStatus(pFileName, pClientVersion);

//            wService.Dispose();
//            wService = null;

//            return wStatus;
//        }





//        /// <summary>
//        /// Configura un ConfigurationFile.
//        /// </summary>
//        /// <param name="pConfigurationFile">Objeto a configurar.</param>
//        /// <param name="pFileName">Nombre de archivo.</param>
//        public void SetConfigurationFile(ConfigurationFile pConfigurationFile, string pFileName)
//        {

//            //pConfigurationFile.Groups = Groups.GetFromXml<Groups>(InvokeService(pFileName));


//        }

//        /// <summary>
//        /// Invoca al web service de configuración.
//        /// </summary>
//        /// <param name="pFileName">Nombre de archivo.</param>
//        /// <returns>string</returns>
//        private string InvokeService(string pFileName)
//        {
//            ConfigurationWebService.ConfigurationService wService = new ConfigurationWebService.ConfigurationService();
//            string wResult = wService.GetConfig(pFileName);

//            wService.Dispose();
//            wService = null;

//            return wResult;
//        }

//    }
//}
