using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using PizzeriaMasterpiece.DTO;
using PizzeriaMasterpiece.WebApiServices.Controllers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace PizzeriaMasterpiece.WebApiServices.Controllers.Tests
{
    [TestClass()]
    public class OrderClientControllerTests
    {
        [TestMethod()]
        public void GetTest()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:6146/api/OrderClient/1");
            request.Method = "GET";
            request.ContentType = "application/json";
            var httpResponse = (HttpWebResponse)request.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                var resultObj = JsonConvert.DeserializeObject<List<OrderDTO>>(result);
                Assert.AreNotEqual(resultObj.Count, 0);
            }
        }

        [TestMethod()]
        public void PostTest()
        {
            var newOrder = new OrderDTO();
            var newOrderDetail = new List<OrderDetailDTO>();
            newOrder.Date = DateTime.Now;
            newOrder.Address = "Av San Gabriel";
            newOrder.Remark = "Traigan oregano";
            newOrder.UserId =  1;
            newOrder.DocumentTypeId = 1;
            var nod = new OrderDetailDTO();
      
            nod.ProductId = 1;
            nod.Price = 20;
            nod.Quantity = 1;
            newOrderDetail.Add(nod);
            newOrder.OrderDetails = newOrderDetail;

            var data = new JavaScriptSerializer().Serialize(newOrder);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:6146/api/OrderClient");
            request.Method = "POST";
            request.ContentType = "application/json";
            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(data);
                streamWriter.Flush();
                streamWriter.Close();

            }
            var httpResponse = (HttpWebResponse)request.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                var resultVote = JsonConvert.DeserializeObject<ResponseDTO>(result);
                Assert.AreEqual(resultVote.Status, 1);
            }
        }
    }
}