using System;
using System.Collections ;
using System.Reflection;

namespace Fwk.AssemblyExplorer
{
    /// <summary>
    /// 
    /// </summary>
	public class AssemblyCollection:CollectionBase
	{
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
		public Assembly this[ int index ]  
		{
			get  
			{
				return( (Assembly) List[index] );
			}
			set  
			{
				List[index] = value;
			}
		}
		public int Add( Assembly value )  
		{
			return( List.Add( value ) );
		}

		
		public int IndexOf( Assembly value )  
		{
			return( List.IndexOf( value ) );
		}

		public void Insert( int index, Assembly value )  
		{
			List.Insert( index, value );
		}

		public void Remove( Assembly value )  
		{
			List.Remove( value );
		}

		public bool Contains( Assembly value )  
		{
			// If value is not of type Int16, this will return false.
			return( List.Contains( value ) );
		}

		protected override void OnInsert( int index, Object value )  
		{
           
		}

		protected override void OnRemove( int index, Object value )  
		{
			if ( value.GetType() != Type.GetType("Fwk.AssemblyExplorer.Assembly") )
				throw new ArgumentException( "El valor debe ser del tipo Fwk.AssemblyExplorer.Assembly", "value" );
		}

		protected override void OnSet( int index, Object oldValue, Object newValue )  
		{
			if ( newValue.GetType() != Type.GetType("Fwk.AssemblyExplorer.Assembly") )
				throw new ArgumentException( "newEl valor debe ser del tipo Fwk.AssemblyExplorer.Assembly.", "newValue" );
		}

		protected override void OnValidate( Object value )  
		{
			if ( value.GetType() != Type.GetType("Fwk.AssemblyExplorer.Assembly") )
				throw new ArgumentException( "El valor debe ser del tipo Fwk.AssemblyExplorer.Assembly." );
		}
	}
	/// <summary>
	/// Summary description for Assembly.
	/// </summary>
	public class Assembly
	{

        private string m_FileAssemblyPath;

        public string FileAssemblyPath
        {
            get { return m_FileAssemblyPath; }
            set { m_FileAssemblyPath = value; }
        }
		private string m_TypeFilter;
		private System.Reflection.Assembly m_Assembly;
		private AssemblyClassCollection m_ClassCollections = null;
        private string m_FullName;

        public string FullName
        {
            get { return m_FullName; }
            set { m_FullName = value; }
        }
       

		#region --[Constructor]--
		public Assembly(string pFileAssemblyPath)
		{
			m_TypeFilter = String.Empty;
			m_FileAssemblyPath = pFileAssemblyPath;
			m_Assembly = System.Reflection.Assembly.LoadFrom(m_FileAssemblyPath);
			m_ClassCollections = new AssemblyClassCollection ();

            m_FullName = m_Assembly.FullName;

         
			FillClassCollections(this.m_Assembly.GetTypes());
		}


		#endregion

		public AssemblyClassCollection ClassCollections
		{
			get {return m_ClassCollections;}
		}

		private void FillClassCollections(Type[] pTypes)
		{
			foreach (Type wAssType in pTypes)
			{
			
				int i = wAssType.Name.Length ;
				
				if (wAssType.Name  == m_TypeFilter || m_TypeFilter == String.Empty )
				{
					AssemblyClass wClass = new AssemblyClass (wAssType);
					m_ClassCollections	.Add(wClass);
				}

			}

		}
	}
}
