using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Fwk.Bases;

namespace Fwk.Bases.FrontEnd
{
    /// <summary>
    /// 
    /// </summary>
    [ToolboxItem(false)]
    public partial class FwkUserControlBase : UserControl, IClientServiceBase
    {

        #region UserControlBase Properties

        private ClientServiceBase _Wrapper;

        /// <summary>
        /// 
        /// </summary>
        public ClientServiceBase Wrapper
        {
            get { return _Wrapper; }

        }

        private IBaseEntity _EntityResult = null;

        /// <summary>
        /// 
        /// </summary>
        public IBaseEntity EntityResult
        {
            get { return _EntityResult; }
            set { _EntityResult = value; }
        }
        private IBaseEntity _EntityParam = null;

        /// <summary>
        /// 
        /// </summary>
        public IBaseEntity EntityParam
        {
            get { return _EntityParam; }
            set { _EntityParam = value; }
        }
        #endregion


        /// <summary>
        /// 
        /// </summary>
        public FwkUserControlBase()
        {
            InitializeComponent();
            _Wrapper = new ClientServiceBase();
        }

        //#region IClientServiceBase Members

       
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <typeparam name="TRequest"></typeparam>
        ///// <typeparam name="TResponse"></typeparam>
        /////<param name="providerName">Proveedor del wrapper. Este valor debe coincidir con un proveedor de metadata en el dispatcher</param>
        ///// <param name="req"></param>
        ///// <returns></returns>
        //public TResponse ExecuteService<TRequest, TResponse>(string providerName, TRequest req)
        //    where TRequest : Fwk.Bases.IServiceContract
        //    where TResponse : Fwk.Bases.IServiceContract, new()
        //{
        //    return _ClientServiceBase.ExecuteService<TRequest, TResponse>(providerName, req);
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <typeparam name="TRequest"></typeparam>
        ///// <typeparam name="TResponse"></typeparam>
        ///// <param name="req"></param>
        ///// <returns></returns>
        //public TResponse ExecuteService<TRequest, TResponse>(TRequest req)
        //    where TRequest : Fwk.Bases.IServiceContract
        //    where TResponse : Fwk.Bases.IServiceContract, new()
        //{
        //    return _ClientServiceBase.ExecuteService<TRequest, TResponse>(string.Empty, req);
        //}
        //#endregion

        //#region [ServiceConfiguration]
        ///// <summary>
        ///// Recupera la configuración de todos los servicios de negocio.
        ///// </summary>
        /////<param name="providerName">Proveedor del wrapper. Este valor debe coincidir con un proveedor de metadata en el dispatcher</param>
        ///// <returns>Lista de configuraciones de servicios de negocio.</returns>
        ///// <date>2006-02-10T00:00:00</date>
        ///// <author>moviedo</author>
        //public ServiceConfigurationCollection GetAllServices(string providerName)
        //{
        //    return _ClientServiceBase.GetAllServices(providerName);
        //}
        ///// <summary>
        ///// Recupera la configuración de un servicio de negocio.
        ///// </summary>
        /////<param name="providerName">Proveedor del wrapper. Este valor debe coincidir con un proveedor de metadata en el dispatcher</param>
        ///// <param name="pServiceName">Nombre del servicio.</param>
        ///// <returns>configuración del servicio de negocio.</returns>
        ///// <date>2006-02-07T00:00:00</date>
        ///// <author>moviedo</author>
        //public ServiceConfiguration GetServiceConfiguration(string providerName ,string pServiceName)
        //{
        //    return _ClientServiceBase.GetServiceConfiguration(providerName, pServiceName);
        //}
        ///// <summary>
        ///// Actualiza la configuración de un servicio de negocio.
        ///// </summary>
        /////<param name="providerName">Proveedor del wrapper. Este valor debe coincidir con un proveedor de metadata en el dispatcher</param>
        ///// <param name="pServiceConfiguration">configuración del servicio de negocio.</param>
        ///// <param name="pServiceName">Nombre del servicio a actualizar.</param>
        ///// <date>2006-02-10T00:00:00</date>
        ///// <author>moviedo</author>
        //public void SetServiceConfiguration(string providerName,String pServiceName, ServiceConfiguration pServiceConfiguration)
        //{ _ClientServiceBase.SetServiceConfiguration(providerName, pServiceName, pServiceConfiguration); }

        ///// <summary>
        ///// Almacena la configuración de un nuevo servicio de negocio.
        ///// </summary>
        /////<param name="providerName">Proveedor del wrapper. Este valor debe coincidir con un proveedor de metadata en el dispatcher</param>
        ///// <param name="pServiceConfiguration">configuración del servicio de negocio.</param>
        ///// <date>2006-02-13T00:00:00</date>
        ///// <author>moviedo</author>
        //public void AddServiceConfiguration(string providerName,ServiceConfiguration pServiceConfiguration)
        //{ _ClientServiceBase.AddServiceConfiguration(providerName, pServiceConfiguration); }

        ///// <summary>
        ///// Elimina la configuración de un servicio de negocio.
        ///// </summary>
        /////<param name="providerName">Proveedor del wrapper. Este valor debe coincidir con un proveedor de metadata en el dispatcher</param>
        ///// <param name="pServiceName">Nombre del servicio.</param>
        ///// <date>2006-02-13T00:00:00</date>
        ///// <author>moviedo</author>
        //public void DeleteServiceConfiguration(string providerName,string pServiceName)
        //{ _ClientServiceBase.DeleteServiceConfiguration(providerName, pServiceName); }


        ///// <summary>
        ///// Obtiene una lista de todas las aplicaciones configuradas en el origen de datos configurado por el 
        ///// proveedor
        ///// </summary>
        ///// <param name="providerName">Nombre del proveedor de metadata de servicios.-</param>
        ///// <returns></returns>
        //public  List<String> GetAllApplicationsId(string providerName)
        //{
        //    return _ClientServiceBase.GetAllApplicationsId(providerName);
        //}

        //#endregion  [ServiceConfiguration]





        
    }
}
