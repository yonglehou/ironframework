﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generation date: 2014/12/15 16:02:22
namespace ODataWebAPI.Tests.BusinessEntities
{
    /// <summary>
    /// There are no comments for Container in the schema.
    /// </summary>
    [global::Microsoft.OData.Client.OriginalNameAttribute("Container")]
    public partial class Container : global::Microsoft.OData.Client.DataServiceContext
    {
        /// <summary>
        /// Initialize a new Container object.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "2.1.0")]
        public Container(global::System.Uri serviceRoot) : 
                base(serviceRoot, global::Microsoft.OData.Client.ODataProtocolVersion.V4)
        {
            this.ResolveName = new global::System.Func<global::System.Type, string>(this.ResolveNameFromType);
            this.ResolveType = new global::System.Func<string, global::System.Type>(this.ResolveTypeFromName);
            this.OnContextCreated();
            this.Format.LoadServiceModel = GeneratedEdmModel.GetInstance;
            this.Format.UseJson();
        }
        partial void OnContextCreated();
        /// <summary>
        /// Since the namespace configured for this service reference
        /// in Visual Studio is different from the one indicated in the
        /// server schema, use type-mappers to map between the two.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "2.1.0")]
        protected global::System.Type ResolveTypeFromName(string typeName)
        {
            global::System.Type resolvedType = this.DefaultResolveType(typeName, "IronFramework.Utility.EntityFramewrok", "ODataWebAPI.Tests.IronFramework.Utility.EntityFramewrok");
            if ((resolvedType != null))
            {
                return resolvedType;
            }
            resolvedType = this.DefaultResolveType(typeName, "BusinessEntities", "ODataWebAPI.Tests.BusinessEntities");
            if ((resolvedType != null))
            {
                return resolvedType;
            }
            return null;
        }
        /// <summary>
        /// Since the namespace configured for this service reference
        /// in Visual Studio is different from the one indicated in the
        /// server schema, use type-mappers to map between the two.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "2.1.0")]
        protected string ResolveNameFromType(global::System.Type clientType)
        {
            global::Microsoft.OData.Client.OriginalNameAttribute originalNameAttribute = (global::Microsoft.OData.Client.OriginalNameAttribute)global::System.Linq.Enumerable.SingleOrDefault(global::Microsoft.OData.Client.Utility.GetCustomAttributes(clientType, typeof(global::Microsoft.OData.Client.OriginalNameAttribute), true));
            if (clientType.Namespace.Equals("ODataWebAPI.Tests.IronFramework.Utility.EntityFramewrok", global::System.StringComparison.Ordinal))
            {
                if (originalNameAttribute != null)
                {
                    return string.Concat("IronFramework.Utility.EntityFramewrok.", originalNameAttribute.OriginalName);
                }
                return string.Concat("IronFramework.Utility.EntityFramewrok.", clientType.Name);
            }
            if (clientType.Namespace.Equals("ODataWebAPI.Tests.BusinessEntities", global::System.StringComparison.Ordinal))
            {
                if (originalNameAttribute != null)
                {
                    return string.Concat("BusinessEntities.", originalNameAttribute.OriginalName);
                }
                return string.Concat("BusinessEntities.", clientType.Name);
            }
            return null;
        }
        /// <summary>
        /// There are no comments for Addresses in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "2.1.0")]
        public global::Microsoft.OData.Client.DataServiceQuery<Address> Addresses
        {
            get
            {
                if ((this._Addresses == null))
                {
                    this._Addresses = base.CreateQuery<Address>("Addresses");
                }
                return this._Addresses;
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "2.1.0")]
        private global::Microsoft.OData.Client.DataServiceQuery<Address> _Addresses;
        /// <summary>
        /// There are no comments for Addresses in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "2.1.0")]
        public void AddToAddresses(Address address)
        {
            base.AddObject("Addresses", address);
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "2.1.0")]
        private abstract class GeneratedEdmModel
        {
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "2.1.0")]
            private static global::Microsoft.OData.Edm.IEdmModel ParsedModel = LoadModelFromString();
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "2.1.0")]
            private const string Edmx = @"<edmx:Edmx Version=""4.0"" xmlns:edmx=""http://docs.oasis-open.org/odata/ns/edmx"">
  <edmx:DataServices>
    <Schema Namespace=""BusinessEntities"" xmlns=""http://docs.oasis-open.org/odata/ns/edm"">
      <EntityType Name=""Address"">
        <Key>
          <PropertyRef Name=""AddressID"" />
        </Key>
        <Property Name=""ModifiedDate"" Type=""Edm.DateTimeOffset"" />
        <Property Name=""AddressID"" Type=""Edm.Int32"" Nullable=""false"" />
        <Property Name=""AddressLine1"" Type=""Edm.String"" />
        <Property Name=""AddressLine2"" Type=""Edm.String"" />
        <Property Name=""City"" Type=""Edm.String"" />
        <Property Name=""StateProvinceID"" Type=""Edm.Int32"" />
        <Property Name=""PostalCode"" Type=""Edm.String"" />
        <Property Name=""rowguid"" Type=""Edm.Guid"" />
      </EntityType>
      <EntityContainer Name=""Container"">
        <EntitySet Name=""Addresses"" EntityType=""BusinessEntities.Address"" />
      </EntityContainer>
    </Schema>
    <Schema Namespace=""IronFramework.Utility.EntityFramewrok"" xmlns=""http://docs.oasis-open.org/odata/ns/edm"">
      <EnumType Name=""State"">
        <Member Name=""Unchanged"" Value=""0"" />
        <Member Name=""Added"" Value=""1"" />
        <Member Name=""Modified"" Value=""2"" />
        <Member Name=""Deleted"" Value=""3"" />
      </EnumType>
    </Schema>
  </edmx:DataServices>
