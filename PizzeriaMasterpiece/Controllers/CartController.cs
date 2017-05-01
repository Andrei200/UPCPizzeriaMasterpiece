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
    public class CartController : Controller
    {
        public async System.Threading.Tasks.Task<ActionResult> List()
        {
            List<OrderCartDTO> orderList = new List<OrderCartDTO>();
            if (System.Web.HttpContext.Current.Session["Cart"] == null)
            {                
                System.Web.HttpContext.Current.Session["Cart"] = orderList;
            }
            ViewBag.ListCart = System.Web.HttpContext.Current.Session["Cart"];
            return View();

        }

        public async Task<JsonResult> DeleteItem(int rowID)
        {
            List<OrderCartDTO> orderList = new List<OrderCartDTO>();
            if (System.Web.HttpContext.Current.Session["Cart"] == null)
            {
                System.Web.HttpContext.Current.Session["Cart"] = orderList;
            }
            orderList = (List<OrderCartDTO>) System.Web.HttpContext.Current.Session["Cart"];

            for(int i = 0; i < orderList.Count; i++)
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