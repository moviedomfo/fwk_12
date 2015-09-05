using System;
using System.Collections.Generic;
using System.Text;


namespace Fwk.Bases
{
	/// <summary>
	/// Interfaz para clases para leer y escribir configuración de servicios de negocio.
	/// </summary>
	/// <remarks>
	/// Esta interfaz deberá ser implementada por todas las clases que interactúan con las fachadas de negocio, siendo utilizadas para realizar lecturas y escrituras de configuración de servicios de negocio.
	/// Cada Implementación deberá ser específica para un tipo de repositorio determinado: archivo xml, base de datos, múltiples archivos de recursos, etc.
	/// </remarks>
	/// <date>2008-04-07T00:00:00</date>
	/// <author>moviedo</author>
	public interface IServiceConfigurationManager
	{
        /// <summary>
        /// 
        /// </summary>
        //string Tag { get; set; }
      
		/// <summary>
		/// Recupera la configuración de un servicio de negocio.
		/// </summary>
		/// <param name="pServiceName">Nombre del servicio.</param>
		/// <returns>configuración del servicio de negocio.</returns>
		/// <date>2008-04-07T00:00:00</date>
		/// <author>moviedo</author>
        ServiceConfiguration GetServiceConfiguration(string pServiceName);

		/// <summary>
		/// Recupera la configuración de todos los servicios de negocio.
		/// </summary>
		/// <returns>Lista de configuraciones de servicios de negocio.</returns>
		/// <date>2010-08-10T00:00:00</date>
		/// <author>moviedo</author>
        ServiceConfigurationCollection GetAllServices(string pApplicationId);


		/// <summary>
		/// Actualiza la configuración de un servicio de negocio.
		/// </summary>
		/// <param name="pServiceConfiguration">configuración del servicio de negocio.</param>
        /// <param name="pServiceName">Nombre del servicio a actualizar.</param>
		/// <date>2010-08-10T00:00:00</date>
		/// <author>moviedo</author>
		void SetServiceConfiguration(string pServiceName,ServiceConfiguration pServiceConfiguration);

		/// <summary>
		/// Almacena la configuración de un nuevo servicio de negocio.
		/// </summary>
		/// <param name="pServiceConfiguration">configuración del servicio de negocio.</param>
		/// <date>2008-04-13T00:00:00</date>
		/// <author>moviedo</author>
		void AddServiceConfiguration(ServiceConfiguration pServiceConfiguration);

		/// <summary>
		/// Elimina la configuración de un servicio de negocio.
		/// </summary>
		/// <param name="pServiceName">Nombre del servicio.</param>
		/// <date>2008-04-13T00:00:00</date>
		/// <author>moviedo</author>
		void DeleteServiceConfiguration(string pServiceName);
	}
}
