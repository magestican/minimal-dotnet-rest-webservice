﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using LinqConnect template.
// Code is generated on: 4/28/2015 8:06:01 AM
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System;
using Devart.Data.Linq;
using Devart.Data.Linq.Mapping;
using System.Data;
using System.ComponentModel;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Linq.Expressions;

namespace TestContext
{

    [DatabaseAttribute(Name = "test")]
    [ProviderAttribute(typeof(Devart.Data.MySql.Linq.Provider.MySqlDataProvider))]
    public partial class TestDataContext : Devart.Data.Linq.DataContext
    {
        public static CompiledQueryCache compiledQueryCache = CompiledQueryCache.RegisterDataContext(typeof(TestDataContext));
        private static MappingSource mappingSource = new Devart.Data.Linq.Mapping.AttributeMappingSource();

        #region Extensibility Method Definitions
    
        partial void OnCreated();
        partial void OnSubmitError(Devart.Data.Linq.SubmitErrorEventArgs args);
        partial void InsertAttend(Attend instance);
        partial void UpdateAttend(Attend instance);
        partial void DeleteAttend(Attend instance);
        partial void InsertEvent(Event instance);
        partial void UpdateEvent(Event instance);
        partial void DeleteEvent(Event instance);
        partial void InsertUser(User instance);
        partial void UpdateUser(User instance);
        partial void DeleteUser(User instance);

        #endregion

        public TestDataContext() :
        base(GetConnectionString("TestDataContextConnectionString"), mappingSource)
        {
            OnCreated();
        }

        public TestDataContext(MappingSource mappingSource) :
        base(GetConnectionString("TestDataContextConnectionString"), mappingSource)
        {
            OnCreated();
        }

        private static string GetConnectionString(string connectionStringName)
        {
            System.Configuration.ConnectionStringSettings connectionStringSettings = System.Configuration.ConfigurationManager.ConnectionStrings[connectionStringName];
            if (connectionStringSettings == null)
                throw new InvalidOperationException("Connection string \"" + connectionStringName +"\" could not be found in the configuration file.");
            return connectionStringSettings.ConnectionString;
        }

        public TestDataContext(string connection) :
            base(connection, mappingSource)
        {
          OnCreated();
        }

        public TestDataContext(System.Data.IDbConnection connection) :
            base(connection, mappingSource)
        {
          OnCreated();
        }

        public TestDataContext(string connection, MappingSource mappingSource) :
            base(connection, mappingSource)
        {
          OnCreated();
        }

        public TestDataContext(System.Data.IDbConnection connection, MappingSource mappingSource) :
            base(connection, mappingSource)
        {
          OnCreated();
        }

        public Devart.Data.Linq.Table<Attend> Attends
        {
            get
            {
                return this.GetTable<Attend>();
            }
        }

        public Devart.Data.Linq.Table<Event> Events
        {
            get
            {
                return this.GetTable<Event>();
            }
        }

        public Devart.Data.Linq.Table<User> Users
        {
            get
            {
                return this.GetTable<User>();
            }
        }
    }
}

namespace TestContext
{

    /// <summary>
    /// There are no comments for TestContext.Attend in the schema.
    /// </summary>
    [Table(Name = @"test.attends")]
    public partial class Attend : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(System.String.Empty);
        #pragma warning disable 0649

        private int _UserId;

        private int _EventId;

        private System.DateTime _ReservedAt = DateTime.Now;
        #pragma warning restore 0649
    
        #region Extensibility Method Definitions

        partial void OnLoaded();
        partial void OnValidate(ChangeAction action);
        partial void OnCreated();
        partial void OnUserIdChanging(int value);
        partial void OnUserIdChanged();
        partial void OnEventIdChanging(int value);
        partial void OnEventIdChanged();
        partial void OnReservedAtChanging(System.DateTime value);
        partial void OnReservedAtChanged();
        #endregion

        public Attend()
        {
            OnCreated();
        }

    
        /// <summary>
        /// There are no comments for UserId in the schema.
        /// </summary>
        [Column(Name = @"user_id", Storage = "_UserId", CanBeNull = false, DbType = "INT(11) NOT NULL", IsPrimaryKey = true)]
        public int UserId
        {
            get
            {
                return this._UserId;
            }
            set
            {
                if (this._UserId != value)
                {
                    this.OnUserIdChanging(value);
                    this.SendPropertyChanging();
                    this._UserId = value;
                    this.SendPropertyChanged("UserId");
                    this.OnUserIdChanged();
                }
            }
        }

    
        /// <summary>
        /// There are no comments for EventId in the schema.
        /// </summary>
        [Column(Name = @"event_id", Storage = "_EventId", CanBeNull = false, DbType = "INT(11) NOT NULL", IsPrimaryKey = true)]
        public int EventId
        {
            get
            {
                return this._EventId;
            }
            set
            {
                if (this._EventId != value)
                {
                    this.OnEventIdChanging(value);
                    this.SendPropertyChanging();
                    this._EventId = value;
                    this.SendPropertyChanged("EventId");
                    this.OnEventIdChanged();
                }
            }
        }

    
        /// <summary>
        /// There are no comments for ReservedAt in the schema.
        /// </summary>
        [Column(Name = @"reserved_at", Storage = "_ReservedAt", CanBeNull = false, DbType = "TIMESTAMP NOT NULL", UpdateCheck = UpdateCheck.Never)]
        public System.DateTime ReservedAt
        {
            get
            {
                return this._ReservedAt;
            }
            set
            {
                if (this._ReservedAt != value)
                {
                    this.OnReservedAtChanging(value);
                    this.SendPropertyChanging();
                    this._ReservedAt = value;
                    this.SendPropertyChanged("ReservedAt");
                    this.OnReservedAtChanged();
                }
            }
        }
   
