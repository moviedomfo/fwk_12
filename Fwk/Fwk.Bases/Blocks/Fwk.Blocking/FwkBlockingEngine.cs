namespace Fwk.Blocking
{
	
    /// <summary>
	/// Marca de bloqueo para un registro de una tabla.-
	/// </summary>
    public class FwkBlockingEngine : BlockingEngineBase
	{
		
      
        /// <summary>
        /// Constructor de <see cref="FwkBlockingEngine"/>
        /// </summary>
        public FwkBlockingEngine(): base("BlockingMarks") { }






        /// <summary>
        /// Retorna los parametros necesarios para realizar un INSERT
        /// </summary>
        /// <param name="pBlockingMark">Marca de bloqueo</param>
        /// <returns></returns>
        protected override System.Collections.Generic.List<System.Data.SqlClient.SqlParameter> 
            GetCustomParametersToInsert(IBlockingMark pBlockingMark)
        {
            return null;
        }


        /// <summary>
        /// Retorna los parametros necesarios para realizar un GET
        /// </summary>
        /// <param name="pBlockingMark">Marca de bloqueo</param>
        /// <returns></returns>
        protected override System.Collections.Generic.List<System.Data.SqlClient.SqlParameter> 
            GetCustomParametersToGetByParams(IBlockingMark pBlockingMark)
        {
            return null;
        }


        /// <summary>
        /// Retorna los parametros necesarios para realizar una busqueda de EXISTENCIA
        /// </summary>
        /// <param name="pBlockingMark">Marca de bloqueo</param>
        /// <returns></returns>
        protected override System.Collections.Generic.List<System.Data.SqlClient.SqlParameter> 
            GetCustomParametersUserExist(IBlockingMark pBlockingMark)
        {
            return null;
        }
    }
}