﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using PizzeriaMasterpiece.DTO;
using PizzeriaMasterpiece.WebApiServices.Controllers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaMasterpiece.WebApiServices.Controllers.Tests
{
    [TestClass()]
    public class OrderAdministratorControllerTests
    {
        [TestMethod()]
        public void GetTest()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:6146/api/OrderAdministrator");
            request.Method = "GET";
            request.ContentType = "application/json";
            var httpResponse = (HttpWebResponse)request.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                var resultObj = JsonConvert.DeserializeObject<List<OrderWorkerDTO>>(result);
                Assert.AreNotEqual(resultObj.Count, 0);
            }
        }
    }
}