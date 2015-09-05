using System;
using System.Collections.Generic;
using System.Text;

namespace Fwk.Bases
{
    /// <summary>
    /// Clase que expone atributos de configuracion utilizados por el framework.-
    /// </summary>
    public static class ConfigurationsHelper
    {
        private static string _HostApplicationName;

        /// <summary>
        /// Indica el nombre de la aplicacion que esta corriendo y utilizando el framework
        /// Ejemplo: Nombre de un servicio, nombre de sitio web, nombre de aplicacion de windows
        /// Este nombre lo utilizanlos componentes del framework para establecer el source u origen de 
        /// eventos lanzado por la aplicacion
        /// </summary>
        public static string HostApplicationName
        {
            get { return _HostApplicationName; }
            set { _HostApplicationName = value; }
        }

        ///// <summary>
        ///// Indica la configuracion del wrapper en el .config .-
        ///// </summary>
        //public static String WrapperSetting
        //{
        //    get { return Properties.Settings.Default.Wrapper; }
            
        //}


        
        ///// <summary>
        ///// Indica el nombre del archivo de remoting que utiliza el cliente en el .config .-
        ///// </summary>
        //public static String RemotingConfigFilePathSetting
        //{
        //    get { return Properties.Settings.Default.DispatcherRemotingConfigFilePath; }
            
        //}
        ///// <summary>
        ///// Indica direccion URL para conectarce a un servicio web que utiliza .-
        ///// </summary>
        //public static String WebServiceDispatcherUrlSetting
        //{
        //    get { return Properties.Settings.Default.WebServiceDispatcherUrl; }

        //}


        ///// <summary>
        ///// ServiceConfigurationFilePath
        ///// </summary>
        //public static String ServiceConfigurationSourceName
        //{
        //    get { return Properties.Settings.Default.ServiceConfigurationSourceName; }

        //}
        ///// <summary>
        ///// ServiceConfigurationManagerType
        ///// </summary>
        //public static String ServiceConfigurationManagerType
        //{
        //    get { return Properties.Settings.Default.ServiceConfigurationManagerType; }

        //}


        public static string ServiceDispatcherConnection { get; set; }

       
    }
}
