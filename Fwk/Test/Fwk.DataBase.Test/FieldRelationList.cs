using System;
using System.Collections.Generic;
using System.Text;

namespace TestDataBases
{

	/// <summary>
	/// Lista de relaciones entre campos de dos tablas.
	/// </summary>
	/// <date>2006-04-05T00:00:00</date>
	/// <author>Marcelo Oviedo</author>
	internal class FieldRelationList : List<FieldRelation>
	{
	}

	/// <summary>
	/// Representa una relación entre dos campos de distintas tablas.
	/// </summary>
	/// <date>2006-04-05T00:00:00</date>
	/// <author>Marcelo Oviedo</author>
	internal struct FieldRelation
	{
		#region [Private fields]

		private string _FieldName;
		private string _ParentFieldName;

		#endregion

		#region [Public properties]

		/// <summary>
		/// Nombre del campo de relación.
		/// </summary>
		/// <date>2006-04-05T00:00:00</date>
		/// <author>Marcelo Oviedo</author>
		public string FieldName
		{
			get	{ return _FieldName; }
			set { _FieldName = value; }
		}

		/// <summary>
		/// Nombre del campo referenciado.
		/// </summary>
		/// <date>2006-04-05T00:00:00</date>
		/// <author>Marcelo Oviedo</author>
		public string ParentFieldName
		{
			get { return _ParentFieldName; }
			set { _ParentFieldName = value; }
		}

		#endregion
	}
}

