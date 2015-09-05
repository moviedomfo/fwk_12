using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using Fwk.Exceptions;



namespace Fwk.Bases
{
    /// <summary>
    /// Interfaz de las contratos que utilizan los servicio.-
    /// </summary>
    /// <date>2007-06-23T00:00:00</date>
    /// <author>moviedo</author>
  	public interface IServiceContract

	{
        
        /// <summary>
        /// Interfaz de entidad 
        /// </summary>
        IEntity IEntity
        {
            get;
           
        }
        /// <summary>
        /// Indica el nombre del servicio. Este nombre debe ser igual a como esta registrado
        /// </summary>
        string ServiceName
        {
            get; set;
        }
        /// <summary>
        /// Informacion del contexto del Request o Response.-
        /// </summary>
		ContextInformation ContextInformation
		{
			get;
			set;
		}
        /// <summary>
        /// Contiene una lista de errores que se pudieran producir en la ejecucion del servicio.-
        /// </summary>
        ServiceError Error
        {
            get; 
            set;
        }
        
        /// <summary>
        /// Retorna un xml de la clase que implementa IServiceContract.-
        /// </summary>
        /// <returns>xml para establecer los valores</returns>
        string GetBusinessDataXml();

        /// <summary>
        /// Retorna un DataSet de la clase que implementa IServiceContract.-
        /// </summary>
        /// <returns>DataSet para establecer los valores</returns>
        DataSet GetBusinessData_DataSet();

        /// <summary>
        /// Inicializa la informacion de negocio del Request o Response con el contenido del xml.-
        /// </summary>
        /// <param name="pXMLBusinessData">xml</param>
        void SetBusinessDataXml(string pXMLBusinessData);

        /// <summary>
        /// Inicializa los datos contexto que pertenecen al Request o Responce con el contenido del xml.-
        /// </summary>
        /// <param name="pXMLData">xml</param>
        void  SetContextInformationXml(string pXMLData);

        /// <summary>
        /// Retorna el xml del contexto que pertenece al Request o Responce .-
        /// </summary>
        /// <returns>xml</returns>
        string  GetContextInformationXml();

        

        /// <summary>
        /// Establece los valores del Request o Responce atravez del xml
        /// </summary>
        /// <param name="pXMLService">xml para establecer los valores</param>
        void SetXml(string pXMLService);


        /// <summary>
        /// Retorna el xml del Request o Response
        /// </summary>
        /// <returns>String</returns>
        string GetXml();

        /// <summary>
        /// Retorna el DataSet del Request o Response
        /// </summary>
        /// <returns>DataSet</returns>
        DataSet GetDataSet();

        /// <summary>
        /// Clona el contrato de servicio
        /// </summary>
        /// <typeparam name="TServiceContract">Tipo de contrato que implementa IServiceContract, puede ser un request o un response </typeparam>
        /// <returns></returns>
        TServiceContract Clone<TServiceContract>() where TServiceContract : IServiceContract;

        /// <summary>
        /// Establece la informacion de inicio de contexto del Request o Responce .-
        /// </summary>
        void InitializeServerContextInformation();

        /// <summary>
        /// Establece la informacion de context del Request o Responce .-
        /// </summary>
        void InitializeHostContextInformation();
	}


    /// <summary>
    /// 
    /// </summary>
    public interface IRequest:IServiceContract
    {

        /// <summary>
        /// 
        /// </summary>
        Fwk.Caching.CacheSettings CacheSettings
        {
            get;
            set;
        }

        /// <summary>
        /// Nmbre del proveedor de seguridad
        /// </summary>
        string SecurityProviderName
        {
            get;
            set;
        }

       

    }



}
