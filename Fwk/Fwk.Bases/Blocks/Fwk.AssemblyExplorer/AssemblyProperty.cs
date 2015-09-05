
using System;
using System.Collections ;
using System.Reflection;
namespace Fwk.AssemblyExplorer
{
    /// <summary>
    /// 
    /// </summary>
	public class AssemblyPropertyCollection:CollectionBase
	{
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
		public AssemblyProperty this[ int index ]  
		{
			get  
			{
				return( (AssemblyProperty) List[index] );
			}
			set  
			{
				List[index] = value;
			}
		}
		public int Add( AssemblyProperty value )  
		{
			return( List.Add( value ) );
		}

		
		public int IndexOf( AssemblyProperty value )  
		{
			return( List.IndexOf( value ) );
		}

		public void Insert( int index, AssemblyProperty value )  
		{
			List.Insert( index, value );
		}

		public void Remove( AssemblyProperty value )  
		{
			List.Remove( value );
		}

		public bool Contains( AssemblyProperty value )  
		{
			// If value is not of type Int16, this will return false.
			return( List.Contains( value ) );
		}

		protected override void OnInsert( int index, Object value )  
		{
			if ( value.GetType() != Type.GetType("Fwk.AssemblyExplorer.AssemblyProperty") )
				throw new ArgumentException( "El valor debe ser del tipo Fwk.AssemblyExplorer.AssemblyProperty.", "value" );
		}

		protected override void OnRemove( int index, Object value )  
		{
			if ( value.GetType() != Type.GetType("Fwk.AssemblyExplorer.AssemblyProperty") )
				throw new ArgumentException( "El valor debe ser del tipo Fwk.AssemblyExplorer.AssemblyProperty", "value" );
		}

		protected override void OnSet( int index, Object oldValue, Object newValue )  
		{
			if ( newValue.GetType() != Type.GetType("Fwk.AssemblyExplorer.AssemblyProperty") )
				throw new ArgumentException( "newEl valor debe ser del tipo Fwk.AssemblyExplorer.AssemblyProperty.", "newValue" );
		}

		protected override void OnValidate( Object value )  
		{
			if ( value.GetType() != Type.GetType("Fwk.AssemblyExplorer.AssemblyProperty") )
				throw new ArgumentException( "El valor debe ser del tipo Fwk.AssemblyExplorer.AssemblyProperty." );
		}
	}

	/// <summary>
	/// Summary description for AssemblyProperty.
	/// </summary>
	public class AssemblyProperty
	{
		private  string  m_Name;
		private  Type  m_PropertyType;
		private  bool  m_CanRead;
		private   bool m_CanWrite;
		private  Type  m_DeclaringType;

		#region --[Constructor]--
		public AssemblyProperty()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		public AssemblyProperty(PropertyInfo pProperty )
		{
			m_Name = pProperty.Name;
			m_PropertyType = pProperty.PropertyType;
			m_CanRead = pProperty.CanRead;
			m_CanWrite = pProperty.CanWrite;
			m_DeclaringType = pProperty.DeclaringType;

		}

	
		#endregion
		public  string Name 
		{
			get	{return m_Name;	} 
			set	{m_Name = value;}
		} 

		public  Type PropertyType 
		{
			get	{return m_PropertyType;	} 
			set	{m_PropertyType = value;}
		} 
		public  bool CanRead 
		{
			get	{return m_CanRead;	} 
			
		} 
		public  bool CanWrite 
		{
			get	{return m_CanWrite;	} 
			
		} 
		public  Type DeclaringType 
		{
			get	{return m_DeclaringType;	} 
			set	{m_DeclaringType = value;}
		} 
		
	}
}
