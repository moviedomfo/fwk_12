using System;
using System.Collections ;
using System.Reflection;
namespace Fwk.AssemblyExplorer
{
    /// <summary>
    /// 
    /// </summary>
	public class AssemblyClassCollection:CollectionBase
	{
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
		public AssemblyClass this[ int index ]  
		{
			get  
			{
				return( (AssemblyClass) List[index] );
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
		public int Add( AssemblyClass value )  
		{
			return( List.Add( value ) );
		}

		
		public int IndexOf( AssemblyClass value )  
		{
			return( List.IndexOf( value ) );
		}

		public void Insert( int index, AssemblyClass value )  
		{
			List.Insert( index, value );
		}

		public void Remove( AssemblyClass value )  
		{
			List.Remove( value );
		}

		public bool Contains( AssemblyClass value )  
		{
			// If value is not of type Int16, this will return false.
			return( List.Contains( value ) );
		}

		protected override void OnInsert( int index, Object value )  
		{
			if ( value.GetType() != Type.GetType("Fwk.AssemblyExplorer.AssemblyClass") )
				throw new ArgumentException( "El valor debe ser del tipo Fwk.AssemblyExplorer.AssemblyClass.", "value" );
		}

		protected override void OnRemove( int index, Object value )  
		{
			if ( value.GetType() != Type.GetType("Fwk.AssemblyExplorer.AssemblyClass") )
				throw new ArgumentException( "El valor debe ser del tipo Fwk.AssemblyExplorer.AssemblyClass", "value" );
		}

		protected override void OnSet( int index, Object oldValue, Object newValue )  
		{
			if ( newValue.GetType() != Type.GetType("Fwk.AssemblyExplorer.AssemblyClass") )
				throw new ArgumentException( "newEl valor debe ser del tipo Fwk.AssemblyExplorer.AssemblyClass.", "newValue" );
		}

		protected override void OnValidate( Object value )  
		{
			if ( value.GetType() != Type.GetType("Fwk.AssemblyExplorer.AssemblyClass") )
				throw new ArgumentException( "El valor debe ser del tipo Fwk.AssemblyExplorer.AssemblyClass." );
		}
	}

	/// <summary>
	/// Summary description for AssemblyType.
	/// </summary>
	public class AssemblyClass

	{
		private string m_Namespace;
		private  string  m_Name;
		private  bool  m_IsPointer;
		private string  m_FullName;
		private  bool  m_IsSealed;
		private  bool  m_IsArray;
		private bool   m_IsClass;
		public System.Reflection.Assembly   m_Assembly;
		private  AssemblyMethodCollection m_Methods = null; 
		private AssemblyPropertyCollection m_Properties= null;
        private Type m_BaseType = null;
        private Type _Type = null;
        public Type BaseType
        {
            get { return m_BaseType; }
            set { m_BaseType = value; }
        }

        public Type Type
        {
            get { return _Type; }
            set { _Type = value; }
        }
        private string m_FullyQualifiedName;

        public string FullyQualifiedName
        {
            get { return m_FullyQualifiedName; }
            set { m_FullyQualifiedName = value; }
        } 
		#region --[Constructor]--
		public AssemblyClass()
		{
	
		}
		public AssemblyClass(Type pClass)
		{
			m_IsPointer	= pClass. IsPointer;
			m_Name	= pClass. Name;
			m_Namespace	= pClass. Namespace;
			m_FullName	= pClass. FullName;
            m_FullyQualifiedName = pClass.AssemblyQualifiedName;
			m_Assembly	= pClass. Assembly;
			m_IsSealed	= pClass. IsSealed;
			m_IsArray	= pClass. IsArray;
			m_IsClass = pClass. IsClass;
            m_BaseType = pClass.BaseType;
			m_Methods = new AssemblyMethodCollection();
			m_Properties = new AssemblyPropertyCollection();
            _Type = pClass;
			this.FillMethods(pClass.GetMethods());
			this.FillPropertys(pClass.GetProperties());

		}

		
		#endregion

		public  string Name 
		{
			get	{return m_Name;	} 
			set	{m_Name = value;}
		} 
		public  string FullName 
		{
			get	{return m_FullName;	} 
			set	{m_FullName = value;}
		} 
		public  string Namespace 
		{
			get	{return m_Namespace;	} 
			
		}
		public  bool IsPointer 
		{
			get	{return m_IsPointer;	} 
		
		} 
		public  bool IsSealed 
		{
			get	{return m_IsSealed;	} 
		
		} 
		public  bool IsArray 
		{
			get	{return m_IsArray;	} 
			
		} 
		public  bool IsClass 
		{
			get	{return m_IsClass;	} 
			
		}
		
		public AssemblyMethodCollection Methods
		{
			get{return m_Methods;}
		}
		public AssemblyPropertyCollection Properties
		{
			get{return m_Properties;}
		}


		private void FillMethods(MethodInfo[] pMethodsInfo)
		{
			foreach (MethodInfo wMethod in pMethodsInfo)
			{
				
				//Cargo los metodos
				if (wMethod.DeclaringType.Namespace == this.m_Namespace)
				{
					AssemblyMethod wAssMethod = new AssemblyMethod (wMethod);
					this.m_Methods.Add(wAssMethod);
				}


			}
		}

		private void FillPropertys(PropertyInfo[] pPropertysInfo)
		{
			string s = string.Empty;
			
			try
			{
				foreach (PropertyInfo wProperty in pPropertysInfo)
				{
					if (wProperty.DeclaringType.Namespace == this.Namespace)
					{
					
						if (wProperty.Name.Length >4)
						{
							s = wProperty.Name.Substring (wProperty.Name.Length -4,4);
						}
					
						if (s != "Null")
						{
							AssemblyProperty wAssProperty = new AssemblyProperty (wProperty);
							this.m_Properties.Add(wAssProperty);
						}
					
					}	
				}
			}
			catch (System.NullReferenceException )
			{
				throw new NullReferenceException ("Referencia Nula");  
			}
		}

	}
}
