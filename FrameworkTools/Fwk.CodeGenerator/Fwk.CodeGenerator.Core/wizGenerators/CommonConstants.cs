using System;
using System.Collections.Generic;
using System.Text;

namespace Fwk.CodeGenerator
{

    public class CodeGeneratorCommon
    {

        /// <summary>
        /// Boton del wizard
        /// </summary>
        public enum WizardButton
        {
            Ok = 0,
            Cancel = 1,
            Next = 2,
            Back = 3
        }

        public class CommonConstants
        {
            #region [constantes]


            public const string CONST_ENTER = "\r\n";
            public const char CONST_TAB = '\t';
            public const string CONST_TABLE_NAME = "[TableName]";
            public const string CONST_TYPENAME = "[TYPENAME]";
            public const string CONST_SCHEMATYPENAME = "[SCHEMATYPENAME]";


            public const string CONST_VALUETAG = "[VALUETAG]";

            public const string CONST_ENTITY_NAME = "[EntityName]";
            public const string CONST_ENTITY_PROPERTY_NAME = "[Property_Name]";
            public const string CONST_ENTITY_PUBLIC_PROPERTY_BODY = "[PROPERTY_BODY]";
            public const string CONST_ENTITY_PRIVATE_MEMBERS_BODY = "[PRIVATE_BODY]";



            public const string CONST_BODY = "[BODY]";

            public const string CONST_STOREDPROCEDURE_NAME = "[StoredProcedureName]";

            public const string CONST_AUTHOR = "[Author]";
            public const string CONST_DESCRIPTION = "[Description]";
            public const string CONST_CREATION_DATETIME = "[CreationDate]";


            public const string CONST_NAMESPACE = "[Namespace]";



            public const string CONST_BACK_END_METHOD_NAME = "[MethodName]";
            public const string CONST_BACK_END_RETURN = "[Return]";
            public const string CONST_BACK_CnnStringKey = "[CnnStringKey]";

            public const string CONST_CHILDS_ITERATION = "[ChildsIteration]";

            public const string CONST_SERVICE_NAME = "$servicename$";
            public const string CONST_FwkProject_NAME = "$fwkprojectname$";
            public const string CONST_SERVICE_RES_CLASS = "[RESClass]";
            public const string CONST_SSERVICE_REQ_CLASS = "[REQClass]";
            public const string CONST_SERVICE_REQUEST_CLASS = "[RequestClass]";
            public const string CONST_SERVICE_RESPONSE_CLASS = "[ResponseClass]";
            public const string CONST_SERVICE_CLASS = "[ServiceClass]";
            public const string CONST_SERVICE_BussinessData = "[BussinessData]";


            #endregion
        }



        /// <summary>
        /// Capa a la que pertenece un componente.
        /// </summary>
        /// <author>Marcelo Oviedo</author>
        public enum ComponentLayer
        {
            /// <summary>
            /// Business entity.
            /// </summary>
            BE,
            /// <summary>
            /// Business component.
            /// </summary>
            BC,
            /// <summary>
            /// Data access component.
            /// </summary>
            DAC,

            /// <summary>
            /// Service
            /// </summary>
            SVC,
            /// <summary>
            /// Common interfaces
            /// </summary>
            ISVC,

            /// <summary>
            /// Common interfaces
            /// </summary>
            SP
        }

        public enum GeneratorsType
        {
            BackEnd = 0,
            Entities = 1,
            Services = 2
        }

        public enum TemplateType
        {
            StoreProcedure = 0,
            DataAccesComponent = 1,
            BussinesEntity = 2,
            Namespaces = 3
        }
     

        /// <summary>
        /// Acción a realizar por un procedimiento almacenado.
        /// </summary>
        /// <remarks>
        /// Se utiliza en el proceso de generación de código de procedimientos almacenados. Los tipos de acciones pueden dividirse en dos conjuntos: <b>built-in</b> (<see cref="Insert"/>, <see cref="Update"/>, <see cref="Delete"/>, <see cref="Get"/>, <see cref="GetAll"/> y <see cref="GetAllPaginated"/>) y <b>generados por el usuario</b> (<see cref="GetByParam"/> y <see cref="Other"/>). La diferencia radica en el proceso de construcción de código a seguir de acuerdo al tipo de Acción de cada método, en los del primer tipo el usuario no tiene ningún control acerca de las opciones de generación (salvo lo que se pueda modificar mediante la alteración de los templates), mientras que el los del segundo tiene mayor libertad para definir las propiedades de cada método.
        /// </remarks>
        /// <author>Marcelo Oviedo</author>
        [Flags()]
        public enum MethodActionType
        {
            /// <summary>
            /// Inserción de un registro.
            /// </summary>
            Insert = 1,
            /// <summary>
            /// Actualización de un registro.
            /// </summary>
            Update = 2,
            /// <summary>
            /// Borrado de un registro.
            /// </summary>
            Delete = 4,
            /// <summary>
            /// Búsqueda de un registro por clave primaria.
            /// </summary>
            Get = 8,

            /// <summary>
            /// Búsqueda de todos los registros de la tabla por páginas.
            /// </summary>
            SearchAllPaginated = 32,
            /// <summary>
            /// Búsqueda por parámetros.
            /// </summary>
            GetByParam = 64,
            /// <summary>
            /// Otro tipo de Acción.
            /// </summary>
            SearchByParam = 128
        }
        public enum SelectedObject
        {
            Tables = 0,
            StoreProcedures = 1,
            Schema = 2,
            Views = 3
        }
   


        public static Boolean ValidateFileByExtencion(string pExtencion, string pFullNemeFile)
        {
            if (!System.IO.File.Exists(pFullNemeFile)) return false;
            if (pFullNemeFile.Length > 3)
            {
                if (pFullNemeFile.Substring(pFullNemeFile.Length - 3, 3).ToLower() != pExtencion.ToLower()) return false;
            }
            else
                return false;

            return true;

        }


    }
}
