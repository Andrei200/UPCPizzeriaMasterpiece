using PizzeriaMasterpiece.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;

namespace PizzeriaMasterpiece.Controllers
{
    public class ProductController : Controller
    {
        public async System.Threading.Tasks.Task<ActionResult> List()
        {

            HttpClient client = new HttpClient();
            var size = new List<ControlBaseDTO>();
            HttpResponseMessage response = await client.GetAsync("http://localhost:6146/api/Size");
            if (response.IsSuccessStatusCode) size = await response.Content.ReadAsAsync<List<ControlBaseDTO>>();
            ViewBag.ListSize = size;            

            var serviceReference = new ProductServiceReference.ProductServiceClient();
            var list = serviceReference.ListAllProductInformation();
            ViewBag.ListProduct = list;
            return View();

        }

        [System.Web.Mvc.Ajax.AjaxMethod(HttpSessionStateRequirement.ReadWrite)]

        public async Task<JsonResult> AddToCart(int productId, int quantity)
        {            
            if (Session["Cart"] == null)
            {
                List<OrderCartDTO> newOrder = new List<OrderCartDTO>();                
                Session.Add("Cart", newOrder);

            }

            List<OrderCartDTO> listOwnOrder = (List<OrderCartDTO>)Session["Cart"];

            OrderCartDTO order = new OrderCartDTO()
            {
                ProductId = productId,
                Quantity = quantity
            };

            listOwnOrder.Add(order);

            Session["Cart"] = listOwnOrder;

            return Json(true);
        }        
    }
}