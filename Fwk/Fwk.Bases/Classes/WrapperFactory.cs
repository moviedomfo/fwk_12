using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.HelperFunctions;
using Fwk.Exceptions;
using Fwk.Caching;
using System.Configuration;
using Fwk.ConfigSection;
using System.Net;

namespace Fwk.Bases
{
    /// <summary>
    /// Esta clace es utilizada por la clase generica Request la cual permite compartir un wrapper estatico entre 
    /// todos los request.-
    /// Cuando las llamadas a servicios es a travez de la clase request se utiliza esta clase
    /// </summary>
    public static class WrapperFactory
    {

        /// <summary>
        /// Representa los diferentes wrapers de la aplicacion cliente
        /// se crea uno por FwkWrapperProvider
        /// </summary>
        internal static Dictionary<string, IServiceWrapper> _WraperPepository;

        /// <summary>
        /// Seccion de configuracion de wrapper
        /// </summary>
        static WrapperProviderSection _ProviderSection;

        /// <summary>
        /// Seccion de configuracion de wrapper
        /// </summary>
        public static WrapperProviderSection ProviderSection
        {
            get { return WrapperFactory._ProviderSection; }

        }
        /// <summary>
        /// Se utiliza este miembro solo para poder cambiar el provider por defecto entiempo de ejecución. 
        /// El _ProviderSection.DefaultProvider no puede ser swichado luego de inicializar la aplicación
        /// </summary>
        static string _DefaultProviderName = String.Empty;

        /// <summary>
        /// Establece cual sera el proveedor por defecto a utilizar en <see cref="WrapperFactory"/>
        /// Util cuando todas las llamadas al metod Execute son SIN espesificar el provider y por alguna regla o cambio 
        /// en el sistema las llamadas deben apuntar a un proveedor q no esta configurado como por defecto.-
        /// </summary>
        /// <param name="providerName"></param>
        public static void ChangeDefaultProvider(string providerName)
        {
            if (!_WraperPepository.ContainsKey(providerName))
            {
                TechnicalException te;
                if (String.IsNullOrEmpty(providerName))
                    te = new TechnicalException(string.Concat("Espesifique un nombre de  proveedor de configuración de wrapper distindo de vacio" ));
                else
                    te = new TechnicalException(string.Concat("El proveedor de configuración del wrapper ", providerName, " del lado del cliente, no existe, verifique en el archivo de configuracion si existe la seccion FwkWrapper y el proveedor mencionado"));

                te.ErrorId = "6000";
                Fwk.Exceptions.ExceptionHelper.SetTechnicalException(te, typeof(WrapperFactory));
                throw te;
            }
            _DefaultProviderName = providerName;
        }
        /// <summary>
        /// Levanta la seccion FwkWrapper.-
        /// Inicialisa el repositorio de wrappers. (no lo llena con los wrappers)
        /// </summary>
        static WrapperFactory()
        {
            
            try
            {
                //Obtiene la la configuracion del wrapper del archivo .config
                _ProviderSection = ConfigurationManager.GetSection("FwkWrapper") as WrapperProviderSection;
                
                if (_ProviderSection == null)
                {
                    TechnicalException te = new TechnicalException(string.Concat("No se puede cargar la configuracion del wrapper en el cliente, verifique si existe la seccion [FwkWrapper] en el archivo de configuracion."));
                    te.ErrorId = "6000";
                    Fwk.Exceptions.ExceptionHelper.SetTechnicalException(te, typeof(WrapperFactory));
                    throw te;
                }

                _WraperPepository = new Dictionary<string, IServiceWrapper>();
                _DefaultProviderName = _ProviderSection.DefaultProviderName;
                IServiceWrapper w = null;
                foreach (WrapperProviderElement provider in _ProviderSection.Providers)
                {
                    w = (IServiceWrapper)ReflectionFunctions.CreateInstance(provider.WrapperProviderType);
                    if (w == null)
                    {

                        TechnicalException te = new TechnicalException(string.Concat("No existe el tipo de wrapper: ", provider.WrapperProviderType));
                        te.ErrorId = "6000";
                        Fwk.Exceptions.ExceptionHelper.SetTechnicalException(te, typeof(WrapperFactory));
                        throw te;
                    }
                    w.ProviderName = provider.Name;
                    w.SourceInfo = provider.SourceInfo;
                    w.ServiceMetadataProviderName = provider.ServiceMetadataProviderName;
                    w.AppId = provider.AppId;
                    //w.DefaultCulture = provider.DefaultCulture;
                    //if (provider.Name.Equals(_DefaultProviderName))
                    //    _WraperPepository.Add(String.Empty, w);
                    //else
                        _WraperPepository.Add(provider.Name, w);

                }
            }
            catch (System.Configuration.ConfigurationErrorsException ex)
            {

                TechnicalException te = new TechnicalException(string.Concat("No se puede cargar la configuracion del wrapper en el cliente, verifique si existe la seccion [FwkWrapper] en el archivo de configuracion."), ex);
                te.ErrorId = "6000";
                Fwk.Exceptions.ExceptionHelper.SetTechnicalException(te, typeof(WrapperFactory));
                throw te;
            }




        }

