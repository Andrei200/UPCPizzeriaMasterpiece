using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PizzeriaMasterpiece.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult List()
        {
            var serviceReference = new ProductServiceReference.ProductServiceClient();
            var list = serviceReference.ListAllProductInformation();
            ViewBag.ListProduct = list;
            return View();

        }
    }
}