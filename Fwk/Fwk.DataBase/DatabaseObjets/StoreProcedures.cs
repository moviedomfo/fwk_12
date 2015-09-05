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
    [XmlRoot("StoreProcedures"), SerializableAttribute]
    public class StoreProcedures : Entities<StoreProcedure> 
    {

        /// <summary>
        /// Metodo estatico que retorna un objeto StoreProcedure apartir de un xml.-
        /// </summary>
        /// <param name="pXml">String con el xml</param>
        /// <returns>StoreProcedure</returns>
        public static StoreProcedure GetStoreProcedureFromXml(String pXml)
        {
            return StoreProcedure.GetFromXml<StoreProcedure>(pXml);
        }

        /// <summary>
        /// Obtienen el StoreProcedure de la coleccion StoreProcedures.-
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public StoreProcedure GetStoreProcedure(string name)
        {
            return this.Where(p => p.Name.Equals(name)).FirstOrDefault<StoreProcedure>();
        }
        /// <summary>
        /// Indica si StoreProcedure se cargo
        /// </summary>
        public System.Boolean IsLoaded = false;

    }

    /// <summary>
    /// 
    /// </summary>
    [XmlInclude(typeof(StoreProcedure)), Serializable]
    public class StoreProcedure : Entity
    {
        #region  privatge members
        private int _Index;
        private string _Name;
        private string _Owner;
        private SPParameters _Params;
        private string _Text;
        private System.Boolean _IsParametersLoaded = false;
        private System.Boolean _Checked = false;
        private String _Schema = String.Empty;

       
       
        #endregion

        #region Constructores
        /// <summary>
        /// Costructor.-
        /// </summary>
        public StoreProcedure()
        {
            _Params = new SPParameters();
        }

        #endregion

        #region Properiades
        /// <summary>
        /// 
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
        /// Indice del sp.-.-
        /// </summary>
        [XmlElement(ElementName = "Index", IsNullable = false, DataType = "int")]
        public int Index
        {
            get { return _Index; }
            set { _Index = value; }
        }

        /// <summary>
        /// Parametros de entrada y salida del store procedure.-
        /// </summary>
        public SPParameters Parameters
        {
            get { return _Params; }
            set { _Params = value; }

        }

        /// <summary>
        /// Nombre store procedure.-
        /// </summary>
        [XmlElement(ElementName = "Name", IsNullable = true, DataType = "string")]
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }

        }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(ElementName = "Owner", IsNullable = true, DataType = "string")]
        public string Owner
        {
            get { return _Owner; }
            set { _Owner = value; }
        }

        /// <summary>
        /// Script del store procedure.-
        /// </summary>
        [XmlElement(ElementName = "Text", IsNullable = true, DataType = "string")]
        public string Text
        {
            get { return _Text; }
            set { _Text = value; }


        }
        /// <summary>
        /// Determina si se le cargaron los parametros a este store procedure.-
        /// </summary>
        [XmlElement(ElementName = "IsParametersLoaded", IsNullable = false, DataType = "boolean")]
        public System.Boolean IsParametersLoaded
        {
            get { return _IsParametersLoaded; }
            set { _IsParametersLoaded = value; }
        }
        #endregion

        

        
    }

}