        /// <summary>
        /// Ejecuta un servicio de negocio
        /// Si se produce el error:
        /// The parameter is incorrect. (Exception from HRESULT: 0x80070057 (E_INVALIDARG))
        /// Se debe a un error que lanza una llamada asincrona en modo debug  
        /// </summary>
        /// <typeparam name="TRequest">Tipo del Request</typeparam>
        /// <typeparam name="TResponse">Tipo del Response</typeparam>
        /// <param name="providerName">Proveedor del wrapper</param>
        /// <param name="pRequest">Objeto request del tipo </param>
        /// <returns></returns>
        public static TResponse ExecuteService<TRequest, TResponse>(string providerName, TRequest pRequest)
            where TRequest : IServiceContract
            where TResponse : IServiceContract, new()
        {
            TResponse wResponse = new TResponse();


            //no se utiliza mas este codigo debido q los wrappers se cargan en el constructor estatico
            //InitWrapper(providerName);//Commented because every provider was loaded on static init constructor 
            if (String.IsNullOrEmpty(providerName))
                providerName = _DefaultProviderName;

            CheckWrapperExist(providerName, wResponse);
            
            Boolean wExecuteOndispatcher = true;
            //Si no ocurrio algun error
            if (wResponse.Error == null)
            {
                IServiceContract res = null;
                IRequest req = (IRequest)pRequest;
                if (string.IsNullOrEmpty(req.ContextInformation.AppId))
                    req.ContextInformation.AppId = _WraperPepository[providerName].AppId;

                if (String.IsNullOrEmpty(req.ContextInformation.ProviderNameWithCultureInfo))
                    req.ContextInformation.ProviderNameWithCultureInfo = _WraperPepository[providerName].ConfigProviderNameWithCultureInfo;

                #region Caching del servicio.
                if (req.CacheSettings != null && req.CacheSettings.CacheOnClientSide) //--------------------------------------->>> Implement the cache factory
                {
                    try
                    {
                        res = ServiceCacheMannager.Get(req);

                        wResponse = (TResponse)res;
                        //Si estaba en la cache no es necesario llamar al despachador de servicio
                        if (wResponse != null)
                            wExecuteOndispatcher = false;
                    }
                    catch (System.Security.SecurityException)
                    {

                    }
                }
                #endregion

                if (wExecuteOndispatcher)
                {
                    try
                    {
                   
                        wResponse = _WraperPepository[providerName].ExecuteService<TRequest, TResponse>(pRequest);
                    }
                    catch (TechnicalException te)
                    {
                        if (te.ErrorId.Equals("7201"))
                            wResponse.Error = ProcessConnectionsException.Process(
                                new TechnicalException(
                                    String.Format(Fwk.Bases.Properties.Resources.Wrapper_ServiceMetadataProviderName_NotExist,
                                    _WraperPepository[providerName].ProviderName, te)));
                        else
                            wResponse.Error = ProcessConnectionsException.Process(te);

                    }
                    catch (Exception ex)
                    {
                        wResponse.Error = ProcessConnectionsException.Process(ex);
                    }

                    //Si aplica cache y se llamo a la ejecucion se debe almacenar en cache para proxima llamada
                    if (req.CacheSettings != null && req.CacheSettings.CacheOnClientSide)
                    {
                        //Es posible que la ejecucion produzca algun error y por lo tanto no se permitira 
                        //su almacen en cache
                        if (wResponse.Error == null)
                            ServiceCacheMannager.Add(req, wResponse);
                    }
                }
            }

            return wResponse;
        }

        /// <summary>
        /// Ejecuta un servicio de negocio con el proveedor de wrapper por defecto
        /// Si se produce el error:
        /// The parameter is incorrect. (Exception from HRESULT: 0x80070057 (E_INVALIDARG))
        /// Se debe a un error que lanza una llamada asincrona en modo debug  
        /// </summary>
        /// <param name="pRequest">Request con datos de entrada para la  ejecución del servicio.</param>
        /// <returns>Dataset con datos de respuesta del servicio.</returns>
        /// <date>2007-08-24T00:00:00</date>
        /// <author>moviedo</author>
        public static TResponse ExecuteService<TRequest, TResponse>(TRequest pRequest)
            where TRequest : IServiceContract
            where TResponse : IServiceContract, new()
        {
            return ExecuteService<TRequest, TResponse>(string.Empty, pRequest);
        }




