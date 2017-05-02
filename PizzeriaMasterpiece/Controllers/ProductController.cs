using PizzeriaMasterpiece.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Services;

namespace PizzeriaMasterpiece.Controllers
{
    public class ProductController : Controller
    {
        string restServiceURL = WebConfigurationManager.AppSettings["RestServiceURL"];
        public async System.Threading.Tasks.Task<ActionResult> List()
        {
            HttpClient client = new HttpClient();
            var size = new List<ControlBaseDTO>();

            if (HttpContext.Cache["SizeList"]==null)
            {
                HttpResponseMessage response = await client.GetAsync(restServiceURL+"Size");
                if (response.IsSuccessStatusCode)
                {
                    size = await response.Content.ReadAsAsync<List<ControlBaseDTO>>();
                    HttpContext.Cache["SizeList"] = size;
                }
            }
            else
            {
                size = (List<ControlBaseDTO>) HttpContext.Cache["SizeList"];
            }
                            
            ViewBag.ListSize = size;
            
            var serviceReference = new ProductServiceReference.ProductServiceClient();
            var list = new Object();            
            if (HttpContext.Cache["PizzaList"] == null)
            {
                list = serviceReference.ListAllProductInformation();
                HttpContext.Cache["PizzaList"] = list;
            }
            else
            {
                list = (ProductDTO[])HttpContext.Cache["PizzaList"];
            }            
            ViewBag.ListProduct = list;
            return View();

        }
                
        public async Task<JsonResult> AddToCart(int productId, int quantity)
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
                ID = listOwnOrder.Count+1,
                Product = product.GetProductInformation(productId),
                Quantity = quantity
            };

            listOwnOrder.Add(order);

            System.Web.HttpContext.Current.Session["Cart"] = listOwnOrder;

            return Json(listOwnOrder);
        }

        public async Task<JsonResult> CheckCart()
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