using System;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using helper = Fwk.HelperFunctions;
using System.ComponentModel;
using System.Diagnostics;
using Fwk.Bases.Debug;

namespace Fwk.Bases
{
    /// <summary>
    /// Clase base que define el comportamiento general de todas las clases tipo Entidad.-
    /// </summary>
    /// <typeparam name="T">Tipo generico que hereda de la clase Entity y que hacepta la clase coleccion en cuestion.-</typeparam>
    /// <Author>Marcelo .F. Oviedo</Author>
    //[DebuggerVisualizer(typeof(IEntityVisualizer))]
    [Serializable]
    public  class Entities<T> : List<T>, IEntity where T : Entity
    {
        #region IEntity Members


           
        /// <summary>
        /// Obtine un xml producto de la serializacion de la coleccion Entities.-
        /// </summary>
        /// <returns>string con el xml de la serializacion</returns>
        public string GetXml()
        {
            return helper.SerializationFunctions.SerializeToXml(this);
        }


        /// <summary>
        /// Obtiene un System.DataSet producto de la deserializacion del objeto.-
        /// </summary>
        /// <returns>System.DataSet</returns>
        public DataSet GetDataSet()
        {
            DataSet wDts = new DataSet();

            String strXml = helper.SerializationFunctions.SerializeToXml(this);
            wDts.ReadXml(new StringReader(strXml));

            return wDts;
        }

        /// <summary>
        /// Metodo estatico que deserializa un objeto a partir del xml correspondiente 
        /// al esquema del objeto.-
        /// </summary>
        /// <param name="pType">Tipo de objeto a deserializar</param>
        /// <param name="pXmlData">Xml con el que se crea el objeto</param>
        /// <returns>object que hereda de Entities</returns>
        [Obsolete("A partir del framework de .net version 2.0 se debe utilizar el metodo generico GetFromXml<IEntity>() ")]
        public static object GetObjectFromXml(Type pType, string pXmlData)
        {
            return helper.SerializationFunctions.DeserializeFromXml(pType, pXmlData);
        }

        /// <summary>
        /// Retorna un objeto a partir de la instancia estatica
        /// </summary>
        /// <typeparam name="TEntities">Tipo de entidad que se decee retornar este es un type gennerico ya que el metodo esta definido en la clase base</typeparam>
        /// <param name="pXmlData">Xml del objeto que se decea retornar</param>
        /// <returns>Entidad  </returns>
        public static TEntities GetFromXml<TEntities>(string pXmlData) where TEntities : Entities<T>
        {

            return (TEntities)helper.SerializationFunctions.DeserializeFromXml(typeof(TEntities), pXmlData);
        }

        /// <summary>
        /// Rellena la clase con los valores del XML 
        /// <param name="pXmlData">Xml con el que se crea el objeto</param>
        /// <summary>
        public void SetXml(string pXmlData)
        {
            helper.SerializationFunctions.DeserializeFromXml(this.GetType(), pXmlData);
        }
        #endregion
       
       

        


        #region ICloneable Members

        /// <summary>
        /// Clona el contrato de servicio
        /// </summary>
        /// <typeparam name="TEntities">Tipo de Entities que implementa IEntity </typeparam>
        /// <returns></returns>
        public TEntities Clone<TEntities>() where TEntities : Entities<T>
        {
            return (TEntities)Fwk.HelperFunctions.SerializationFunctions.Deserialize(this.GetType(), this.GetXml());
        }
        /// <summary>
        /// Crea una copia espejo de la clase.-
        /// </summary>
        /// <returns></returns>
        public Entities<T> Clone()
        {
            return (Entities<T>)((ICloneable)this).Clone();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        object ICloneable.Clone()
        {
            return this.MemberwiseClone();
        }
        #endregion

        #region ToString
        /// <summary>
        /// Returns a <see cref="T:System.String"></see> that represents the current <see cref="T:System.Object"></see>.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"></see> that represents the current <see cref="T:System.Object"></see>.
        /// </returns>
        public override string ToString()
        {
            string s = this.GetType().Name + " Collection" + System.Environment.NewLine;
            foreach (T Item in this)
            {
                s += Item.ToString() + System.Environment.NewLine;
            }
            return s;
        }
        #endregion 
    }

    [Serializable]
    public class BaseEntities<T> : List<T>, IBaseEntity where T : BaseEntity
    {
        /// <summary>
        /// Obtine un xml producto de la serializacion de la coleccion Entities.-
        /// </summary>
        /// <returns>string con el xml de la serializacion</returns>
        public string GetXml()
        {
            return helper.SerializationFunctions.SerializeToXml(this);
        }

        /// <summary>
        /// Rellena la clase con los valores del XML 
        /// <param name="pXmlData">Xml con el que se crea el objeto</param>
        /// <summary>
        public void SetXml(string pXmlData)
        {
            helper.SerializationFunctions.DeserializeFromXml(this.GetType(), pXmlData);
        }
        #region ICloneable Members

        /// <summary>
        /// Clona el contrato de servicio
        /// </summary>
        /// <typeparam name="TEntities">Tipo de Entities que implementa IEntity </typeparam>
        /// <returns></returns>
        public TEntities Clone<TEntities>() where TEntities : BaseEntities<T>
        {
            return (TEntities)Fwk.HelperFunctions.SerializationFunctions.Deserialize(this.GetType(), this.GetXml());
        }
        /// <summary>
        /// Crea una copia espejo de la clase.-
        /// </summary>
        /// <returns></returns>
        public BaseEntities<T> Clone()
        {
            return (BaseEntities<T>)((ICloneable)this).Clone();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        object ICloneable.Clone()
        {
            return this.MemberwiseClone();
        }
        #endregion

      
    }
}
