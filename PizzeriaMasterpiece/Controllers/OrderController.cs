﻿using Newtonsoft.Json;
using PizzeriaMasterpiece.DTO;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Web.Mvc;

namespace PizzeriaMasterpiece.Controllers
{
    public class OrderController : Controller
    {
        private string restServiceURL = WebConfigurationManager.AppSettings["RestServiceURL"];

        public ActionResult MyOrder()
        {
            if (Session["User"] == null)
            {
                TempData["Login"] = "Ingrese su usuario y contraseña";
                return Redirect("/Account/Login");
            }

            UserDTO u = (UserDTO)Session["User"];
            var serviceReference = new OrderServiceReference.OrderServiceClient();
            var list = serviceReference.GetOrdersByClient(u.UserId);
            ViewBag.ListOrder = list;

            return View();
        }

        public async Task<JsonResult> CreateOrder(string address, string remark, int documentType)
        {
            UserDTO u = (UserDTO)Session["User"];
            List<OrderCartDTO> orderList = new List<OrderCartDTO>();
            if (System.Web.HttpContext.Current.Session["Cart"] == null)
            {
                System.Web.HttpContext.Current.Session["Cart"] = orderList;
            }
            orderList = (List<OrderCartDTO>)System.Web.HttpContext.Current.Session["Cart"];
            var newOrder = new OrderDTO();
            var newOrderDetail = new List<OrderDetailDTO>();
            newOrder.Date = DateTime.Now;
            newOrder.Address = address;
            newOrder.Remark = remark;
            newOrder.UserId = u.UserId;
            newOrder.DocumentTypeId = documentType;
            var nod = new OrderDetailDTO();
            for (var i = 0; i < orderList.Count; i++)
            {
                nod.ProductId = orderList[i].Product.ProductId;
                nod.Price = orderList[i].Product.Price.Value;
                nod.Quantity = orderList[i].Quantity;
                newOrderDetail.Add(nod);
            }
            newOrder.OrderDetails = newOrderDetail;
            var final = new ResponseDTO();
            HttpClient client = new HttpClient();
            var jsonRequest = JsonConvert.SerializeObject(newOrder);
            var content = new StringContent(jsonRequest, Encoding.UTF8, "text/json");
            HttpResponseMessage response = await client.PostAsync(restServiceURL + "OrderClient", content);

            if (response.IsSuccessStatusCode)
            {
                final = await response.Content.ReadAsAsync<ResponseDTO>();
                System.Web.HttpContext.Current.Session["Cart"] = new List<OrderCartDTO>();
            }

            return Json(final);
        }
    }
}