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
        //traer  todos  los  productos que  usen  el  supply 
        public async Task<List<SupplyProductDTO>> GetAllProductBySupply(int supplyId) {
            using (var context = new PizzeriaMasterpieceEntities()) {
                var result = await context.Supplies.Where(p => p.SupplyId == supplyId)
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
                    }).ToListAsync();
                return result;
            }
        }

 //       public async Task<List<SupplyProductDTO>> GetAllProductBySupply2(int supplyId) {
 //           using (var context = new PizzeriaMasterpieceEntities())
 //           {
 //               var result = (from ps in context.ProductSupplies
 //                             join s in context.Supplies on s.SupplyId equals ps.SupplyId
 //                             join p in context.Products on p.ProductId equals ps.ProductId
 //                             where ps.SupplyId = supplyId
 //                   select (r => new SupplyProductDTO {
 //                       SupplyId = r.SupplyId
 //                   }).ToList()  ).ToListAsync();

 //               return result;
 //           }
 //   //ps.ProductId, ps.SupplyId, ps.Quantity,
	////s.Code, s.Name, s.Description,
	////p.Code, p.Name, p.Description
 //       }


        // traer  todos  los  supply  que  usen  el  producto
        public async Task<List<ProductoSupplyDTO>> GetAllSupplyByProduct(int productId)
        {
            using (var context = new PizzeriaMasterpieceEntities()) {
                var result = await context.Products.Where(p => p.ProductId == productId)
                    .Select(q => new ProductoSupplyDTO
                    {
                        ProductId = q.ProductId,
                        Code = q.Code,
                        Name = q.Name,
                        Description = q.Description,
                        SupplyDetails = q.ProductSupplies.Select(r => new ProductoSupplyDatailDTO {
                            SupplyId = r.SupplyId,
                            Quantity = r.Quantity
                        }).ToList()
                    }).ToListAsync();
                return result;
            }
        }

    }
}
