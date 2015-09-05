using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fwk.Bases
{
    /// <summary>
    /// Concesva un diccionario estatico de elementos T y los instancia una sola vez
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SingletonFactoryArray<T>
    {
        Dictionary<string, SingletonFactory<T>> _dic = new Dictionary<string, SingletonFactory<T>>();

        /// <summary>
        /// Retorna un objeto tipo T.-
        /// Si esta en el diccionario se retorna esta instancia si no se crea una .- 
        /// Quien crea la instancia y pasa los parametros es la clase SingletonFactory.-
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public T Create(string key)
        {
            T genericObject;
            if (_dic.Keys.Contains(key))
                genericObject = _dic[key].GetObject();
            else
            {
                SingletonFactory<T> sf = new SingletonFactory<T>();
                _dic.Add(key, sf);
                genericObject = sf.GetObject();
            }
            return genericObject;

        }
        /// <summary>
        /// Retorna un objeto tipo T.-
        /// Si esta en el diccionario se retorna esta instancia si no se crea una .- 
        /// Quien crea la instancia y pasa los parametros es la clase SingletonFactory.-
        /// </summary>
        /// <param name="key">Nombre clave del objeto</param>
        /// <param name="constructorParams">Parametros del contructor la clase T</param>
        /// <returns></returns>
        public T Create(string key, object[] constructorParams)
        {
            T genericObject;
            if (_dic.Keys.Contains(key))
                genericObject = _dic[key].GetObject();
            else
            {
                SingletonFactory<T> sf = new SingletonFactory<T>(constructorParams);
                _dic.Add(key, sf);
                genericObject = sf.GetObject();
            }
            return genericObject;

        }

        /// <summary>
        /// Agrega un objeto T al diccionario
        /// </summary>
        /// <param name="key">Nombre clave del objeto</param>
        /// <param name="objetc">Objeto del tipo T </param>
        public void Add(string key, T objetc)
        {
            SingletonFactory<T> sf = new SingletonFactory<T>();
            _dic.Add(key, sf);
            sf.SetObject(objetc);
        }

        /// <summary>
        /// Remueve el objeto con la clave espesificada
        /// </summary>
        /// <param name="key"></param>
        public void Remove(string key)
        {
           _dic.Remove(key);
               
        }
        public void Clear(string key)
        {
            _dic.Clear();

        }
    }


}
