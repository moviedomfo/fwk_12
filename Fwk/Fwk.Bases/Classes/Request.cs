using System;
using Fwk.Bases;
using System.Collections.Generic;
using Fwk.HelperFunctions;
using Fwk.Caching;
using Fwk.Exceptions;
using System.Xml.Serialization;

namespace Fwk.Bases
{
    /// <summary>
    /// Clase base de los request
    /// </summary>
    /// <example>
    /// <para>El siguiente ejemplo muestra un clase que hereda de la base Request que permite definir el contratode srvicio CrearCliente
    /// por lo  tanto recime la infotmacion de la entidad Clientes.-</para>
    /// <code>
    /// <![CDATA[
    ///  namespace Empresa.BackEnd.ISVC.CrearCliente.req
    ///       {
    ///   public class CrearClienteRequest : Request <Clientes>
    ///    {
    ///
    ///        public CrearClienteRequest()
    ///       {
    ///           this.ServiceName = "CrearClienteService";
    ///       }
    ///    }
    ///
    ///    #region [BussinesData]
    ///    [XmlRoot("ClientesList"), SerializableAttribute]
    ///    public class ClientesList : Entities
    ///    {
    ///        #region [Methods]
    ///        /// <summary>
    ///        /// Metodo estatico que retorna un objeto ClientesList apartir de un xml.-
    ///        /// </summary>
    ///        /// <param name="pXml">String con el xml</param>
    ///        /// <returns>ClientesList</returns>
    ///        public static ClientesList GetClientesListFromXml(String pXml)
    ///        {
    ///            return (ClientesList)Entity.GetObjectFromXml(typeof(ClientesList), pXml);
    ///        }
    ///        #endregion
    ///    }
    ///    [XmlInclude(typeof(Clientes)), Serializable]
    ///    public class Clientes : Entity
    ///    {
    ///        #region [Private Members]
    ///        private System.Int32? _IdCliente;
    ///        private System.Int64? _CUIT;
    ///        private System.String _RazonSocial;
    ///        #endregion
    ///        #region [Properties]
    ///
    ///        #region [IdCliente]
    ///        [XmlElement(ElementName = "IdCliente", DataType = "int")]
    ///        public int? IdCliente
    ///        {
    ///            get { return _IdCliente; }
    ///            set { _IdCliente = value; }
    ///        }
    ///        #endregion
    ///
    ///        #region [CUIT]
    ///
    ///        public Int64? CUIT
    ///        {
    ///            get { return _CUIT; }
    ///            set { _CUIT = value; }
    ///        }
    ///        #endregion
    ///
    ///        #region [RazonSocial]
    ///        [XmlElement(ElementName = "RazonSocial", DataType = "string")]
    ///        public String RazonSocial
    ///        {
    ///            get { return _RazonSocial; }
    ///            set { _RazonSocial = value; }
    ///        }
    ///        #endregion
    ///
    ///        #region [NombreFantasia]
    ///        [XmlElement(ElementName = "NombreFantasia", DataType = "string")]
    ///        public String NombreFantasia
    ///        {
    ///            get { return _NombreFantasia; }
    ///            set { _NombreFantasia = value; }
    ///        }
    ///        #endregion
    ///
    ///        #endregion
    ///
    ///       #region [Methods]
    ///        /// <summary>
    ///        /// Metodo estatico que retorna un objeto Clientes apartir de un xml.-
    ///        /// </summary>
    ///        /// <param name="pXml">String con el xml</param>
    ///        /// <returns>Clientes</returns>
    ///        public static Clientes GetClientesFromXml(String pXml)
    ///        {
    ///            return (Clientes)Entity.GetObjectFromXml(typeof(Clientes), pXml);
    ///        }
    ///        #endregion
    ///    }
    ///    #endregion
    /// }
    /// ]]>
    /// </code> 
    ///</example>
    /// <typeparam name="T">Cualquier objeto que implemente de IEntity <see cref="IEntity"/></typeparam>
    /// <date>2007-06-23T00:00:00</date> 
    /// <author>moviedo</author> 
    [Serializable]
    public abstract class Request<T> : ServiceContractBase<T>, IRequest
		where T : IEntity, new()
	{
        string _SecurityProviderName;

   

        /// <summary>
        /// Nombre del proveedor deseguridad
        /// Si esta en blanco se utilizara el po defecto
        /// </summary>
        public string SecurityProviderName
        {
            get { return _SecurityProviderName; }
            set { _SecurityProviderName = value; }
        }
        CacheSettings _CacheSettings = new CacheSettings ();

        /// <summary>
        /// Configuracion de cache del request
        /// </summary>
        public CacheSettings CacheSettings
        {
            get { return _CacheSettings; }
            set { _CacheSettings = value; }
        }

        private Boolean _Encrypt;

        /// <summary>
        /// Determina si el xml del request esta encriptado
        /// </summary>
        public Boolean Encrypt
        {
            get { return _Encrypt; }
            set { _Encrypt = value; }
        }

        
     
        /// <summary>
        /// Ejecuta un servicio de negocio. Utiliza el wrapper por defecto
        /// 
        /// Si se produce el error:
        /// The parameter is incorrect. (Exception from HRESULT: 0x80070057 (E_INVALIDARG))
        /// Se debe a un error que lanza una llamada asincrona en modo debug
        /// </summary>
        /// <param name="pRequest">Datos de entrada para la  ejecución del servicio.</param>
        /// <returns>Dataset con datos de respuesta del servicio.</returns>
        /// <date>2007-08-24T00:00:00</date>
        /// <author>moviedo</author>
        public virtual TResponse ExecuteService<TRequest, TResponse>(TRequest pRequest)
            where TRequest : IServiceContract
            where TResponse : IServiceContract, new()
        {

            return WrapperFactory.ExecuteService<TRequest, TResponse>(pRequest);
    
        }
        /// <summary>
        ///  Ejecuta un servicio de negocio. Utiliza el wrapper por defecto
        /// Si se produce el error:
        /// The parameter is incorrect. (Exception from HRESULT: 0x80070057 (E_INVALIDARG))
        /// Se debe a un error que lanza una llamada asincrona en modo debug 
        /// </summary>
        /// <typeparam name="TRequest"></typeparam>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="providerName">Nombre del proveedor de la metadata de servicio</param>
        /// <param name="pRequest">Request con datos de entrada para la  ejecución del servicio.</param>
        /// <returns></returns>
        public TResponse ExecuteService<TRequest, TResponse>(string providerName, TRequest pRequest)
            where TRequest : IServiceContract
            where TResponse : IServiceContract, new()
        {

            return WrapperFactory.ExecuteService<TRequest, TResponse>(providerName, pRequest);


        }
       
    }

    /// <summary>
    /// 
    /// </summary>
    [XmlInclude(typeof(DummyContract)), Serializable]
    public class DummyContract:Entity
    { 
    }
}