        public event PropertyChangingEventHandler PropertyChanging;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
		        var handler = this.PropertyChanging;
            if (handler != null)
                handler(this, emptyChangingEventArgs);
        }

        protected virtual void SendPropertyChanging(System.String propertyName) 
        {    
		        var handler = this.PropertyChanging;
            if (handler != null)
                handler(this, new PropertyChangingEventArgs(propertyName));
        }

        protected virtual void SendPropertyChanged(System.String propertyName)
        {    
		        var handler = this.PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    /// <summary>
    /// There are no comments for TestContext.Event in the schema.
    /// </summary>
    [Table(Name = @"test.events")]
    public partial class Event : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(System.String.Empty);
        #pragma warning disable 0649

        private decimal _Id;

        private int _UserId;

        private string _Name;

        private System.DateTime _StartDate;
        #pragma warning restore 0649
    
        #region Extensibility Method Definitions

        partial void OnLoaded();
        partial void OnValidate(ChangeAction action);
        partial void OnCreated();
        partial void OnIdChanging(decimal value);
        partial void OnIdChanged();
        partial void OnUserIdChanging(int value);
        partial void OnUserIdChanged();
        partial void OnNameChanging(string value);
        partial void OnNameChanged();
        partial void OnStartDateChanging(System.DateTime value);
        partial void OnStartDateChanged();
        #endregion

        public Event()
        {
            OnCreated();
        }

    
        /// <summary>
        /// There are no comments for Id in the schema.
        /// </summary>
        [Column(Name = @"id", Storage = "_Id", AutoSync = AutoSync.OnInsert, CanBeNull = false, DbType = "BIGINT(20) UNSIGNED NOT NULL AUTO_INCREMENT", IsDbGenerated = true, IsPrimaryKey = true)]
        public decimal Id
        {
            get
            {
                return this._Id;
            }
            set
            {
                if (this._Id != value)
                {
                    this.OnIdChanging(value);
                    this.SendPropertyChanging();
                    this._Id = value;
                    this.SendPropertyChanged("Id");
                    this.OnIdChanged();
                }
            }
        }

    
        /// <summary>
        /// There are no comments for UserId in the schema.
        /// </summary>
        [Column(Name = @"user_id", Storage = "_UserId", CanBeNull = false, DbType = "INT(11) NOT NULL", UpdateCheck = UpdateCheck.Never)]
        public int UserId
        {
            get
            {
                return this._UserId;
            }
            set
            {
                if (this._UserId != value)
                {
                    this.OnUserIdChanging(value);
                    this.SendPropertyChanging();
                    this._UserId = value;
                    this.SendPropertyChanged("UserId");
                    this.OnUserIdChanged();
                }
            }
        }

    
        /// <summary>
        /// There are no comments for Name in the schema.
        /// </summary>
        [Column(Name = @"name", Storage = "_Name", CanBeNull = false, DbType = "VARCHAR(100) NOT NULL", UpdateCheck = UpdateCheck.Never)]
        public string Name
        {
            get
            {
                return this._Name;
            }
            set
            {
                if (this._Name != value)
                {
                    this.OnNameChanging(value);
                    this.SendPropertyChanging();
                    this._Name = value;
                    this.SendPropertyChanged("Name");
                    this.OnNameChanged();
                }
            }
        }

    
        /// <summary>
        /// There are no comments for StartDate in the schema.
        /// </summary>
        [Column(Name = @"start_date", Storage = "_StartDate", CanBeNull = false, DbType = "DATETIME NOT NULL", UpdateCheck = UpdateCheck.Never)]
        public System.DateTime StartDate
        {
            get
            {
                return this._StartDate;
            }
            set
            {
                if (this._StartDate != value)
                {
                    this.OnStartDateChanging(value);
                    this.SendPropertyChanging();
                    this._StartDate = value;
                    this.SendPropertyChanged("StartDate");
                    this.OnStartDateChanged();
                }
            }
        }
   
        public event PropertyChangingEventHandler PropertyChanging;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
		        var handler = this.PropertyChanging;
            if (handler != null)
                handler(this, emptyChangingEventArgs);
        }

        protected virtual void SendPropertyChanging(System.String propertyName) 
        {    
		        var handler = this.PropertyChanging;
            if (handler != null)
                handler(this, new PropertyChangingEventArgs(propertyName));
        }

        protected virtual void SendPropertyChanged(System.String propertyName)
        {    
		        var handler = this.PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    /// <summary>
    /// There are no comments for TestContext.User in the schema.
    /// </summary>
    [Table(Name = @"test.users")]
    public partial class User : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(System.String.Empty);
        #pragma warning disable 0649

        private decimal _Id;

        private string _Name;

        private string _Password;

        private string _Email;

        private int _GroupId;
        #pragma warning restore 0649
    
        #region Extensibility Method Definitions

        partial void OnLoaded();
        partial void OnValidate(ChangeAction action);
        partial void OnCreated();
        partial void OnIdChanging(decimal value);
        partial void OnIdChanged();
        partial void OnNameChanging(string value);
        partial void OnNameChanged();
        partial void OnPasswordChanging(string value);
        partial void OnPasswordChanged();
        partial void OnEmailChanging(string value);
        partial void OnEmailChanged();
        partial void OnGroupIdChanging(int value);
        partial void OnGroupIdChanged();
        #endregion

        public User()
        {
            OnCreated();
        }

    
        /// <summary>
        /// There are no comments for Id in the schema.
        /// </summary>
        [Column(Name = @"id", Storage = "_Id", AutoSync = AutoSync.OnInsert, CanBeNull = false, DbType = "BIGINT(20) UNSIGNED NOT NULL AUTO_INCREMENT", IsDbGenerated = true, IsPrimaryKey = true)]
        public decimal Id
        {
            get
            {
                return this._Id;
            }
            set
            {
                if (this._Id != value)
                {
                    this.OnIdChanging(value);
                    this.SendPropertyChanging();
                    this._Id = value;
                    this.SendPropertyChanged("Id");
                    this.OnIdChanged();
                }
            }
        }

    
        /// <summary>
        /// There are no comments for Name in the schema.
        /// </summary>
        [Column(Name = @"name", Storage = "_Name", CanBeNull = false, DbType = "VARCHAR(100) NOT NULL", UpdateCheck = UpdateCheck.Never)]
        public string Name
        {
            get
            {
                return this._Name;
            }
            set
            {
                if (this._Name != value)
                {
                    this.OnNameChanging(value);
                    this.SendPropertyChanging();
                    this._Name = value;
                    this.SendPropertyChanged("Name");
                    this.OnNameChanged();
                }
            }
        }

    
        /// <summary>
        /// There are no comments for Password in the schema.
        /// </summary>
        [Column(Name = @"`password`", Storage = "_Password", CanBeNull = false, DbType = "VARCHAR(100) NOT NULL", UpdateCheck = UpdateCheck.Never)]
        public string Password
        {
            get
            {
                return this._Password;
            }
            set
            {
                if (this._Password != value)
                {
                    this.OnPasswordChanging(value);
                    this.SendPropertyChanging();
                    this._Password = value;
                    this.SendPropertyChanged("Password");
                    this.OnPasswordChanged();
                }
            }
        }

    
        /// <summary>
        /// There are no comments for Email in the schema.
        /// </summary>
        [Column(Name = @"email", Storage = "_Email", CanBeNull = false, DbType = "VARCHAR(100) NOT NULL", UpdateCheck = UpdateCheck.Never)]
        public string Email
        {
            get
            {
                return this._Email;
            }
            set
            {
                if (this._Email != value)
                {
                    this.OnEmailChanging(value);
                    this.SendPropertyChanging();
                    this._Email = value;
                    this.SendPropertyChanged("Email");
                    this.OnEmailChanged();
                }
            }
        }

    
        /// <summary>
        /// There are no comments for GroupId in the schema.
        /// </summary>
        [Column(Name = @"group_id", Storage = "_GroupId", CanBeNull = false, DbType = "INT(11) NOT NULL", UpdateCheck = UpdateCheck.Never)]
        public int GroupId
        {
            get
            {
                return this._GroupId;
            }
            set
            {
                if (this._GroupId != value)
                {
                    this.OnGroupIdChanging(value);
                    this.SendPropertyChanging();
                    this._GroupId = value;
                    this.SendPropertyChanged("GroupId");
                    this.OnGroupIdChanged();
                }
            }
        }
   
        public event PropertyChangingEventHandler PropertyChanging;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
		        var handler = this.PropertyChanging;
            if (handler != null)
                handler(this, emptyChangingEventArgs);
        }

        protected virtual void SendPropertyChanging(System.String propertyName) 
        {    
		        var handler = this.PropertyChanging;
            if (handler != null)
                handler(this, new PropertyChangingEventArgs(propertyName));
        }

        protected virtual void SendPropertyChanged(System.String propertyName)
        {    
		        var handler = this.PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
