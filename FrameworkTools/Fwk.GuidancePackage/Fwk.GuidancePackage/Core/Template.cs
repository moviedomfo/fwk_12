using System;
using System.Linq;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Fwk.Guidance.Core
{
    /// <summary>
    /// Coleccion de objetos Template, hereda de System.Collections.Generic.List<>
    /// </summary>
    //[XmlRoot("TemplateDocument"), SerializableAttribute]
    public class TemplateDocument : List<Template>
    {

        /// <summary>
        /// Obtienen una tabla determinada en la coleccion de tablas.-
        /// </summary>
        /// <param name="pTemplateName">Nombre de la tabla.-</param>
        /// <returns></returns>
        internal Template GetTemplate(string pTemplateName)
        {
            return this.First(p => p.Name == pTemplateName);
        }


       

    }

    //[XmlInclude(typeof(Template)), Serializable]
    public class Template 
    {
        private string _Name;

        //[XmlAttribute("name")]
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        private string _Content;
       
        
        /// <summary>
        /// Es el template en si.- este atributo se llama Body en el xml.-
        /// </summary>
        public string Content
        {
            get { return _Content; }
            set { _Content = value; }
        }

     
    }


    ////[XmlRoot("MappingTypes"), SerializableAttribute]
    public class MappingTypes : List<MappingType>
    {
        internal bool ExistMappingType_sqlname(string sqlname)
        {
                return this.Exists(p => p.Sqlname.Equals(sqlname, StringComparison.OrdinalIgnoreCase));
        }

        internal MappingType GetMappingType_sqlname(string sqlname)
        {
            if (string.IsNullOrEmpty(sqlname))
                return null;
            else
                return this.First(p => p.Sqlname.Equals(sqlname, StringComparison.OrdinalIgnoreCase));
        }

        internal MappingType GetMappingType_dbtype(string dbname)
        {
            return this.First(p => p.DBtype.Equals(dbname,StringComparison.OrdinalIgnoreCase));
        }


       

    }

    ////[XmlInclude(typeof(MappingType)), Serializable]
    public class MappingType
    {

       public  MappingType()
        { }
       public MappingType(string psqlname, string pcshrarptype,  string pdbtype,string ptargetschematype, string pparameterpattern)
       {
           sqlname = psqlname;
           cshrarptype = pcshrarptype;
           dbtype =pdbtype;
           parameterpattern =pparameterpattern;
       }
         string sqlname;

         //    //[XmlAttribute("sqlname")]
        public string Sqlname
        {
            get { return sqlname; }
            set { sqlname = value; }
        }

        string cshrarptype;
        ////[XmlAttribute("cshrarptype")]
        public string Cshrarptype
        {
            get { return cshrarptype; }
            set { cshrarptype = value; }
        }

        string dbtype;
        //[XmlAttribute("dbtype")]
        public string DBtype
        {
            get { return dbtype; }
            set { dbtype = value; }
        }

        string parameterpattern;
        //[XmlAttribute("parameterpattern")]
        public string Parameterpattern
        {
            get { return parameterpattern; }
            set { parameterpattern = value; }
        }

       


    }

    

}

