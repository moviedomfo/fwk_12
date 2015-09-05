using System;
using System.Diagnostics;
using System.Text;

namespace Fwk.HelperFunctions
{
	/// <summary>
	/// Provee funcionalidades para el manejo de logs de nuestras aplicaciones.- 
	/// </summary>
	public class LogFunctions
	{
	    ///<summary>
	    /// Enumeracion de modos de logueos que utilizan las aplicaciones 
	    ///</summary>
	    public enum LogMode
	    {
            /// <summary>
            /// Modo que permite registrar en un archivo de Logs
            /// </summary>
	        File = 0,
            /// <summary>
            /// Modo que permite registrar un evento en el Visor de sucesos
            /// </summary>
	        EventViewer = 1
	    } ;
        /// <summary>
        /// Metodo que permite escribir un log en el Log viewer o en un archivo dependiendo del 
        /// parametro 
        /// </summary>
        /// <param name="pMessage">Mensaje del log.-</param>
        /// <param name="pFileName">Nombre del archivo donde se guarda el Log si modalidad log es <remarks "LogMode.File"</param>
		/// <param name="pSource">El origen por el cual la qplicacion es registrada </param>
        /// <param name="pLogMode">Si es "EventViewer" genera un registro en Event Viewer 
        /// Si es "FileLog" genera una linea en un archivo de log</param>
		/// <param name="pEventLogEntryType">Espesifica el tipo de log, puede ser :
        /// Error , Warning, Information, SuccessAudit etc.
		/// </param>
        public static void WriteLog(string pMessage, string pFileName, string pSource, 
            LogMode pLogMode, EventLogEntryType pEventLogEntryType)
		{
			if (pLogMode == LogMode.EventViewer)
			{
			  EventLog.WriteEntry(pSource, pMessage, pEventLogEntryType);
			}

            if (pLogMode == LogMode.File)
			{
				StringBuilder wFileText = new StringBuilder ();
				wFileText.Append(Environment.NewLine);
				wFileText.Append("--------------------------------" + "[" + pSource + "]" + "------------------------------------------------------------------");
				wFileText.Append(Environment.NewLine);
				wFileText.Append(DateTime.Now.ToString() + " Host: " + Environment.MachineName);
				wFileText.Append(Environment.NewLine);
				wFileText.Append(pMessage);
				wFileText.Append(Environment.NewLine);
				FileFunctions.SaveTextFile(pFileName, wFileText.ToString(), true);
			}
		}
	}
}