        /// <summary>
        /// Inicializa un wrapper deacuerdo el nombre del proveedor
        /// Carga al wrapper el nombre
        /// </summary>
        /// <param name="providerName">Proveedor del wrapper. Este valor debe coincidir con un proveedor de metadata en el dispatcher</param>
        internal static void InitWrapper(string providerName)
        {
            //Si no se espesifica npmbre de provdor se da por entendido que se trata de un proveedor por defecto
            if (String.IsNullOrEmpty(providerName))
                providerName = _DefaultProviderName;
            if (!_WraperPepository.ContainsKey(providerName))
            {
                try
                {
                    WrapperProviderElement provider = _ProviderSection.GetProvider(providerName);

                    if (provider == null)
                    {
                        TechnicalException te;
                        if (providerName.Equals(_DefaultProviderName)) 
                            te = new TechnicalException(string.Concat("El proveedor de configuración del wrapper por defecto del lado del cliente, no existe, verifique en el archivo de configuracion si existe la seccion FwkWrapper y el proveedor por defecto"));
                        else
                            te = new TechnicalException(string.Concat("El proveedor de configuración del wrapper ", providerName, " del lado del cliente, no existe, verifique en el archivo de configuracion si existe la seccion FwkWrapper y el proveedor mencionado"));

                        te.ErrorId = "6000";
                        Fwk.Exceptions.ExceptionHelper.SetTechnicalException(te, typeof(WrapperFactory));
                        throw te;
                    }
                    ///No se almacenan mas providers con String.Empty
                    //if (provider.Name.Equals(_ProviderSection.DefaultProviderName)) providerName = String.Empty;



                    IServiceWrapper w = (IServiceWrapper)ReflectionFunctions.CreateInstance(provider.WrapperProviderType);
                    
                    w.ProviderName = provider.Name;
                    w.SourceInfo = provider.SourceInfo;
                    w.ServiceMetadataProviderName = provider.ServiceMetadataProviderName;
                    w.AppId = provider.AppId;
                    //w.DefaultCulture = provider.DefaultCulture;
                    
                    _WraperPepository.Add(providerName, w);


                }
                catch (Exception ex)
                {
                    ServiceError wServiceError = ProcessConnectionsException.Process(ex);
                    TechnicalException te = new TechnicalException(wServiceError.Assembly, wServiceError.Namespace, wServiceError.Class, wServiceError.Machine, wServiceError.UserName, wServiceError.Message, ex);

                    throw te;

                }

            }
        }

        /// <summary>
        /// Solo chequea si existe el proveedor. Si no, lanza una excepción.-
        /// </summary>
        /// <param name="providerName"></param>
        static void CheckWrapperExist(string providerName,IServiceContract res)
        {
            //Dado que el proveedor por defecto es agregado como String.Empty
            if (String.IsNullOrEmpty(providerName)) providerName = _DefaultProviderName;
            
            if (!_WraperPepository.ContainsKey(providerName))
            {
                TechnicalException te;
                 if (providerName.Equals(_DefaultProviderName)) 
                    te = new TechnicalException(string.Concat("El proveedor de configuración del wrapper por defecto del lado del cliente, no existe, verifique en el archivo de configuracion si existe la seccion FwkWrapper y el proveedor por defecto"));
                else
                    te = new TechnicalException(string.Concat("El proveedor de configuración del wrapper ", providerName, " del lado del cliente, no existe, verifique en el archivo de configuracion si existe la seccion FwkWrapper y el proveedor mencionado"));

                te.ErrorId = "6000";
                Fwk.Exceptions.ExceptionHelper.SetTechnicalException(te, typeof(WrapperFactory));
                res.Error = ProcessConnectionsException.Process(te);
            }
        }

        /// <summary>
        /// Get wrapper from IServiceWrapper factory`s dictionary
        /// </summary>
        /// <param name="providerName"></param>
        public static IServiceWrapper GetWrapper(string providerName)
        {
            if (String.IsNullOrEmpty(providerName)) providerName = _DefaultProviderName;
 
            //if (providerName.Equals(_ProviderSection.DefaultProviderName)) providerName = String.Empty;

            InitWrapper(providerName);

            //if (providerName.Equals(_ProviderSection.DefaultProviderName))
            //    return _WraperPepository[string.Empty];

            if (_WraperPepository.ContainsKey(providerName))
            {
                return _WraperPepository[providerName];
            }
            throw new Fwk.Exceptions.TechnicalException(string.Concat("No se encuentra el wrapper solicitado [", providerName, "]"));
        }



        public static Dictionary<string, IServiceWrapper> GetPepository()
        { return _WraperPepository; }
    }
}
