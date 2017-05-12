using System;
using System.IO;
using System.Data;
using System.Collections.Generic;
using System.Text;
using helper = Fwk.HelperFunctions;
using System.Reflection;
using System.Diagnostics;
using Fwk.Bases.Debug;
using System.ComponentModel;
using System.Xml.Serialization;

namespace Fwk.Bases
{
    /// <summary>
    /// Clase base abstracta que define comportamiento para las clses tipo Entidad.-
    /// Las clases tipo entidad no tienen comportamiento de negocio solo los comportamientos
    /// heredados de su clase base.-
    /// </summary>
    /// <example>
    /// <para>El siguiente ejemplo muestra un clase que hereda de la base Entity</para>
    /// <code>
    /// <![CDATA[
    ///    [XmlInclude(typeof(Cliente)), Serializable]
    ///    public class Cliente : Entity
    ///    {
    ///        #region [Private Members]
    ///        private System.Int32? _IdCliente;
    ///        private System.Int64? _CUIT;
    ///        private System.String _RazonSocial;
    ///        #endregion
    ///        #region [Properties]
    ///
    ///        #region [IdCliente]
    ///        [XmlElement(ElementName = "IdCliente", DataType = "int")]
    ///        public int? IdCliente
    ///        {
    ///            get { return _IdCliente; }
    ///            set { _IdCliente = value; }
    ///        }
    ///        #endregion
    ///
    ///        #region [CUIT]
    ///
    ///        public Int64? CUIT
    ///        {
    ///            get { return _CUIT; }
    ///            set { _CUIT = value; }
    ///        }
    ///        #endregion
    ///
    ///        #region [RazonSocial]
    ///        [XmlElement(ElementName = "RazonSocial", DataType = "string")]
    ///        public String RazonSocial
    ///        {
    ///            get { return _RazonSocial; }
    ///            set { _RazonSocial = value; }
    ///        }
    ///        #endregion
    ///
    ///        #region [NombreFantasia]
    ///        [XmlElement(ElementName = "NombreFantasia", DataType = "string")]
    ///        public String NombreFantasia
    ///        {
    ///            get { return _NombreFantasia; }
    ///            set { _NombreFantasia = value; }
    ///        }
    ///        #endregion
    ///
    ///        #endregion
    ///
    ///       #region [Methods]
    ///        /// <summary>
    ///        /// Metodo estatico que retorna un objeto Cliente apartir de un xml.-
    ///        /// </summary>
    ///        /// <param name="pXml">String con el xml</param>
    ///        /// <returns>Clientes</returns>
    ///        public static Cliente GetClientesFromXml(String pXml)
    ///        {
    ///            return (Cliente)Entity.GetObjectFromXml(typeof(Cliente), pXml);
    ///        }
    ///        #endregion
    ///    }
    ///    #endregion
    /// }
    /// ]]>
    /// </code> 
    /// <code>
    /// <![CDATA[
    ///  [XmlRoot("ClienteList"), SerializableAttribute]
    ///public class ClienteList : Entities<Cliente>
    ///{
   ///     #region [Methods]
///        /// <summary>
    ///  /// Metodo estatico que retorna un objeto ClienteList apartir de un xml.-
    ///        /// </summary>
    ///       /// <param name="pXml">String con el xml</param>
    ///       /// <returns>ClienteList</returns>
    ///      public static ClienteList GetClienteListFromXml(String pXml)
    ///      {
    ///          return (ClienteList)Entity.GetObjectFromXml(typeof(ClienteList), pXml);
    ///      }
    ///      #endregion
    ///   }
    /// ]]>
    /// </code>
    ///</example>
    /// <Author>Marcelo .F. Oviedo</Author> 
    //[DebuggerVisualizer(typeof(IEntityVisualizer))]
    [Serializable]
    public abstract class Entity : BaseEntity ,IEntity
    {
        #region  History
        List<String> _HistoryProperties;

        private IFwkHistory _IHistory;
        protected bool mBeingUndone = false;
        public Entity()
        {
            ConstructPropertiesToHistoryArray();
            if (PerformHistory())
            {
                _IHistory = new FwkMultipleEntityHistory(this);
            }
        }


       
      

