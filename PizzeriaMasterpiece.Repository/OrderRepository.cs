using PizzeriaMasterpiece.DTO;
using PizzeriaMasterpiece.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaMasterpiece.Repository
{
    public class OrderRepository
    {

        public OrderDTO GetOrder(int OrderId)
        {
            using (var context = new PizzeriaMasterpieceEntities())
            {
                var result =  context.Orders.Where(p => p.OrderId == OrderId)
                    .Select(q => new OrderDTO
                    {
                        OrderId = q.OrderId,
                        Address = q.Address,
                        Date = q.Date,
                        DocumentTypeId = q.DocumentTypeId,
                        OrderNo = q.OrderNo,
                        Remark = q.Remark,
                        UserId = q.UserId,
                        OrderStatusId = q.OrderStatusId,
                        OrderDetails = q.OrderDetails.Select(r => new OrderDetailDTO
                        {
                            OrderDetailId = r.OrderDetailId,
                            ProductId = r.ProductId.Value,
                            ProductName = r.Product.Name,
                            Price = r.Price,
                            Quantity = r.Quantity,
                            TotalPrice = r.TotalPrice
                        }).ToList()
                    }).FirstOrDefault();

                return result;
            }
        }

        public int InsertOrder(OrderDTO product)
        {
            using (var context = new PizzeriaMasterpieceEntities())
            {
                var newOrder = new Order
                {
                    OrderId = -1,
                    Date = product.Date,
                    Address = product.Address,
                    Remark = product.Remark,
                    OrderStatusId = 1,
                    DocumentTypeId = product.DocumentTypeId,
                    UserId = product.UserId
                };

                var autoId = 0;
                foreach (var item in product.OrderDetails)
                {
                    var newOrderDetail = new OrderDetail
                    {
                        OrderDetailId = --autoId,
                        OrderId = newOrder.OrderId,
                        Price = item.Price,
                        ProductId = item.ProductId,
                        Quantity = item.Quantity,
                        TotalPrice = item.Quantity * item.Price          
                    };
                    newOrder.OrderDetails.Add(newOrderDetail);
                } 
                
                context.Orders.Add(newOrder);
                context.SaveChanges();

                var currentOrder = context.Orders.Find(newOrder.OrderId);
                currentOrder.OrderNo = "W" + newOrder.OrderId.ToString().PadLeft(9, '0');
                context.SaveChanges();
                return newOrder.OrderId;
            }
        }

        public int UpdateOrderStatus(OrderStatusDTO order)
        {
            using (var context = new PizzeriaMasterpieceEntities())
            {
                var currentOrder= context.Orders.Find(order.OrderId);
                currentOrder.OrderStatusId = order.OrderStatusId;
                context.SaveChanges();
                return currentOrder.OrderId;
            }
        }

        public List<OrderDTO> GetOrdersByClient(int userId)
        {
            using (var context = new PizzeriaMasterpieceEntities())
            {
                var result =  context.Orders.Where(p => p.UserId == userId)
                    .Select(q => new OrderDTO 
                    {
                       OrderId  = q.OrderId,
                       OrderNo = q.OrderNo,
                       Address = q.Address,
                       Date = q.Date,
                       Remark = q.Remark,
                       DocumentTypeId = q.DocumentTypeId,
                       DocumentTypeName = q.DocumentType.Name,
                       OrderStatusId = q.OrderStatusId,
                       OrderStatusName = q.OrderStatu.Name,
                       OrderDetails = q.OrderDetails.Select(r => new OrderDetailDTO{
                           OrderDetailId = r.OrderDetailId,
                           ProductId = r.ProductId.Value,
                           ProductName = r.Product.Name,
                           Price = r.Price,
                           Quantity = r.Quantity,
                           TotalPrice = r.TotalPrice
                       }).ToList()
                    }).ToList();

                return result;
            }
        }

        public List<OrderWorkerDTO> GetOrdersByCriteria(OrderSearchCriteriaDTO criteria)
        {
                
            using (var context = new PizzeriaMasterpieceEntities())
            {
                var query = context.Orders.Where(p => p.UserId == criteria.UserId || criteria.UserId == null);
                query = query.Where(p => p.OrderStatusId == criteria.OrderStatusId || criteria.OrderStatusId == null);
                query = query.Where(p => p.Date >= criteria.StartDate || criteria.StartDate == null);
                query = query.Where(p => p.Date <= criteria.EndDate || criteria.EndDate == null);

                var result = query.Select(q => new OrderWorkerDTO
                {
                    OrderId = q.OrderId,
                    OrderNo = q.OrderNo,
                    Address = q.Address,
                    Date = q.Date,
                    Remark = q.Remark,
                    DocumentTypeId = q.DocumentTypeId,
                    DocumentTypeName = q.DocumentType.Name,
                    OrderStatusId = q.OrderStatusId,
                    OrderStatusName = q.OrderStatu.Name,
                    DocumentNo = q.User.DocumentNo,
                    Email = q.User.Email,
                    FirstName = q.User.FirstName,
                    LastName = q.User.LastName,
                    PhoneNumber = q.User.PhoneNumber,
                    OrderDetails = q.OrderDetails.Select(r => new OrderDetailDTO
                    {
                        OrderDetailId = r.OrderDetailId,
                        ProductId = r.ProductId.Value,
                        ProductName = r.Product.Name,
                        Price = r.Price,
                        Quantity = r.Quantity,
                        TotalPrice = r.TotalPrice,
                        Supplies = r.Product.ProductSupplies.Select(p => new SupplyDTO
                        {
                            SupplyId=p.Supply.SupplyId,
                            Code=p.Supply.Code,
                            Description=p.Supply.Description,
                            IsActive=p.Supply.IsActive,
                            Name=p.Supply.Name,
                            Quantity=p.Supply.Quantity
                        }).ToList()
                      }).ToList()
                   }).OrderByDescending(q=> q.Date).ToList();

                return result;
            }
        }


    }
}
