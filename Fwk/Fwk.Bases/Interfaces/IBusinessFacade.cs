 using System;
using System.Collections.Generic;
using System.Text;

namespace Fwk.Bases
{
	/// <summary>
	/// Interfaz para clases que ejecutan un servicio de negocio.
	/// </summary>
	/// <remarks>
	/// Esta interfaz deberá ser implementada por todas las clases que ejecuten un servicio de negocio. 
	/// Estas clases deberán implementar el comportamiento no funcional que no es provisto por el servicio que expone los servicios de negocio (seguridad, transaccionalidad, logueo, etc).
	/// </remarks>
	public interface IBusinessFacade
	{
		/// <summary>
		/// Ejecuta un servicio de negocio.
		/// </summary>
        /// <param name="pServiceName">Nombre del servicio.</param>
		/// <param name="pData">XML con datos de entrada para el servicio.</param>
		/// <returns>XML resultado del servicio.</returns>
        string ExecuteService(string providerName ,string pServiceName, string pData);
	}
}
