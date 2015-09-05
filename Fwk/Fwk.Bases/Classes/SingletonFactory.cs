using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.HelperFunctions;

namespace Fwk.Bases
{

    /// <summary>
    /// Clase que se encarga de crear una instancia de cualquier objeto.-
    /// No se pasan parametros 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SingletonFactory<T>
    {
        T _SomeObject;
        object[] _ConstructorParams = null;
        /// <summary>
        /// 
        /// </summary>
        public SingletonFactory()
        { 

        }

        /// <summary>
        /// Constructor con parametros que inicializaran la clase T
        /// </summary>
        /// <param name="constructorParams">Parametros del contructor la clase T</param>
        public SingletonFactory(object[] constructorParams)
        {
            _ConstructorParams = constructorParams;
        }
        /// <summary>
        /// Instancia y retorna un objeto tipo T.-
        /// </summary>
        /// <returns></returns>
        public T GetObject()
        {
            if (_SomeObject == null)
            {
                if (_ConstructorParams == null)
                    _SomeObject = (T)ReflectionFunctions.CreateInstance(string.Concat(typeof(T).FullName, ",", typeof(T).Assembly.FullName));
                else
                    _SomeObject = (T)ReflectionFunctions.CreateInstance(string.Concat(typeof(T).FullName, ",", typeof(T).Assembly.FullName), _ConstructorParams);
            }
            return _SomeObject;
        }

        /// <summary>
        /// Establece el valor del objeto T
        /// </summary>
        /// <param name="someObject"></param>
        public void  SetObject(T someObject)
        {
            _SomeObject = someObject;
        }
    }

}
