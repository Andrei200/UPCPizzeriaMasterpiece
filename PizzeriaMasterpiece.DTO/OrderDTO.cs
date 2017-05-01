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
        public int? UserId { get; set; }
    }

    public class OrderWorkerDTO : OrderDTO
    {      
        public string DocumentNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class OrderCartDTO
    {
        public ProductDTO Product { get; set; }
        public int Quantity { get; set; }
    }

    public class OrderStatusDTO
    {
        public int OrderId { get; set; }
        public int OrderStatusId { get; set; }
    }
}
