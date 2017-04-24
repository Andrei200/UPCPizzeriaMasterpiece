using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PizzeriaMasterpiece.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult Panel()
        {
            return View();
        }

        public ActionResult Order()
        {
            return View();
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