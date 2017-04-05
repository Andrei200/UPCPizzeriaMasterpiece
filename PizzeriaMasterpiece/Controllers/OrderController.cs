using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PizzeriaMasterpiece.Controllers
{
    public class OrderController : Controller
    {
        public ActionResult MyOrder()
        {
            ViewBag.Message = "Your pizza page.";

            return View();
        }
    }
}