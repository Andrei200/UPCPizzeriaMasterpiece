using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaMasterpiece.DTO
{
    public class SupplyDTO

    {
        public int? SupplyId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? Quantity { get; set; }
        public byte? IsActive { get; set; }
    }


    public class SupplyProductDetailDTO {
        public int? ProductId { get; set; }
        public string Code { get; set; }
        public string Name { get; set;  }
        public string Description { get; set; }
        public int? Quantity { get; set; }
    }

    public class SupplyProductDTO

    {
        public SupplyProductDTO() { 
            ProductDetails = new List<SupplyProductDetailDTO>(); 
        }

        public int? SupplyId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? Quantity { get; set; }
        public byte? IsActive { get; set; }

        public List<SupplyProductDetailDTO> ProductDetails { get; set; }
    }


    public class ProductoSupplyDatailDTO {
        public int? SupplyId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? Quantity { get; set;  }
    }

    public class ProductoSupplyDTO {
        public ProductoSupplyDTO() {
            SupplyDetails = new List<ProductoSupplyDatailDTO>();
        }

        public int? ProductId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<ProductoSupplyDatailDTO> SupplyDetails { get; set; }
    }
}
