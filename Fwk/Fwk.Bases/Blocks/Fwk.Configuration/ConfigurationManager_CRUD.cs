using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.ConfigSection;
using Fwk.Configuration.Common;

namespace Fwk.Configuration
{

    /// <summary>
    /// Esta clase fue tiene como objetivo realizar todo tipo de operaciones transaccionales coon los objetos ConfiguracionFile de configuracion
    /// Dependiendo del tipo de proveedor de configucracion realizara operaciones de IO o DataBase
    /// </summary>
    public class ConfigurationManager_CRUD
    {

        /// <summary>
        /// Agrega una nueva propiedad
        /// </summary>
        /// <param name="configProvider">Proveedor de configuracion</param>
        /// <param name="groupName">Nombre del gruop que contiene las propiedades</param>
        /// <param name="property"></param>
        public static void AddProperty(string configProvider,string groupName, Key property)
        {
            ConfigurationManager.AddProperty(configProvider, groupName, property);
            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="configProvider">Proveedor de configuracion</param>
        /// <param name="propertyName">Nombre de la propiedad o key.name</param>
        /// <param name="groupName">Nombre del gruop que contiene las propiedades</param>
        public static void RemoveProperty(string configProvider,  string groupName,string propertyName)
        {
            ConfigurationManager.RemoveProperty(configProvider, groupName, propertyName);

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="configProvider">Proveedor de configuracion</param>
        /// <param name="group"></param>
        public static void AddGroup(string configProvider, Group group)
        {
            ConfigurationManager.AddGroup(configProvider,  group);
        }

 
        /// <summary>
        /// Elimina un grupo compoleto de la configuracion
        /// </summary>
        /// <param name="configProvider">Proveedor de configuracion</param>
        /// <param name="groupName">Nombre del grupo</param>
        public static void RemoveGroup(string configProvider, string groupName)
        {
            ConfigurationManager.RemoveGroup(configProvider, groupName);
        }

        /// <summary>
        /// Cambia el nombre de un grupo.-
        /// </summary>
        /// <param name="configProvider">Proveedor de configuracion</param>
        /// <param name="groupName">Nombre del grupo</param>
        /// <param name="newGroupName">Nuevo nombre del grupo</param>
        public static void ChangeGroupName(string configProvider, string groupName, string newGroupName)
        {
            ConfigurationManager.ChangeGroupName(configProvider, groupName, newGroupName);
        }

        /// <summary>
        /// Realiza cambios a una propiedad.-
        /// </summary>
        /// <param name="configProvider">Nombre del proveedor de configuracion</param>
        /// <param name="groupName">Nombre del grupo donde se encuentra la propiedad</param>
        /// <param name="property">Propiedad actualizada. Este objeto puede contener todos sus valores modifcados</param>
        /// <param name="propertyName">Nombre de la propiedad que se mofdifico.- Este valor es el original sin modificacion</param>
        public static void ChangeProperty(string configProvider, string groupName, Key property, string propertyName)
        {
            ConfigurationManager.ChangeProperty(configProvider, groupName, property, propertyName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sourceConfigurationFile"></param>
        /// <param name="provider"></param>
        public static void Import(ConfigurationFile sourceConfigurationFile,ConfigProviderElement provider)
        {
            ConfigurationManager.Import(sourceConfigurationFile, provider);
        }
    }
}
