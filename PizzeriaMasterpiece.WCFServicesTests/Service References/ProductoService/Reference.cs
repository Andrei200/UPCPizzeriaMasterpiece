﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PizzeriaMasterpiece.WCFServicesTests.ProductoService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ProductDTO", Namespace="http://schemas.datacontract.org/2004/07/PizzeriaMasterpiece.DTO")]
    [System.SerializableAttribute()]
    public partial class ProductDTO : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DescriptionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ImagePathField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<byte> IsActiveField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<decimal> PriceField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ProductIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> SizeIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SizeNameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Code {
            get {
                return this.CodeField;
            }
            set {
                if ((object.ReferenceEquals(this.CodeField, value) != true)) {
                    this.CodeField = value;
                    this.RaisePropertyChanged("Code");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Description {
            get {
                return this.DescriptionField;
            }
            set {
                if ((object.ReferenceEquals(this.DescriptionField, value) != true)) {
                    this.DescriptionField = value;
                    this.RaisePropertyChanged("Description");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ImagePath {
            get {
                return this.ImagePathField;
            }
            set {
                if ((object.ReferenceEquals(this.ImagePathField, value) != true)) {
                    this.ImagePathField = value;
                    this.RaisePropertyChanged("ImagePath");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<byte> IsActive {
            get {
                return this.IsActiveField;
            }
            set {
                if ((this.IsActiveField.Equals(value) != true)) {
                    this.IsActiveField = value;
                    this.RaisePropertyChanged("IsActive");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<decimal> Price {
            get {
                return this.PriceField;
            }
            set {
                if ((this.PriceField.Equals(value) != true)) {
                    this.PriceField = value;
                    this.RaisePropertyChanged("Price");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ProductId {
            get {
                return this.ProductIdField;
            }
            set {
                if ((this.ProductIdField.Equals(value) != true)) {
                    this.ProductIdField = value;
                    this.RaisePropertyChanged("ProductId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> SizeId {
            get {
                return this.SizeIdField;
            }
            set {
                if ((this.SizeIdField.Equals(value) != true)) {
                    this.SizeIdField = value;
                    this.RaisePropertyChanged("SizeId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string SizeName {
            get {
                return this.SizeNameField;
            }
            set {
                if ((object.ReferenceEquals(this.SizeNameField, value) != true)) {
                    this.SizeNameField = value;
                    this.RaisePropertyChanged("SizeName");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="SupplyProductDTO", Namespace="http://schemas.datacontract.org/2004/07/PizzeriaMasterpiece.DTO")]
    [System.SerializableAttribute()]
    public partial class SupplyProductDTO : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DescriptionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<byte> IsActiveField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private PizzeriaMasterpiece.WCFServicesTests.ProductoService.SupplyProductDetailDTO[] ProductDetailsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> QuantityField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> SupplyIdField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Code {
            get {
                return this.CodeField;
            }
            set {
                if ((object.ReferenceEquals(this.CodeField, value) != true)) {
                    this.CodeField = value;
                    this.RaisePropertyChanged("Code");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Description {
            get {
                return this.DescriptionField;
            }
            set {
                if ((object.ReferenceEquals(this.DescriptionField, value) != true)) {
                    this.DescriptionField = value;
                    this.RaisePropertyChanged("Description");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<byte> IsActive {
            get {
                return this.IsActiveField;
            }
            set {
                if ((this.IsActiveField.Equals(value) != true)) {
                    this.IsActiveField = value;
                    this.RaisePropertyChanged("IsActive");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public PizzeriaMasterpiece.WCFServicesTests.ProductoService.SupplyProductDetailDTO[] ProductDetails {
            get {
                return this.ProductDetailsField;
            }
            set {
                if ((object.ReferenceEquals(this.ProductDetailsField, value) != true)) {
                    this.ProductDetailsField = value;
                    this.RaisePropertyChanged("ProductDetails");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> Quantity {
            get {
                return this.QuantityField;
            }
            set {
                if ((this.QuantityField.Equals(value) != true)) {
                    this.QuantityField = value;
                    this.RaisePropertyChanged("Quantity");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> SupplyId {
            get {
                return this.SupplyIdField;
            }
            set {
                if ((this.SupplyIdField.Equals(value) != true)) {
                    this.SupplyIdField = value;
                    this.RaisePropertyChanged("SupplyId");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="SupplyProductDetailDTO", Namespace="http://schemas.datacontract.org/2004/07/PizzeriaMasterpiece.DTO")]
    [System.SerializableAttribute()]
    public partial class SupplyProductDetailDTO : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DescriptionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> ProductIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> QuantityField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Code {
            get {
                return this.CodeField;
            }
            set {
                if ((object.ReferenceEquals(this.CodeField, value) != true)) {
                    this.CodeField = value;
                    this.RaisePropertyChanged("Code");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Description {
            get {
                return this.DescriptionField;
            }
            set {
                if ((object.ReferenceEquals(this.DescriptionField, value) != true)) {
                    this.DescriptionField = value;
                    this.RaisePropertyChanged("Description");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> ProductId {
            get {
                return this.ProductIdField;
            }
            set {
                if ((this.ProductIdField.Equals(value) != true)) {
                    this.ProductIdField = value;
                    this.RaisePropertyChanged("ProductId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> Quantity {
            get {
                return this.QuantityField;
            }
            set {
                if ((this.QuantityField.Equals(value) != true)) {
                    this.QuantityField = value;
                    this.RaisePropertyChanged("Quantity");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ProductoService.IProductService")]
    public interface IProductService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/GetProductInformation", ReplyAction="http://tempuri.org/IProductService/GetProductInformationResponse")]
        PizzeriaMasterpiece.WCFServicesTests.ProductoService.ProductDTO GetProductInformation(int productId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/GetProductInformation", ReplyAction="http://tempuri.org/IProductService/GetProductInformationResponse")]
        System.Threading.Tasks.Task<PizzeriaMasterpiece.WCFServicesTests.ProductoService.ProductDTO> GetProductInformationAsync(int productId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/InsertProductInformation", ReplyAction="http://tempuri.org/IProductService/InsertProductInformationResponse")]
        PizzeriaMasterpiece.WCFServicesTests.ProductoService.ProductDTO InsertProductInformation(PizzeriaMasterpiece.WCFServicesTests.ProductoService.ProductDTO product);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/InsertProductInformation", ReplyAction="http://tempuri.org/IProductService/InsertProductInformationResponse")]
        System.Threading.Tasks.Task<PizzeriaMasterpiece.WCFServicesTests.ProductoService.ProductDTO> InsertProductInformationAsync(PizzeriaMasterpiece.WCFServicesTests.ProductoService.ProductDTO product);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/UpdateProductInformation", ReplyAction="http://tempuri.org/IProductService/UpdateProductInformationResponse")]
        PizzeriaMasterpiece.WCFServicesTests.ProductoService.ProductDTO UpdateProductInformation(PizzeriaMasterpiece.WCFServicesTests.ProductoService.ProductDTO product);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/UpdateProductInformation", ReplyAction="http://tempuri.org/IProductService/UpdateProductInformationResponse")]
        System.Threading.Tasks.Task<PizzeriaMasterpiece.WCFServicesTests.ProductoService.ProductDTO> UpdateProductInformationAsync(PizzeriaMasterpiece.WCFServicesTests.ProductoService.ProductDTO product);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/ListAllProductInformation", ReplyAction="http://tempuri.org/IProductService/ListAllProductInformationResponse")]
        PizzeriaMasterpiece.WCFServicesTests.ProductoService.ProductDTO[] ListAllProductInformation();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/ListAllProductInformation", ReplyAction="http://tempuri.org/IProductService/ListAllProductInformationResponse")]
        System.Threading.Tasks.Task<PizzeriaMasterpiece.WCFServicesTests.ProductoService.ProductDTO[]> ListAllProductInformationAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/ListAllProductBySupply", ReplyAction="http://tempuri.org/IProductService/ListAllProductBySupplyResponse")]
        PizzeriaMasterpiece.WCFServicesTests.ProductoService.SupplyProductDTO[] ListAllProductBySupply(int supplyId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/ListAllProductBySupply", ReplyAction="http://tempuri.org/IProductService/ListAllProductBySupplyResponse")]
        System.Threading.Tasks.Task<PizzeriaMasterpiece.WCFServicesTests.ProductoService.SupplyProductDTO[]> ListAllProductBySupplyAsync(int supplyId);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IProductServiceChannel : PizzeriaMasterpiece.WCFServicesTests.ProductoService.IProductService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ProductServiceClient : System.ServiceModel.ClientBase<PizzeriaMasterpiece.WCFServicesTests.ProductoService.IProductService>, PizzeriaMasterpiece.WCFServicesTests.ProductoService.IProductService {
        
        public ProductServiceClient() {
        }
        
        public ProductServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ProductServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ProductServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ProductServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public PizzeriaMasterpiece.WCFServicesTests.ProductoService.ProductDTO GetProductInformation(int productId) {
            return base.Channel.GetProductInformation(productId);
        }
        
        public System.Threading.Tasks.Task<PizzeriaMasterpiece.WCFServicesTests.ProductoService.ProductDTO> GetProductInformationAsync(int productId) {
            return base.Channel.GetProductInformationAsync(productId);
        }
        
        public PizzeriaMasterpiece.WCFServicesTests.ProductoService.ProductDTO InsertProductInformation(PizzeriaMasterpiece.WCFServicesTests.ProductoService.ProductDTO product) {
            return base.Channel.InsertProductInformation(product);
        }
        
        public System.Threading.Tasks.Task<PizzeriaMasterpiece.WCFServicesTests.ProductoService.ProductDTO> InsertProductInformationAsync(PizzeriaMasterpiece.WCFServicesTests.ProductoService.ProductDTO product) {
            return base.Channel.InsertProductInformationAsync(product);
        }
        
        public PizzeriaMasterpiece.WCFServicesTests.ProductoService.ProductDTO UpdateProductInformation(PizzeriaMasterpiece.WCFServicesTests.ProductoService.ProductDTO product) {
            return base.Channel.UpdateProductInformation(product);
        }
        
        public System.Threading.Tasks.Task<PizzeriaMasterpiece.WCFServicesTests.ProductoService.ProductDTO> UpdateProductInformationAsync(PizzeriaMasterpiece.WCFServicesTests.ProductoService.ProductDTO product) {
            return base.Channel.UpdateProductInformationAsync(product);
        }
        
        public PizzeriaMasterpiece.WCFServicesTests.ProductoService.ProductDTO[] ListAllProductInformation() {
            return base.Channel.ListAllProductInformation();
        }
        
        public System.Threading.Tasks.Task<PizzeriaMasterpiece.WCFServicesTests.ProductoService.ProductDTO[]> ListAllProductInformationAsync() {
            return base.Channel.ListAllProductInformationAsync();
        }
        
        public PizzeriaMasterpiece.WCFServicesTests.ProductoService.SupplyProductDTO[] ListAllProductBySupply(int supplyId) {
            return base.Channel.ListAllProductBySupply(supplyId);
        }
        
        public System.Threading.Tasks.Task<PizzeriaMasterpiece.WCFServicesTests.ProductoService.SupplyProductDTO[]> ListAllProductBySupplyAsync(int supplyId) {
            return base.Channel.ListAllProductBySupplyAsync(supplyId);
        }
    }
}
