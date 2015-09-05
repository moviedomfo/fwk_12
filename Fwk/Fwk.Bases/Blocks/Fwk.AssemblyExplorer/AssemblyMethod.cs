using System;
using System.Collections ;
using System.Reflection;
namespace Fwk.AssemblyExplorer
{
    /// <summary>
    /// 
    /// </summary>
	public class AssemblyMethodCollection:CollectionBase 
	{
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
		public AssemblyMethod this[ int index ]  
		{
			get  
			{
				return( (AssemblyMethod) List[index] );
			}
			set  
			{
				List[index] = value;
			}
		}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
		public int Add( AssemblyMethod value )  
		{
			return( List.Add( value ) );
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public int IndexOf( AssemblyMethod value )  
		{
			return( List.IndexOf( value ) );
		}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
		public void Insert( int index, AssemblyMethod value )  
		{
			List.Insert( index, value );
		}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
		public void Remove( AssemblyMethod value )  
		{
			List.Remove( value );
		}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
		public bool Contains( AssemblyMethod value )  
		{
			// If value is not of type Int16, this will return false.
			return( List.Contains( value ) );
		}

		protected override void OnInsert( int index, Object value )  
		{
			if ( value.GetType() != Type.GetType("Fwk.AssemblyExplorer.AssemblyMethod") )
				throw new ArgumentException( "El valor debe ser del tipo Fwk.AssemblyExplorer.AssemblyMethod.", "value" );
		}

		protected override void OnRemove( int index, Object value )  
		{
			if ( value.GetType() != Type.GetType("Fwk.AssemblyExplorer.AssemblyMethod") )
				throw new ArgumentException( "El valor debe ser del tipo Fwk.AssemblyExplorer.AssemblyMethod", "value" );
		}

		protected override void OnSet( int index, Object oldValue, Object newValue )  
		{
			if ( newValue.GetType() != Type.GetType("Fwk.AssemblyExplorer.AssemblyMethod") )
				throw new ArgumentException( "newEl valor debe ser del tipo Fwk.AssemblyExplorer.AssemblyMethod.", "newValue" );
		}

		protected override void OnValidate( Object value )  
		{
			if ( value.GetType() != Type.GetType("Fwk.AssemblyExplorer.AssemblyMethod") )
				throw new ArgumentException( "El valor debe ser del tipo Fwk.AssemblyExplorer.AssemblyMethod." );
		}
	}
	/// <summary>
	/// Summary description for AssemblyMethod.
	/// </summary>
	public class AssemblyMethod
	{
		private string m_Name;
		private Type m_ReturnType;
		private bool m_IsPrivate ;
		private bool m_IsPublic ;
		private bool m_IsCallByOtherClass;
		private bool m_IsConstructor;
		private AssemblyParameterCollection m_Parameters;

		#region --[Constructor]--
		public AssemblyMethod()
		{
			
		}
		public AssemblyMethod(MethodInfo wAssemblyMethod)
		{
			m_Name = wAssemblyMethod.Name;
			m_ReturnType = wAssemblyMethod.ReturnType;
			m_IsPrivate = wAssemblyMethod.IsPrivate;
			m_IsPublic = wAssemblyMethod.IsPublic;
			m_IsCallByOtherClass = wAssemblyMethod.IsAssembly;
			m_IsConstructor = wAssemblyMethod.IsConstructor;
			m_Parameters = new  AssemblyParameterCollection();

			FillParameters(wAssemblyMethod.GetParameters());
			
		}
		#endregion

		public  string Name 
		{
			get	{return m_Name;	} 
			set	{m_Name = value;}
		} 
		public  Type ReturnType 
		{
			get	{return m_ReturnType;	} 
			set	{m_ReturnType = value;}
		} 

		public  bool IsPrivate 
		{
			get	{return m_IsPrivate;	} 
			set	{m_IsPrivate = value;}
		} 
		public  bool IsPublic 
		{
			get	{return m_IsPublic;	} 
			set	{m_IsPublic = value;}
		} 
		public  bool IsCallByOtherClass 
		{
			get	{return m_IsCallByOtherClass;	} 
			set	{m_IsCallByOtherClass = value;}
		} 
		public  bool IsConstructor 
		{
			get	{return m_IsConstructor;	} 
			set	{m_IsConstructor = value;}
		} 


		public AssemblyParameterCollection Parameters
		{
			get	{return m_Parameters;} 
			set	
			{
				m_Parameters = value;
			}
		}


		private void FillParameters(ParameterInfo[] Parameters)
		{
			foreach (ParameterInfo wParameterInfo in  Parameters)
			{
				AssemblyParameter wAssParameter = new AssemblyParameter (wParameterInfo);
				this.m_Parameters.Add (wAssParameter);
			}
		}
	}

	
}

