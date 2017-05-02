using PizzeriaMasterpiece.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaMasterpiece.WCFServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IOrderService" in both code and config file together.
    [ServiceContract]
    public interface IOrderService
    {
        [OperationContract]
        List<ControlBaseDTO> GetSizePizza();

        [OperationContract]
        List<OrderDTO>  GetOrdersByClient(int userId);

        [OperationContract]
        List<OrderWorkerDTO> GetOrdersByCriteria(OrderSearchCriteriaDTO criteria);

        [OperationContract]
        ResponseDTO UpdateOrderStatus(OrderStatusDTO order);

    }
}
