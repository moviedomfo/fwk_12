using System;

namespace Fwk.Bases
{
	/// <summary>
    /// Esta clace almacena el valor y nombre de una propiedad
	/// </summary>
	[Serializable]
	public class PropertyValue
	{
		private string PropName;
		private object PropVal;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="propName"></param>
        /// <param name="propVal"></param>
		public PropertyValue(string propName, object propVal)
		{
			PropName = propName;
			PropVal = propVal;
		}
        /// <summary>
        /// 
        /// </summary>
		public string PropertyName
		{
			get
			{
				return PropName;
			}
			set
			{
				PropName = value;
			}
		}
        /// <summary>
        /// 
        /// </summary>
		public object Value
		{
			get
			{
				return PropVal;
			}
			set
			{
				PropVal = value;
			}
		}
	}
}
