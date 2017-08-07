using System;
using System.Data;
using System.IO;
using System.Collections.Generic;
using System.Text;
using Fwk.Bases;
using Fwk.HelperFunctions;
using System.Xml.Serialization;
using System.Xml;
using Fwk.Exceptions;

namespace Fwk.Bases
{
    /// <summary>
    /// Clase base con el comportamiento general de los Request y Responses
    /// </summary>
    /// <typeparam name="T"> <see cref="IEntity"/> </typeparam>
    [Serializable]
    public class ServiceContractBase<T>:IServiceContract where T : IBaseEntity , new()
    {
        
        T m_Data = new T();
        private string _ServiceName;
        ContextInformation m_Context = new ContextInformation();

        ServiceError m_Error;

        /// <summary>
        /// Contiene una lista de errores que se pudieran producir en la ejecucion del servicio.-
        /// </summary>
        public ServiceError Error
        {
            get { return m_Error; }
            set { m_Error = value; }
        }

        /// <summary>
        /// Indica el nombre del servicio. Este nombre debe ser igual a como esta registrado
        /// </summary>
        public string ServiceName
        {
            get
            {
                return _ServiceName;
            }
            set
            {
                _ServiceName = value;
            }
        }

        #region [BusinessData]
        
        /// <summary>
        /// Clase que implementa <see cref="IEntity"/>
        /// </summary>
        public T BusinessData
        {
            get { return m_Data; }
            set { m_Data = value; }
        }

        /// <summary>
        /// Inicializa los datos de negocio que pertenecen al Request/Response con el contenido del xml.-
        /// </summary>
        /// <param name="pXMLData">Xml que respeta el esquema de la informacion de negocio del Request o Response.</param>
        public void SetBusinessDataXml(string pXMLData)
        {
            m_Data = (T)SerializationFunctions.Deserialize(typeof(T), pXMLData);
        }

        /// <summary>
        /// Retorna el xml de la porcion de negocio que pertenece al Request o Response.-
        /// </summary>
        /// <returns>Xml producto de la serializacion de la informacion de negocio.- </returns>
        public string GetBusinessDataXml()
        {
            return m_Data.GetXml();
        }

        /// <summary>
        /// Retorna el DataSet de la porcion de negocio que pertenece al Request o Response.-
        /// </summary>
        /// <returns>DataSet de la informacion de negocio.- </returns>
        public DataSet GetBusinessData_DataSet()
        {
            DataSet ds = new DataSet();
            ds.ReadXml(new StringReader(m_Data.GetXml()));
            ds.DataSetName = "BusinessData";
            return ds;
        }
        #endregion

        #region [Request/Response]
        /// <summary>
        /// Rellena el Request/Response con la informacion del xml.-
        /// </summary>
        /// <pXMLReques>Xml del Request o Response</pXMLReques>
        public void SetXml(string pXMLService)
        {
            XmlDocument wDom = new XmlDocument();
            wDom.LoadXml(pXMLService);

            StringBuilder xml = new StringBuilder();
            
            xml.Append(wDom.SelectSingleNode(@"/" + wDom.DocumentElement.Name + @"/ContextInformation").OuterXml);
       
            SetContextInformationXml(xml.ToString());
            xml = new StringBuilder();

            xml.Append("<");
            xml.Append(m_Data.GetType().Name);
            xml.Append(">");
            xml.Append(wDom.SelectSingleNode(@"/" + wDom.DocumentElement.Name + @"/BusinessData").InnerXml);
            xml.Append(@"</");
            xml.Append(m_Data.GetType().Name);
            xml.Append(">");

            SetBusinessDataXml(xml.ToString());
            
            if(wDom.SelectSingleNode("//Error") != null)
            {
                if (wDom.SelectSingleNode(@"/" + wDom.DocumentElement.Name + @"/Error").HasChildNodes)
                {
                    SetErrors(wDom.SelectSingleNode(@"/" + wDom.DocumentElement.Name + @"/Error").OuterXml);
                }
            }
            xml = null;
            wDom = null;
        }

        private void SetErrors(string pXmlError)
        {

            m_Error = (ServiceError)SerializationFunctions.Deserialize(typeof(ServiceError), pXmlError);
        }
        /// <summary>
        /// Obtiene el xml del request o response .-
        /// </summary>
        /// <returns>Xml producto de la serializacion</returns>
        public string GetXml()
        {
            return SerializationFunctions.SerializeToXml(this);
        }

