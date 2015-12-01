using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using Fwk.Params.BE;
using System.Globalization;

namespace ParamsManager
{
    internal class MultilanguageDAC
    {
        internal static string cnnStringName = "bb";
        internal static string cnnString = string.Empty;
        static MultilanguageDAC()
        {
            DatabaseFactory.SetDatabaseProviderFactory(new DatabaseProviderFactory(), false);
            cnnString = System.Configuration.ConfigurationManager.ConnectionStrings[cnnStringName].ConnectionString;
        }
        internal static List<fwk_Param> Params_Retrive()
        {
            List<fwk_Param> list2 = new List<fwk_Param>();
            fwk_Param param = null;
            var list = Fwk.Params.Back.ParamDAC.RetriveByParams(null, null, String.Empty, MultilanguageDAC.cnnStringName);

            foreach (ParamBE p in list)
            {
                param = new fwk_Param();
                param.Culture = p.Culture;
                param.ParamId = p.ParamId;
                param.ParentId = p.ParentId;
                param.Description = p.Description;
                param.Enabled = p.Enabled;
                param.Id = p.Id;
                param.Name = p.Name;

                list2.Add(param);
            }
            return list2;
        }

        internal static DataSet RetrivePivotedParams(String columns)
        {
            Database wDataBase = null;
            DbCommand wCmd = null;

            wDataBase = DatabaseFactory.CreateDatabase(cnnStringName);
            wCmd = wDataBase.GetStoredProcCommand("Params_PIVOT");
            wDataBase.AddInParameter(wCmd, "columns", System.Data.DbType.String, columns);

            return wDataBase.ExecuteDataSet(wCmd);
        }

        /// <summary>
        /// Verifico si existe un registros con los parametros asados.
        /// ParentId
        /// ParamId
        /// cultura
        /// </summary>
        /// <param name="culture">Lenguaje</param>
        /// <param name="parentId">Padre o tipo</param>
        /// <param name="paramId">ParamId o identificador</param>
        internal static void Param_ValidateUpdate(fwk_Param param)
        {
            using (ConfigDataContext dc = new ConfigDataContext(cnnString))
            {
                bool wExist = false;
               
                wExist = dc.fwk_Params.Any(p => p.Culture.Equals(param.Culture)
                      && p.ParentId.Equals(param.ParentId)
                      //&& p.Name.Equals(param.Name)
                       && p.ParamId.Equals(param.ParamId) == false);
                if (wExist)
                {
                    throw new Fwk.Exceptions.FunctionalException(String.Format("Ya existe la param {0} codig:{1} tipo {2} cultura:{2}", param.Name, param.ParamId, param.Culture));
                }
                
               
            }
        }

