using System;
using System.Collections.Generic;
using System.Text;
using Fwk.Bases;
using System.Xml.Serialization;
namespace Fwk.DataBase.Interfaces
{
    /// <summary>
    /// Interface de coleccion de tablas y store procedures
    /// </summary>
    public interface IDatabaseObjetcEntities
    {

        /// <summary>
        /// Obtienen una Entity determinada en la coleccion de Entities 
        /// </summary>
        /// <param name="pItemName">Nombre del item a buscar. -</param>
        /// <returns></returns>
        IDatabaseObjetcEntity GetDatabaseObjetcEntity(string pItemName);

        /// <summary>
        /// Obtine un dataset producto de la serializacion de la clase Tables
        /// </summary>
        /// <returns>Dataset</returns>
        System.Data.DataSet GetDataSet();

        /// <summary>
        /// Obtine un xml producto de la serializacion de la clase 
        /// </summary>
        /// <returns>string con el xml de la serializacion</returns>
        string GetXml();
    	
    }

  


    /// <summary>
    /// Interfece base de una tabla o store procedure 
    /// </summary>
    public interface IDatabaseObjetcEntity
    {

        /// <summary>
        /// 
        /// </summary>
        IDatabaseObjetcEntities DatabaseObjetcItems{ get; set; }

        /// <summary>
        /// Indice dentro de la coleccion.-
        /// </summary>
        int Index { get; set; }

        /// <summary>
        /// Nombre de tabla o store procedure
        /// </summary>
        string Name { get; set; }

      
        /// <summary>
        /// Obtienen un dataset de la Entity
        /// </summary>
        /// <returns></returns>
        System.Data.DataSet GetDataSet();

        /// <summary>
        /// Obtienene un xml que representa la entidad
        /// </summary>
        /// <returns></returns>
        string GetXml();
    }

    /// <summary>
    /// 
    /// </summary>
    public interface ITable : IDatabaseObjetcEntity
    {
    
        /// <summary>
        /// Determina si se cargo o no las columnas de la tabla .-
        /// </summary>
        bool IsColumnsLoaded { get; set; }
        //string Name { get; set; }

        /// <summary>
        /// Owner de la tabla.-
        /// </summary>
        string Owner { get; set; }

        /// <summary>
        /// 
        /// </summary>
        Fwk.DataBase.DataEntities.Keys PrimaryKeys { get; set; }

        /// <summary>
        /// 
        /// </summary>
        Fwk.DataBase.DataEntities.Keys ClavesForaneas { get; set; }


        /// <summary>
        /// Columnas de la tabla .-
        /// </summary>
        Fwk.DataBase.DataEntities.Columns Columns { get; set; }

    
    }

    /// <summary>
    /// 
    /// </summary>
    public interface IStoreProcedure : IDatabaseObjetcEntity
    {
        //System.Data.DataSet GetDataSet();
        //string GetXml();

        /// <summary>
        /// Indica si se cargaron las columnas de la tabla
        /// </summary>
        bool IsParametersLoaded { get; set; }

        //string Name { get; set; }

        /// <summary>
        /// Aplicable solo a store procedure
        /// </summary>
        string Owner { get; set; }

        /// <summary>
        /// 
        /// </summary>
        Fwk.DataBase.DataEntities.SPParameters Parameters { get; set; }

        /// <summary>
        /// Texto del store procedure. Aplicable solo a store procedure. 
        /// </summary>
        string Text { get; set; }
    }




    /// <summary>
    /// Interface de coleccion de tablas y store procedures
    /// </summary>
    public interface IDatabaseObjetcItems
    {

        /// <summary>
        /// Obtienen una Entity determinada en la coleccion de Entities 
        /// </summary>
        /// <param name="pItemName">Nombre del item a buscar. -</param>
        /// <returns></returns>
        IDatabaseObjetcItem GetDatabaseObjetcItem(string pItemName);

        /// <summary>
        /// Obtine un dataset producto de la serializacion de la clase Tables
        /// </summary>
        /// <returns>Dataset</returns>
        System.Data.DataSet GetDataSet();

        /// <summary>
        /// Obtine un xml producto de la serializacion de la clase.
        /// </summary>
        /// <returns>string con el xml de la serializacion</returns>
        string GetXml();

    }




    /// <summary>
    /// interface base de de parametros o columnas
    /// </summary>
    public interface IDatabaseObjetcItem
    {
        /// <summary>
        /// Tipo de datos  System.Data.SqlDbType del Item (parametro de sp o columna)
        /// </summary>
        System.Data.SqlDbType DbSqlType { get; set; }

        /// <summary>
        /// Tamaño maximo que soporta el item (parametro de sp o columna)
        /// </summary>
        int Length { get; set; }

        /// <summary>
        /// Nombre del parametro de sp o columna.-
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Indica si parametro de sp o columna acepta nulos.-
        /// </summary>
        bool Nullable { get; set; }

        /// <summary>
        /// Indica si el parametro de sp o columna de la entidad esta seleccionada o no.-
        /// </summary>
        bool Selected { get; set; }

        /// <summary>
        /// Determina un string con el tipo del parametro de sp o columna.-
        /// </summary>
        string Type { get; set; }

    

        /// <summary>
        /// Retorna un xml de la entidad que Implementa IDatabaseObjetcItems
        /// </summary>
        /// <returns>xml</returns>
        string GetXml();

        /// <summary>
        /// Retorna un dataset de la entidad que Implementa IDatabaseObjetcItems
        /// </summary>
        /// <returns>DataSet</returns>
        System.Data.DataSet GetDataSet();
    }

    /// <summary>
    /// Interfaz para los parametros de un SP.-
    /// </summary>
    public interface ISPParameter : IDatabaseObjetcItem
    {
      
        /// <summary>
        /// Orden del parametro en el SP.-
        /// </summary>
        int ParamOrder { get; set; }

        /// <summary>
        /// 
        /// </summary>
        string Collation { get; set; }

        /// <summary>
        /// Indica la direccion del item si es de entrada o salida 
        /// Para tablas no proviene de la base dadatos esta informacion .- 
        /// </summary>
        System.Data.ParameterDirection Direction { get; set; }

        /// <summary>
        /// 
        /// </summary>
        int Prec { get; set; }

    }

    /// <summary>
    /// Interfaz para las columnas de una tabla.-
    /// </summary>
    public interface IColumn : IDatabaseObjetcItem
    {
        

        /// <summary>
        /// 
        /// </summary>
        string Computed { get; set; }

        /// <summary>
        /// 
        /// </summary>
        string CSharpDataType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        bool IsIdentity { get; set; }

        //bool IsNullable { get; set; }

        /// <summary>
        /// Indica si la columna es una clave .-
        /// </summary>
        bool KeyField { get; set; }

    }

}
