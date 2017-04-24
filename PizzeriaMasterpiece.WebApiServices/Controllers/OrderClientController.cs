using PizzeriaMasterpiece.DTO;
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
    public class OrderClientController : ApiController
    {
        // GET: api/OrderClient
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/OrderClient/5
        public async Task<List<OrderDTO>> Get(int id)
        {
            var orderRepository = new OrderRepository();
            return await orderRepository.GetOrdersByClient(id);
        }

        // POST: api/OrderClient
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/OrderClient/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/OrderClient/5
        public void Delete(int id)
        {
        }
    }
}
