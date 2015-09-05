using System;
using System.Xml;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Diagnostics;

namespace Fwk.ServiceManagement.Tools.Win32
{
    /// <summary>
    /// 
    /// </summary>
    public class Common
    {
        public enum TipoBusquedaEnum
        {
            Start = 1,
            Contains = 2,
            Finalize = 3,
            Equal = 4
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pPath"></param>
        /// <returns></returns>
        public static string OpenTextFile(string pPath)
        {
            FileStream fs = null;
            StreamReader sr = null;
            try
            {
                fs = new FileStream(pPath, FileMode.Open, FileAccess.Read);
                sr = new StreamReader(fs);
                return sr.ReadToEnd();
            }
            catch (System.IO.DirectoryNotFoundException )
            {
                throw new Exception("Acegurece que esten los templates completos donde se encuentra el ejecutable de la aplicacion");
            }
            catch (Exception ex)
            {
                throw ex;
            }
      
        }

  
       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pExtencion"></param>
        /// <param name="pFullNemeFile"></param>
        /// <returns></returns>
        public static Boolean ValidateFileByExtencion(string pExtencion, string pFullNemeFile)
        {
            if (!System.IO.File.Exists(pFullNemeFile)) return false;
            if (pFullNemeFile.Length > 3)
            {
                if (pFullNemeFile.Substring(pFullNemeFile.Length - 3, 3).ToLower() != pExtencion.ToLower()) return false;
            }
            else
                return false;

            return true;

        }

        /// <summary>
        /// 
        /// </summary>
        public static void CreateEventLog()
        {
            String Source = "CodeGenerator";
            if (!EventLog.SourceExists(Source, Environment.MachineName))
            {
                EventLog.CreateEventSource(Source, Source);
            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pMessage"></param>
        /// <param name="pException"></param>
        /// <param name="pEventID"></param>
        /// <param name="pEventLogEntryType"></param>
        public static void WriteEntryEventLog(String pMessage, Exception pException, int pEventID,EventLogEntryType pEventLogEntryType)
        {
            String LogName = "CodeGenerator";

            // Insert into event log
            EventLog Log = new EventLog();
            Log.Source = LogName;

            pMessage += Environment.NewLine + GetAllMessageException(pException);
            Log.WriteEntry(pMessage, pEventLogEntryType,pEventID);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static String GetAllMessageException(Exception ex)
        {
            StringBuilder wMessage = new StringBuilder();
            wMessage.Append(ex.Message);
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
                wMessage.Append(ex.Message);
            }
            return wMessage.ToString();
        }

    }


   
}
