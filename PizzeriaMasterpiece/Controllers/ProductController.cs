using PizzeriaMasterpiece.DTO;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Web.Mvc;

namespace PizzeriaMasterpiece.Controllers
{
    public class ProductController : Controller
    {
        private string restServiceURL = WebConfigurationManager.AppSettings["RestServiceURL"];

        public async Task<ActionResult> List()
        {
            HttpClient client = new HttpClient();
            var size = new List<ControlBaseDTO>();

            HttpResponseMessage response = await client.GetAsync(restServiceURL + "Size");
            if (response.IsSuccessStatusCode)
            {
                size = await response.Content.ReadAsAsync<List<ControlBaseDTO>>();
                HttpContext.Cache["SizeList"] = size;
            }

            ViewBag.ListSize = size;

            var serviceReference = new ProductServiceReference.ProductServiceClient();

            var list = serviceReference.ListAllProductInformation();
            HttpContext.Cache["PizzaList"] = list;

            ViewBag.ListProduct = list;
            return View();
        }

        public JsonResult AddToCart(int productId, int quantity)
        {
            if (System.Web.HttpContext.Current.Session["Cart"] == null)
            {
                List<OrderCartDTO> newOrder = new List<OrderCartDTO>();
                System.Web.HttpContext.Current.Session["Cart"] = newOrder;
            }

            List<OrderCartDTO> listOwnOrder = (List<OrderCartDTO>)System.Web.HttpContext.Current.Session["Cart"];

            var product = new ProductServiceReference.ProductServiceClient();

            OrderCartDTO order = new OrderCartDTO()
            {
                ID = listOwnOrder.Count + 1,
                Product = product.GetProductInformation(productId),
                Quantity = quantity
            };

            listOwnOrder.Add(order);

            System.Web.HttpContext.Current.Session["Cart"] = listOwnOrder;

            return Json(listOwnOrder);
        }

        public JsonResult CheckCart()
        {
            if (System.Web.HttpContext.Current.Session["Cart"] == null)
            {
                List<OrderCartDTO> newOrder = new List<OrderCartDTO>();
                System.Web.HttpContext.Current.Session["Cart"] = newOrder;
            }
            return Json(System.Web.HttpContext.Current.Session["Cart"]);
        }
    }
}