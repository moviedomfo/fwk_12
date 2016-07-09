using System;
using System.Collections.Generic;
using System.Text;

namespace Fwk.Bases
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
	public class ContextInformation
	{
        
        string _ProviderName;
		string _UserId;
        string _HostName;
        string _HostIp;
        string _ServerName;
        string _Culture;
        DateTime _ServerTime = new DateTime();
        DateTime _HostTime = new DateTime();
        /// <summary>
        /// Indica la cultura, en texto, del cliente q realizo la peticion del REQ .- 
        /// </summary>
        public string Culture
        {
            get { return _Culture; }
            set { _Culture = value; }
        }
        /// <summary>
        /// Identifica la cultura con la q trabajara el servicio. Util para manejo de decimales 
        /// Idiomas llamadas a config mannager con texto o mensajes en un determinado idioma.-
        /// etc.-
        /// Generalmente este valor es establecido por la Fachada de sevicios en el framework y  es 
        /// obtenido de la configuracion de Service Metadata Provider. El provider se determina a traves de ExecuteService(providerName,....)
        /// Si DefaultCulture es distinto e null se utilizara el mismo, de lo contrario se utilizara el obtenido de la configuracion de Service Metadata Provider.
        /// </summary>
        public string ProviderNameWithCultureInfo { get; set; }

        /// <summary>
        /// Indica el host que inicio la peticion del servicio .-
        /// </summary>
        public string HostName
        {
            get { return _HostName; }
            set { _HostName = value; }
        }

        /// <summary>
        /// Indica `la IP del host que inicio la peticion del servicio .-
        /// </summary>
        public string HostIp
        {
            get { return _HostIp; }
            set { _HostIp = value; }
        }

        /// <summary>
        /// Indica fecha y hora de inicio o fin del servicio del lado del Cliente.-
        /// Para un Request  -->  fecha y hora de inicio del lado del cliente (horario de inicio desde el host).-
        /// Para un Response -->  fecha y hora de finalizacion del lado del cliente (horario de llegada al host)-
        /// </summary>
        public DateTime HostTime
        {
            get { return _HostTime; }
            set { _HostTime = value; }
        }

        /// <summary>
        /// Indica el server que atendio el servicio servicio .-
        /// </summary>
        public string ServerName
        {
            get { return _ServerName; }
            set { _ServerName = value; }
        }

        /// <summary>
        /// Indica fecha y hora de inicio o fin del servicio del lado del Servidor o despachador de servicio.-
        /// Para un Request  -->  fecha y hora de inicio del lado del server .-
        /// Para un Response -->  fecha y hora de finalizacion del lado del server .-
        /// </summary>
        public DateTime ServerTime
        {
            get { return _ServerTime; }
            set { _ServerTime = value; }
        }

        /// <summary>
        /// Indica el usuario logueado en el host que inicio el servicio.-
        /// </summary>
        [Obsolete("UserName se dejara de utilizar en proximas versiones de fwk, en su lugar utilice UserId")]
		public string UserName
		{
			get { return _UserId; }
			set { _UserId = value; }
		}

        /// <summary>
        /// Indica el identificador usuario logueado en el host que inicio el servicio.-
        /// Aqui puede alojar valores de cualquier tipo (guid,int, string, etc) llevados a String.-
        /// </summary>
        public string UserId
        {
            get { return _UserId; }
            set { _UserId = value; }
        }
        /// <summary>
        /// Identificador de aplicaion,cliente donde este instalado o para quien este instalado.-
        /// Utiil para identificar logs, discriminar cadenas de conecciones, etc.-
        /// </summary>
        public string AppId { get; set; }


        /// <summary>
        /// Si el run time se encuentra en BackEnd representa el nombre del ServiceMetadataProviderName 
        /// Si el run time se encuentra en FrontEnd (controller o componentes win 32) representa Wrapper Provider Name
        /// </summary>
        public string ProviderName
        {
            get { return _ProviderName; }
            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ProviderName"></param>
        internal void SetProviderName(string ProviderName)
        {
            _ProviderName = ProviderName;
        }
	}
}
