using System;
using Fwk.Bases;
using System.Collections.Generic;

namespace Fwk.Bases
{
    /// <summary>
    /// Clase bases de los Responses
    /// </summary>
    /// <typeparam name="T">Cualquier objeto que implemente de IEntity <see cref="IEntity"/></typeparam>
    /// <date>2007-06-23T00:00:00</date>
    /// <author>moviedo</author>
    [Serializable]
    public abstract class Response<T> : ServiceContractBase<T> where T : IBaseEntity, new()
	{
       
    }

}
