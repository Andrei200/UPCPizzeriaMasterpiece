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
    public class CartController : Controller
    {
        private string restServiceURL = WebConfigurationManager.AppSettings["RestServiceURL"];

        public async Task<ActionResult> List()
        {
            HttpClient client = new HttpClient();
            var dt = new List<ControlBaseDTO>();

            HttpResponseMessage response = await client.GetAsync(restServiceURL + "DocumentType");
            if (response.IsSuccessStatusCode) dt = await response.Content.ReadAsAsync<List<ControlBaseDTO>>();

            ViewBag.ListDT = dt;

            List<OrderCartDTO> orderList = new List<OrderCartDTO>();
            if (System.Web.HttpContext.Current.Session["Cart"] == null)
            {
                System.Web.HttpContext.Current.Session["Cart"] = orderList;
            }
            ViewBag.ListCart = System.Web.HttpContext.Current.Session["Cart"];
            return View();

        }

        public JsonResult DeleteItem(int rowID)
        {
            List<OrderCartDTO> orderList = new List<OrderCartDTO>();
            if (System.Web.HttpContext.Current.Session["Cart"] == null)
            {
                System.Web.HttpContext.Current.Session["Cart"] = orderList;
            }
            orderList = (List<OrderCartDTO>)System.Web.HttpContext.Current.Session["Cart"];

            for (int i = 0; i < orderList.Count; i++)
            {
                if (orderList[i].ID == rowID)
                {
                    orderList.RemoveAt(i);
                    break;
                }
            }

            ViewBag.ListCart = orderList;
            return Json(orderList);

        }
    }
}