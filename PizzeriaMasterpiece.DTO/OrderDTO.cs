using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaMasterpiece.DTO
{
    public class OrderDTO
    {

        public OrderDTO(){
            OrderDetails = new List<OrderDetailDTO>();
        }
        public int OrderId { get; set; }
        public string OrderNo { get; set; }
        public DateTime? Date { get; set; }
        public string Address { get; set; }
        public string Remark { get; set; }
        public int? OrderStatusId { get; set; }
        public string OrderStatusName { get; set; }
        public int? DocumentTypeId { get; set; }
        public string DocumentTypeName { get; set; }
        public List<OrderDetailDTO> OrderDetails { get; set; }
    }

    public class OrderWorkerDTO : OrderDTO
    {
        UserDTO User { get; set; }
    }
}
