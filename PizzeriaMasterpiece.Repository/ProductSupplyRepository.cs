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
  public  class ProductSupplyRepository
    {
        public List<SupplyProductDTO> GetAllProductBySupply(int supplyId) {
            using (var context = new PizzeriaMasterpieceEntities()) {
                var result = context.Supplies.Where(p => p.SupplyId == supplyId)
                    .Select(q => new SupplyProductDTO
                    {
                        SupplyId = q.SupplyId,
                        Code = q.Code,
                        Name = q.Name,
                        Description = q.Description,
                        Quantity = q.Quantity,
                        IsActive = q.IsActive,
                        ProductDetails = q.ProductSupplies.Select(r => new SupplyProductDetailDTO {
                            ProductId = r.ProductId,
                            Quantity = r.Quantity
                        }).ToList()
                    }).ToList();
                return result;
            }
        }


        public List<SupplyDTO> GetSuppliesByProduct(int productId)
        {
            using (var context = new PizzeriaMasterpieceEntities()) {
                var result = context.ProductSupplies.Where(p => p.ProductId == productId)
                        .Select(r => new SupplyDTO
                        {
                            SupplyId = r.SupplyId,
                            Quantity = r.Quantity
                        }).ToList();
                return result;
            }
        }

    }
}
