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
    public class SizeController : ApiController
    {
        public List<ControlBaseDTO> Get()
        {
            var repository = new SizeRepository();
            return repository.GetSizes();
        }

    }
}
