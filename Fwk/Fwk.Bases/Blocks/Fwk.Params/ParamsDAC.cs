using System;
using System.Text;
using System.Data;
using System.Data.Common;
using Fwk.Bases;
using System.Linq;
using Fwk.Params.BE;
using Fwk.ConfigData;


namespace Fwk.Params.Back
{
    /// <summary>
    /// 
    /// </summary>
    public class ParamDAC
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="paramId"></param>
        /// <param name="parentId"></param>
        /// <param name="culture"></param>
        /// <param name="cnnStringName"></param>
        /// <returns></returns>
        public static Boolean Exist(int? paramId, int? parentId, string culture, string cnnStringName)
        {
          
            try
            {
                using (Fwk.ConfigData.FwkDatacontext dc = new Fwk.ConfigData.FwkDatacontext(getCnnString(cnnStringName)))
                {
                    bool exist =  dc.fwk_Params.Any(s=>

                                        (!parentId.HasValue || s.ParentId.Equals(parentId))
                                         &&
                                         (!paramId.HasValue || s.ParamId.Equals(paramId))
                                         &&
                                         (string.IsNullOrEmpty(culture) || s.Culture.Equals(culture))
                                         );

                    return exist;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        /// <summary>
        /// Retorna un param por id y cultura
        /// </summary>
        /// <param name="paramId"></param>
        /// <param name="culture"></param>
        /// <param name="cnnStringName"></param>
        /// <returns></returns>
        public static ParamBE Get(int? paramId, string culture, string cnnStringName)
        {
            ParamBE wParamBE =null;

            try
            {
                using (Fwk.ConfigData.FwkDatacontext dc = new Fwk.ConfigData.FwkDatacontext(getCnnString(cnnStringName)))
                {
                    var param_db = dc.fwk_Params.Where(s =>
                                        
                                         (!paramId.HasValue || s.ParamId.Equals(paramId))
                                         &&
                                         (string.IsNullOrEmpty(culture) || s.Culture.Equals(culture))
                                         ).FirstOrDefault();
                    if (param_db != null)
                    {
                        wParamBE = new ParamBE();
                        wParamBE.ParamId = param_db.ParamId;
                        wParamBE.ParentId = param_db.ParentId;
                        wParamBE.Name = param_db.Name;
                        wParamBE.Description = param_db.Description;
                        wParamBE.Enabled = param_db.Enabled;
                        wParamBE.Culture = param_db.Culture;
                        wParamBE.Id = param_db.Id;
                    }
                    return wParamBE;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        static string getCnnString(string cnnStringName)
        {
            if (String.IsNullOrEmpty(cnnStringName))
                throw new Fwk.Exceptions.TechnicalException("Debe proporcionar un nombre de cadena de conexión ");
            if (System.Configuration.ConfigurationManager.ConnectionStrings[cnnStringName]==null)
                throw  new Fwk.Exceptions.TechnicalException("Debe proporcionar un nombre de cadena de conexión valido ");

            return System.Configuration.ConfigurationManager.ConnectionStrings[cnnStringName].ToString();
        }

        /// <summary>
        /// Retorna parametros por id, id padre, y filtra x vigentes o no vigentes La cultura puede se String.Empty
        /// en cuyo caso no la tendra en cuenta para el filtro
        /// </summary>
        /// <param name="parentId">Relacion con otro param</param>
        /// <param name="enabled">Vigentes o no</param>
        /// <param name="culture">Cultura que se desea consultar: th-TH, en-US, es-AR etc etc</param>
        /// <param name="cnnStringName">Cadena de coneccion</param>
        /// <returns></returns>
        public static ParamList RetriveByParams(int? parentId, bool? enabled,string culture, string cnnStringName)
        {


            ParamList wParamList = new ParamList();
            ParamBE wParamBE = null;
            try
            {
                using (Fwk.ConfigData.FwkDatacontext dc = new Fwk.ConfigData.FwkDatacontext(getCnnString(cnnStringName)))
                {
                    var rulesinCat = from s in dc.fwk_Params where 
                                        
                                        
                                           (!parentId.HasValue || s.ParentId.Equals(parentId))
                                        &&
                                           (!enabled.HasValue || s.Enabled.Equals(enabled)
                                             &&
                                           (string.IsNullOrEmpty(culture) || s.Culture.Equals(culture)))
                                     select s;


                    foreach (Fwk.ConfigData.fwk_Param param_db in rulesinCat.ToList<Fwk.ConfigData.fwk_Param>())
                    {
                        wParamBE = new ParamBE();
                        wParamBE.ParamId = param_db.ParamId;
                        wParamBE.ParentId = param_db.ParentId;
                        wParamBE.Name = param_db.Name;
                        wParamBE.Description = param_db.Description;
                        wParamBE.Enabled = param_db.Enabled;
                        wParamBE.Culture = param_db.Culture;
                        wParamBE.Id = param_db.Id;

                        wParamList.Add(wParamBE);
                    }
                }


                return wParamList;


            }
            catch (Exception ex)
            {
                throw ex;
            }

           
        }


       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="paramBE"></param>
        /// <param name="userId"></param>
        /// <param name="cnnStringName"></param>
        public static void Create(ParamBE paramBE, Guid? userId, string cnnStringName)
        {
            using (Fwk.ConfigData.FwkDatacontext dc = new Fwk.ConfigData.FwkDatacontext(getCnnString(cnnStringName)))
            {
                Fwk.ConfigData.fwk_Param param = new ConfigData.fwk_Param();
                param.Culture = paramBE.Culture;
                param.Description = paramBE.Description;
                param.Enabled = true;
                param.Name = paramBE.Name;
                param.ParamId = paramBE.ParamId;
                param.ParentId = paramBE.ParentId;
                
                dc.fwk_Params.InsertOnSubmit(param);
                dc.SubmitChanges();
                paramBE.Id = param.Id;
                
            }
           
        }


        /// <summary>
        /// Actualiza fwk_Param
        /// </summary>
        /// <param name="paramBE"></param>
        /// <param name="userUpdateId"></param>
        /// <param name="cnnStringName"></param>
        public static void Update(ParamBE paramBE, Guid? userUpdateId, string cnnStringName)
        {
            using (Fwk.ConfigData.FwkDatacontext dc = new Fwk.ConfigData.FwkDatacontext(getCnnString(cnnStringName)))
            {
                Fwk.ConfigData.fwk_Param param = dc.fwk_Params.Where(p => p.Id.Equals(paramBE.Id)).FirstOrDefault();
                if (param != null)
                {
                  
                    param.Enabled = true;
                    param.Name = paramBE.Name;
                    param.Culture = paramBE.Culture;
                    param.Description = paramBE.Description;
                    //param.ParamId = paramBE.ParamId;
                    //param.ParentId = paramBE.ParentId;
                    dc.SubmitChanges();
                }
            }
        }

        /// <summary>
        /// Permite eliminar por 
        /// solo parentId
        /// solo paramId
        /// por ambos
        /// no permite que ambos sean Null
        /// </summary>
        /// <param name="paramId"></param>
        /// <param name="parentId"></param>
        /// <param name="cnnStringName"></param>
        public static void Delete(int? paramId, int? parentId, string cnnStringName)
        {
            //no permite que ambos sean Null
            if (paramId.HasValue == false || parentId.HasValue == false)
                throw new Fwk.Exceptions.TechnicalException("Debe proporcinar almeno uno de los dos parametros");
            using (Fwk.ConfigData.FwkDatacontext dc = new Fwk.ConfigData.FwkDatacontext(getCnnString(cnnStringName)))
            {
                var paramsList = dc.fwk_Params.Where(p => (paramId.HasValue == false || p.ParamId.Equals(paramId.Value)) &&
                       (parentId.HasValue == false || p.ParentId.Equals(parentId.Value)));
                foreach (fwk_Param p in paramsList)
                {
                    dc.fwk_Params.DeleteOnSubmit(p);
                }
                dc.SubmitChanges();

            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool IsUsed(int id)
        {
            //Database wDatabase = null;
            //DbCommand wCmd = null;

            //try
            //{
            //    wDatabase = DatabaseFactory.CreateDatabase("PelsoftGastos");
            //    wCmd = wDatabase.GetStoredProcCommand("Param_g_IsUsed");
            //    wDatabase.AddInParameter(wCmd, "ParamId", System.Data.DbType.Int32, id);
            

            //    wDatabase.AddOutParameter(wCmd, "Used", System.Data.DbType.Boolean,1);
                
            //    wDatabase.ExecuteNonQuery(wCmd);

            //    return (System.Boolean)wDatabase.GetParameterValue(wCmd, "Used");
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
            throw new NotImplementedException("Fwk Delete Param no esta implementado");
        }

    }
}