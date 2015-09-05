using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using Fwk.Exceptions;

namespace Fwk.Logging.Targets
{
    /// <summary>
    /// Destino de tipo archivo .log.
    /// </summary>
    /// <date>2006/09/02</date>
    /// <author>moviedo</author>
    public class FileTarget : Target
    {
        #region <constructor>
        
        /// <summary>
        /// Constructor de FileTarget.
        /// </summary>
        public FileTarget()
        {
            this.Type = TargetType.File;
        }
        #endregion
        #region <public overrides>
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pEvent"></param>
        /// <returns></returns>
        public override Events SearchByParam(Event pEvent)
        {
            throw new NotImplementedException("No se implementa SearchByParam en un evento proveniente un archivo comun.- Solo de xml");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pEvent"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public override Events SearchByParam(Event pEvent, DateTime t)
        {
            throw new NotImplementedException("No se implementa SearchByParam en un evento proveniente un archivo comun.- Solo de xml y database");
        }
        /// <summary>
        /// Implementación de la escritura del log del evento
        /// en archivo .log.
        /// </summary>
        /// <param name="pEvent">Evento a loguear.</param>
        public override void Write(Event pEvent)
        {
            CheckOpenStreamWriter();
            Fwk.HelperFunctions.FileFunctions.SaveTextFile(this.FileName, pEvent.ToString(), true);
        }

        /// <summary>
        /// No se implementa Remove en un evento proveniente un archivo comun.- Solo de xml y database
        /// </summary>
        /// <param name="eventIdList"></param>
        public override void Remove(List<string> eventIdList)
        {
            throw new NotImplementedException("No se implementa Remove en un evento proveniente un archivo comun.- Solo de xml y database");
        }


        /// <summary>
        /// No se implementa Remove en un evento proveniente un archivo comun.- Solo de xml y database
        /// </summary>
        /// <param name="eventIdList"></param>
        public override void Remove(List<Guid> eventIdList)
        {
            throw new NotImplementedException("No se implementa Remove en un evento proveniente un archivo comun.- Solo de xml y database");
        }
        #endregion

        #region <private methods>
        /// <summary>
        ///Chequea si existe previamente el archiivo o no tambien el directorio de logs
        /// 
        /// </summary>
        /// <returns>StreamWriter.</returns>
        private void  CheckOpenStreamWriter()
        {
            //StreamWriter wStreamWriter;

            if (this.FileName.Trim().Length == 0)
            {
                throw new TechnicalException("Debe especificar un FileName.");
            }

            FileInfo wFileInfo = new FileInfo(this.FileName);
            if (!wFileInfo.Exists)
            {
                if (!wFileInfo.Directory.Exists)
                {
                    Directory.CreateDirectory(wFileInfo.DirectoryName);
                }
            }
            //wStreamWriter = new StreamWriter(this.FileName, true);
            //return wStreamWriter;
        }
        #endregion

      
    }
}
