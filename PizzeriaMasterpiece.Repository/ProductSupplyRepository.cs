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


        //Sandro Gamio pino
        //public async Task<List<SupplyProduct2DTO>> GetAllProductBySupply2(int supplyId)
        //{
        //    using (var context = new PizzeriaMasterpieceEntities())
        //    {
        //        var result = await from p in context.ProductSupplies
        //            join p1 in context.Supplies on p.SupplyId equals p1.SupplyId
        //            join p2 in context.Products on p.ProductId equals p2.ProductId
        //            where p.SupplyId == supplyId
        //            select(r => new SupplyProduct2DTO {
        //                SupplyId = p.SupplyId,
        //                SupplyCode = p1.Code,
        //                SupplyName = p1.Name,
        //                SupplyDescription = p1.Description,
        //                SupplyIsActive = p1.IsActive,
        //                ProductId = p.ProductId,
        //                ProductCode = p2.Code,
        //                ProductName = p2.Name,
        //                ProductDescription = p2.Description,
        //                Quantity = p.Quantity
        //            });

        //        return result;
        //    }
        //}


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
