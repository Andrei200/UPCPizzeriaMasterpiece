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
    }
}