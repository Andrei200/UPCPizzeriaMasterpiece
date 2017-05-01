using PizzeriaMasterpiece.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PizzeriaMasterpiece.Controllers
{
    public class OrderController : Controller
    {
        public async Task<ActionResult> MyOrder()
        {
            if (Session["User"] == null)
            {
                ViewBag.Login = "Ingrese su usuario y contraseña";
                return Redirect("/Account/Login");
            }                
            
            UserDTO u = (UserDTO)Session["User"];
            var serviceReference = new OrderServiceReference.OrderServiceClient();
            var list = serviceReference.GetOrdersByClient(u.UserId);
            ViewBag.ListOrder = list;            

            return View();
        }

        public async Task<JsonResult> CreateOrder(string address, string remark)
        {
            List<OrderCartDTO> orderList = new List<OrderCartDTO>();
            if (System.Web.HttpContext.Current.Session["Cart"] == null)
            {
                System.Web.HttpContext.Current.Session["Cart"] = orderList;
            }
            orderList = (List<OrderCartDTO>)System.Web.HttpContext.Current.Session["Cart"];           
            ViewBag.ListCart = orderList;
            return Json(orderList);

        }
    }
}