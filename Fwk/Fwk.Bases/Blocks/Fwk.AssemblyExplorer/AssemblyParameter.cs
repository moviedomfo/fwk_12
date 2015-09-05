using System;
using System.Collections ;
using System.Reflection;

namespace Fwk.AssemblyExplorer
{
    /// <summary>
    /// 
    /// </summary>
	public class AssemblyParameterCollection : CollectionBase		
	
	{
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
		public AssemblyParameter this[ int index ]  
		{
			get  
			{
				return( (AssemblyParameter) List[index] );
			}
			set  
			{
				List[index] = value;
			}
		}
		public int Add( AssemblyParameter value )  
		{
			return( List.Add( value ) );
		}

		
		public int IndexOf( AssemblyParameter value )  
		{
			return( List.IndexOf( value ) );
		}

		public void Insert( int index, AssemblyParameter value )  
		{
			List.Insert( index, value );
		}

		public void Remove( AssemblyParameter value )  
		{
			List.Remove( value );
		}

		public bool Contains( AssemblyParameter value )  
		{
			// If value is not of type Int16, this will return false.
			return( List.Contains( value ) );
		}

		protected override void OnInsert( int index, Object value )  
		{
			if ( value.GetType() != Type.GetType("Fwk.AssemblyExplorer.AssemblyParameter") )
				throw new ArgumentException( "El valor debe ser del tipo Fwk.AssemblyExplorer.AssemblyParameter.", "value" );
		}

		protected override void OnRemove( int index, Object value )  
		{
			if ( value.GetType() != Type.GetType("Fwk.AssemblyExplorer.AssemblyParameter") )
				throw new ArgumentException( "El valor debe ser del tipo Fwk.AssemblyExplorer.AssemblyParameter", "value" );
		}

		protected override void OnSet( int index, Object oldValue, Object newValue )  
		{
			if ( newValue.GetType() != Type.GetType("Fwk.AssemblyExplorer.AssemblyParameter") )
				throw new ArgumentException( "newEl valor debe ser del tipo Fwk.AssemblyExplorer.AssemblyParameter.", "newValue" );
		}

		protected override void OnValidate( Object value )  
		{
			if ( value.GetType() != Type.GetType("Fwk.AssemblyExplorer.AssemblyParameter") )
				throw new ArgumentException( "El valor debe ser del tipo Fwk.AssemblyExplorer.AssemblyParameter." );
		}
	}
	/// <summary>
	/// Summary description for AssemblyParameter.
	/// </summary>
	public class AssemblyParameter
	{
		private string m_Name;
		private Type	m_ParameterType;
		private bool	m_IsOut;
		private bool	m_IsIn;
		private int		m_Position;
		private object	m_DefaultValue;

		#region --[Constructor]--

		

		public AssemblyParameter()
		{
			
		}
		public AssemblyParameter(ParameterInfo pParameter)
		 {
			m_Name =	pParameter.Name;
			m_IsOut = pParameter.IsOut;
			m_ParameterType = pParameter.ParameterType;
			m_IsIn = pParameter.IsIn;
			m_Position = pParameter.Position;
			m_DefaultValue = pParameter.DefaultValue;
			
		 }

		#endregion

		public string Name
		{
			get {return m_Name;}
		}
		public Type ParameterType
		{
			get {return m_ParameterType;}
		}
		public bool IsOut
		{
			get {return m_IsOut;}
		}
		public bool IsIn
		{
			get {return m_IsIn;}
		}
		public Object DefaultValue
		{
			get {return m_DefaultValue;}
		}
		public Object Position
		{
			get {return m_Position;}
		}
		
	}
}
