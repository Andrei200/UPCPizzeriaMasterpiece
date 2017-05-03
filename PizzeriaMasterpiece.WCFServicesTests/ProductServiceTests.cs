using Microsoft.VisualStudio.TestTools.UnitTesting;
using PizzeriaMasterpiece.WCFServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaMasterpiece.WCFServices.Tests
{
    [TestClass()]
    public class ProductServiceTests
    {
        [TestMethod()]
        public void GetProductInformationTest()
        {
            var serviceReference = new WCFServicesTests.ProductServiceReference.ProductServiceClient();
            var service = new WCFServicesTests.ProductServiceReference.ProductDTO();
            var result = serviceReference.GetProductInformation(1);
            Assert.AreEqual(result.Code, "AMEPR");
        }

        [TestMethod()]
        public void ListAllProductInformationTest()
        {
            var serviceReference = new WCFServicesTests.ProductServiceReference.ProductServiceClient();
            var service = new WCFServicesTests.ProductServiceReference.ProductDTO();
            var result = serviceReference.ListAllProductInformation();
            Assert.AreNotEqual(result.Count(), 0);
        }
    }
}