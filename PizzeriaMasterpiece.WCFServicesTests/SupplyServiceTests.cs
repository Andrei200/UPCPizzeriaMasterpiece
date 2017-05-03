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
    public class SupplyServiceTests
    {
        [TestMethod()]
        public void ListAllSupplyInformationTest()
        {
            var serviceReference = new WCFServicesTests.SupplyServiceReference.SupplyServieClient();
            var result = serviceReference.ListAllSupplyInformation();
            Assert.AreNotEqual(result.Count(), 0);
        }

        [TestMethod()]
        public void UpdateSupplyInformationTest()
        {
            var serviceReference = new WCFServicesTests.SupplyServiceReference.SupplyServieClient();
            var serviceDTO = new WCFServicesTests.SupplyServiceReference.SupplyDTO();
            serviceDTO.SupplyId = 1;
            serviceDTO.Quantity = 100;


            var result = serviceReference.UpdateSupplyInformation(serviceDTO);
            Assert.AreEqual(result.Quantity,100);
        }
    }
}