        #region Perform  History

        void ConstructPropertiesToHistoryArray()
        {
            _HistoryProperties = new List<string>();
            FwkHistoryAttribute CustAttr;
            foreach (PropertyInfo wPropertyInfo in this.GetType().GetProperties())
            {
                CustAttr = (FwkHistoryAttribute)Attribute.GetCustomAttribute(wPropertyInfo, typeof(FwkHistoryAttribute));
                if (CustAttr != null)
                {
                    _HistoryProperties.Add(CustAttr.Name);
                }
            }

        }

        /// <summary>
        /// Establece una marca de historia con los valores actuales de la clase
        /// </summary>
        public void SetHistory()
        {
            ((Fwk.Bases.FwkMultipleEntityHistory)_IHistory).AddHistoryToAllProperties(_HistoryProperties.ToArray());

        }

        
        /// <summary>
        /// Solo se usa dentro de la propiedad que se quiera almacenar
        /// Este metodo agrega la propiedad al ala pila undo . 
        /// Es llamada de la clace que hereda de Entity en el metodo Set de la propiedad
        /// This method delegates the call to the mHistory.Store method 
        /// IF the Undo flag is not set.
        /// </summary>
        /// <param name="propertyName">Nombre de la propiedad /param>
        /// <param name="Value"></param>
        protected void AddHistory(string propertyName, object Value)
        {
            if (PerformHistory() && !mBeingUndone)
                ((Fwk.Bases.FwkSingleEntityHistory)_IHistory).Store(propertyName, Value);
        }

        bool PerformHistory()
        {
            return (_HistoryProperties.Count > 0 ? true : false);
        }


        /// <summary>
        /// 
        /// </summary>
        public bool CanUndo()
        {
            
                if (PerformHistory())
                    return _IHistory.CanUndo;
                else
                    return false;
            
        }
        /// <summary>
        /// 
        /// </summary>
        public bool CanRedo()
        {
            
                if (PerformHistory())
                    return _IHistory.CanRedo;
                else
                    return false;

            
        }
       
