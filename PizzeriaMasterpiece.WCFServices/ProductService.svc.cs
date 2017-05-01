using PizzeriaMasterpiece.DTO;
using PizzeriaMasterpiece.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace PizzeriaMasterpiece.WCFServices
{
  
    public class ProductService : IProductService
    {
        public ProductDTO GetProductInformation(int productoId)
        {
            var productRepository = new ProductRepository();
            return productRepository.GetProduct(productoId);
        }

        public ProductDTO InsertProductInformation(ProductDTO product)
        {
            var productRepository = new ProductRepository();
            return productRepository.InsertProduct(product);
        }

        public ProductDTO UpdateProductInformation(ProductDTO product)
        {
            var productRepository = new ProductRepository();
            return productRepository.UpdateProduct(product);
        }

        public List<ProductDTO> ListAllProductInformation()
        {
            var productRepository = new ProductRepository();
            return productRepository.GetProductList();
        }

        public List<SupplyProductDTO> ListAllProductBySupply(int supplyId)
        {
            var productSupplyRepository = new ProductSupplyRepository();
            return productSupplyRepository.GetAllProductBySupply(supplyId);
        }
    }
}
