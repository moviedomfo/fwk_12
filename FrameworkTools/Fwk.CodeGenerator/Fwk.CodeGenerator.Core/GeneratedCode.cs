using System;
using System.Text;


namespace Fwk.CodeGenerator
{
	/// <summary>
	/// Acumulador de código generado.
	/// </summary>
	
	/// <author>Marcelo Oviedo</author>
    [Serializable ]
    public class GeneratedCode
	{
		#region [Private fields]

        private object _Tag = null;

        public object Tag
        {
            get { return _Tag; }
            set { _Tag = value; }
        }
		private string _Id;
		private StringBuilder _Code;
	    private CodeGeneratorCommon.MethodActionType _MethodActionType;

        public CodeGeneratorCommon.MethodActionType MethodActionType
        {
            get { return _MethodActionType; }
            set { _MethodActionType = value; }
        }
		#endregion
		
		#region [Public properties]

		/// <summary>
		/// Identificador del código generado.
		/// </summary>
		// <author>Marcelo Oviedo</author>
		public string Id
		{
			get { return _Id; }
			set { _Id = value; }
		}

		/// <summary>
		/// código generado.
		/// </summary>
		/// <author>Marcelo Oviedo</author>
		public StringBuilder Code
		{
			get { return _Code; }
			set { _Code = value; }
		}

		#endregion

		#region [Constructors]

		/// <summary>
		/// Constructor por defecto.
		/// </summary>
		
		/// <author>Marcelo Oviedo</author>
		public GeneratedCode()
		{
			_Id = string.Empty;
			_Code = new StringBuilder();
            _MethodActionType = new CodeGeneratorCommon.MethodActionType();
		}

		#endregion
	}
}
