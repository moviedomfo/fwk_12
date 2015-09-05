using System;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Fwk.Bases;
using System.Xml.Serialization;

namespace Fwk.DataBase.DataEntities
{
   

    /// <summary>
    /// Coleccion de tipos de datos de SQL que son deficidos por el usuario
    /// </summary>
    [XmlRoot("UserDefinedTypes"), SerializableAttribute]
    public class UserDefinedTypes : Entities<UserDefinedType>
    {

       

        /// <summary>
        /// Obtiene una UserDefinedType de la coleccion de UserDefinedTypes .-
        /// </summary>
        /// <param name="name">Nombre del tipo definido por el usuario-</param>
        /// <returns>UserDefinedType</returns>
        public UserDefinedType GetUserDefinedType(string name)
        {
            return this.Where(p => p.Name.Equals(name)).FirstOrDefault<UserDefinedType>();
        }
    }

    /// <summary>
    /// Clase que reprecenta la un tipodefinido por el usuario.- Es un tipo de dato customizado.-
    /// </summary>
    [XmlInclude(typeof(UserDefinedType)), Serializable]
    public class UserDefinedType : Entity
    {
        private string _Name;
        private string _Schema;
        private Int32 _Length;
        private Int32 _NumericPrecision;
        private string _SystemType;

      
        private Boolean _Nullable;
        
        /// <summary>
        /// Nombre del tipo
        /// </summary>
        public UserDefinedType()
        {
        }
        /// <summary>
        /// Tipo del sistema que conforma el tiipo de dato definido por el usuario.-
        /// </summary>
        public string SystemType
        {
            get { return _SystemType; }
            set { _SystemType = value; }
        }
        /// <summary>
        /// Nombre del tipo definido por el usuario.-
        /// </summary>
        [XmlElement(ElementName = "Name", IsNullable = true, DataType = "string")]
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        /// <summary>
        /// Esquema al que pertenece el tipo definido por el usuario.-
        /// </summary>
        [XmlElement(ElementName = "Schema", IsNullable = true, DataType = "string")]
        public string Schema
        {
            get { return _Schema; }
            set { _Schema = value; }
        }

        /// <summary>
        /// Largo del tipo definido por el usuario.-
        /// </summary>
        public Int32 Length
        {
            get { return _Length; }
            set { _Length = value; }
        }

        /// <summary>
        /// Precicion
        /// </summary>
        public Int32 NumericPrecision
        {
            get { return _NumericPrecision; }
            set { _NumericPrecision = value; }
        }


        /// <summary>
        /// indica si este tipo de datos acepta nulos o no.-
        /// </summary>
        public Boolean Nullable
        {
            get { return _Nullable; }
            set { _Nullable = value; }
        }
    }
}
