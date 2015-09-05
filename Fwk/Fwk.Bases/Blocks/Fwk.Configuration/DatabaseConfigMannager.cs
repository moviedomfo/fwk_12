using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Fwk.Configuration.Common;
using Fwk.Bases.Properties;
using Fwk.HelperFunctions;
using Fwk.Configuration;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using Fwk.ConfigSection;
using Fwk.Exceptions;

using Fwk.ConfigData;

namespace Fwk.Configuration
{
    /// <summary>
    /// Configuration manager con origen en base de datos SQL Server.-
    /// </summary>
    class DatabaseConfigManager
    {
        static ConfigurationRepository _Repository;


        static DatabaseConfigManager()
        {
            if (_Repository == null)
            {
                _Repository = new ConfigurationRepository();
            }
        }



        /// <summary>
        /// Obtiene una propiedad determinada de un archivo de configuracion .-
        /// </summary>
        /// <param name="configProvider">Proveedor de configuuracion</param>
        /// <param name="groupName">Nombre del grupo donde se encuentra la propiedad</param>
        /// <param name="propertyName">Nombre de la propiedad a obtener</param>
        /// <returns>String con la propiedad</returns>
        /// <Author>Marcelo Oviedo</Author>
        internal static string GetProperty(string configProvider, string groupName, string propertyName)
        {
            return GetProperty_FromDB(configProvider, groupName, propertyName);
            //ConfigProviderElement provider = ConfigurationManager.GetProvider(configProvider);

            //ConfigurationFile wConfigurationFile = GetConfig(provider, provider.SourceInfo);

            //Group wGroup = wConfigurationFile.Groups.GetFirstByName(pGroupName);
            //if (wGroup == null)
            //{

            //    TechnicalException te = new TechnicalException(string.Concat(new String[] { "No se encuentra el grupo ", pGroupName, " en el archivo de configuración: ", provider.BaseConfigFile }));
            //    te.ErrorId = "8006";
            //    Fwk.Exceptions.ExceptionHelper.SetTechnicalException(te, typeof(ConfigurationManager));
            //    throw te;
            //}
            //Key wKey = wGroup.Keys.GetFirstByName(propertyName);
            //if (wKey == null)
            //{
            //    TechnicalException te = new TechnicalException(string.Concat(new String[] { "No se encuentra la propiedad ", propertyName, " en el grupo de propiedades: ", pGroupName, " del archivo de configuración: ", provider.BaseConfigFile }));
            //    te.ErrorId = "8007";
            //    Fwk.Exceptions.ExceptionHelper.SetTechnicalException(te, typeof(ConfigurationManager));
            //    throw te;
            //}


            //return wKey.Value.Text;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="configProvider"></param>
        /// <param name="groupName"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        static string GetProperty_FromDB(string configProvider, string groupName, string propertyName)
        {
            ConfigProviderElement provider = ConfigurationManager.GetProvider(configProvider);
            if (System.Configuration.ConfigurationManager.ConnectionStrings[provider.SourceInfo] == null)
            {
                TechnicalException te = new TechnicalException(string.Concat("Problemas con Fwk.Configuration, no se puede encontrar la cadena de conexión: ", provider.SourceInfo));
                ExceptionHelper.SetTechnicalException<DatabaseConfigManager>(te);
                te.ErrorId = "8200";
                throw te;
            }
         
            try
            {
                using (FwkDatacontext dc = new FwkDatacontext(System.Configuration.ConfigurationManager.ConnectionStrings[provider.SourceInfo].ConnectionString))
                {
                    var val = dc.fwk_ConfigManagers.Where(config =>
                        config.ConfigurationFileName.ToLower().Equals(provider.BaseConfigFile.ToLower())  &&
                        config.group.ToLower().Equals(groupName.ToLower()) &&
                        config.key.ToLower().Equals(propertyName.ToLower())).FirstOrDefault();

                    if (val == null)
                    {
                        TechnicalException te = new TechnicalException(string.Concat(new String[] { "No se encuentra la propiedad ", propertyName, " en el grupo de propiedades: ", groupName, " del archivo de configuración: ", provider.BaseConfigFile }));
                        te.ErrorId = "8007";
                        Fwk.Exceptions.ExceptionHelper.SetTechnicalException(te, typeof(ConfigurationManager));
                        throw te;
                   }
                    return val.value;
                }
                
            }
            catch (Exception ex)
            {
                TechnicalException te = new TechnicalException("Problemas con Fwk.Configuration al realizar operaciones con la base de datos \r\n", ex);
                ExceptionHelper.SetTechnicalException<DatabaseConfigManager>(te);
                te.ErrorId = "8200";
                throw te;

            }

        }

        /// <summary>
        /// Obtiene un ConfigurationFile <see cref="ConfigurationFile" atravez de su nombre/>
        /// </summary>
        /// <param name="pFileName">Nombre del archivo xml con la configuracion</param>
        /// <param name="pCnnStringName">Nombre de cadena de coneccion.</param>
        /// <returns><see cref="ConfigurationFile"/></returns>
        /// <Author>Marcelo Oviedo</Author>
        internal static ConfigurationFile GetConfigurationFile(ConfigProviderElement provider)
        {
            return GetConfig(provider); 
        }


        /// <summary>
        /// Obtiene un grupo determinado en el archivo de configuracion
        /// </summary>
        /// <param name="configProvider">Proveedor de configuuracion</param>
        /// <param name="groupName">Nombre del grupo</param>
        /// <returns>Hashtable con los grupos contenidos en el archivo de configuracion</returns>
        /// <Author>Marcelo Oviedo</Author>
        internal static Group GetGroup(string configProvider, string groupName)
        {
            ConfigProviderElement provider = ConfigurationManager.GetProvider(configProvider);

            Group wGroup = null;
            try
            {
                
                using (FwkDatacontext dc = new FwkDatacontext(DatabaseConfigManager.GetCnnString(provider)))
                {
                    var properties_group = dc.fwk_ConfigManagers.Where(config =>
                       config.ConfigurationFileName.ToLower().Equals(provider.BaseConfigFile.ToLower()) &&
                       config.group.ToLower().Equals(groupName.ToLower())
                       );

                    if (properties_group == null)
                    {
                        TechnicalException te = new TechnicalException(string.Concat(new String[] { "No se encuentra el grupo ", groupName, " en el archivo de configuración: ", provider.BaseConfigFile }));
                        te.ErrorId = "8006";
                        Fwk.Exceptions.ExceptionHelper.SetTechnicalException(te, typeof(ConfigurationManager));
                        throw te;
                    }
                    wGroup = new Group();
                    wGroup.Keys = new Keys();
                    Key wKey = new Key();

                    foreach (var item in properties_group)
                    {
                        wKey = new Key();
                        wKey.Name = item.key;
                        wKey.Value.Text = item.value;
                        wKey.Encrypted = item.encrypted;
                        wGroup.Keys.Add(wKey);
                    }
                }
            }
            catch (Exception ex)
            {
                TechnicalException te = new TechnicalException("Problemas con Fwk.Configuration al realizar operaciones con la base de datos \r\n", ex);
                ExceptionHelper.SetTechnicalException<DatabaseConfigManager>(te);
                te.ErrorId = "8200";
                throw te;

            }
          


            return wGroup;
        }

        static string GetCnnString(ConfigProviderElement provider)
        {
            
            if (provider.SourceInfoIsConnectionString)
            {
                return  provider.SourceInfo;
            }
            else
            {
                if (System.Configuration.ConfigurationManager.ConnectionStrings[provider.SourceInfo] == null)
                {
                    TechnicalException te = new TechnicalException(string.Concat("Problemas con Fwk.Configuration, no se puede encontrar la cadena de conexión: ", provider.SourceInfo));
                    ExceptionHelper.SetTechnicalException<DatabaseConfigManager>(te);
                    te.ErrorId = "8200";
                    throw te;
                }
                return  System.Configuration.ConfigurationManager.ConnectionStrings[provider.SourceInfo].ConnectionString;
            }
            
        }
        #region [Private members]




        /// <summary>
        /// Devuelve el contenido completo de un archivo de configuración
        /// dado el nombre de archivo.
        /// </summary>
        /// <param name="provider">provider</param>
        /// <returns><see cref="ConfigurationFile"/></returns>
        /// <Author>Marcelo Oviedo</Author>
        static ConfigurationFile GetConfig(ConfigProviderElement provider)
        {
            ConfigurationFile wConfigurationFile = GetFromDatabase(provider.BaseConfigFile, provider);

            return wConfigurationFile;

        }

        /// <summary>
        /// Busca en la base de datos el archivo de configuracion
        /// </summary>
        /// <param name="pFileName">Nombre de archivo.</param>
        /// <param name="provider">provider</param>
        /// <Author>Marcelo Oviedo</Author>
        static ConfigurationFile GetFromDatabase(string pFileName, ConfigProviderElement provider)
        {

            ConfigurationFile wConfigurationFile = new ConfigurationFile();
            wConfigurationFile.Groups = new Groups();
            string groupAuxiliar = string.Empty;
            Group g = null;
            Key k = null;
            wConfigurationFile.FileName = pFileName;

            try
            {
                using (FwkDatacontext dc = new FwkDatacontext(GetCnnString(provider)))
                {

                    IEnumerable<fwk_ConfigManager> fwk_ConfigManagerList = from s in dc.fwk_ConfigManagers
                                                                             where s.ConfigurationFileName.Equals(pFileName)

                                                                             select s;

                    foreach (fwk_ConfigManager fwk_Config in fwk_ConfigManagerList.OrderBy(p => p.group))
                    {
                        if (!groupAuxiliar.Equals(fwk_Config.group))
                        {
                            groupAuxiliar = Convert.ToString(fwk_Config.group);
                            g = new Group();
                            g.Name = groupAuxiliar;
                            wConfigurationFile.Groups.Add(g);
                        }

                        k = new Key();
                        k.Encrypted = fwk_Config.encrypted;
                        k.Name = fwk_Config.key;
                        k.Value.Text = fwk_Config.value;

                        g.Keys.Add(k);
                    }

                }
            }
            catch (Exception ex)
            {
                TechnicalException te = new TechnicalException("Problemas con Fwk.Configuration al realizar operaciones con la base de datos \r\n", ex);
                ExceptionHelper.SetTechnicalException<DatabaseConfigManager>(te);
                te.ErrorId = "8200";
                throw te;
            }

            return wConfigurationFile;
        }


        /// <summary>
        /// Busca en la base de datos el archivo de configuracion
        /// </summary>
        /// <param name="groupName"></param>
        /// <param name="keyName"></param>
        /// <param name="destinationProvider">Provedor destino</param>
        /// <Author>Marcelo Oviedo</Author>
        static bool ExistProperty(string groupName,string keyName, ConfigProviderElement destinationProvider)
        {
            try
            {
                using (FwkDatacontext dc = new FwkDatacontext(GetCnnString(destinationProvider)))
                {

                      var properties = dc.fwk_ConfigManagers.Where(config =>
                       config.ConfigurationFileName.ToLower().Equals(destinationProvider.BaseConfigFile.ToLower())
                       &&         config.group.ToLower().Equals(groupName.ToLower())
                       && config.key.ToLower().Equals(keyName.ToLower())
                       );

                      return properties.Any();
                }
            }
            catch (Exception ex)
            {
                TechnicalException te = new TechnicalException("Problemas con Fwk.Configuration al realizar operaciones con la base de datos \r\n", ex);
                ExceptionHelper.SetTechnicalException<DatabaseConfigManager>(te);
                te.ErrorId = "8200";
                throw te;
            }

            
        }

        #endregion

        /// <summary>
        ///Si grupo no existe en un provider p/bd es por que seguramente se agrego el grupo por la aplicacion del fwk y ahun este grupo se encuentra vasio.
        ///y no es posible agregar grupos vasios ya que los grupos tienen que tener al menos una propiedad para ser agregados a la tabla
        /// </summary>
        /// <param name="provider">Proveedor de configuracion</param>
        /// <param name="key"></param>
        /// <param name="groupName">Nombre del gruop que contiene las propiedades</param>
        internal static void AddProperty(ConfigProviderElement provider, Key key, string groupName)
        {
            
            System.Text.StringBuilder sqlCommand = new StringBuilder();

            ConfigurationFile wConfigurationFile = GetConfig(provider); 
            Group wGroup = wConfigurationFile.Groups.GetFirstByName(groupName);

            //Si grupo no existe en un provider p/bd es por que seguramente se agrego el grupo por la aplicacion del fwk y ahun este grupo se encuentra vasio.
            //y no es posible agregar grupos vasios ya que los grupos tienen que tener al menos una propiedad para ser agregados a la tabla
            if (wGroup == null)
            {
                wGroup = new Group();
                wGroup.Keys = new Keys();
                wGroup.Name=groupName;
                AddGroup(provider, wGroup);
            }
            wGroup.Keys.Add(key);



            fwk_ConfigManager confg;
            try
            {
                using (FwkDatacontext dc = new FwkDatacontext(GetCnnString(provider)))
                {

                    confg = new fwk_ConfigManager();
                    confg.ConfigurationFileName = provider.BaseConfigFile;
                    confg.key = key.Name;
                    confg.encrypted = key.Encrypted;
                    confg.value = key.Value.Text;
                    confg.group = groupName;

                    dc.fwk_ConfigManagers.InsertOnSubmit(confg);


                    dc.SubmitChanges();
                }

            }
            catch (Exception ex)
            {
                TechnicalException te = new TechnicalException("Problemas con Fwk.Configuration al realizar operaciones con la base de datos \r\n", ex);
                ExceptionHelper.SetTechnicalException<DatabaseConfigManager>(te);
                te.ErrorId = "8200";
                throw te;

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="provider">Proveedor de configuracion</param>
        /// <param name="group">Grupo</param>
        internal static void AddGroup(ConfigProviderElement provider, Group group)
        {
            
            ConfigurationFile wConfigurationFile = GetConfig(provider);


            wConfigurationFile.Groups.Add(group);
            fwk_ConfigManager confg;

            try
            {
                using (FwkDatacontext dc = new FwkDatacontext(GetCnnString(provider)))
                {
                    foreach (Key k in group.Keys)
                    {
                        confg = new fwk_ConfigManager();
                        confg.ConfigurationFileName = provider.BaseConfigFile;
                        confg.key = k.Name;
                        confg.encrypted = k.Encrypted;
                        confg.value = k.Value.Text;
                        confg.group = group.Name;
                        dc.fwk_ConfigManagers.InsertOnSubmit(confg);

                    }
                    dc.SubmitChanges();
                }

            }
            catch (Exception ex)
            {
                TechnicalException te = new TechnicalException("Problemas con Fwk.Configuration al realizar operaciones con la base de datos \r\n", ex);
                ExceptionHelper.SetTechnicalException<DatabaseConfigManager>(te);
                te.ErrorId = "8200";
                throw te;
            }
        }



        /// <summary>
        /// Elimina una porpiedad de la cinfuguracion
        /// </summary>
        /// <param name="provider">Proveedor de configuracion</param>
        /// <param name="groupName">Gupo al que pertenece la propiedad</param>
        /// <param name="propertyName">Nombre de la propiedad</param>
        internal static void RemoveProperty(ConfigProviderElement provider, string groupName, string propertyName)
        {
            ConfigurationFile wConfigurationFile = GetConfig(provider); //_Repository.GetConfigurationFile(provider.BaseConfigFile);
            Group g = wConfigurationFile.Groups.GetFirstByName(groupName);
            Key k = g.Keys.GetFirstByName(propertyName);
            g.Keys.Remove(k);
            System.Text.StringBuilder sqlCommand = new StringBuilder("Delete from [fwk_ConfigManager] where ");
            sqlCommand.AppendLine(string.Concat("ConfigurationFileName = '", provider.BaseConfigFile, "'"));
            sqlCommand.AppendLine(string.Concat("and [group] = '", groupName, "'"));
            sqlCommand.AppendLine(string.Concat("and [key] = '", propertyName, "'"));
            //if (!String.IsNullOrEmpty( provider.ApplicationId))
            //    sqlCommand.AppendLine(string.Concat("and AppId = '", provider.ApplicationId, "'"));


            EexeSqlCommand(sqlCommand.ToString(), provider.SourceInfo);
        }

        /// <summary>
        /// Elimina un grupo de la configuracion
        /// </summary>
        /// <param name="provider">Proveedor de configuracion</param>
        /// <param name="groupName">Nombre del grupo a eliminar</param>
        internal static void RemoveGroup(ConfigProviderElement provider, string groupName)
        {

            ConfigurationFile wConfigurationFile = GetConfig(provider);
            Group g = wConfigurationFile.Groups.GetFirstByName(groupName);

            wConfigurationFile.Groups.Remove(g);



            System.Text.StringBuilder sqlCommand = new StringBuilder("Delete from [fwk_ConfigManager] where ");
            sqlCommand.AppendLine(string.Concat("ConfigurationFileName = '", provider.BaseConfigFile, "'"));
            sqlCommand.AppendLine(string.Concat("and [group] = '", groupName, "'"));

            //if (!String.IsNullOrEmpty(provider.ApplicationId))
            //    sqlCommand.AppendLine(string.Concat("and AppId = '", provider.ApplicationId, "'"));

            EexeSqlCommand(sqlCommand.ToString(), provider.SourceInfo);
        }


        static void EexeSqlCommand(string sqlCommand, string cnnStringName)
        {
            if (System.Configuration.ConfigurationManager.ConnectionStrings[cnnStringName] == null)
            {
                TechnicalException te = new TechnicalException(string.Concat("Problemas con Fwk.Configuration, no se puede encontrar la cadena de conexión: ", cnnStringName));
                ExceptionHelper.SetTechnicalException<DatabaseConfigManager>(te);
                te.ErrorId = "8200";
                throw te;
            }

            Database wDataBase = null;
            DbCommand wCmd = null;
            try
            {
                wDataBase = DatabaseFactory.CreateDatabase(cnnStringName);


                wCmd = wDataBase.GetSqlStringCommand(sqlCommand);
                wCmd.CommandType = CommandType.Text;

                wDataBase.ExecuteNonQuery(wCmd);
            }
            catch (Exception ex)
            {
                TechnicalException te = new TechnicalException("Problemas con Fwk.Configuration al realizar operaciones con la base de datos \r\n", ex);
                ExceptionHelper.SetTechnicalException<DatabaseConfigManager>(te);
                te.ErrorId = "8200";
                throw te;
            }

        }

        /// <summary>
        /// Cambia el nombre de un grupo.-
        /// </summary>
        /// <param name="provider">Proveedor de configuracion</param>
        /// <param name="groupName">Nombre del grupo</param>
        /// <param name="newGroupName">Nuevo nombre del grupo</param>
        internal static void ChangeGroupName(ConfigProviderElement provider, string groupName, string newGroupName)
        {
            //ConfigurationFile wConfigurationFile = GetConfig(provider);
            try
            {
                using (FwkDatacontext dc = new FwkDatacontext(GetCnnString(provider)))
                {
                    var configs = dc.fwk_ConfigManagers.Where(p =>
                          p.group.Equals(groupName)
                          && p.ConfigurationFileName.Equals(provider.BaseConfigFile));

                    foreach (fwk_ConfigManager confg in configs)
                    {
                        confg.group = newGroupName;
                    }
                    dc.SubmitChanges();
                }


            }
            catch (Exception ex)
            {
                TechnicalException te = new TechnicalException("Problemas con Fwk.Configuration al realizar operaciones con la base de datos \r\n", ex);
                ExceptionHelper.SetTechnicalException<DatabaseConfigManager>(te);
                te.ErrorId = "8200";
                throw te;

            }
        }

        /// <summary>
        /// Realiza cambios a una propiedad.-
        /// </summary>
        /// <param name="provider">Proveedor de configuracion</param>
        /// <param name="groupName">Nombre del grupo donde se encuentra la propiedad</param>
        /// <param name="property">Propiedad actualizada. Este objeto puede contener todos sus valores modifcados</param>
        /// <param name="propertyName">Nombre de la propiedad que se mofdifico.- Este valor es el original sin modificacion</param>
        internal static void ChangeProperty(ConfigProviderElement provider, string groupName, Key property, string propertyName)
        {

            try
            {
                using (FwkDatacontext dc = new FwkDatacontext(GetCnnString(provider)))
                {

                    var prop = dc.fwk_ConfigManagers.Where(config =>
                               config.ConfigurationFileName.ToLower().Equals(provider.BaseConfigFile.ToLower())
                               && config.group.ToLower().Equals(groupName.ToLower())
                               && config.key.ToLower().Equals(propertyName.ToLower())
                   ).FirstOrDefault<fwk_ConfigManager>();
                    prop.value = property.Value.Text;
                    prop.encrypted = property.Encrypted;
                    prop.key = property.Name;
                    dc.SubmitChanges();
                }

            }
            catch (Exception ex)
            {
                TechnicalException te = new TechnicalException("Problemas con Fwk.Configuration al realizar operaciones con la base de datos \r\n", ex);
                ExceptionHelper.SetTechnicalException<DatabaseConfigManager>(te);
                te.ErrorId = "8200";
                throw te;

            }
        }


        /// <summary>
        /// Vuelve a cargar el archivo de configuracion desde el origen de datos
        /// </summary>
        /// <param name="provider">Proveedor de configuracion</param>
        /// <returns></returns>
        internal static ConfigurationFile RefreshConfigurationFile(ConfigProviderElement provider)
        {
            ConfigurationFile wConfigurationFile = _Repository.GetConfigurationFile(provider.Name);
            if (wConfigurationFile != null)
            {
                _Repository.RemoveConfigurationFile(wConfigurationFile);
                wConfigurationFile = null;
            }

            wConfigurationFile = GetFromDatabase(provider.BaseConfigFile, provider);
            _Repository.AddConfigurationFile(wConfigurationFile);

            return wConfigurationFile;
        }


        internal static void Import(ConfigProviderElement provider, ConfigurationFile sourceConfigurationFile)
        {
            foreach (Group wGrp in sourceConfigurationFile.Groups)
            {
                foreach (Fwk.Configuration.Common.Key wKey in wGrp.Keys)
                {
                    if (ExistProperty(wGrp.Name, wKey.Name, provider))
                    {
                        ChangeProperty(provider,wGrp.Name,wKey,wKey.Name);
                    }
                    else
                    {
                    AddProperty(provider, wKey, wGrp.Name);
                    }
                    
                }
            }
        }
    }
}
