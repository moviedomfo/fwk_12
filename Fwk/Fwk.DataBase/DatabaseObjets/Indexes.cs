using System;
using System.Data;
using System.Linq;
using Fwk.Bases;
using System.Xml.Serialization;

namespace Fwk.DataBase.DataEntities
{
    /// <summary>
    /// Indexes
    /// </summary>
    [XmlRoot("Indexes"), SerializableAttribute]
    public class Indexes : Entities<Index>
    {
        /// <summary>
        /// Metodo estatico que retorna un objeto Indexes apartir de un xml.-
        /// </summary>
        /// <param name="pXml">String con el xml</param>
        /// <returns>SPParameter</returns>
        public static Indexes GetIndexesFromXml(String pXml)
        {

            return Indexes.GetFromXml<Indexes>(pXml); 
        }

        /// <summary>
        /// Obtiene un Index de la coleccion de Indexes.-
        /// </summary>
        /// <param name="name">Nombre del indice.-</param>
        /// <returns>Index</returns>
        public Index GetIndex(string name)
        {
          return this.Where(p => p.Name.Equals(name)).FirstOrDefault<Index>();
        }
    }


	/// <summary>
	/// Descripción breve de ClavePrimaria.
	/// </summary>
    [XmlInclude(typeof(Index)), Serializable]
    public class Index : Entity 
	{
		#region Constantes
		private const string PK ="PK";
		private const string IDXO ="IDXO";
		private const string IDXF ="IDXF";
		#endregion

		private string _Name;
		private string _IndexDescription;
		private string _IndexKeys;
		private string _Type;
        private string _Description;
    
		
        /// <summary>
        /// 
        /// </summary>
        [XmlElement(ElementName = "Description", IsNullable = true, DataType = "string")]	
        public string Description
		{
            get { return _Description; }
			
		}
        /// <summary>
        /// 
        /// </summary>
        [XmlElement(ElementName = "Type", IsNullable = true, DataType = "string")]	
        public string Type
		{
			get{return _Type;}
			
		}
        /// <summary>
        /// 
        /// </summary>
        [XmlElement(ElementName = "Name", IsNullable = true, DataType = "string")]	
		public  string Name
		{
			get
			{
				return _Name;
			}
			set
			{
				_Name = value;

				
				if (_Name.Substring (0,2) ==PK)
				{
					_Type = PK;
					_Description ="Primary key";
				}
				if (_Name.Substring (0,4) ==IDXF)
				{
					_Type = IDXF;
                    _Description = "Index";
				}
				if (_Name.Substring (0,4) ==IDXO)
				{
					_Type = IDXO;
					_Description ="Index";
				}
				
			}
		}

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(ElementName = "IndexDescription", IsNullable = true, DataType = "string")]	
		public  string IndexDescription
		{
			get{return _IndexDescription;}
			set{_IndexDescription= value;}
		}
        /// <summary>
        /// 
        /// </summary>
        [XmlElement(ElementName = "IndexKeys", IsNullable = true, DataType = "string")]	
		public  string IndexKeys
		{
			get{return _IndexKeys;}
			set{_IndexKeys= value;}
		}


        
	}

}