        /// <summary>
        /// 
        /// </summary>
        public void Redo()
        {
            if (PerformHistory() && _IHistory.CanRedo)
            {
                mBeingUndone = true;
                _IHistory.Redo();
                mBeingUndone = false;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public void Undo()
        {
            if (PerformHistory() && _IHistory.CanUndo)
            {
                mBeingUndone = true;
                _IHistory.Undo();
                mBeingUndone = false;
            }
        }


        #endregion
        #endregion
        #region IEntity Members

       


       
       
        /// <summary>
        /// Obtiene un System.DataSet .-
        /// </summary>
        /// <returns>DataSet</returns>
        public DataSet GetDataSet()
        {

            DataSet wDts = new DataSet(this.GetType().Name);

            String strXml = helper.SerializationFunctions.SerializeToXml(this);
            wDts.ReadXml(new StringReader(strXml));

            return wDts;
        }

        /// <summary>
        /// Obtine un xml producto de la serializacion de la clase FacturaBE
        /// </summary>
        /// <returns>string con el xml de la serializacion</returns>
        public string GetXml()
        {
            return helper.SerializationFunctions.SerializeToXml(this);
        }





        /// <summary>
        /// Metodo estatico que deserializa on objeto y retorna el xmls correspondiente
        /// </summary>
        /// <param name="pType">Tipo de objeto a deserializar</param>
        /// <param name="pXMLData">Xml con el que se crea el objeto</param>
        /// <returns>object que hereda de Entity</returns>
        [Obsolete("A partir del framework de .net version 2.0 se debe utilizar el metodo generico GetFromXml<IEntity>() ")]
        public static object GetObjectFromXml(Type pType, string pXMLData)
        {
            return helper.SerializationFunctions.DeserializeFromXml(pType, pXMLData);
        }

        /// <summary>
        /// Rellena la clase con los valores del XML :No utilizar este método
        /// <param name="pXmlData">Xml con el que se crea el objeto</param>
        /// <summary>
        [Obsolete("A partir del framework de .net version 2.0 se debe utilizar el metodo generico GetFromXml<IEntity>() ")]
        public void SetXml(string pXmlData)
        {
        }
        /// <summary>
        /// Retorna un objeto a partir de la instancia estatica
        /// </summary>
        /// <typeparam name="T">Tipo de entidad que se decee retornar este es un type gennerico ya que el metodo esta definido en la clase base</typeparam>
        /// <param name="pXmlData">Xml del objeto que se decea retornar</param>
        /// <returns>Entidad  </returns>
        public static T GetFromXml<T>(string pXmlData) where T : Entity
        {
            return (T)helper.SerializationFunctions.DeserializeFromXml(typeof(T), pXmlData);
        }
        #endregion
         
        

        #region ICloneable Members
        ///// <summary>
        ///// Crea una copia espejo de la clase.-
        ///// </summary>
        ///// <typeparam name="TEntity">Tipo de Entity que implementa IEntity </typeparam>
        ///// <returns></returns>
        //public TEntity Clone<TEntity>() where TEntity : Entity
        //{
        //    //return (TEntity)Fwk.HelperFunctions.SerializationFunctions.Deserialize(this.GetType(), this.GetXml());
        //    return (TEntity)Clone();
        //}

        ///// <summary>
        ///// Crea una copia espejo de la clase.-
        ///// </summary>
        ///// <returns></returns>
        //public Entity Clone()
        //{
        //    return (Entity)((ICloneable)this).Clone();
        //}
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <returns></returns>
        //object ICloneable.Clone()
        //{
        //    return this.MemberwiseClone();
        //}
        #endregion



        #region ToString Method

        ///<summary>
        /// Returns a String that represents the current object.
        ///</summary>
        public override string ToString()
        {
            //return string.Format(System.Globalization.CultureInfo.InvariantCulture,
            //    "{14}{13}- CustomerId: {0}{13}- CustomerRef: {1}{13}- CompanyName: {2}{13}- ContactName: {3}{13}- ContactTitle: {4}{13}- Address: {5}{13}- City: {6}{13}- Region: {7}{13}- PostalCode: {8}{13}- Country: {9}{13}- Phone: {10}{13}- Fax: {11}{13}- AuditStamp: {12}{13}{15}",
            //    this.CustomerId,
            //    this.CustomerRef,
            //    this.CompanyName,
            //    (this.ContactName == null) ? string.Empty : this.ContactName.ToString(),
            //    (this.ContactTitle == null) ? string.Empty : this.ContactTitle.ToString(),
            //    (this.Address == null) ? string.Empty : this.Address.ToString(),
            //    (this.City == null) ? string.Empty : this.City.ToString(),
            //    (this.Region == null) ? string.Empty : this.Region.ToString(),
            //    (this.PostalCode == null) ? string.Empty : this.PostalCode.ToString(),
            //    (this.Country == null) ? string.Empty : this.Country.ToString(),
            //    (this.Phone == null) ? string.Empty : this.Phone.ToString(),
            //    (this.Fax == null) ? string.Empty : this.Fax.ToString(),
            //    (this.AuditStamp == null) ? string.Empty : this.AuditStamp.ToString(),
            //    System.Environment.NewLine,
            //    this.GetType(),
            //    this.Error.Length == 0 ? string.Empty : string.Format("- Error: {0}\n", this.Error));

            return HelperFunctions.TypeFunctions.ToString(this);
        }
        /// <summary>
        /// Give a string representation of a object, with use of reflection.
        /// </summary>
        /// <param name="o">O.</param>
        /// <returns></returns>
        public static string ToString(Object o)
        {
            StringBuilder sb = new StringBuilder();
            Type t = o.GetType();

            PropertyInfo[] pi = t.GetProperties();

            sb.Append("Properties for: " + o.GetType().Name + System.Environment.NewLine);
            foreach (PropertyInfo i in pi)
            {
                try
                {
                    sb.Append("\t" + i.Name + "(" + i.PropertyType.ToString() + "): ");
                    if (null != i.GetValue(o, null))
                    {
                        sb.Append(i.GetValue(o, null).ToString());
                    }

                }
                catch
                {
                }
                sb.Append(System.Environment.NewLine);

            }

            FieldInfo[] fi = t.GetFields();

            foreach (FieldInfo i in fi)
            {
                try
                {
                    sb.Append("\t" + i.Name + "(" + i.FieldType.ToString() + "): ");
                    if (null != i.GetValue(o))
                    {
                        sb.Append(i.GetValue(o).ToString());
                    }

                }
                catch
                {
                }
                sb.Append(System.Environment.NewLine);

            }

            return sb.ToString();
        }
        #endregion ToString Method
    }


    /// <summary>
    /// 
    /// </summary>
    
    [Serializable]
    public abstract class BaseEntity : IBaseEntity
    {

        #region ICloneable Members
        /// <summary>
        /// Crea una copia espejo de la clase.-
        /// </summary>
        /// <typeparam name="TEntity">Tipo de Entity que implementa IBaseEntity </typeparam>
        /// <returns></returns>
        public TEntity Clone<TEntity>() where TEntity : BaseEntity
        {
            return (TEntity)Clone();
        }

        /// <summary>
        /// Crea una copia espejo de la clase.-
        /// </summary>
        /// <returns></returns>
        public BaseEntity Clone()
        {
            return (BaseEntity)((ICloneable)this).Clone();
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


        #region IEntity Members



        EntityState _EntityState = EntityState.Unchanged;
        /// <summary>
        /// Retorna el estado de modificacion actual de la clase 
        /// </summary>
        [BrowsableAttribute(false)]
        public EntityState EntityState
        {
            get
            {
                return _EntityState;
            }
            set
            {
                _EntityState = value;
            }
        }

        /// <summary>
        /// Obtine un xml producto de la serializacion de la clase FacturaBE
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
        [Obsolete("Utilizar en metodo estatico de la clase =  T GetFromXml<T>(string pXmlData) ")]
        public void SetXml(string pXmlData)
        {
           
        }
        /// <summary>
        /// Retorna un objeto a partir de la instancia estatica
        /// </summary>
        /// <typeparam name="T">Tipo de entidad que se decee retornar este es un type gennerico ya que el metodo esta definido en la clase base</typeparam>
        /// <param name="pXmlData">Xml del objeto que se decea retornar</param>
        /// <returns>Entidad  </returns>
        public static T GetFromXml<T>(string pXmlData) where T : BaseEntity
        {

            return (T)helper.SerializationFunctions.DeserializeFromXml(typeof(T), pXmlData);
        }
        #endregion


        #region ToString Method

        ///<summary>
        /// Returns a String that represents the current object.
        ///</summary>
        public override string ToString()
        {
            
            return HelperFunctions.TypeFunctions.ToString(this);
        }
        /// <summary>
        /// Give a string representation of a object, with use of reflection.
        /// </summary>
        /// <param name="o">O.</param>
        /// <returns></returns>
        public static string ToString(Object o)
        {
            StringBuilder sb = new StringBuilder();
            Type t = o.GetType();

            PropertyInfo[] pi = t.GetProperties();

            sb.Append("Properties for: " + o.GetType().Name + System.Environment.NewLine);
            foreach (PropertyInfo i in pi)
            {
                try
                {
                    sb.Append("\t" + i.Name + "(" + i.PropertyType.ToString() + "): ");
                    if (null != i.GetValue(o, null))
                    {
                        sb.Append(i.GetValue(o, null).ToString());
                    }

                }
                catch
                {
                }
                sb.Append(System.Environment.NewLine);

            }

            FieldInfo[] fi = t.GetFields();

            foreach (FieldInfo i in fi)
            {
                try
                {
                    sb.Append("\t" + i.Name + "(" + i.FieldType.ToString() + "): ");
                    if (null != i.GetValue(o))
                    {
                        sb.Append(i.GetValue(o).ToString());
                    }

                }
                catch
                {
                }
                sb.Append(System.Environment.NewLine);

            }

            return sb.ToString();
        }
        #endregion 
    }
}
