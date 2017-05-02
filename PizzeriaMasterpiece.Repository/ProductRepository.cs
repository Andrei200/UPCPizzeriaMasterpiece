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
        public ProductDTO GetProduct(int productId)
        {
            using (var context = new PizzeriaMasterpieceEntities())
            {
                var result = context.Products.Where(p => p.ProductId == productId)
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
                    }).FirstOrDefault();

                return result;
            }
        }

        public int InsertProduct(ProductDTO product)
        {
            using (var context = new PizzeriaMasterpieceEntities())
            {
                var newProduct = new Product
                {
                    ProductId = -1,
                    Code = product.Code,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price.Value,
                    ImagePath = product.ImagePath,
                    SizeId = product.SizeId,
                    IsActive = 1,
                };

                context.Products.Add(newProduct);
                context.SaveChanges();
                return newProduct.ProductId;
            }
        }

        public int UpdateProduct(ProductDTO product)
        {
            using (var context = new PizzeriaMasterpieceEntities())
            {
                var currentProduct = context.Products.Find(product.ProductId);
                if (!string.IsNullOrWhiteSpace(product.Description)) currentProduct.Description = product.Description;
                if (product.Price != null) currentProduct.Price = product.Price.Value;
                if (!string.IsNullOrWhiteSpace(product.ImagePath)) currentProduct.ImagePath = product.ImagePath;
                if (product.IsActive != null) currentProduct.IsActive = product.IsActive;
                context.SaveChanges();
                return currentProduct.ProductId;
            }
        }

        public List<ProductDTO> GetProductList()
        {
            using (var context = new PizzeriaMasterpieceEntities())
            {
                var result = context.Products.Where(p => p.IsActive == 1)
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
                .ToList();

                return result;
            }
        }
       
    }
}