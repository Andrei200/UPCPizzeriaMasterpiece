﻿using PizzeriaMasterpiece.DTO;
using PizzeriaMasterpiece.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PizzeriaMasterpiece.WCFServices
{
  
    public class ProductService : IProductService
    {
        public async Task<ProductDTO> GetProductInformation(int productoId)
        {
            var productRepository = new ProductRepository();
            return await productRepository.GetProduct(productoId);
        }

        public async Task<ProductDTO> InsertProductInformation(ProductDTO product)
        {
            var productRepository = new ProductRepository();
            return await productRepository.InsertProduct(product);
        }

        public async Task<ProductDTO> UpdateProductInformation(ProductDTO product)
        {
            var productRepository = new ProductRepository();
            return await productRepository.UpdateProduct(product);
        }

        public async Task<List<ProductDTO>> ListAllProductInformation()
        {
            var productRepository = new ProductRepository();
            return await productRepository.GetProductList();
        }
    }
}