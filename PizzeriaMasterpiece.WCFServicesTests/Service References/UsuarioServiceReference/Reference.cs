﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PizzeriaMasterpiece.WCFServicesTests.UsuarioServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="UsuarioDTO", Namespace="http://schemas.datacontract.org/2004/07/PizzeriaMasterpiece.Model")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(PizzeriaMasterpiece.WCFServicesTests.UsuarioServiceReference.UsuarioRegistroDTO))]
    public partial class UsuarioDTO : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ApellidoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CorreoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DNIField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DireccionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdUsuarioField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NombreField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TelefonoField;
        
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
        public string Apellido {
            get {
                return this.ApellidoField;
            }
            set {
                if ((object.ReferenceEquals(this.ApellidoField, value) != true)) {
                    this.ApellidoField = value;
                    this.RaisePropertyChanged("Apellido");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Correo {
            get {
                return this.CorreoField;
            }
            set {
                if ((object.ReferenceEquals(this.CorreoField, value) != true)) {
                    this.CorreoField = value;
                    this.RaisePropertyChanged("Correo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string DNI {
            get {
                return this.DNIField;
            }
            set {
                if ((object.ReferenceEquals(this.DNIField, value) != true)) {
                    this.DNIField = value;
                    this.RaisePropertyChanged("DNI");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Direccion {
            get {
                return this.DireccionField;
            }
            set {
                if ((object.ReferenceEquals(this.DireccionField, value) != true)) {
                    this.DireccionField = value;
                    this.RaisePropertyChanged("Direccion");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int IdUsuario {
            get {
                return this.IdUsuarioField;
            }
            set {
                if ((this.IdUsuarioField.Equals(value) != true)) {
                    this.IdUsuarioField = value;
                    this.RaisePropertyChanged("IdUsuario");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Nombre {
            get {
                return this.NombreField;
            }
            set {
                if ((object.ReferenceEquals(this.NombreField, value) != true)) {
                    this.NombreField = value;
                    this.RaisePropertyChanged("Nombre");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Telefono {
            get {
                return this.TelefonoField;
            }
            set {
                if ((object.ReferenceEquals(this.TelefonoField, value) != true)) {
                    this.TelefonoField = value;
                    this.RaisePropertyChanged("Telefono");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="UsuarioRegistroDTO", Namespace="http://schemas.datacontract.org/2004/07/PizzeriaMasterpiece.Model")]
    [System.SerializableAttribute()]
    public partial class UsuarioRegistroDTO : PizzeriaMasterpiece.WCFServicesTests.UsuarioServiceReference.UsuarioDTO {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ContrasenaField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Contrasena {
            get {
                return this.ContrasenaField;
            }
            set {
                if ((object.ReferenceEquals(this.ContrasenaField, value) != true)) {
                    this.ContrasenaField = value;
                    this.RaisePropertyChanged("Contrasena");
                }
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="UsuarioServiceReference.IUsuarioService")]
    public interface IUsuarioService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUsuarioService/GetUserInformation", ReplyAction="http://tempuri.org/IUsuarioService/GetUserInformationResponse")]
        PizzeriaMasterpiece.WCFServicesTests.UsuarioServiceReference.UsuarioDTO GetUserInformation(int usuarioId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUsuarioService/GetUserInformation", ReplyAction="http://tempuri.org/IUsuarioService/GetUserInformationResponse")]
        System.Threading.Tasks.Task<PizzeriaMasterpiece.WCFServicesTests.UsuarioServiceReference.UsuarioDTO> GetUserInformationAsync(int usuarioId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUsuarioService/InsertUserInformation", ReplyAction="http://tempuri.org/IUsuarioService/InsertUserInformationResponse")]
        PizzeriaMasterpiece.WCFServicesTests.UsuarioServiceReference.UsuarioDTO InsertUserInformation(PizzeriaMasterpiece.WCFServicesTests.UsuarioServiceReference.UsuarioRegistroDTO usuario);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUsuarioService/InsertUserInformation", ReplyAction="http://tempuri.org/IUsuarioService/InsertUserInformationResponse")]
        System.Threading.Tasks.Task<PizzeriaMasterpiece.WCFServicesTests.UsuarioServiceReference.UsuarioDTO> InsertUserInformationAsync(PizzeriaMasterpiece.WCFServicesTests.UsuarioServiceReference.UsuarioRegistroDTO usuario);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IUsuarioServiceChannel : PizzeriaMasterpiece.WCFServicesTests.UsuarioServiceReference.IUsuarioService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class UsuarioServiceClient : System.ServiceModel.ClientBase<PizzeriaMasterpiece.WCFServicesTests.UsuarioServiceReference.IUsuarioService>, PizzeriaMasterpiece.WCFServicesTests.UsuarioServiceReference.IUsuarioService {
        
        public UsuarioServiceClient() {
        }
        
        public UsuarioServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public UsuarioServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UsuarioServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UsuarioServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public PizzeriaMasterpiece.WCFServicesTests.UsuarioServiceReference.UsuarioDTO GetUserInformation(int usuarioId) {
            return base.Channel.GetUserInformation(usuarioId);
        }
        
        public System.Threading.Tasks.Task<PizzeriaMasterpiece.WCFServicesTests.UsuarioServiceReference.UsuarioDTO> GetUserInformationAsync(int usuarioId) {
            return base.Channel.GetUserInformationAsync(usuarioId);
        }
        
        public PizzeriaMasterpiece.WCFServicesTests.UsuarioServiceReference.UsuarioDTO InsertUserInformation(PizzeriaMasterpiece.WCFServicesTests.UsuarioServiceReference.UsuarioRegistroDTO usuario) {
            return base.Channel.InsertUserInformation(usuario);
        }
        
        public System.Threading.Tasks.Task<PizzeriaMasterpiece.WCFServicesTests.UsuarioServiceReference.UsuarioDTO> InsertUserInformationAsync(PizzeriaMasterpiece.WCFServicesTests.UsuarioServiceReference.UsuarioRegistroDTO usuario) {
            return base.Channel.InsertUserInformationAsync(usuario);
        }
    }
}