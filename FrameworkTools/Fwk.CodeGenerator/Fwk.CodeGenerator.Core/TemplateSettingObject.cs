using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Text;

namespace Fwk.CodeGenerator
{
    [TypeConverterAttribute(typeof(ExpandableObjectConverter))]
    public class TemplateSettingObject
    {
        private Project _TableDataGateway;
        private StoreProceduresPattern _StoreProcedures;
        private Entities _Entities;
        private MethodsName _MethodsName;
        private Methods _Methods;
        private String _FullFileName;
        private Others _OthersSettings;

        public Others OthersSettings
        {
            get { return _OthersSettings; }
            set { _OthersSettings = value; }
        }
        public  StoreProceduresPattern StoreProcedures
        {
            get { return _StoreProcedures; }
            set { _StoreProcedures = value; }
        }


        public Project Project
        {
            get { return _TableDataGateway; }
            set { _TableDataGateway = value; }
        }



        public MethodsName MethodsName
        {
            get { return _MethodsName; }
            set { _MethodsName = value; }
        }



        public Entities Entities
        {
            get { return _Entities; }
            set { _Entities = value; }
        }


        public Methods Methods
        {
            get { return _Methods; }
            set { _Methods = value; }
        }

        public String FullFileName
        {
            get { return _FullFileName; }
            set { _FullFileName = value; }
        }

        public String FileName
        {
            get { return System.IO.Path.GetFileName(_FullFileName); ; }
           
        }
        public TemplateSettingObject()
        {
            _TableDataGateway = new Project();
            _StoreProcedures = new StoreProceduresPattern();
            _Entities = new Entities();
            _MethodsName = new MethodsName();
            _Methods = new Methods();
            _OthersSettings = new Others();
        }
        public TemplateSettingObject Clone()
        {
            TemplateSettingObject wTemplateSettingObject = new TemplateSettingObject();

            wTemplateSettingObject._MethodsName = this._MethodsName;
            wTemplateSettingObject._StoreProcedures  = this._StoreProcedures;
            wTemplateSettingObject._TableDataGateway = this._TableDataGateway;
            wTemplateSettingObject._Entities = this.Entities;
            wTemplateSettingObject._Methods = this._Methods;
            wTemplateSettingObject._MethodsName = this._MethodsName;
            wTemplateSettingObject._FullFileName = this._FullFileName;
            wTemplateSettingObject._OthersSettings = this._OthersSettings;
            return wTemplateSettingObject;
        }
    }


    [TypeConverterAttribute(typeof(ExpandableObjectConverter))]
    public class Project
    {
        private String _ProjectName = "MyProject";
        private String _BusinessEntities = "Common.BE";
        private String _InterfaceServices = "Common.ISVC";
        private String _BusinessService = "BackEnd.SVC";
        private String _BusinessComponents = "BackEnd.BC";
        private String _DataAccessComponent = "BackEnd.DAC";

        [Description("Nombre del proyecto")]
        [Category("Project")]
        public String ProjectName
        {
            get { return _ProjectName; }
            set {
                _ProjectName = value;

                _BusinessComponents = string.Concat(_ProjectName, @".Backend.BC");
                _BusinessEntities = string.Concat(_ProjectName, @".Common.BE");
                _DataAccessComponent = string.Concat(_ProjectName, @".Backend.DAC");
                _InterfaceServices = string.Concat(_ProjectName, @".Common.ISVC");
                _BusinessService = string.Concat(_ProjectName, @".Backend.SVC");
            }
        }

        [Description("SVC Namespace")]
        [Category("Project")]
        public String BusinessService
        {
            get { return string.Concat(_ProjectName, @".Backend.SVC"); }
       
        }
        [Description("BC Namespace")]
        [Category("Project")]
        public String BusinessComponents
        {
            get { return _BusinessComponents = string.Concat(_ProjectName, @".Backend.BC"); ; }
           
        }


        [Description("DAC Namespace")]
        [Category("Project")]
        public String DataAccessComponent
        {
            get { return _DataAccessComponent = string.Concat(_ProjectName, @".Backend.DAC"); ; }
       
        }
     

        [Description("ISVC Namespace")]
        [Category("Namespaces")]
        public String InterfaceServices
        {
            get { return _InterfaceServices = string.Concat(_ProjectName, @".Common.ISVC"); ; }
         
        }

        [Description("Entities Namespace")]
        [Category("Project")]
        public String BusinessEntities
        {
            get { return _BusinessEntities = string.Concat(_ProjectName, @".Common.BE"); ; }
 
        }



        public override string ToString()
        {
            return "Inserte aquí el nombre del proyecto o aplicacion .-";
        }
    }

   