        /// <summary>
        /// Verifico si tiene algun hijo
        /// </summary>
        /// <param name="param"></param>
        internal static void Param_ValidateRemove(fwk_Param param)
        {
            using (ConfigDataContext dc = new ConfigDataContext(cnnString))
            {
                //Verifico si tiene algun hijo
                bool wExist = dc.fwk_Params.Any(p => p.ParentId.Equals(param.ParamId)); 
                if (wExist)
                {
                    throw new Fwk.Exceptions.FunctionalException(String.Format("{0} es padre de otros en la Base de datos", param.Name));
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="culture">Lenguaje</param>
        /// <param name="parentId">Padre o tipo</param>
        /// <param name="paramId">Codigo de param o identificador</param>
        /// <param name="name"></param>
        internal static void Param_Update(fwk_Param param)
        {
            using (ConfigDataContext dc = new ConfigDataContext(cnnString))
            {
                bool wExist = false;
                fwk_Param record;

                //Verifico que clave y valor exista
                wExist = dc.fwk_Params.Any(p => p.Culture.Equals(param.Culture)
                      //&& p.ParentId.Equals(param.ParentId)
                      && p.Name.Equals(param.Name)
                       && p.ParamId.Equals(param.ParamId)==false);
                if (wExist)
                {
                    throw new Fwk.Exceptions.FunctionalException(String.Format("Ya existe la param {0} codig:{1} tipo {2} cultura:{2}", param.Name, param.ParamId, param.Culture));
                }
                else
                {
                    record = dc.fwk_Params.Where(p =>    p.Id.Equals(param.Id)).FirstOrDefault<fwk_Param>();
                    record.Name = param.Name;
                    record.ParamId = param.ParamId;
                    record.ParentId = param.ParentId;
                    record.Description = param.Description;
                    record.Culture = param.Culture;
                    
                

                    dc.SubmitChanges();
                }
              
            }
        }

        internal static void Param_Remove(int id)
        {
            using (ConfigDataContext dc = new ConfigDataContext(cnnString))
            {
                var records = dc.fwk_Params.Where(p => p.Id.Equals(id));

                foreach (fwk_Param param in records)
                {
                    dc.fwk_Params.DeleteOnSubmit(param);
                }
                dc.SubmitChanges();
            }
        }

        /// <summary>
        /// Verifico que clave y valor exista
        /// </summary>
        /// <param name="param"></param>
        internal static void Param_CreateNew_Validate_Existent(fwk_Param param)
        {

            Boolean wExist = false;
            using (ConfigDataContext dc = new ConfigDataContext(cnnString))
            {

                
                wExist = dc.fwk_Params.Any(p => p.Culture.Equals(param.Culture) && p.ParamId.Equals(param.ParamId));

                if (wExist)
                {
                    param = dc.fwk_Params.Where(p => p.Culture.Equals(param.Culture) && p.ParamId.Equals(param.ParamId)).FirstOrDefault();
                    throw new Fwk.Exceptions.FunctionalException(String.Format("Ya existe la param {0} codigo: {1} tipo {2} cultura:{2}", param.Name, param.ParamId, param.Culture));
                }
               
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        internal static void Param_CreateNew(fwk_Param param)
        {
            Param_CreateNew_Validate_Existent(param);
           
    
            using (ConfigDataContext dc = new ConfigDataContext(cnnString))
            {


                        dc.fwk_Params.InsertOnSubmit(param);
                    
                    dc.SubmitChanges();
            }

        }
        internal static List<String> RetriveCulturesArray()
        {
            List<String> list = new List<string>();
          foreach (CultureInfo ci in CultureInfo.GetCultures(CultureTypes.AllCultures))
            {
                string specName = "(none)";
                try
                {
                    specName = CultureInfo.CreateSpecificCulture(ci.Name).Name;

                }

                catch
                {

                }
                //list.Add(String.Format("{0,-12}{1,-12}{2}", ci.Name, specName, ci.EnglishName));
                //list.Add(String.Format("{0,-12},{1}", specName, ci.EnglishName));
                list.Add(specName);

            }

          return list;
        }
        #region Config
        internal static void CreateORUpdateKey(string language, string group, string key, string value)
        {
            using (ConfigDataContext dc = new ConfigDataContext(cnnString))
            {
                bool wExist = false;
                fwk_ConfigManager record;

                //Verifico que clave y valor exista
                wExist = dc.fwk_ConfigManagers.Any(p => p.ConfigurationFileName.Equals(language)
                && p.group.Equals(group)
                && p.key.Equals(key));

                if (wExist)
                {
                    record = dc.fwk_ConfigManagers.Where(p => p.ConfigurationFileName.Equals(language)
                                      && p.group.Equals(group)
                                      && p.key.Equals(key)).FirstOrDefault<fwk_ConfigManager>();

                    record.value = value;// e.Value.ToString().Trim();
                }

                else
                {
                    record = new fwk_ConfigManager();
                    record.ConfigurationFileName = language;
                    record.group = group;
                    record.key = key;
                    record.value = value;
                    dc.fwk_ConfigManagers.InsertOnSubmit(record);
                }
                dc.SubmitChanges();
            }
        }
        internal static void CreateNewKey(string group, string key, out string errorMsg)
        {
            string language;
            errorMsg = string.Empty;
            fwk_ConfigManager record = null;
            Boolean wExist = false;
            using (ConfigDataContext dc = new ConfigDataContext(cnnString))
            {
                for (int i = 0; i < Fwk.Configuration.ConfigurationManager.ConfigProvider.Providers.Count; i++)
                {
                    language = Fwk.Configuration.ConfigurationManager.ConfigProvider.Providers[i].Name;
                    //Verifico que clave y valor exista
                    wExist = dc.fwk_ConfigManagers.Any(p => p.ConfigurationFileName.Equals(language)
                    && p.group.Equals(group)
                    && p.key.Equals(key));

                    if (wExist)
                    {

                        errorMsg = String.Format("Ya existe la clave {0} en el grupo {1} para alguno de los lenguajes", key, group);
                        continue;
                    }
                    else
                    {
                        record = new fwk_ConfigManager();
                        record.ConfigurationFileName = language;
                        record.group = group;
                        record.key = key;
                        dc.fwk_ConfigManagers.InsertOnSubmit(record);
                    }
                    dc.SubmitChanges();
                }
            }
        }

        internal static void Remove(string group, string key)
        {
            using (ConfigDataContext dc = new ConfigDataContext(cnnString))
            {
                var records = dc.fwk_ConfigManagers.Where(p =>
                                            p.group.Equals(group)
                                       && p.key.Equals(key));

                foreach (fwk_ConfigManager config in records)
                {
                    dc.fwk_ConfigManagers.DeleteOnSubmit(config);
                }
                dc.SubmitChanges();
            }
        }

        internal static DataSet RetrivePivotedConfigs(String columns)
        {
            Database wDataBase = null;
            DbCommand wCmd = null;

            wDataBase = DatabaseFactory.CreateDatabase(cnnStringName);
            wCmd = wDataBase.GetStoredProcCommand("fwk_ConfigManager_PIVOT");
            wDataBase.AddInParameter(wCmd, "columns", System.Data.DbType.String, columns);

            return wDataBase.ExecuteDataSet(wCmd);
        }


        #endregion
    }
}


