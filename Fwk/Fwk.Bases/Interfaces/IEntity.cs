using System.Data;
using System;

namespace Fwk.Bases
{
    /// <summary>
    /// Define la interfaz de todas las Entidades tipo coleccion y escalares.
    /// Es decir la interfaz de las Entities y las Entity
    /// </summary>
    public interface IEntity : IBaseEntity
    {


        /// <summary>
        ///  Obtiene un System.DataSet 
        /// </summary>
        /// <returns></returns>
        DataSet GetDataSet();

  
    }
    /// <summary>
    /// Define la interfaz de todas las Entidades tipo coleccion y escalares.
    /// Es decir la interfaz de las Entities y las Entity
    /// </summary>
    public interface IBaseEntity : ICloneable
    {
        /// <summary>
        /// Obtine un xml producto de la serializacion de la coleccion Entities.-
        /// </summary>
        /// <returns>string con el xml de la serializacion</returns>
        string GetXml();

        /// <summary>
        /// Rellena la clase con los valores del XML 
        /// <param name="pXmlData">Xml con el que se crea el objeto</param>
        /// </summary>
        void SetXml(string pXmlData);

    

    }
   
}