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
                return new List<OrderWorkerDTO>();
            }
        }


    }
}
