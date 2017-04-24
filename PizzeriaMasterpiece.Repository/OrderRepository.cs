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

        public async Task<List<OrderDTO>> GetOrdersByClient(int userId)
        {
            using (var context = new PizzeriaMasterpieceEntities())
            {
                var result = await context.Orders.Where(p => p.UserId == userId)
                    .Select(q => new OrderDTO 
                    {
                       OrderId  = q.OrderId ,
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
                           ProductId = r.ProductId,
                           ProductName = r.Product.Name,
                           Price = r.Price,
                           Quantity = r.Quantity,
                           TotalPrice = r.TotalPrice
                       }).ToList()
                    }).ToListAsync();

                return result;
            }
        }

        public async Task<List<OrderWorkerDTO>> GetOrdersByCriteria(OrderSearchCriteriaDTO criteria)
        {
                
            using (var context = new PizzeriaMasterpieceEntities())
            {
                var query = context.Orders.Where(p => p.UserId == criteria.UserId || criteria.UserId == null);
                query = query.Where(p => p.OrderStatusId == criteria.OrderStatusId || criteria.OrderStatusId == null);
                query = query.Where(p => p.Date >= criteria.StartDate || criteria.StartDate == null);
                query = query.Where(p => p.Date <= criteria.EndDate || criteria.EndDate == null);

                var result = await query.Select(q => new OrderWorkerDTO
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
                        ProductId = r.ProductId,
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
                   }).ToListAsync();

                return result;
            }
        }


    }
}
