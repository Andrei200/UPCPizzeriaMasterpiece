using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaMasterpiece.DTO
{
    public class OrderDetailDTO
    {
        public OrderDetailDTO() {
            Supplies = new List<SupplyDTO>();
        }

        public int OrderDetailId { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public List<SupplyDTO> Supplies { get; set; }
    }
}
