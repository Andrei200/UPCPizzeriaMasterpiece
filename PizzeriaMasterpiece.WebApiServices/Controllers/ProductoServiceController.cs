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
    public class ProductoServiceController : ApiController
    {
        // GET api/<controller>
        public async Task<List<ProductoDTO>> Get()
        {
            var productoRepository = new ProductoRepository();
            return await productoRepository.GetProductList();
        }

        // GET api/<controller>/5
        public async Task<ProductoDTO> Get(int id)
        {
            var productoRepository = new ProductoRepository();
            return await productoRepository.GetProduct(id);
        }

        // POST api/<controller>
        public async Task<ProductoDTO> Post(ProductoDTO producto)
        {
            var productoRepository = new ProductoRepository();
            return await productoRepository.InsertProduct(producto);
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