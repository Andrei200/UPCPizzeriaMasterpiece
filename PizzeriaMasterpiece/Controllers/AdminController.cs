using Newtonsoft.Json;
using PizzeriaMasterpiece.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PizzeriaMasterpiece.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult Panel()
        {
            return View();
        }

        public async System.Threading.Tasks.Task<ActionResult> Order()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("http://localhost:6146/api/OrderAdministrator");
            var listOrder = new List<OrderDTO>();            
            if (response.IsSuccessStatusCode)
            {
                listOrder = await response.Content.ReadAsAsync<List<OrderDTO>>();
            }
            ViewBag.ListOrder = listOrder;
            return View();
        }

        public ActionResult Product()
        {
            var serviceReference = new ProductServiceReference.ProductServiceClient();
            var list = serviceReference.ListAllProductInformation();            
            ViewBag.ListProduct = list;
            return View();
        }

    }
}