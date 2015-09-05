using System;
using System.Data;
using System.Linq;
using Fwk.Bases;
using System.Xml.Serialization;

namespace Fwk.DataBase.DataEntities
{
    /// <summary>
    /// Parametros de un store procedure.- 
    /// </summary>
    [XmlRoot("SPParameters"), SerializableAttribute]
    public class SPParameters : Entities<SPParameter>
    {

        /// <summary>
        /// Metodo estatico que retorna un objeto SPParameter apartir de un xml.-
        /// </summary>
        /// <param name="pXml">String con el xml</param>
        /// <returns>SPParameter</returns>
        public static SPParameters GetSPParameterFromXml(String pXml)
        {

            return Entities<SPParameter>.GetFromXml<SPParameters>(pXml); 
        }
       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public SPParameter GetSPParameter(string name)
        {
            return this.Where(p => p.Name.Equals(name)).FirstOrDefault<SPParameter>();
        }
        
    }

    /// <summary>
    /// 
    /// </summary>
    [XmlInclude(typeof(SPParameter)), Serializable]
	public class SPParameter:Entity
	{
		#region privatge members
		private Boolean _Selected=true;
		private string _Name;
		private string _Type;
		private System.Data.SqlDbType _DbSqlType;
        private Int32 _Length;
		private Int32 _Prec;
		private bool _Nullable;
		private Int32 _ParamOrder;
		private string _Collation;
		private System.Data.ParameterDirection _Direction;
        private int _Index;
		#endregion 

		#region Constructores
        /// <summary>
        /// 
        /// </summary>
		public  Boolean Selected  
		{			
			get	{return _Selected;}
			set {_Selected = value;}
		}
        /// <summary>
        /// 
        /// </summary>
		public SPParameter()
		{
		}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pName"></param>
		public SPParameter(string pName )
		{
			_Name = pName;
		}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="pName"></param>
        /// <param name="pType"></param>
        /// <param name="pLength"></param>
		public SPParameter(string pName , string pType , Int32 pLength)
		{
			_Name = pName;
			_Type = pType;
            _Length = pLength;
		}

		#endregion 

        /// <summary>
        /// Indice del Sp dentro de la coleccion.-
        /// </summary>
        [XmlElement(ElementName = "Index", IsNullable = false, DataType = "int")]
        public int Index
        {
            get { return _Index; }
            set { _Index = value; }
        }

        /// <summary>
        /// ParameterDirection
        /// </summary>
		public System.Data.ParameterDirection Direction
		{
			get{return _Direction;}
			set{_Direction = value;}
		}

        /// <summary>
        /// 
        /// </summary>
		public Int32 Length
		{
			get{return _Length;}
			set{_Length = value;}
		}

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(ElementName = "Name", IsNullable = true, DataType = "string")]					   
		public string Name
		{
			get{ return _Name;}
			set{_Name = value;}
			
		}

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(ElementName = "Type", IsNullable = true, DataType = "string")]
		public string Type
		{
			get{return _Type;}
			set
			{
				_Type = value;
				_DbSqlType = Fwk.HelperFunctions.TypeFunctions.ConvertSQLToDbSql(value);
					 
			}
		}

        /// <summary>
        /// 
        /// </summary>
		public  System.Data.SqlDbType DbSqlType 
		{
			get{return _DbSqlType;}
			set{_DbSqlType = value;}
		}

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(ElementName = "Prec", IsNullable = false, DataType = "int")]
		public Int32 Prec 
		{
			get{ return _Prec;}
			set{_Prec = value;}
		}

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(ElementName = "IsNullable", IsNullable = false, DataType = "boolean")]
		public System.Boolean Nullable
		{
			get{ return _Nullable;}
			set{_Nullable = value;}
		}

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(ElementName = "ParamOrder", IsNullable = false, DataType = "int")]
		public Int32 ParamOrder
		{
			get{return _ParamOrder;}
			set{_ParamOrder = value;}
		}

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(ElementName = "Collation", IsNullable = true, DataType = "string")]
		public string Collation 
		{
			get{return _Collation;}
			set{_Collation = value;}
		}


        


        #region [Statics methods]

        /// <summary>
        /// Obtienen la direccione de un parametro 
        /// </summary>
        /// <param name="pColum_Type">COLUMN_TYPE</param>
        /// <returns>System.Data.ParameterDirection ej. Input, Outputm, etc </returns>
        public static System.Data.ParameterDirection GetDirecction(int pColum_Type)
        {
            System.Data.ParameterDirection wDirection = new ParameterDirection();
            switch (pColum_Type)
            {
                case 1:
                    {
                        wDirection = ParameterDirection.Input;
                        break;
                    }
                case 2:
                    {
                        wDirection = ParameterDirection.Output;
                        break;
                    }

                case 4:
                    {
                        wDirection = ParameterDirection.ReturnValue;
                        break;
                    }
                case 5:
                    {
                        wDirection = ParameterDirection.ReturnValue;
                        break;
                    }
            }
            return wDirection;

        }
        #endregion



        
    }

}
