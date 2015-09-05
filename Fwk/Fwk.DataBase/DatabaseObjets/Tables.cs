using System;
using System.Data;
using System.Linq;
using Fwk.Bases;
using System.Xml.Serialization;


namespace Fwk.DataBase.DataEntities
{
    /// <summary>
    /// 
    /// </summary>
    [XmlRoot("Tables"), SerializableAttribute]
    public class Tables : Entities<Table>
    {

        /// <summary>
        /// Metodo estatico que retorna un objeto Tables apartir de un xml.-
        /// </summary>
        /// <param name="pXml">String con el xml</param>
        /// <returns>Tables</returns>
        public static Tables GetTablesFromXml(String pXml)
        {
            return Tables.GetFromXml<Tables>(pXml); 
        }

        /// <summary>
        /// Obtienen una tabla determinada en la coleccion de tablas.-
        /// </summary>
        /// <param name="name">Nombre de la tabla.-</param>
        /// <returns></returns>
        public Table GetTable(string name)
        {
            return this.Where(p => p.Name.Equals(name)).FirstOrDefault<Table>();
        }

        /// <summary>
        /// Indica si Tables esta cargado.-
        /// </summary>
        public System.Boolean IsLoaded = false;





    }

    /// <summary>
    /// Descripción breve de Tabla.
    /// </summary>
    [XmlInclude(typeof(Table)), Serializable]
    public class Table : Entity
    {

        #region Atributos
        private int _Index;
        private string _Name;
        private string _Owner;
        private Columns _Columns = new Columns();
        private Keys _PrimaryKeys = new Keys();
        private Keys _ClavesForaneas = new Keys();
        private System.Boolean _IsColumnsLoaded = false;
        private System.Boolean _Checked = false;
        private String _Schema;
        #endregion

        #region Constructores
        /// <summary>
        /// 
        /// </summary>
      
        public Table()
        {
          
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pName"></param>
        public Table(string pName)
        {
            _Name = pName;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pName"></param>
        /// <param name="pOwner"></param>
        public Table(string pName, string pOwner)
        {
            _Name = pName;
            _Owner = pOwner;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pName"></param>
        /// <param name="pOwner"></param>
        /// <param name="pColumns"></param>
        public Table(string pName, string pOwner, Columns pColumns)
        {
            _Name = pName;
            _Owner = pOwner;
            _Columns = pColumns;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pName"></param>
        /// <param name="pOwner"></param>
        /// <param name="pColumns"></param>
        /// <param name="pPrimaryKeys"></param>
        public Table(string pName, string pOwner, Columns pColumns, Keys pPrimaryKeys)
        {
            _Name = pName;
            _Owner = pOwner;
            _Columns = pColumns;
            _PrimaryKeys = pPrimaryKeys;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pName"></param>
        /// <param name="pOwner"></param>
        /// <param name="pColumns"></param>
        /// <param name="pPrimaryKeys"></param>
        /// <param name="pClavesForaneas"></param>
        public Table(string pName, string pOwner, Columns pColumns, Keys pPrimaryKeys, Keys pClavesForaneas)
        {
            _Name = pName;
            _Owner = pOwner;
            _Columns = pColumns;
            _PrimaryKeys = pPrimaryKeys;
            _ClavesForaneas = pClavesForaneas;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Nombre del esquema al qe pertenece la tabla
        /// </summary>
        public String Schema
        {
            get { return _Schema; }
            set { _Schema = value; }
        }
        /// <summary>
        /// Selected
        /// </summary>
        [XmlElement(ElementName = "Checked", IsNullable = false, DataType = "boolean")]
        public Boolean Checked
        {
            get { return _Checked; }
            set { _Checked = value; }
        }

        /// <summary>
        /// Determina si se cargo o no las columnas de la tabla .-
        /// </summary>
        [XmlElement(ElementName = "IsColumnsLoaded", IsNullable = false, DataType = "boolean")]
        public System.Boolean IsColumnsLoaded
        {
            get { return _IsColumnsLoaded; }
            set { _IsColumnsLoaded = value; }
        }

        /// <summary>
        /// Indice del la tabla.-
        /// </summary>
        [XmlElement(ElementName = "Index", IsNullable = false, DataType = "int")]
        public int Index
        {
            get { return _Index; }
            set { _Index = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(ElementName = "Name", IsNullable = true, DataType = "string")]
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        /// <summary>
        /// Owner de la tabla.-
        /// </summary>
        [XmlElement(ElementName = "Owner", IsNullable = true, DataType = "string")]
        public string Owner
        {
            get { return _Owner; }
            set { _Owner = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Columns Columns
        {
            get { return _Columns; }
            set { _Columns = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Keys PrimaryKeys
        {
            get { return _PrimaryKeys; }
            set { _PrimaryKeys = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Keys ClavesForaneas
        {
            get { return _ClavesForaneas; }
            set { _ClavesForaneas = value; }
        }


        #endregion

        


    }


}
