using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace Fwk.Bases
{
	/// <summary>
	/// Clase base que representa un servicio de negocio abstracto. Es la clase de la que deben heredar todas aquellas clases que sean implementaciones de servicios de negocio.
	/// </summary>
	/// <remarks>Las clases que heredan de esta clase abstracta son las encargadas de orquestrar las llamadas a los distintos componentes de negocio y de laintegración con otros sistemas.</remarks>
	public abstract class BusinessService<TRequest, TResponse> 
		where TRequest : IServiceContract
        where TResponse : IServiceContract
	{
        /// <summary>
        /// Ejecuta el servicio de negocio.
        /// </summary>
        /// <param name="pServiceRequest"></param>
        /// <returns></returns>
        abstract public TResponse Execute(TRequest pServiceRequest);

	}
}
