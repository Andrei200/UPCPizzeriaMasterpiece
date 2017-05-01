using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using PizzeriaMasterpiece.DTO;
using System.Threading.Tasks;
using PizzeriaMasterpiece.Repository;

namespace PizzeriaMasterpiece.WCFServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "OrderService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select OrderService.svc or OrderService.svc.cs at the Solution Explorer and start debugging.
    public class OrderService : IOrderService
    {
        public List<OrderDTO> GetOrdersByClient(int userId)
        {
            var orderRepository = new OrderRepository();
            return  orderRepository.GetOrdersByClient(userId);
        }

        public List<OrderWorkerDTO> GetOrdersByCriteria(OrderSearchCriteriaDTO criteria)
        {
            var orderRepository = new OrderRepository();
            return  orderRepository.GetOrdersByCriteria(criteria);
        }
    }
}
