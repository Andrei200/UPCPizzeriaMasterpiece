using PizzeriaMasterpiece.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace PizzeriaMasterpiece.Controllers
{


    public class OrderController : Controller
    {
        public async System.Threading.Tasks.Task<ActionResult> MyOrder()
        {
            ViewBag.Message = "Your pizza page.";
            //HttpClient client = new HttpClient();
            //var order = new List<OrderDTO>();
            //HttpResponseMessage response = await client.GetAsync("http://localhost:6146/api/OrderClient/1");
            //if (response.IsSuccessStatusCode)
            //{
            //    order = await response.Content.ReadAsAsync<List<OrderDTO>>();
            //}
            return View();
        }
    }
}