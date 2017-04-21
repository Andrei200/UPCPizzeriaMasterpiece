using PizzeriaMasterpiece.DTO;
using PizzeriaMasterpiece.Model;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace PizzeriaMasterpiece.Repository
{
    public class ProductRepository
    {
        public async Task<ProductDTO> GetProduct(int productId)
        {
            using (var context = new PizzeriaMasterpieceEntities())
            {
                var result = await context.Products.Where(p => p.ProductId == productId)
                    .Select(q => new ProductDTO
                    {
                        ProductId = q.ProductId,
                        Description = q.Description,
                        Price = q.Price,
                        Code = q.Code,
                        Name = q.Name,
                        ImagePath = q.ImagePath,
                        SizeId = q.SizeId,
                        SizeName = q.Size.Name,
                        IsActive = q.IsActive,
                    }).FirstOrDefaultAsync();

                return result;
            }
        }

        public async Task<ProductDTO> InsertProduct(ProductDTO product)
        {
            using (var context = new PizzeriaMasterpieceEntities())
            {
                var newProduct = new Product
                {
                    ProductId = -1,
                    Code = product.Code,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    ImagePath = product.ImagePath,
                    SizeId = product.SizeId,
                    IsActive = 1,
                };

                context.Products.Add(newProduct);
                context.SaveChanges();

                return await GetProduct(newProduct.ProductId);
            }
        }

        public async Task<List<ProductDTO>> GetProductList()
        {
            using (var context = new PizzeriaMasterpieceEntities())
            {
                var result = await context.Products.Where(p => p.IsActive == 1)
                .Select(q => new ProductDTO
                {
                    ProductId = q.ProductId,
                    Description = q.Description,
                    Price = q.Price,
                    Code = q.Code,
                    Name = q.Name,
                    ImagePath = q.ImagePath,
                    SizeId = q.SizeId,
                    SizeName = q.Size.Name
                })
                .ToListAsync();

                return result;
            }
        }

        public async Task<ProductDTO> UpdateProduct(ProductDTO product)
        {
            using (var context = new PizzeriaMasterpieceEntities())
            {
                var currentProduct = await context.Products.FindAsync(product.ProductId);
                currentProduct.Description = product.Description;
                currentProduct.Price = product.Price;
                currentProduct.ImagePath = product.ImagePath;
                currentProduct.IsActive = product.IsActive;
                context.SaveChanges();

                return await GetProduct(currentProduct.ProductId);
            }
        }
    }
}