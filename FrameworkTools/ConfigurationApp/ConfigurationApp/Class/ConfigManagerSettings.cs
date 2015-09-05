//using System;
//using System.ComponentModel;
//using System.Text;

//namespace ConfigurationApp
//{
//    /// <summary>
//    /// Clase qque reprecenta un setting de configuracion
//    /// </summary>
//    internal class Settings
//    {
//        private string _SectionName;
//        private string _Name;
//        private string _Value;

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="Name">Nombre</param>
//        /// <param name="SectionName">Nombre de la seccion a la que pertenece</param>
//        public Settings(string Name, string SectionName)
//        {
//            _Name = Name;
//            _SectionName = SectionName;
//        }
//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="Name">Nombre del Setting</param>
//        public Settings(string Name)
//        {
//            _Name = Name;
            
//        }
//        [Description("Nombre de la seccion a la que pertenece")]
//        public string SectionName
//        {
//            get { return _SectionName; }

//        }
//        [Description("Nombre del Setting")]
//        public string Name
//        {
//            get { return _Name; }
            
//        }

//        [Description("Valor de configuracion que asume")]
//        public string Value
//        {
//            get { return _Value; }
//            set { _Value = value; }
//        }

//    }
//}
