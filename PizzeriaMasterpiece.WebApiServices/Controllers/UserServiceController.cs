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
    public class UserServiceController : ApiController
    {
        // GET: api/UsuarioService
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/UsuarioService/5
        public async Task<UserDTO> Get(int id)
        {
            var userRepository = new UserRepository();
            return await userRepository.GetUser(id);
        }

        // POST: api/UsuarioService
        public async Task<UserDTO> Post(UserRegistrationDTO user)
        {
            var userRepository = new UserRepository();
            return await userRepository.InsertUser(user);
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
