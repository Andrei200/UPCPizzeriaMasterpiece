using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PizzeriaMasterpiece.Services.Tests
{
    [TestClass()]
    public class UserServiceTests
    {
        [TestMethod()]
        public void GetUserInformationTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void InsertUserInformationTest()
        {
            var serviceReference = new WCFServicesTests.UserServiceReference.UserServiceClient();
            var user = new WCFServicesTests.UserServiceReference.UserRegistrationDTO();
            user.FirstName = "Sandro";
            user.LastName = "Gamio";
            user.DocumentNo = "12457800";
            user.Email = "agamio@gmail.com";
            user.PhoneNumber = "998712457";
            user.Address = "Miraflores 515";
            user.Password = "12345678";
            var result = serviceReference.InsertUserInformation(user);
            Assert.AreEqual(result.DocumentNo, "12457800");
        }

        [TestMethod()]
        public void GetSize() {
            var serviceRerence = new WCFServicesTests.UserServiceReference.UserServiceClient();
            var size = new WCFServicesTests.UserServiceReference.UserRegistrationDTO();
        }

    }
}