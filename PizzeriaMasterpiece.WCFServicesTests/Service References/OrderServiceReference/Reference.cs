﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PizzeriaMasterpiece.WCFServicesTests.OrderServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="OrderDTO", Namespace="http://schemas.datacontract.org/2004/07/PizzeriaMasterpiece.DTO")]
    [System.SerializableAttribute()]
    public partial class OrderDTO : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AddressField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<System.DateTime> DateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> DocumentTypeIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DocumentTypeNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private PizzeriaMasterpiece.WCFServicesTests.OrderServiceReference.OrderDetailDTO[] OrderDetailsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int OrderIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string OrderNoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> OrderStatusIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string OrderStatusNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string RemarkField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> UserIdField;
        
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
        public string Address {
            get {
                return this.AddressField;
            }
            set {
                if ((object.ReferenceEquals(this.AddressField, value) != true)) {
                    this.AddressField = value;
                    this.RaisePropertyChanged("Address");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<System.DateTime> Date {
            get {
                return this.DateField;
            }
            set {
                if ((this.DateField.Equals(value) != true)) {
                    this.DateField = value;
                    this.RaisePropertyChanged("Date");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> DocumentTypeId {
            get {
                return this.DocumentTypeIdField;
            }
            set {
                if ((this.DocumentTypeIdField.Equals(value) != true)) {
                    this.DocumentTypeIdField = value;
                    this.RaisePropertyChanged("DocumentTypeId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string DocumentTypeName {
            get {
                return this.DocumentTypeNameField;
            }
            set {
                if ((object.ReferenceEquals(this.DocumentTypeNameField, value) != true)) {
                    this.DocumentTypeNameField = value;
                    this.RaisePropertyChanged("DocumentTypeName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public PizzeriaMasterpiece.WCFServicesTests.OrderServiceReference.OrderDetailDTO[] OrderDetails {
            get {
                return this.OrderDetailsField;
            }
            set {
                if ((object.ReferenceEquals(this.OrderDetailsField, value) != true)) {
                    this.OrderDetailsField = value;
                    this.RaisePropertyChanged("OrderDetails");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int OrderId {
            get {
                return this.OrderIdField;
            }
            set {
                if ((this.OrderIdField.Equals(value) != true)) {
                    this.OrderIdField = value;
                    this.RaisePropertyChanged("OrderId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string OrderNo {
            get {
                return this.OrderNoField;
            }
            set {
                if ((object.ReferenceEquals(this.OrderNoField, value) != true)) {
                    this.OrderNoField = value;
                    this.RaisePropertyChanged("OrderNo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> OrderStatusId {
            get {
                return this.OrderStatusIdField;
            }
            set {
                if ((this.OrderStatusIdField.Equals(value) != true)) {
                    this.OrderStatusIdField = value;
                    this.RaisePropertyChanged("OrderStatusId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string OrderStatusName {
            get {
                return this.OrderStatusNameField;
            }
            set {
                if ((object.ReferenceEquals(this.OrderStatusNameField, value) != true)) {
                    this.OrderStatusNameField = value;
                    this.RaisePropertyChanged("OrderStatusName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Remark {
            get {
                return this.RemarkField;
            }
            set {
                if ((object.ReferenceEquals(this.RemarkField, value) != true)) {
                    this.RemarkField = value;
                    this.RaisePropertyChanged("Remark");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> UserId {
            get {
                return this.UserIdField;
            }
            set {
                if ((this.UserIdField.Equals(value) != true)) {
                    this.UserIdField = value;
                    this.RaisePropertyChanged("UserId");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="OrderDetailDTO", Namespace="http://schemas.datacontract.org/2004/07/PizzeriaMasterpiece.DTO")]
    [System.SerializableAttribute()]
    public partial class OrderDetailDTO : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int OrderDetailIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal PriceField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ProductIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ProductNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int QuantityField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private PizzeriaMasterpiece.WCFServicesTests.OrderServiceReference.SupplyDTO[] SuppliesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal TotalPriceField;
        
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
        public int OrderDetailId {
            get {
                return this.OrderDetailIdField;
            }
            set {
                if ((this.OrderDetailIdField.Equals(value) != true)) {
                    this.OrderDetailIdField = value;
                    this.RaisePropertyChanged("OrderDetailId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal Price {
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
        public string ProductName {
            get {
                return this.ProductNameField;
            }
            set {
                if ((object.ReferenceEquals(this.ProductNameField, value) != true)) {
                    this.ProductNameField = value;
                    this.RaisePropertyChanged("ProductName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Quantity {
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
        public PizzeriaMasterpiece.WCFServicesTests.OrderServiceReference.SupplyDTO[] Supplies {
            get {
                return this.SuppliesField;
            }
            set {
                if ((object.ReferenceEquals(this.SuppliesField, value) != true)) {
                    this.SuppliesField = value;
                    this.RaisePropertyChanged("Supplies");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal TotalPrice {
            get {
                return this.TotalPriceField;
            }
            set {
                if ((this.TotalPriceField.Equals(value) != true)) {
                    this.TotalPriceField = value;
                    this.RaisePropertyChanged("TotalPrice");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="SupplyDTO", Namespace="http://schemas.datacontract.org/2004/07/PizzeriaMasterpiece.DTO")]
    [System.SerializableAttribute()]
    public partial class SupplyDTO : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
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
    [System.Runtime.Serialization.DataContractAttribute(Name="OrderStatusDTO", Namespace="http://schemas.datacontract.org/2004/07/PizzeriaMasterpiece.DTO")]
    [System.SerializableAttribute()]
    public partial class OrderStatusDTO : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int OrderIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int OrderStatusIdField;
        
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
        public int OrderId {
            get {
                return this.OrderIdField;
            }
            set {
                if ((this.OrderIdField.Equals(value) != true)) {
                    this.OrderIdField = value;
                    this.RaisePropertyChanged("OrderId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int OrderStatusId {
            get {
                return this.OrderStatusIdField;
            }
            set {
                if ((this.OrderStatusIdField.Equals(value) != true)) {
                    this.OrderStatusIdField = value;
                    this.RaisePropertyChanged("OrderStatusId");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="ResponseDTO", Namespace="http://schemas.datacontract.org/2004/07/PizzeriaMasterpiece.DTO")]
    [System.SerializableAttribute()]
    public partial class ResponseDTO : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MessageField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int StatusField;
        
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
        public string Message {
            get {
                return this.MessageField;
            }
            set {
                if ((object.ReferenceEquals(this.MessageField, value) != true)) {
                    this.MessageField = value;
                    this.RaisePropertyChanged("Message");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Status {
            get {
                return this.StatusField;
            }
            set {
                if ((this.StatusField.Equals(value) != true)) {
                    this.StatusField = value;
                    this.RaisePropertyChanged("Status");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="OrderServiceReference.IOrderService")]
    public interface IOrderService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOrderService/GetOrdersByClient", ReplyAction="http://tempuri.org/IOrderService/GetOrdersByClientResponse")]
        PizzeriaMasterpiece.WCFServicesTests.OrderServiceReference.OrderDTO[] GetOrdersByClient(int userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOrderService/GetOrdersByClient", ReplyAction="http://tempuri.org/IOrderService/GetOrdersByClientResponse")]
        System.Threading.Tasks.Task<PizzeriaMasterpiece.WCFServicesTests.OrderServiceReference.OrderDTO[]> GetOrdersByClientAsync(int userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOrderService/UpdateOrderStatus", ReplyAction="http://tempuri.org/IOrderService/UpdateOrderStatusResponse")]
        PizzeriaMasterpiece.WCFServicesTests.OrderServiceReference.ResponseDTO UpdateOrderStatus(PizzeriaMasterpiece.WCFServicesTests.OrderServiceReference.OrderStatusDTO order);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOrderService/UpdateOrderStatus", ReplyAction="http://tempuri.org/IOrderService/UpdateOrderStatusResponse")]
        System.Threading.Tasks.Task<PizzeriaMasterpiece.WCFServicesTests.OrderServiceReference.ResponseDTO> UpdateOrderStatusAsync(PizzeriaMasterpiece.WCFServicesTests.OrderServiceReference.OrderStatusDTO order);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IOrderServiceChannel : PizzeriaMasterpiece.WCFServicesTests.OrderServiceReference.IOrderService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class OrderServiceClient : System.ServiceModel.ClientBase<PizzeriaMasterpiece.WCFServicesTests.OrderServiceReference.IOrderService>, PizzeriaMasterpiece.WCFServicesTests.OrderServiceReference.IOrderService {
        
        public OrderServiceClient() {
        }
        
        public OrderServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public OrderServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public OrderServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public OrderServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public PizzeriaMasterpiece.WCFServicesTests.OrderServiceReference.OrderDTO[] GetOrdersByClient(int userId) {
            return base.Channel.GetOrdersByClient(userId);
        }
        
        public System.Threading.Tasks.Task<PizzeriaMasterpiece.WCFServicesTests.OrderServiceReference.OrderDTO[]> GetOrdersByClientAsync(int userId) {
            return base.Channel.GetOrdersByClientAsync(userId);
        }
        
        public PizzeriaMasterpiece.WCFServicesTests.OrderServiceReference.ResponseDTO UpdateOrderStatus(PizzeriaMasterpiece.WCFServicesTests.OrderServiceReference.OrderStatusDTO order) {
            return base.Channel.UpdateOrderStatus(order);
        }
        
        public System.Threading.Tasks.Task<PizzeriaMasterpiece.WCFServicesTests.OrderServiceReference.ResponseDTO> UpdateOrderStatusAsync(PizzeriaMasterpiece.WCFServicesTests.OrderServiceReference.OrderStatusDTO order) {
            return base.Channel.UpdateOrderStatusAsync(order);
        }
    }
}