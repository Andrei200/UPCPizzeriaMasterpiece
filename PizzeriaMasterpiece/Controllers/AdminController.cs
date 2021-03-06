﻿using PizzeriaMasterpiece.DTO;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Web.Mvc;

namespace PizzeriaMasterpiece.Controllers
{
    public class AdminController : Controller
    {
        private string restServiceURL = WebConfigurationManager.AppSettings["RestServiceURL"];

        public ActionResult Panel()
        {
            if (Session["User"] == null)
            {
                ViewBag.Login = "Ingrese su usuario y contraseña";
                return Redirect("/Account/Login");
            }
            else if (((UserDTO)Session["User"]).RoleId != 1) //only admin
            {
                return Redirect("/Account/NoAccess");
            }

            return View();
        }

        public async Task<ActionResult> Order()
        {
            if (Session["User"] == null)
            {
                ViewBag.Login = "Ingrese su usuario y contraseña";
                return Redirect("/Account/Login");
            }
            else if (((UserDTO)Session["User"]).RoleId != 1) //only admin
            {
                return Redirect("/Account/NoAccess");
            }

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(restServiceURL + "OrderAdministrator");
            var listOrder = new List<OrderDTO>();
            if (response.IsSuccessStatusCode)
            {
                listOrder = await response.Content.ReadAsAsync<List<OrderDTO>>();
            }
            ViewBag.ListOrder = listOrder;
            return View();
        }

        public ActionResult AproveOrder(int orderId, int orderStatusId)
        {
            var serviceReference = new OrderServiceReference.OrderServiceClient();
            OrderStatusDTO os = new OrderStatusDTO()
            {
                OrderId = orderId,
                OrderStatusId = 2
            };
            var response = serviceReference.UpdateOrderStatus(os);
            return Json(response);
        }

        public ActionResult CancelOrder(int orderId, int orderStatusId)
        {
            var serviceReference = new OrderServiceReference.OrderServiceClient();
            OrderStatusDTO os = new OrderStatusDTO()
            {
                OrderId = orderId,
                OrderStatusId = 3
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