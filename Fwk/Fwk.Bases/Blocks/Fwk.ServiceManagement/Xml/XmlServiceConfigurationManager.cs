using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Fwk.HelperFunctions;
using Fwk.Transaction;
using Fwk.Xml;
//using Fwk.ServiceManagement.Xml;
using Fwk.Bases;
using Fwk.Exceptions;

namespace Fwk.ServiceManagement
{
    /// <summary>
    /// Manejador de configuración de servicios que trabaja con un archivo XML como repositorio de configuración.
    /// </summary>
    /// <date>2008-04-07T00:00:00</date>
    /// <author>moviedo</author>
     sealed class XmlServiceConfigurationManager
    {
        #region < IServiceConfiguration Members >

        /// <summary>
        /// Busca el archivo BPConfig y lo carga a _Services que es un ServiceConfigurationCollection
        /// </summary>
        /// <returns></returns>
        /// <date>2007-07-13T00:00:00</date>
        /// <author>moviedo</author>
        internal static ServiceConfigurationCollection GetAllServices(string xmlConfigFile)
        {

            return LoadAllServices(xmlConfigFile);

        }

        /// <summary>
        /// Busca el archivo  lo carga a _Services que es un ServiceConfigurationCollection
        /// </summary>
        ///<param name="xmlConfigFile"></param>
        /// <returns></returns>
        /// <date>2007-07-13T00:00:00</date>
        /// <author>moviedo</author>
        static ServiceConfigurationCollection LoadAllServices(string xmlConfigFile)
        {

            try
            {
                if (!System.IO.File.Exists(xmlConfigFile))
                
                {
                    //Application.StartupPath
                    xmlConfigFile = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), xmlConfigFile);
                }

                String xml = FileFunctions.OpenTextFile(xmlConfigFile);
                return (ServiceConfigurationCollection)SerializationFunctions.DeserializeFromXml(typeof(ServiceConfigurationCollection), xml);

            }
            catch (System.IO.IOException ioex)
            {

                TechnicalException te = new TechnicalException(Fwk.Bases.Properties.Resources.ServiceManagement_SourceInfo_Error, ioex);
                if (string.IsNullOrEmpty(ConfigurationsHelper.HostApplicationName))
                    te.Source = string.Concat("Despachador de servicios en ", Environment.MachineName);
                else
                    te.Source = ConfigurationsHelper.HostApplicationName;

                te.ErrorId = "7004";
                te.Assembly = typeof(XmlServiceConfigurationManager).AssemblyQualifiedName;
                te.Class = typeof(XmlServiceConfigurationManager).Name;
                te.Namespace = typeof(XmlServiceConfigurationManager).Namespace;
                throw te;


            }
            catch (TechnicalException te)
            {
                throw te;
            }
            catch (Exception ex)
            {
                string strError = string.Concat("Error al inicializar la metadata de los servicios  \r\n ",
                "Nombre de archivo :", xmlConfigFile, Environment.NewLine);

                Fwk.Exceptions.TechnicalException te = new Fwk.Exceptions.TechnicalException(strError, ex);

                if (string.IsNullOrEmpty(ConfigurationsHelper.HostApplicationName))
                    te.Source = string.Concat("Despachador de servicios en ", Environment.MachineName);
                else
                    te.Source = ConfigurationsHelper.HostApplicationName;
                te.ErrorId = "7004";
                te.Assembly = typeof(XmlServiceConfigurationManager).AssemblyQualifiedName;
                te.Class = typeof(XmlServiceConfigurationManager).Name;
                te.Namespace = typeof(XmlServiceConfigurationManager).Namespace;
                throw te;
            }
        }




        /// <summary>
        /// Guarda los cambios en el archivo
        /// </summary>
        /// <param name="xmlConfigFile">Nombre del archivo que contiene la metadata.</param>
        /// <param name="services">Repositorio de servicios enmemoria.</param>
        internal static void SetServiceConfiguration(string xmlConfigFile, ServiceConfigurationCollection services)
        {

            SaveServiceConfigFile(xmlConfigFile, services);
          
        }

        /// <summary>
        /// Almacena la configuración de un nuevo servicio de negocio.
        /// </summary>
        /// <param name="pServiceConfiguration">configuración del servicio de negocio.</param>
        /// <param name="xmlConfigFile">Nombre del archivo que contiene la metadata.</param>
        /// <param name="services"></param>
        internal static void AddServiceConfiguration(ServiceConfiguration pServiceConfiguration, string xmlConfigFile, ServiceConfigurationCollection services)
        {
            SaveServiceConfigFile(xmlConfigFile, services);
        }

        /// <summary>
        /// Elimina la configuración de un servicio de negocio.
        /// </summary>
        /// <param name="xmlConfigFile">Nombre del archivo que contiene la metadata.</param>
        /// <param name="services">Repositorio de servicios enmemoria.</param>
        /// <date>2010-08-11T00:00:00</date>
        /// <author>moviedo</author>
        internal static void DeleteServiceConfiguration(string xmlConfigFile, ServiceConfigurationCollection services)
        {
            SaveServiceConfigFile(xmlConfigFile, services);
        }

        #endregion

        #region < Private methods >





        /// <summary>
        /// Guarda los cambios en el archivo
        /// </summary>
        /// <param name="xmlConfigFile">Nombre del archivo que contiene la metadata.</param>
        /// <param name="services">Repositorio de servicios enmemoria.</param>
        static void SaveServiceConfigFile(string xmlConfigFile, ServiceConfigurationCollection services)
        {
            String xml = SerializationFunctions.SerializeToXml(services);
            try
            {
                HelperFunctions.FileFunctions.SaveTextFile(xmlConfigFile, xml, false);
            }

            catch (System.UnauthorizedAccessException)
            {

                TechnicalException te = new TechnicalException(string.Concat("No tiene permiso para actualizar el archivo ", xmlConfigFile));
                te.ErrorId = "7100";
                Fwk.Exceptions.ExceptionHelper.SetTechnicalException<XmlServiceConfigurationManager>(te);
                throw te;
            }

        }
        #endregion







    }
}
