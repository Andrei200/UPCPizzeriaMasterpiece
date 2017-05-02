using Newtonsoft.Json;
using PizzeriaMasterpiece.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace PizzeriaMasterpiece.Controllers
{
    public class AdminController : Controller
    {
        private string restServiceURL = WebConfigurationManager.AppSettings["RestServiceURL"];
        public ActionResult Panel()
        {
            return View();
        }

        public async System.Threading.Tasks.Task<ActionResult> Order()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(restServiceURL+"OrderAdministrator");
            var listOrder = new List<OrderDTO>();            
            if (response.IsSuccessStatusCode)
            {
                listOrder = await response.Content.ReadAsAsync<List<OrderDTO>>();
            }
            /*var serviceReference = new OrderServiceReference.OrderServiceClient();
            OrderSearchCriteriaDTO osc = new OrderSearchCriteriaDTO();
            var listOrder = serviceReference.GetOrdersByCriteria(osc);*/
            ViewBag.ListOrder = listOrder;
            return View();
        }

        public async Task<ActionResult> AproveOrder(int orderId, int orderStatusId)
        {
            var serviceReference = new OrderServiceReference.OrderServiceClient();
            OrderStatusDTO os = new OrderStatusDTO()
            {
                OrderId = orderId,
                OrderStatusId = orderStatusId
            };
            var response = serviceReference.UpdateOrderStatus(os);
            return Json(response);
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