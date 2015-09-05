using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fwk.Bases
{
    /// <summary>
    /// Clase base de la que heredan estaticamente todos los componentes DAC
    /// </summary>
    public class BaseDAC
    {

        /// <summary>
        /// Busca cadenas de conección.- Primero intenta buscar en el AppSetings luego si no tiene exito en el 
        /// ConfigarionMannager 
        /// </summary>
        /// <param name="pCompayId">Identificador de empresa</param>
        /// <returns></returns>
        protected static string GetCnnstring(string pCompayId)
        {
            string cnnString = GetCnnstring_App(pCompayId);
            if (string.IsNullOrEmpty(cnnString))
                cnnString = GetCnnstrng_ConfigMng(pCompayId);

            return cnnString;
        }

        /// <summary>
        /// Busca cadenas de coenección en el archivo de configuracion AppSettings
        /// </summary>
        /// <param name="pCompayId">Identificador de empresa</param>
        /// <returns></returns>
        protected static string GetCnnstring_App(string pCompayId)
        {
            if (System.Configuration.ConfigurationManager.ConnectionStrings[pCompayId] != null)
            {
                return System.Configuration.ConfigurationManager.ConnectionStrings[pCompayId].ConnectionString;
            }
            return string.Empty;
        }

        /// <summary>
        /// Busca cadenas de coenección en el archivo de configuracion Configuracion mannager del framework
        /// </summary>
        /// <param name="pCompayId">Identificador de empresa</param>
        /// <returns></returns>
        protected static string GetCnnstrng_ConfigMng(string pCompayId)
        {

            return Fwk.Configuration.ConfigurationManager.GetProperty("BackFwkSettings", pCompayId);

        }
    }

    /// <summary>
    /// Clase base de la que pueden heredar todos los componentes BC
    /// </summary>
    public class BaseBC
    {
        private string _AppId;

        /// <summary>
        /// Identificador de empresa
        /// </summary>
        protected string CompanyId
        {
            get { return _AppId; }
        }
        /// <summary>
        /// Cosntructor unico
        /// </summary>
        /// <param name="pCompanyId">Identificador de empresa</param>
        public BaseBC(string pCompanyId)
        {
            _AppId = pCompanyId;
        }
        

     
    }
}