    [TypeConverterAttribute(typeof(ExpandableObjectConverter))]
    public class Entities
    {
        String _CollectionsSufix = "List";

        [Description("Indica como se identifican las clases tipo Entities. ej: ClienteSBE")]
        public String CollectionsSufix
        {
            get { return _CollectionsSufix; }
            set { _CollectionsSufix = value; }
        }
        
        String _EntitySufix = "BE";
        

        [Description("Indica como se identifican las clases tipo Entity. ej: ClienteBE")]
        public String EntitySufix
        {
            get { return _EntitySufix; }
            set { _EntitySufix = value; }
        }

        private String _BusinessDataSufix = "";
        [Description("Indica como se identifican las clases tipo Entity pero dentro de una interfaz de servicio. ej: ClienteBE")]
        public String BusinessDataSufix
        {
            get { return _BusinessDataSufix; }
            set { _BusinessDataSufix = value; }
        }

        private String _BusinessDataCollectionSufix = "List";
        [Description("Indica como se identifican las clases tipo Entities pero dentro de una interfaz de servicio. ej: ClienteBE")]
        public String BusinessDataCollectionSufix
        {
            get { return _BusinessDataCollectionSufix; }
            set { _BusinessDataCollectionSufix = value; }
        }


        public override string ToString()
        {
            return "Define el prefijo o sufijo de las clases IEntity. ej: ClientBE para la entidad  ClientList para su colección.";
        }


    }

    [TypeConverterAttribute(typeof(ExpandableObjectConverter))]
    public class Others
    {
        String _ConnectionStringKey = "ConnectionStringKey";

        public String ConnectionStringKey
        {
            get { return _ConnectionStringKey; }
            set { _ConnectionStringKey = value; }
        }

        public override string ToString()
        {

            return String.Empty;
        }
    }
    [TypeConverterAttribute(typeof(ExpandableObjectConverter))]
    public class MethodsName
    {
        String _Insert = "Insert";
        public String Insert
        {
            get { return _Insert; }
            set { _Insert = value; }
        }

        String _Delete = "Delete";
        public String Delete
        {
            get { return _Delete; }
            set { _Delete = value; }
        }

        String _Update = "Update";
        public String Update
        {
            get { return _Update; }
            set { _Update = value; }
        }

        

        String _SearchByParam = "SearchByParam";
        public String SearchByParam
        {
            get { return _SearchByParam; }
            set { _SearchByParam = value; }
        }

      

        public override string ToString()
        {
            //return "Methods name to use in generated backend code";
            return "Nombre de los métodos para los componentes de backend";
        }
    }



    [TypeConverterAttribute(typeof(ExpandableObjectConverter))]
    public class StoreProceduresPattern
    {
        private String _DeleteSufix = "_d";

        public String DeleteSufix
        {
            get { return _DeleteSufix; }
            set { _DeleteSufix = value; }
        }
        private String _UpdateSufix = "_u";

        public String UpdateSufix
        {
            get { return _UpdateSufix; }
            set { _UpdateSufix = value; }
        }
        private String _InsertSufix = "_i";

        public String InsertSufix
        {
            get { return _InsertSufix; }
            set { _InsertSufix = value; }
        }
        private String _SearchByParamSufix = "_s";

        public String SearchByParamSufix
        {
            get { return _SearchByParamSufix; }
            set { _SearchByParamSufix = value; }
        }
       

      

      

        public override string ToString()
        {
            //return "Store procedure sufix pattern";
            return "Sufijos o prefijos de los SPs. Ej: Insert_i";
        }

    }

    [TypeConverterAttribute(typeof(ExpandableObjectConverter))]
    public class Methods
    {
        private Boolean _IncludeInsert = true;

        public Boolean IncludeInsert
        {
            get { return _IncludeInsert; }
            set { _IncludeInsert = value; }
        }
        private Boolean _IncludeDelete = true;

        public Boolean IncludeDelete
        {
            get { return _IncludeDelete; }
            set { _IncludeDelete = value; }
        }
        private Boolean _IncludeUpdate = true;

        public Boolean IncludeUpdate
        {
            get { return _IncludeUpdate; }
            set { _IncludeUpdate = value; }
        }
       
        private Boolean _IncludeSearchByParam = true;

        public Boolean IncludeSearchByParam
        {
            get { return _IncludeSearchByParam; }
            set { _IncludeSearchByParam = value; }
        }
      


        private Boolean _GenerateBatch = true;
        
        
        [Description("Establece si se insertan en forma de batch")]
        public Boolean GenerateBatch
        {
            get { return _GenerateBatch; }
            set { _GenerateBatch = value; }
        }


        public override string ToString()
        {
            return "Configuracion de motodos en el backend";
        }
    }

}
