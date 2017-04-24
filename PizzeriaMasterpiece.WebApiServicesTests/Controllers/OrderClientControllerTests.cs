using Microsoft.VisualStudio.TestTools.UnitTesting;
using PizzeriaMasterpiece.WebApiServices.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaMasterpiece.WebApiServices.Controllers.Tests
{
    [TestClass()]
    public class OrderClientControllerTests
    {
        static HttpClient client = new HttpClient();
        [TestMethod()]
        public async void GetTest()
        {
            HttpResponseMessage response = await client.GetAsync("http://localhost:6146/api/OrderClient/1");
            Assert.Fail();
        }
    }
}