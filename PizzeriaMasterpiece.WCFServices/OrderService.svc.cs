using PizzeriaMasterpiece.DTO;
using PizzeriaMasterpiece.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzeriaMasterpiece.WCFServices
{
    public class OrderService : IOrderService
    {
        

        public List<OrderDTO> GetOrdersByClient(int userId)
        {
            var orderRepository = new OrderRepository();
            return orderRepository.GetOrdersByClient(userId);
        }

        //public List<OrderWorkerDTO> GetOrdersByCriteria(OrderSearchCriteriaDTO criteria)
        //{
        //    var orderRepository = new OrderRepository();
        //    return orderRepository.GetOrdersByCriteria(criteria);
        //}

        public List<ControlBaseDTO> GetSizePizza()
        {
            throw new NotImplementedException();
        }

        public ResponseDTO UpdateOrderStatus(OrderStatusDTO order)
        {
            try
            {
                var orderRepository = new OrderRepository();
                var supplyRepository = new SupplyRepository();
                var productSupplyRepository = new ProductSupplyRepository();
                if (order.OrderStatusId == 3)
                {
                    orderRepository.UpdateOrderStatus(order);
                    return new ResponseDTO()
                    {
                        Status = 1,
                        Message = "Pedido Cancelado"
                    };
                }
                else
                {
                    var currentoOrder = orderRepository.GetOrder(order.OrderId);
                    if (currentoOrder.OrderStatusId != 1)
                    {
                        return new ResponseDTO()
                        {
                            Status = 1,
                            Message = "El Pedido ya fue atendido"
                        };
                    }
                    var currentSupplies = supplyRepository.GetSupplies();
                    var usedSupplies = new List<SupplyDTO>();
                    foreach (var odetail in currentoOrder.OrderDetails)
                    {
                        var supplies = productSupplyRepository.GetSuppliesByProduct(odetail.ProductId);
                        foreach (var supply in supplies)
                        {
                            var csupply = usedSupplies.FirstOrDefault(p => p.SupplyId == supply.SupplyId);
                            if (csupply != null)
                            {
                                csupply.Quantity = csupply.Quantity + supply.Quantity * odetail.Quantity;
                            }
                            else
                            {
                                var newcsupply = new SupplyDTO();
                                newcsupply.SupplyId = supply.SupplyId;
                                newcsupply.Quantity = supply.Quantity * odetail.Quantity;
                                usedSupplies.Add(newcsupply);
                            }
                        }
                    }

                    foreach (var item in usedSupplies)
                    {
                        var csupply = currentSupplies.FirstOrDefault(p => p.SupplyId == item.SupplyId);
                        if (item.Quantity > csupply.Quantity)
                        {
                            order.OrderStatusId = 3;
                            orderRepository.UpdateOrderStatus(order);
                            return new ResponseDTO()
                            {
                                Status = 1,
                                Message = "Pedido Cancelado Automaticamente por falta de Stock"
                            };
                        }
                    }

                    foreach (var item in usedSupplies)
                    {
                        var csupply = currentSupplies.FirstOrDefault(p => p.SupplyId == item.SupplyId);
                        csupply.Quantity = csupply.Quantity - item.Quantity;
                        supplyRepository.UpdateSupply(csupply);
                    }
                    orderRepository.UpdateOrderStatus(order);
                    return new ResponseDTO()
                    {
                        Status = 1,
                        Message = "Pedido Aprobado"
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResponseDTO()
                {
                    Status = 0,
                    Message = "A ocurrido un error"
                };
            }
        }
    }
}