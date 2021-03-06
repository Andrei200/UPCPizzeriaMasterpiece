﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PizzeriaMasterpiece.ProductServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ProductServiceReference.IProductService")]
    public interface IProductService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/GetProductInformation", ReplyAction="http://tempuri.org/IProductService/GetProductInformationResponse")]
        PizzeriaMasterpiece.DTO.ProductDTO GetProductInformation(int productId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/GetProductInformation", ReplyAction="http://tempuri.org/IProductService/GetProductInformationResponse")]
        System.Threading.Tasks.Task<PizzeriaMasterpiece.DTO.ProductDTO> GetProductInformationAsync(int productId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/InsertProductInformation", ReplyAction="http://tempuri.org/IProductService/InsertProductInformationResponse")]
        PizzeriaMasterpiece.DTO.ProductDTO InsertProductInformation(PizzeriaMasterpiece.DTO.ProductDTO product);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/InsertProductInformation", ReplyAction="http://tempuri.org/IProductService/InsertProductInformationResponse")]
        System.Threading.Tasks.Task<PizzeriaMasterpiece.DTO.ProductDTO> InsertProductInformationAsync(PizzeriaMasterpiece.DTO.ProductDTO product);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/UpdateProductInformation", ReplyAction="http://tempuri.org/IProductService/UpdateProductInformationResponse")]
        PizzeriaMasterpiece.DTO.ProductDTO UpdateProductInformation(PizzeriaMasterpiece.DTO.ProductDTO product);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/UpdateProductInformation", ReplyAction="http://tempuri.org/IProductService/UpdateProductInformationResponse")]
        System.Threading.Tasks.Task<PizzeriaMasterpiece.DTO.ProductDTO> UpdateProductInformationAsync(PizzeriaMasterpiece.DTO.ProductDTO product);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/ListAllProductInformation", ReplyAction="http://tempuri.org/IProductService/ListAllProductInformationResponse")]
        PizzeriaMasterpiece.DTO.ProductDTO[] ListAllProductInformation();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/ListAllProductInformation", ReplyAction="http://tempuri.org/IProductService/ListAllProductInformationResponse")]
        System.Threading.Tasks.Task<PizzeriaMasterpiece.DTO.ProductDTO[]> ListAllProductInformationAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/ListAllProductBySupply", ReplyAction="http://tempuri.org/IProductService/ListAllProductBySupplyResponse")]
        PizzeriaMasterpiece.DTO.SupplyProductDTO[] ListAllProductBySupply(int supplyId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/ListAllProductBySupply", ReplyAction="http://tempuri.org/IProductService/ListAllProductBySupplyResponse")]
        System.Threading.Tasks.Task<PizzeriaMasterpiece.DTO.SupplyProductDTO[]> ListAllProductBySupplyAsync(int supplyId);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IProductServiceChannel : PizzeriaMasterpiece.ProductServiceReference.IProductService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ProductServiceClient : System.ServiceModel.ClientBase<PizzeriaMasterpiece.ProductServiceReference.IProductService>, PizzeriaMasterpiece.ProductServiceReference.IProductService {
        
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
        
        public PizzeriaMasterpiece.DTO.ProductDTO GetProductInformation(int productId) {
            return base.Channel.GetProductInformation(productId);
        }
        
        public System.Threading.Tasks.Task<PizzeriaMasterpiece.DTO.ProductDTO> GetProductInformationAsync(int productId) {
            return base.Channel.GetProductInformationAsync(productId);
        }
        
        public PizzeriaMasterpiece.DTO.ProductDTO InsertProductInformation(PizzeriaMasterpiece.DTO.ProductDTO product) {
            return base.Channel.InsertProductInformation(product);
        }
        
        public System.Threading.Tasks.Task<PizzeriaMasterpiece.DTO.ProductDTO> InsertProductInformationAsync(PizzeriaMasterpiece.DTO.ProductDTO product) {
            return base.Channel.InsertProductInformationAsync(product);
        }
        
        public PizzeriaMasterpiece.DTO.ProductDTO UpdateProductInformation(PizzeriaMasterpiece.DTO.ProductDTO product) {
            return base.Channel.UpdateProductInformation(product);
        }
        
        public System.Threading.Tasks.Task<PizzeriaMasterpiece.DTO.ProductDTO> UpdateProductInformationAsync(PizzeriaMasterpiece.DTO.ProductDTO product) {
            return base.Channel.UpdateProductInformationAsync(product);
        }
        
        public PizzeriaMasterpiece.DTO.ProductDTO[] ListAllProductInformation() {
            return base.Channel.ListAllProductInformation();
        }
        
        public System.Threading.Tasks.Task<PizzeriaMasterpiece.DTO.ProductDTO[]> ListAllProductInformationAsync() {
            return base.Channel.ListAllProductInformationAsync();
        }
        
        public PizzeriaMasterpiece.DTO.SupplyProductDTO[] ListAllProductBySupply(int supplyId) {
            return base.Channel.ListAllProductBySupply(supplyId);
        }
        
        public System.Threading.Tasks.Task<PizzeriaMasterpiece.DTO.SupplyProductDTO[]> ListAllProductBySupplyAsync(int supplyId) {
            return base.Channel.ListAllProductBySupplyAsync(supplyId);
        }
    }
}
