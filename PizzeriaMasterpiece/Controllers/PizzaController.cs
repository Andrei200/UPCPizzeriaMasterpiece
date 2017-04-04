using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PizzeriaMasterpiece.Controllers
{
    public class PizzaController : Controller
    {
        public ActionResult List()
        {
            ViewBag.Message = "Your pizza page.";

            return View();
        }
    }
}