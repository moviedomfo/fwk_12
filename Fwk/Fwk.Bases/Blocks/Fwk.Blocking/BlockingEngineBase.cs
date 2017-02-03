using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Threading;
using Fwk.Configuration;
using Fwk.Exceptions;
using System.Diagnostics;

namespace Fwk.Blocking
{
    
    /// <summary>
    /// Clase base de implementacien standar de blocking
    /// </summary>
    /// <Auhor>moviedo</Auhor>
    public abstract class BlockingEngineBase : IBlockingEngine
    {
        
        #region Members

        String _Table_BlockingMarks_Name;

        #endregion


        #region Contructors

        /// <summary>
        /// Constructor
        /// </summary>
        public BlockingEngineBase() { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pTableNamme">Nombre de la tabla en Bloqcking</param>
        public BlockingEngineBase(String pBlockingTableNamme)
        {
            _Table_BlockingMarks_Name = pBlockingTableNamme;
        }

        #endregion


        #region Privates Methods

        /// <summary>
        /// Realiza un bloqueo creando una
        /// BlockingMarks. Previamente verifica que no haya sido bloqueadas
        /// anteriormente ninguna de las instancias.
        /// </summary>
        /// <param name="IBlockingMark"><see cref="IBlockingMark"/></param>
        public int Create(IBlockingMark pIBlockingMark)
        {
            ///Llama a al metodo abstracto que es implementado por las clases hijas para obtener los
            ///parametros customizados.-
            List<SqlParameter> wSqlParameterlist = GetCustomParametersToInsert(pIBlockingMark);
            
            return BlockingEngineDAC.AddMark(pIBlockingMark, wSqlParameterlist,_Table_BlockingMarks_Name);
        }


        public void ClearBlockingMarksByUserName(string pUserName)
        {
            BlockingEngineDAC.ClearBlockingMarksByUserName(_Table_BlockingMarks_Name, pUserName);
        }

        /// <summary>
        /// Libera un contexto de bloqueo, borrando todas las marcas
        /// que posean el mismo id de Contexto.
        /// </summary>
        /// <param name="pBlockingId">Id de bloqueo a liberar</param>
        public void Remove(Int32 pBlockingId)
        {

            BlockingMarkBase wBlockingMark = new BlockingMarkBase(_Table_BlockingMarks_Name);
            wBlockingMark.BlockingId = pBlockingId;
            wBlockingMark.FwkGuid = null;
            BlockingEngineDAC.RemoveMark(wBlockingMark);
        }

        /// <summary>
        /// Libera un contexto de bloqueo, borrando todas las marcas
        /// que posean el mismo id de Contexto.
        /// Adicionalmente hace un backup de los registros bloqueantes
        /// que se borran, si se desea.
        /// </summary>
        /// <param name="pGuid">Guid de bloqueo a liberar</param>
        public void Remove(Guid pGuid)
        {
            BlockingMarkBase wBlockingMark = new BlockingMarkBase(pGuid, _Table_BlockingMarks_Name);
            wBlockingMark.BlockingId = null;
            BlockingEngineDAC.RemoveMark(wBlockingMark);
        }

        /// <summary>
        /// Limpia todas las marcas para las cuales se cumplió el TTL.
        /// Este método se ejecuta desde un servicio.
        /// </summary>
        /// <param name="pBackupMarks">Le dice al método si hacer Backup
        /// de las marcas que se borran.</param>
        /// <returns>Retorna la cantidad de marcas borradas.</returns>
        public static int ClearBlockingMarks()
        {
            /// Declaro conexión y comando
            using (SqlConnection wCnn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["BlockingModel"].ConnectionString))
            using (SqlCommand wCmd = new SqlCommand("BlockingMarks_d_clear", wCnn))
            {
                try
                {
                    wCmd.CommandType = CommandType.StoredProcedure;

                    /// Se setean los parámetros.
                    SqlParameter wParam;


                    wParam = wCmd.Parameters.Add("@Count", SqlDbType.Int);
                    wParam.Value = 0;
                    wParam.Direction = ParameterDirection.Output;

                    /// Se abre la conexión y se ejecuta el comando.
                    wCnn.Open();
                    wCmd.ExecuteNonQuery();

                    /// Se retorna la cantidad de marcas borradas.
                    return int.Parse(wCmd.Parameters["@Count"].Value.ToString());
                }
                catch (Exception ex)
                {
                    /// Si se produjo alguna excepción, se reenvía
                    throw ex;
                }
                finally
                {
                    /// Cierra la conexión si está abierta
                    if (wCnn.State == ConnectionState.Open)
                        wCnn.Close();
                }
            }
        }
        
