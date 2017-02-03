using System;
using System.Collections.Generic;
using System.Text;
using Fwk.Configuration;
using System.Data;
using System.Threading;
using Fwk.Exceptions;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Fwk.Blocking
{
    /// <summary>
    /// IBlockingEngine interfaz de motor de bnloqueo
    /// </summary>
    /// <Auhor>moviedo</Auhor>
    public interface IBlockingEngine
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pIBlockingMark"></param>
        /// <returns></returns>
        int Create(IBlockingMark pIBlockingMark);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pBlockingMark"></param>
        /// <returns></returns>
        DataTable GetByParam(IBlockingMark pBlockingMark);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pBlockingMark"></param>
        /// <returns></returns>
        DataTable GetByParamCustom(IBlockingMark pBlockingMark);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pGuid"></param>
        void Remove(Guid pGuid);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pBlockingId"></param>
        void Remove(Int32 pBlockingId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pBlockingMark"></param>
        /// <returns></returns>
        List<String> ExistsUser(IBlockingMark pBlockingMark);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pGUID"></param>
        /// <param name="pBlockingId"></param>
        /// <returns></returns>
        Boolean Exists(Guid? pGUID, Int32? pBlockingId);

    }
}


