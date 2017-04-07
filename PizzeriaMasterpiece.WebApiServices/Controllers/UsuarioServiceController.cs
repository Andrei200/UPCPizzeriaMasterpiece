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
    public class UsuarioServiceController : ApiController
    {
        // GET: api/UsuarioService
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/UsuarioService/5
        public async Task<UsuarioDTO> Get(int id)
        {
            var usurioRepository = new UsuarioRepository();
            return await usurioRepository.GetUserInformation(id);
        }

        // POST: api/UsuarioService
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/UsuarioService/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/UsuarioService/5
        public void Delete(int id)
        {
        }
    }
}