        /// <summary>
        /// Obtiene el DataSet del request o response .-
        /// </summary>
        /// <returns>DataSet producto de la serializacion</returns>
        public DataSet GetDataSet()
        {
            DataSet ds = new DataSet(this.GetType().Name);
            ds.ReadXml(new StringReader(GetXml()));
            return ds;
        }
        #endregion

        #region [Context Information]

        /// <summary>
        /// Informacion de contexto hacerca del Request del servio.-
        /// </summary>
        public ContextInformation ContextInformation
        {
            get { return m_Context; }
            set { m_Context = value; }
        }

        
        /// <summary>
        /// Inicializa los datos contexto que pertenecen al Request con el contenido del xml.-
        /// </summary>
        /// <param name="pXMLData">xml</param>
        public void SetContextInformationXml(string pXMLData)
        {
            m_Context = (ContextInformation)
                Fwk.HelperFunctions.SerializationFunctions.Deserialize(typeof(ContextInformation), pXMLData);
        }

        /// <summary>
        /// Retorna el xml del Context que pertenece al Request o Response.-
        /// </summary>
        /// <returns>xml</returns>
        public string GetContextInformationXml()
        {
            return SerializationFunctions.SerializeToXml(m_Context);

        }


        /// <summary>
        /// Establece la informacion de contexto del Request o Response del lado del despachador de servicios.-
        /// </summary>
        public void InitializeServerContextInformation()
        {
            if (m_Context == null)
                m_Context = new ContextInformation();

            m_Context.ServerTime = DateTime.Now;
            m_Context.ServerName = Environment.MachineName;
           
        }

        /// <summary>
        /// Establece la informacion de contexto del Request o Response del lado del cliente.-
        /// </summary>
        public void InitializeHostContextInformation()
        {
            if (m_Context == null)
                m_Context = new ContextInformation();

            m_Context.HostName = Environment.MachineName;
            if (string.IsNullOrEmpty(m_Context.UserId))
                m_Context.UserId = Environment.UserName;

            m_Context.HostTime = DateTime.Now;
            //m_Context.CompanyId = GetCompanyId();

            //solo si es un objeto request
            //if (typeof(IRequest).IsInstanceOfType(this))
            //{
            //    //Obtener nombre del proveedor de seguridad. Membership,Rol y Autthorization Provider
           
            //}
        }

        /// <summary>
        /// Busca el identificador de compañia o compañia-aplicacion en el archivo de configuracion o Configuracion mannager del framework
        /// </summary>
        /// <returns></returns>
        //protected static string GetCompanyId()
        //{
        //    string wCompanyId = System.Configuration.ConfigurationManager.AppSettings["CompanyId"];
        //    try
        //    {
        //        if (string.IsNullOrEmpty(wCompanyId))
        //            wCompanyId = Fwk.Configuration.ConfigurationManager.GetProperty("ClientFwkSettings", "CompanyId");
        //    }
        //    catch (System.TypeInitializationException)
        //    {
        //        return string.Empty;
        //    }
        //    if (wCompanyId == null)
        //        return string.Empty;

        //    return wCompanyId;
        //}


        /// <summary>
        /// Busca cadenas de coenección en el archivo de configuracion Configuracion mannager del framework
        /// </summary>
        /// <returns></returns>
        //protected static string GetSecurtyProviderName()
        //{

        //    string wSecurtyProviderName = System.Configuration.ConfigurationManager.AppSettings["SecurtyProviderName"];
        //    try
        //    {
        //        if (string.IsNullOrEmpty(wSecurtyProviderName))
        //            wSecurtyProviderName = Fwk.Configuration.ConfigurationManager.GetProperty("ClientFwkSettings", "SecurtyProviderName");
        //    }
        //    catch (System.TypeInitializationException)
        //    {
        //        return string.Empty;
        //    }
        //    if (wSecurtyProviderName == null)
        //        return string.Empty;
           
        //    return wSecurtyProviderName;
        //}

        /// <summary>
        /// Clona el contrato de servicio
        /// </summary>
        /// <typeparam name="TServiceContract">Tipo de contrato que implementa IServiceContract, puede ser un request o un response </typeparam>
        /// <returns></returns>
        public TServiceContract Clone<TServiceContract>() where TServiceContract : IServiceContract 
        {
            return (TServiceContract)Fwk.HelperFunctions.SerializationFunctions.Deserialize(this.GetType(), this.GetXml());
        }

        #endregion





        #region IServiceContract Members
        /// <summary>
        /// GetBusinessDataObject
        /// </summary>
        public IBaseEntity IEntity
        {
            get
            {
                return m_Data;
            }
           
        }

        #endregion


    }
}

