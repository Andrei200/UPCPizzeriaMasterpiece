﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PizzeriaMasterpiece.OrderServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="OrderServiceReference.IOrderService")]
    public interface IOrderService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOrderService/GetOrdersByClient", ReplyAction="http://tempuri.org/IOrderService/GetOrdersByClientResponse")]
        PizzeriaMasterpiece.DTO.OrderDTO[] GetOrdersByClient(int userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOrderService/GetOrdersByClient", ReplyAction="http://tempuri.org/IOrderService/GetOrdersByClientResponse")]
        System.Threading.Tasks.Task<PizzeriaMasterpiece.DTO.OrderDTO[]> GetOrdersByClientAsync(int userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOrderService/GetOrdersByCriteria", ReplyAction="http://tempuri.org/IOrderService/GetOrdersByCriteriaResponse")]
        PizzeriaMasterpiece.DTO.OrderWorkerDTO[] GetOrdersByCriteria(PizzeriaMasterpiece.DTO.OrderSearchCriteriaDTO criteria);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOrderService/GetOrdersByCriteria", ReplyAction="http://tempuri.org/IOrderService/GetOrdersByCriteriaResponse")]
        System.Threading.Tasks.Task<PizzeriaMasterpiece.DTO.OrderWorkerDTO[]> GetOrdersByCriteriaAsync(PizzeriaMasterpiece.DTO.OrderSearchCriteriaDTO criteria);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IOrderServiceChannel : PizzeriaMasterpiece.OrderServiceReference.IOrderService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class OrderServiceClient : System.ServiceModel.ClientBase<PizzeriaMasterpiece.OrderServiceReference.IOrderService>, PizzeriaMasterpiece.OrderServiceReference.IOrderService {
        
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
        
        public PizzeriaMasterpiece.DTO.OrderDTO[] GetOrdersByClient(int userId) {
            return base.Channel.GetOrdersByClient(userId);
        }
        
        public System.Threading.Tasks.Task<PizzeriaMasterpiece.DTO.OrderDTO[]> GetOrdersByClientAsync(int userId) {
            return base.Channel.GetOrdersByClientAsync(userId);
        }
        
        public PizzeriaMasterpiece.DTO.OrderWorkerDTO[] GetOrdersByCriteria(PizzeriaMasterpiece.DTO.OrderSearchCriteriaDTO criteria) {
            return base.Channel.GetOrdersByCriteria(criteria);
        }
        
        public System.Threading.Tasks.Task<PizzeriaMasterpiece.DTO.OrderWorkerDTO[]> GetOrdersByCriteriaAsync(PizzeriaMasterpiece.DTO.OrderSearchCriteriaDTO criteria) {
            return base.Channel.GetOrdersByCriteriaAsync(criteria);
        }
    }
}