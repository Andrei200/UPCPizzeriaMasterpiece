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
    public class OrderServiceTests
    {
        [TestMethod()]
        public void GetOrdersByClientTest()
        {
            var serviceReference = new WCFServicesTests.OrderServiceReference.OrderServiceClient();
            var result = serviceReference.GetOrdersByClient(1);
            Assert.AreNotEqual(result.Count(), 0);
        }

        [TestMethod()]
        public void UpdateOrderStatusTest()
        {
            var serviceReference = new WCFServicesTests.OrderServiceReference.OrderServiceClient();
            var serviceDTO = new WCFServicesTests.OrderServiceReference.OrderStatusDTO();
            serviceDTO.OrderId = 1;
            serviceDTO.OrderStatusId = 2;

            var result = serviceReference.UpdateOrderStatus(serviceDTO);
            Assert.AreEqual(result.Message, "El Pedido ya fue atendido");
        }
    }
}