</edmx:Edmx>";
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "2.1.0")]
            public static global::Microsoft.OData.Edm.IEdmModel GetInstance()
            {
                return ParsedModel;
            }
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "2.1.0")]
            private static global::Microsoft.OData.Edm.IEdmModel LoadModelFromString()
            {
                global::System.Xml.XmlReader reader = CreateXmlReader(Edmx);
                try
                {
                    return global::Microsoft.OData.Edm.Csdl.EdmxReader.Parse(reader);
                }
                finally
                {
                    ((global::System.IDisposable)(reader)).Dispose();
                }
            }
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "2.1.0")]
            private static global::System.Xml.XmlReader CreateXmlReader(string edmxToParse)
            {
                return global::System.Xml.XmlReader.Create(new global::System.IO.StringReader(edmxToParse));
            }
        }
    }
    /// <summary>
    /// There are no comments for AddressSingle in the schema.
    /// </summary>
    [global::Microsoft.OData.Client.OriginalNameAttribute("AddressSingle")]
    public partial class AddressSingle : global::Microsoft.OData.Client.DataServiceQuerySingle<Address>
    {
        /// <summary>
        /// Initialize a new AddressSingle object.
        /// </summary>
        public AddressSingle(global::Microsoft.OData.Client.DataServiceContext context, string path)
            : base(context, path) {}

        /// <summary>
        /// Initialize a new AddressSingle object.
        /// </summary>
        public AddressSingle(global::Microsoft.OData.Client.DataServiceContext context, string path, bool isComposable)
            : base(context, path, isComposable) {}
    }
    /// <summary>
    /// There are no comments for Address in the schema.
    /// </summary>
    /// <KeyProperties>
    /// AddressID
    /// </KeyProperties>
    [global::Microsoft.OData.Client.Key("AddressID")]
    [global::Microsoft.OData.Client.EntitySet("Addresses")]
    [global::Microsoft.OData.Client.OriginalNameAttribute("Address")]
    public partial class Address : global::System.ComponentModel.INotifyPropertyChanged
    {
        /// <summary>
        /// Create a new Address object.
        /// </summary>
        /// <param name="addressID">Initial value of AddressID.</param>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "2.1.0")]
        public static Address CreateAddress(int addressID)
        {
            Address address = new Address();
            address.AddressID = addressID;
            return address;
        }
        /// <summary>
        /// There are no comments for Property ModifiedDate in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "2.1.0")]
        [global::Microsoft.OData.Client.OriginalNameAttribute("ModifiedDate")]
        public global::System.Nullable<global::System.DateTimeOffset> ModifiedDate
        {
            get
            {
                return this._ModifiedDate;
            }
            set
            {
                this.OnModifiedDateChanging(value);
                this._ModifiedDate = value;
                this.OnModifiedDateChanged();
                this.OnPropertyChanged("ModifiedDate");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "2.1.0")]
        private global::System.Nullable<global::System.DateTimeOffset> _ModifiedDate;
        partial void OnModifiedDateChanging(global::System.Nullable<global::System.DateTimeOffset> value);
        partial void OnModifiedDateChanged();
        /// <summary>
        /// There are no comments for Property AddressID in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "2.1.0")]
        [global::Microsoft.OData.Client.OriginalNameAttribute("AddressID")]
        public int AddressID
        {
            get
            {
                return this._AddressID;
            }
            set
            {
                this.OnAddressIDChanging(value);
                this._AddressID = value;
                this.OnAddressIDChanged();
                this.OnPropertyChanged("AddressID");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "2.1.0")]
        private int _AddressID;
        partial void OnAddressIDChanging(int value);
        partial void OnAddressIDChanged();
        /// <summary>
        /// There are no comments for Property AddressLine1 in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "2.1.0")]
        [global::Microsoft.OData.Client.OriginalNameAttribute("AddressLine1")]
        public string AddressLine1
        {
            get
            {
                return this._AddressLine1;
            }
            set
            {
                this.OnAddressLine1Changing(value);
                this._AddressLine1 = value;
                this.OnAddressLine1Changed();
                this.OnPropertyChanged("AddressLine1");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "2.1.0")]
        private string _AddressLine1;
        partial void OnAddressLine1Changing(string value);
        partial void OnAddressLine1Changed();
        /// <summary>
        /// There are no comments for Property AddressLine2 in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "2.1.0")]
        [global::Microsoft.OData.Client.OriginalNameAttribute("AddressLine2")]
        public string AddressLine2
        {
            get
            {
                return this._AddressLine2;
            }
            set
            {
                this.OnAddressLine2Changing(value);
                this._AddressLine2 = value;
                this.OnAddressLine2Changed();
                this.OnPropertyChanged("AddressLine2");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "2.1.0")]
        private string _AddressLine2;
        partial void OnAddressLine2Changing(string value);
        partial void OnAddressLine2Changed();
        /// <summary>
        /// There are no comments for Property City in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "2.1.0")]
        [global::Microsoft.OData.Client.OriginalNameAttribute("City")]
        public string City
        {
            get
            {
                return this._City;
            }
            set
            {
                this.OnCityChanging(value);
                this._City = value;
                this.OnCityChanged();
                this.OnPropertyChanged("City");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "2.1.0")]
        private string _City;
        partial void OnCityChanging(string value);
        partial void OnCityChanged();
        /// <summary>
        /// There are no comments for Property StateProvinceID in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "2.1.0")]
        [global::Microsoft.OData.Client.OriginalNameAttribute("StateProvinceID")]
        public global::System.Nullable<int> StateProvinceID
        {
            get
            {
                return this._StateProvinceID;
            }
            set
            {
                this.OnStateProvinceIDChanging(value);
                this._StateProvinceID = value;
                this.OnStateProvinceIDChanged();
                this.OnPropertyChanged("StateProvinceID");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "2.1.0")]
        private global::System.Nullable<int> _StateProvinceID;
        partial void OnStateProvinceIDChanging(global::System.Nullable<int> value);
        partial void OnStateProvinceIDChanged();
        /// <summary>
        /// There are no comments for Property PostalCode in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "2.1.0")]
        [global::Microsoft.OData.Client.OriginalNameAttribute("PostalCode")]
        public string PostalCode
        {
            get
            {
                return this._PostalCode;
            }
            set
            {
                this.OnPostalCodeChanging(value);
                this._PostalCode = value;
                this.OnPostalCodeChanged();
                this.OnPropertyChanged("PostalCode");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "2.1.0")]
        private string _PostalCode;
        partial void OnPostalCodeChanging(string value);
        partial void OnPostalCodeChanged();
        /// <summary>
        /// There are no comments for Property Rowguid in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "2.1.0")]
        [global::Microsoft.OData.Client.OriginalNameAttribute("rowguid")]
        public global::System.Nullable<global::System.Guid> Rowguid
        {
            get
            {
                return this._Rowguid;
            }
            set
            {
                this.OnRowguidChanging(value);
                this._Rowguid = value;
                this.OnRowguidChanged();
                this.OnPropertyChanged("rowguid");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "2.1.0")]
        private global::System.Nullable<global::System.Guid> _Rowguid;
        partial void OnRowguidChanging(global::System.Nullable<global::System.Guid> value);
        partial void OnRowguidChanged();
        /// <summary>
        /// This event is raised when the value of the property is changed
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "2.1.0")]
        public event global::System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// The value of the property is changed
        /// </summary>
        /// <param name="property">property name</param>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.OData.Client.Design.T4", "2.1.0")]
        protected virtual void OnPropertyChanged(string property)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new global::System.ComponentModel.PropertyChangedEventArgs(property));
            }
        }
    }
    /// <summary>
    /// Class containing all extension methods
    /// </summary>
    public static class ExtensionMethods
    {
        /// <summary>
        /// Get an entity of type global::ODataWebAPI.Tests.BusinessEntities.Address as global::ODataWebAPI.Tests.BusinessEntities.AddressSingle specified by key from an entity set
        /// </summary>
        /// <param name="source">source entity set</param>
        /// <param name="keys">dictionary with the names and values of keys</param>
        public static global::ODataWebAPI.Tests.BusinessEntities.AddressSingle ByKey(this global::Microsoft.OData.Client.DataServiceQuery<global::ODataWebAPI.Tests.BusinessEntities.Address> source, global::System.Collections.Generic.Dictionary<string, object> keys)
        {
            return new global::ODataWebAPI.Tests.BusinessEntities.AddressSingle(source.Context, source.GetKeyPath(global::Microsoft.OData.Client.Serializer.GetKeyString(source.Context, keys)));
        }
        /// <summary>
        /// Get an entity of type global::ODataWebAPI.Tests.BusinessEntities.Address as global::ODataWebAPI.Tests.BusinessEntities.AddressSingle specified by key from an entity set
        /// </summary>
        /// <param name="source">source entity set</param>
        /// <param name="addressID">The value of addressID</param>
        public static global::ODataWebAPI.Tests.BusinessEntities.AddressSingle ByKey(this global::Microsoft.OData.Client.DataServiceQuery<global::ODataWebAPI.Tests.BusinessEntities.Address> source,
            int addressID)
        {
            global::System.Collections.Generic.Dictionary<string, object> keys = new global::System.Collections.Generic.Dictionary<string, object>
            {
                { "AddressID", addressID }
            };
            return new global::ODataWebAPI.Tests.BusinessEntities.AddressSingle(source.Context, source.GetKeyPath(global::Microsoft.OData.Client.Serializer.GetKeyString(source.Context, keys)));
        }
    }
}
namespace ODataWebAPI.Tests.IronFramework.Utility.EntityFramewrok
{
    /// <summary>
    /// There are no comments for State in the schema.
    /// </summary>
    [global::Microsoft.OData.Client.OriginalNameAttribute("State")]
    public enum State
    {
        [global::Microsoft.OData.Client.OriginalNameAttribute("Unchanged")]
        Unchanged = 0,
        [global::Microsoft.OData.Client.OriginalNameAttribute("Added")]
        Added = 1,
        [global::Microsoft.OData.Client.OriginalNameAttribute("Modified")]
        Modified = 2,
        [global::Microsoft.OData.Client.OriginalNameAttribute("Deleted")]
        Deleted = 3
    }
}