        public DataTable GetByParam(IBlockingMark pBlockingMark)
        {
            return BlockingEngineDAC.GetByParam(pBlockingMark);
        }

        public DataTable GetByParamCustom(IBlockingMark pBlockingMark)
        {
            List<SqlParameter> wSqlParameterlist = GetCustomParametersToGetByParams(pBlockingMark);
            return BlockingEngineDAC.GetByParam(pBlockingMark, wSqlParameterlist);
        }

        protected abstract List<SqlParameter> GetCustomParametersToInsert(IBlockingMark pBlockingMark);
        protected abstract List<SqlParameter> GetCustomParametersToGetByParams(IBlockingMark pBlockingMark);
        protected abstract List<SqlParameter> GetCustomParametersUserExist(IBlockingMark pBlockingMark);

        /// <summary>
        /// Retorna el RetryCount.
        /// </summary>
        /// <returns>RetryCount</returns>
        private int GetRetryCount()
        {
            int ret;
            try
            {
                ret = Convert.ToInt32(ConfigurationManager.GetProperty("BlockingModel", "RetryCount"));
            }
            catch (Exception ex)
            {
                BlockingHelper.WriteLog("Se produjo una excepción al obtener la propiedad 'RetryCount' del grupo 'BlockingModel' en el archivo 'ConfigurationManager.xml'\r\n" + ex.ToString(), EventLogEntryType.Warning);
                ret = 0;
            }
            return ret;
        }

        /// <summary>
        /// Retorna si aplica blocking o no
        /// </summary>
        private bool PerformBlocking
        {
            get
            {
                try
                {
                    return Convert.ToBoolean(ConfigurationManager.GetProperty("BlockingModel", "PerformBlocking"));
                }
                catch (Exception ex)
                {
                    BlockingHelper.WriteLog("Se produjo una excepción al obtener la propiedad 'PerformBlocking' del grupo 'BlockingModel' en el archivo 'ConfigurationManager.xml'\r\n" + ex.ToString(), EventLogEntryType.Warning);
                    return false;
                }
            }
        }

        #endregion


        #region IBlockingEngine Members

        /// <summary>
        /// Verifica si existe marcas. Si exite alguna marca retorna los usuarios.
        /// </summary>
        /// <param name="pBlockingMark"></param>
        /// <returns></returns>
        public Boolean Exists(Guid? pGUID, int? pBlockingId)
        {
            BlockingMarkBase pBlockingMark = new BlockingMarkBase(pGUID, _Table_BlockingMarks_Name);

            pBlockingMark.BlockingId = pBlockingId;

            return BlockingEngineDAC.Exists(pBlockingMark,_Table_BlockingMarks_Name);
        }

        /// <summary>
        /// Verifica si existe marcas. Si exite alguna marca retorna los usuarios.
        /// </summary>
        /// <param name="pBlockingMark"></param>
        /// <returns></returns>
        public List<string> ExistsUser(IBlockingMark pBlockingMark)
        {
            List<SqlParameter> wSqlParameterlist = GetCustomParametersUserExist(pBlockingMark);
     
            return BlockingEngineDAC.ExistsUsers(pBlockingMark, wSqlParameterlist,_Table_BlockingMarks_Name);
        }

        #endregion

    }

}