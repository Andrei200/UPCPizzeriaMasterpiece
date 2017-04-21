using PizzeriaMasterpiece.DTO;
using PizzeriaMasterpiece.Model;
using PizzeriaMasterpiece.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace PizzeriaMasterpiece.WebApiServices.Controllers
{
    public class ProductServiceController : ApiController
    {
        // GET api/<controller>
        public async Task<List<ProductDTO>> Get()
        {
            var productRepository = new ProductRepository();
            return await productRepository.GetProductList();
        }

        // GET api/<controller>/5
        public async Task<ProductDTO> Get(int id)
        {
            var productRepository = new ProductRepository();
            return await productRepository.GetProduct(id);
        }

        // POST api/<controller>
        public async Task<ProductDTO> Post(ProductDTO product)
        {
            var productRepository = new ProductRepository();
            return await productRepository.InsertProduct(product);
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}