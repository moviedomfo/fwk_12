﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Fwk.Security.ActiveDirectory.AD_Entities
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="seguridad")]
	public partial class SqlDomainURLDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertDomainsUrl(DomainsUrl instance);
    partial void UpdateDomainsUrl(DomainsUrl instance);
    partial void DeleteDomainsUrl(DomainsUrl instance);
    #endregion
		
		public SqlDomainURLDataContext() : 
				base(global::Fwk.Security.Properties.Settings.Default.seguridadConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public SqlDomainURLDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public SqlDomainURLDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public SqlDomainURLDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public SqlDomainURLDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<DomainsUrl> DomainsUrls
		{
			get
			{
				return this.GetTable<DomainsUrl>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.DomainsUrl")]
	public partial class DomainsUrl : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _DomainID;
		
		private string _DomainName;
		
		private string _LDAPPath;
		
		private System.Data.Linq.Binary _Usr;
		
		private System.Data.Linq.Binary _Pwd;
		
		private string _DomainDN;
		
		private string _SiteName;
		
		private EntityRef<DomainsUrl> _DomainsUrl2;
		
		private EntityRef<DomainsUrl> _DomainsUrl1;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnDomainIDChanging(int value);
    partial void OnDomainIDChanged();
    partial void OnDomainNameChanging(string value);
    partial void OnDomainNameChanged();
    partial void OnLDAPPathChanging(string value);
    partial void OnLDAPPathChanged();
    partial void OnUsrChanging(System.Data.Linq.Binary value);
    partial void OnUsrChanged();
    partial void OnPwdChanging(System.Data.Linq.Binary value);
    partial void OnPwdChanged();
    partial void OnDomainDNChanging(string value);
    partial void OnDomainDNChanged();
    partial void OnSiteNameChanging(string value);
    partial void OnSiteNameChanged();
    #endregion
		
		public DomainsUrl()
		{
			this._DomainsUrl2 = default(EntityRef<DomainsUrl>);
			this._DomainsUrl1 = default(EntityRef<DomainsUrl>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DomainID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int DomainID
		{
			get
			{
				return this._DomainID;
			}
			set
			{
				if ((this._DomainID != value))
				{
					if (this._DomainsUrl1.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnDomainIDChanging(value);
					this.SendPropertyChanging();
					this._DomainID = value;
					this.SendPropertyChanged("DomainID");
					this.OnDomainIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DomainName", DbType="NVarChar(16) NOT NULL", CanBeNull=false)]
		public string DomainName
		{
			get
			{
				return this._DomainName;
			}
			set
			{
				if ((this._DomainName != value))
				{
					this.OnDomainNameChanging(value);
					this.SendPropertyChanging();
					this._DomainName = value;
					this.SendPropertyChanged("DomainName");
					this.OnDomainNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LDAPPath", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
		public string LDAPPath
		{
			get
			{
				return this._LDAPPath;
			}
			set
			{
				if ((this._LDAPPath != value))
				{
					this.OnLDAPPathChanging(value);
					this.SendPropertyChanging();
					this._LDAPPath = value;
					this.SendPropertyChanged("LDAPPath");
					this.OnLDAPPathChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Usr", DbType="VarBinary(50) NOT NULL", CanBeNull=false, UpdateCheck=UpdateCheck.Never)]
		public System.Data.Linq.Binary Usr
		{
			get
			{
				return this._Usr;
			}
			set
			{
				if ((this._Usr != value))
				{
					this.OnUsrChanging(value);
					this.SendPropertyChanging();
					this._Usr = value;
					this.SendPropertyChanged("Usr");
					this.OnUsrChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Pwd", DbType="VarBinary(50) NOT NULL", CanBeNull=false, UpdateCheck=UpdateCheck.Never)]
		public System.Data.Linq.Binary Pwd
		{
			get
			{
				return this._Pwd;
			}
			set
			{
				if ((this._Pwd != value))
				{
					this.OnPwdChanging(value);
					this.SendPropertyChanging();
					this._Pwd = value;
					this.SendPropertyChanged("Pwd");
					this.OnPwdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DomainDN", DbType="VarChar(80)")]
		public string DomainDN
		{
			get
			{
				return this._DomainDN;
			}
			set
			{
				if ((this._DomainDN != value))
				{
					this.OnDomainDNChanging(value);
					this.SendPropertyChanging();
					this._DomainDN = value;
					this.SendPropertyChanged("DomainDN");
					this.OnDomainDNChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SiteName", DbType="VarChar(50)")]
		public string SiteName
		{
			get
			{
				return this._SiteName;
			}
			set
			{
				if ((this._SiteName != value))
				{
					this.OnSiteNameChanging(value);
					this.SendPropertyChanging();
					this._SiteName = value;
					this.SendPropertyChanged("SiteName");
					this.OnSiteNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="DomainsUrl_DomainsUrl", Storage="_DomainsUrl2", ThisKey="DomainID", OtherKey="DomainID", IsUnique=true, IsForeignKey=false)]
		public DomainsUrl DomainsUrl2
		{
			get
			{
				return this._DomainsUrl2.Entity;
			}
			set
			{
				DomainsUrl previousValue = this._DomainsUrl2.Entity;
				if (((previousValue != value) 
							|| (this._DomainsUrl2.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._DomainsUrl2.Entity = null;
						previousValue.DomainsUrl1 = null;
					}
					this._DomainsUrl2.Entity = value;
					if ((value != null))
					{
						value.DomainsUrl1 = this;
					}
					this.SendPropertyChanged("DomainsUrl2");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="DomainsUrl_DomainsUrl", Storage="_DomainsUrl1", ThisKey="DomainID", OtherKey="DomainID", IsForeignKey=true)]
		public DomainsUrl DomainsUrl1
		{
			get
			{
				return this._DomainsUrl1.Entity;
			}
			set
			{
				DomainsUrl previousValue = this._DomainsUrl1.Entity;
				if (((previousValue != value) 
							|| (this._DomainsUrl1.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._DomainsUrl1.Entity = null;
						previousValue.DomainsUrl2 = null;
					}
					this._DomainsUrl1.Entity = value;
					if ((value != null))
					{
						value.DomainsUrl2 = this;
						this._DomainID = value.DomainID;
					}
					else
					{
						this._DomainID = default(int);
					}
					this.SendPropertyChanged("DomainsUrl1");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
