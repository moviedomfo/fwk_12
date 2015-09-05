using System.Diagnostics;
using System.Data;
using System.Text;
using System;
using Fwk.Exceptions;

namespace Fwk.Blocking
{
    /// <summary>
    /// 
    /// </summary>
	public class BlockingHelper
	{
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pLog"></param>
        /// <param name="pType"></param>
		public static void WriteLog(string pLog, EventLogEntryType pType)
		{
            EventLog.WriteEntry("Fwk.Blocking", pLog, pType);
		}

      
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pBlockingEngineBase"></param>
        /// <param name="pGUID"></param>
        public static void CheckAndReleaseBlocking(BlockingEngineBase pBlockingEngineBase, Guid pGUID)
        {
            if (!pBlockingEngineBase.Exists(pGUID, null))
            {
                throw new BlockingFunctionalException("BlockingExpiro");
            }

            pBlockingEngineBase.Remove(pGUID);
        }
	} 
}
