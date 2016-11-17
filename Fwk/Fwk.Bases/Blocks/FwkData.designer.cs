﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Fwk.ConfigData
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="fwktest1")]
	public partial class FwkDatacontext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void Insertfwk_Log(fwk_Log instance);
    partial void Updatefwk_Log(fwk_Log instance);
    partial void Deletefwk_Log(fwk_Log instance);
    partial void Insertfwk_ConfigManager(fwk_ConfigManager instance);
    partial void Updatefwk_ConfigManager(fwk_ConfigManager instance);
    partial void Deletefwk_ConfigManager(fwk_ConfigManager instance);
    partial void Insertfwk_ServiceDispatcher(fwk_ServiceDispatcher instance);
    partial void Updatefwk_ServiceDispatcher(fwk_ServiceDispatcher instance);
    partial void Deletefwk_ServiceDispatcher(fwk_ServiceDispatcher instance);
    partial void Insertfwk_Param(fwk_Param instance);
    partial void Updatefwk_Param(fwk_Param instance);
    partial void Deletefwk_Param(fwk_Param instance);
    partial void Insertfwk_ServiceAudit(fwk_ServiceAudit instance);
    partial void Updatefwk_ServiceAudit(fwk_ServiceAudit instance);
    partial void Deletefwk_ServiceAudit(fwk_ServiceAudit instance);
    #endregion
		
		public FwkDatacontext() : 
				base(global::Fwk.Bases.Properties.Settings.Default.fwktestConnectionString1, mappingSource)
		{
			OnCreated();
		}
		
		public FwkDatacontext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public FwkDatacontext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public FwkDatacontext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public FwkDatacontext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<fwk_Log> fwk_Logs
		{
			get
			{
				return this.GetTable<fwk_Log>();
			}
		}
		
		public System.Data.Linq.Table<fwk_ConfigManager> fwk_ConfigManagers
		{
			get
			{
				return this.GetTable<fwk_ConfigManager>();
			}
		}
		
		public System.Data.Linq.Table<fwk_ServiceDispatcher> fwk_ServiceDispatchers
		{
			get
			{
				return this.GetTable<fwk_ServiceDispatcher>();
			}
		}
		
		public System.Data.Linq.Table<fwk_Param> fwk_Params
		{
			get
			{
				return this.GetTable<fwk_Param>();
			}
		}
		
		public System.Data.Linq.Table<fwk_ServiceAudit> fwk_ServiceAudits
		{
			get
			{
				return this.GetTable<fwk_ServiceAudit>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.fwk_Logs")]
	public partial class fwk_Log : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Guid _Id;
		
		private System.Data.Linq.Binary _Message;
		
		private string _Source;
		
		private string _LogType;
		
		private string _Machine;
		
		private System.DateTime _LogDate;
		
		private string _UserLoginName;
		
		private string _AppId;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(System.Guid value);
    partial void OnIdChanged();
    partial void OnMessageChanging(System.Data.Linq.Binary value);
    partial void OnMessageChanged();
    partial void OnSourceChanging(string value);
    partial void OnSourceChanged();
    partial void OnLogTypeChanging(string value);
    partial void OnLogTypeChanged();
    partial void OnMachineChanging(string value);
    partial void OnMachineChanged();
    partial void OnLogDateChanging(System.DateTime value);
    partial void OnLogDateChanged();
    partial void OnUserLoginNameChanging(string value);
    partial void OnUserLoginNameChanged();
    partial void OnAppIdChanging(string value);
    partial void OnAppIdChanged();
    #endregion
		
		public fwk_Log()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", DbType="UniqueIdentifier NOT NULL", IsPrimaryKey=true)]
		public System.Guid Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Message", DbType="VarBinary(2000) NOT NULL", CanBeNull=false, UpdateCheck=UpdateCheck.Never)]
		public System.Data.Linq.Binary Message
		{
			get
			{
				return this._Message;
			}
			set
			{
				if ((this._Message != value))
				{
					this.OnMessageChanging(value);
					this.SendPropertyChanging();
					this._Message = value;
					this.SendPropertyChanged("Message");
					this.OnMessageChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Source", DbType="NVarChar(20) NOT NULL", CanBeNull=false)]
		public string Source
		{
			get
			{
				return this._Source;
			}
			set
			{
				if ((this._Source != value))
				{
					this.OnSourceChanging(value);
					this.SendPropertyChanging();
					this._Source = value;
					this.SendPropertyChanged("Source");
					this.OnSourceChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LogType", DbType="NVarChar(20) NOT NULL", CanBeNull=false)]
		public string LogType
		{
			get
			{
				return this._LogType;
			}
			set
			{
				if ((this._LogType != value))
				{
					this.OnLogTypeChanging(value);
					this.SendPropertyChanging();
					this._LogType = value;
					this.SendPropertyChanged("LogType");
					this.OnLogTypeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Machine", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Machine
		{
			get
			{
				return this._Machine;
			}
			set
			{
				if ((this._Machine != value))
				{
					this.OnMachineChanging(value);
					this.SendPropertyChanging();
					this._Machine = value;
					this.SendPropertyChanged("Machine");
					this.OnMachineChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LogDate", DbType="DateTime NOT NULL")]
		public System.DateTime LogDate
		{
			get
			{
				return this._LogDate;
			}
			set
			{
				if ((this._LogDate != value))
				{
					this.OnLogDateChanging(value);
					this.SendPropertyChanging();
					this._LogDate = value;
					this.SendPropertyChanged("LogDate");
					this.OnLogDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserLoginName", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
		public string UserLoginName
		{
			get
			{
				return this._UserLoginName;
			}
			set
			{
				if ((this._UserLoginName != value))
				{
					this.OnUserLoginNameChanging(value);
					this.SendPropertyChanging();
					this._UserLoginName = value;
					this.SendPropertyChanged("UserLoginName");
					this.OnUserLoginNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AppId", DbType="NVarChar(100)")]
		public string AppId
		{
			get
			{
				return this._AppId;
			}
			set
			{
				if ((this._AppId != value))
				{
					this.OnAppIdChanging(value);
					this.SendPropertyChanging();
					this._AppId = value;
					this.SendPropertyChanged("AppId");
					this.OnAppIdChanged();
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.fwk_ConfigManager")]
	public partial class fwk_ConfigManager : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _ConfigurationFileName;
		
		private string _group;
		
		private string _key;
		
		private bool _encrypted;
		
		private string _value;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnConfigurationFileNameChanging(string value);
    partial void OnConfigurationFileNameChanged();
    partial void OngroupChanging(string value);
    partial void OngroupChanged();
    partial void OnkeyChanging(string value);
    partial void OnkeyChanged();
    partial void OnencryptedChanging(bool value);
    partial void OnencryptedChanged();
    partial void OnvalueChanging(string value);
    partial void OnvalueChanged();
    #endregion
		
		public fwk_ConfigManager()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ConfigurationFileName", DbType="NVarChar(50) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string ConfigurationFileName
		{
			get
			{
				return this._ConfigurationFileName;
			}
			set
			{
				if ((this._ConfigurationFileName != value))
				{
					this.OnConfigurationFileNameChanging(value);
					this.SendPropertyChanging();
					this._ConfigurationFileName = value;
					this.SendPropertyChanged("ConfigurationFileName");
					this.OnConfigurationFileNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[group]", Storage="_group", DbType="NVarChar(50) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string group
		{
			get
			{
				return this._group;
			}
			set
			{
				if ((this._group != value))
				{
					this.OngroupChanging(value);
					this.SendPropertyChanging();
					this._group = value;
					this.SendPropertyChanged("group");
					this.OngroupChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[key]", Storage="_key", DbType="NVarChar(50) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string key
		{
			get
			{
				return this._key;
			}
			set
			{
				if ((this._key != value))
				{
					this.OnkeyChanging(value);
					this.SendPropertyChanging();
					this._key = value;
					this.SendPropertyChanged("key");
					this.OnkeyChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_encrypted", DbType="Bit NOT NULL")]
		public bool encrypted
		{
			get
			{
				return this._encrypted;
			}
			set
			{
				if ((this._encrypted != value))
				{
					this.OnencryptedChanging(value);
					this.SendPropertyChanging();
					this._encrypted = value;
					this.SendPropertyChanged("encrypted");
					this.OnencryptedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_value", DbType="NVarChar(1000)")]
		public string value
		{
			get
			{
				return this._value;
			}
			set
			{
				if ((this._value != value))
				{
					this.OnvalueChanging(value);
					this.SendPropertyChanging();
					this._value = value;
					this.SendPropertyChanged("value");
					this.OnvalueChanged();
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.fwk_ServiceDispatcher")]
	public partial class fwk_ServiceDispatcher : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _InstanseName;
		
		private short _AuditMode;
		
		private string _HostIp;
		
		private string _HostName;
		
		private string _CompanyName;
		
		private System.Data.Linq.Binary _Logo;
		
		private System.Nullable<System.Guid> _InstanseId;
		
		private string _Url_URI;
		
		private System.Nullable<int> _Port;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnInstanseNameChanging(string value);
    partial void OnInstanseNameChanged();
    partial void OnAuditModeChanging(short value);
    partial void OnAuditModeChanged();
    partial void OnHostIpChanging(string value);
    partial void OnHostIpChanged();
    partial void OnHostNameChanging(string value);
    partial void OnHostNameChanged();
    partial void OnCompanyNameChanging(string value);
    partial void OnCompanyNameChanged();
    partial void OnLogoChanging(System.Data.Linq.Binary value);
    partial void OnLogoChanged();
    partial void OnInstanseIdChanging(System.Nullable<System.Guid> value);
    partial void OnInstanseIdChanged();
    partial void OnUrl_URIChanging(string value);
    partial void OnUrl_URIChanged();
    partial void OnPortChanging(System.Nullable<int> value);
    partial void OnPortChanged();
    #endregion
		
		public fwk_ServiceDispatcher()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_InstanseName", DbType="VarChar(200) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string InstanseName
		{
			get
			{
				return this._InstanseName;
			}
			set
			{
				if ((this._InstanseName != value))
				{
					this.OnInstanseNameChanging(value);
					this.SendPropertyChanging();
					this._InstanseName = value;
					this.SendPropertyChanged("InstanseName");
					this.OnInstanseNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AuditMode", DbType="SmallInt NOT NULL")]
		public short AuditMode
		{
			get
			{
				return this._AuditMode;
			}
			set
			{
				if ((this._AuditMode != value))
				{
					this.OnAuditModeChanging(value);
					this.SendPropertyChanging();
					this._AuditMode = value;
					this.SendPropertyChanged("AuditMode");
					this.OnAuditModeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_HostIp", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string HostIp
		{
			get
			{
				return this._HostIp;
			}
			set
			{
				if ((this._HostIp != value))
				{
					this.OnHostIpChanging(value);
					this.SendPropertyChanging();
					this._HostIp = value;
					this.SendPropertyChanged("HostIp");
					this.OnHostIpChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_HostName", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string HostName
		{
			get
			{
				return this._HostName;
			}
			set
			{
				if ((this._HostName != value))
				{
					this.OnHostNameChanging(value);
					this.SendPropertyChanging();
					this._HostName = value;
					this.SendPropertyChanged("HostName");
					this.OnHostNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CompanyName", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string CompanyName
		{
			get
			{
				return this._CompanyName;
			}
			set
			{
				if ((this._CompanyName != value))
				{
					this.OnCompanyNameChanging(value);
					this.SendPropertyChanging();
					this._CompanyName = value;
					this.SendPropertyChanged("CompanyName");
					this.OnCompanyNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Logo", DbType="VarBinary(1000)", UpdateCheck=UpdateCheck.Never)]
		public System.Data.Linq.Binary Logo
		{
			get
			{
				return this._Logo;
			}
			set
			{
				if ((this._Logo != value))
				{
					this.OnLogoChanging(value);
					this.SendPropertyChanging();
					this._Logo = value;
					this.SendPropertyChanged("Logo");
					this.OnLogoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_InstanseId", DbType="UniqueIdentifier")]
		public System.Nullable<System.Guid> InstanseId
		{
			get
			{
				return this._InstanseId;
			}
			set
			{
				if ((this._InstanseId != value))
				{
					this.OnInstanseIdChanging(value);
					this.SendPropertyChanging();
					this._InstanseId = value;
					this.SendPropertyChanged("InstanseId");
					this.OnInstanseIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Url_URI", DbType="VarChar(1000)")]
		public string Url_URI
		{
			get
			{
				return this._Url_URI;
			}
			set
			{
				if ((this._Url_URI != value))
				{
					this.OnUrl_URIChanging(value);
					this.SendPropertyChanging();
					this._Url_URI = value;
					this.SendPropertyChanged("Url_URI");
					this.OnUrl_URIChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Port", DbType="Int")]
		public System.Nullable<int> Port
		{
			get
			{
				return this._Port;
			}
			set
			{
				if ((this._Port != value))
				{
					this.OnPortChanging(value);
					this.SendPropertyChanging();
					this._Port = value;
					this.SendPropertyChanged("Port");
					this.OnPortChanged();
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.fwk_Param")]
	public partial class fwk_Param : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ParamId;
		
		private System.Nullable<int> _ParentId;
		
		private string _Name;
		
		private string _Description;
		
		private bool _Enabled;
		
		private string _Culture;
		
		private int _Id;
		
		private EntityRef<fwk_Param> _fwk_Param2;
		
		private EntityRef<fwk_Param> _fwk_Param1;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnParamIdChanging(int value);
    partial void OnParamIdChanged();
    partial void OnParentIdChanging(System.Nullable<int> value);
    partial void OnParentIdChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnDescriptionChanging(string value);
    partial void OnDescriptionChanged();
    partial void OnEnabledChanging(bool value);
    partial void OnEnabledChanged();
    partial void OnCultureChanging(string value);
    partial void OnCultureChanged();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    #endregion
		
		public fwk_Param()
		{
			this._fwk_Param2 = default(EntityRef<fwk_Param>);
			this._fwk_Param1 = default(EntityRef<fwk_Param>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ParamId", DbType="Int NOT NULL")]
		public int ParamId
		{
			get
			{
				return this._ParamId;
			}
			set
			{
				if ((this._ParamId != value))
				{
					this.OnParamIdChanging(value);
					this.SendPropertyChanging();
					this._ParamId = value;
					this.SendPropertyChanged("ParamId");
					this.OnParamIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ParentId", DbType="Int")]
		public System.Nullable<int> ParentId
		{
			get
			{
				return this._ParentId;
			}
			set
			{
				if ((this._ParentId != value))
				{
					this.OnParentIdChanging(value);
					this.SendPropertyChanging();
					this._ParentId = value;
					this.SendPropertyChanged("ParentId");
					this.OnParentIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Description", DbType="VarChar(50)")]
		public string Description
		{
			get
			{
				return this._Description;
			}
			set
			{
				if ((this._Description != value))
				{
					this.OnDescriptionChanging(value);
					this.SendPropertyChanging();
					this._Description = value;
					this.SendPropertyChanged("Description");
					this.OnDescriptionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Enabled", DbType="Bit NOT NULL")]
		public bool Enabled
		{
			get
			{
				return this._Enabled;
			}
			set
			{
				if ((this._Enabled != value))
				{
					this.OnEnabledChanging(value);
					this.SendPropertyChanging();
					this._Enabled = value;
					this.SendPropertyChanged("Enabled");
					this.OnEnabledChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Culture", DbType="Char(5) NOT NULL", CanBeNull=false)]
		public string Culture
		{
			get
			{
				return this._Culture;
			}
			set
			{
				if ((this._Culture != value))
				{
					this.OnCultureChanging(value);
					this.SendPropertyChanging();
					this._Culture = value;
					this.SendPropertyChanged("Culture");
					this.OnCultureChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					if (this._fwk_Param1.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="fwk_Param_fwk_Param", Storage="_fwk_Param2", ThisKey="Id", OtherKey="Id", IsUnique=true, IsForeignKey=false)]
		public fwk_Param fwk_Param2
		{
			get
			{
				return this._fwk_Param2.Entity;
			}
			set
			{
				fwk_Param previousValue = this._fwk_Param2.Entity;
				if (((previousValue != value) 
							|| (this._fwk_Param2.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._fwk_Param2.Entity = null;
						previousValue.fwk_Param1 = null;
					}
					this._fwk_Param2.Entity = value;
					if ((value != null))
					{
						value.fwk_Param1 = this;
					}
					this.SendPropertyChanged("fwk_Param2");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="fwk_Param_fwk_Param", Storage="_fwk_Param1", ThisKey="Id", OtherKey="Id", IsForeignKey=true)]
		public fwk_Param fwk_Param1
		{
			get
			{
				return this._fwk_Param1.Entity;
			}
			set
			{
				fwk_Param previousValue = this._fwk_Param1.Entity;
				if (((previousValue != value) 
							|| (this._fwk_Param1.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._fwk_Param1.Entity = null;
						previousValue.fwk_Param2 = null;
					}
					this._fwk_Param1.Entity = value;
					if ((value != null))
					{
						value.fwk_Param2 = this;
						this._Id = value.Id;
					}
					else
					{
						this._Id = default(int);
					}
					this.SendPropertyChanged("fwk_Param1");
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.fwk_ServiceAudit")]
	public partial class fwk_ServiceAudit : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private System.DateTime _LogTime;
		
		private string _ServiceName;
		
		private System.DateTime _Send_Time;
		
		private System.DateTime _Resived_Time;
		
		private string _Send_UserId;
		
		private string _Send_Machine;
		
		private string _Dispatcher_Instance_Name;
		
		private string _ApplicationId;
		
		private System.Data.Linq.Binary _Requets;
		
		private System.Data.Linq.Binary _Response;
		
		private System.Data.Linq.Binary _ServiceError;
		
		private string _Message;
		
		private string _Logtype;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnLogTimeChanging(System.DateTime value);
    partial void OnLogTimeChanged();
    partial void OnServiceNameChanging(string value);
    partial void OnServiceNameChanged();
    partial void OnSend_TimeChanging(System.DateTime value);
    partial void OnSend_TimeChanged();
    partial void OnResived_TimeChanging(System.DateTime value);
    partial void OnResived_TimeChanged();
    partial void OnSend_UserIdChanging(string value);
    partial void OnSend_UserIdChanged();
    partial void OnSend_MachineChanging(string value);
    partial void OnSend_MachineChanged();
    partial void OnDispatcher_Instance_NameChanging(string value);
    partial void OnDispatcher_Instance_NameChanged();
    partial void OnApplicationIdChanging(string value);
    partial void OnApplicationIdChanged();
    partial void OnRequetsChanging(System.Data.Linq.Binary value);
    partial void OnRequetsChanged();
    partial void OnResponseChanging(System.Data.Linq.Binary value);
    partial void OnResponseChanged();
    partial void OnServiceErrorChanging(System.Data.Linq.Binary value);
    partial void OnServiceErrorChanged();
    partial void OnMessageChanging(string value);
    partial void OnMessageChanged();
    partial void OnLogtypeChanging(string value);
    partial void OnLogtypeChanged();
    #endregion
		
		public fwk_ServiceAudit()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LogTime", DbType="DateTime NOT NULL")]
		public System.DateTime LogTime
		{
			get
			{
				return this._LogTime;
			}
			set
			{
				if ((this._LogTime != value))
				{
					this.OnLogTimeChanging(value);
					this.SendPropertyChanging();
					this._LogTime = value;
					this.SendPropertyChanged("LogTime");
					this.OnLogTimeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ServiceName", DbType="VarChar(200) NOT NULL", CanBeNull=false)]
		public string ServiceName
		{
			get
			{
				return this._ServiceName;
			}
			set
			{
				if ((this._ServiceName != value))
				{
					this.OnServiceNameChanging(value);
					this.SendPropertyChanging();
					this._ServiceName = value;
					this.SendPropertyChanged("ServiceName");
					this.OnServiceNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Send_Time", DbType="DateTime NOT NULL")]
		public System.DateTime Send_Time
		{
			get
			{
				return this._Send_Time;
			}
			set
			{
				if ((this._Send_Time != value))
				{
					this.OnSend_TimeChanging(value);
					this.SendPropertyChanging();
					this._Send_Time = value;
					this.SendPropertyChanged("Send_Time");
					this.OnSend_TimeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Resived_Time", DbType="DateTime NOT NULL")]
		public System.DateTime Resived_Time
		{
			get
			{
				return this._Resived_Time;
			}
			set
			{
				if ((this._Resived_Time != value))
				{
					this.OnResived_TimeChanging(value);
					this.SendPropertyChanging();
					this._Resived_Time = value;
					this.SendPropertyChanged("Resived_Time");
					this.OnResived_TimeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Send_UserId", DbType="VarChar(200) NOT NULL", CanBeNull=false)]
		public string Send_UserId
		{
			get
			{
				return this._Send_UserId;
			}
			set
			{
				if ((this._Send_UserId != value))
				{
					this.OnSend_UserIdChanging(value);
					this.SendPropertyChanging();
					this._Send_UserId = value;
					this.SendPropertyChanged("Send_UserId");
					this.OnSend_UserIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Send_Machine", DbType="VarChar(200) NOT NULL", CanBeNull=false)]
		public string Send_Machine
		{
			get
			{
				return this._Send_Machine;
			}
			set
			{
				if ((this._Send_Machine != value))
				{
					this.OnSend_MachineChanging(value);
					this.SendPropertyChanging();
					this._Send_Machine = value;
					this.SendPropertyChanged("Send_Machine");
					this.OnSend_MachineChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Dispatcher_Instance_Name", DbType="VarChar(200) NOT NULL", CanBeNull=false)]
		public string Dispatcher_Instance_Name
		{
			get
			{
				return this._Dispatcher_Instance_Name;
			}
			set
			{
				if ((this._Dispatcher_Instance_Name != value))
				{
					this.OnDispatcher_Instance_NameChanging(value);
					this.SendPropertyChanging();
					this._Dispatcher_Instance_Name = value;
					this.SendPropertyChanged("Dispatcher_Instance_Name");
					this.OnDispatcher_Instance_NameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ApplicationId", DbType="VarChar(200)")]
		public string ApplicationId
		{
			get
			{
				return this._ApplicationId;
			}
			set
			{
				if ((this._ApplicationId != value))
				{
					this.OnApplicationIdChanging(value);
					this.SendPropertyChanging();
					this._ApplicationId = value;
					this.SendPropertyChanged("ApplicationId");
					this.OnApplicationIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Requets", DbType="VarBinary(MAX)", UpdateCheck=UpdateCheck.Never)]
		public System.Data.Linq.Binary Requets
		{
			get
			{
				return this._Requets;
			}
			set
			{
				if ((this._Requets != value))
				{
					this.OnRequetsChanging(value);
					this.SendPropertyChanging();
					this._Requets = value;
					this.SendPropertyChanged("Requets");
					this.OnRequetsChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Response", DbType="VarBinary(MAX)", UpdateCheck=UpdateCheck.Never)]
		public System.Data.Linq.Binary Response
		{
			get
			{
				return this._Response;
			}
			set
			{
				if ((this._Response != value))
				{
					this.OnResponseChanging(value);
					this.SendPropertyChanging();
					this._Response = value;
					this.SendPropertyChanged("Response");
					this.OnResponseChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ServiceError", DbType="VarBinary(MAX)", UpdateCheck=UpdateCheck.Never)]
		public System.Data.Linq.Binary ServiceError
		{
			get
			{
				return this._ServiceError;
			}
			set
			{
				if ((this._ServiceError != value))
				{
					this.OnServiceErrorChanging(value);
					this.SendPropertyChanging();
					this._ServiceError = value;
					this.SendPropertyChanged("ServiceError");
					this.OnServiceErrorChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Message", DbType="VarChar(MAX)")]
		public string Message
		{
			get
			{
				return this._Message;
			}
			set
			{
				if ((this._Message != value))
				{
					this.OnMessageChanging(value);
					this.SendPropertyChanging();
					this._Message = value;
					this.SendPropertyChanged("Message");
					this.OnMessageChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Logtype", DbType="VarChar(10) NOT NULL", CanBeNull=false)]
		public string Logtype
		{
			get
			{
				return this._Logtype;
			}
			set
			{
				if ((this._Logtype != value))
				{
					this.OnLogtypeChanging(value);
					this.SendPropertyChanging();
					this._Logtype = value;
					this.SendPropertyChanged("Logtype");
					this.OnLogtypeChanged();
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
