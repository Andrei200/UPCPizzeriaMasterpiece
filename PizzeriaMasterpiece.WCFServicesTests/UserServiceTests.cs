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
        public void LoginUserInformation()
        {

            var serviceReference = new WCFServicesTests.UserServiceReference.UserServiceClient();
            var user = new WCFServicesTests.UserServiceReference.UserLoginDTO();
            user.Email = "j@gmail.com";
            user.Password = "123456";

            var result = serviceReference.LoginUserInformation(user);
            Assert.AreEqual(result.DocumentNo, "45127845");

        }


      
        [TestMethod()]
        public void UpdateUserInformation()
        {
            var serviceReference = new WCFServicesTests.UserServiceReference.UserServiceClient();
            var user = new WCFServicesTests.UserServiceReference.UserRegistrationDTO();
            user.UserId = 2;
            user.FirstName = "Frank";
            user.LastName = "Mamani";
            user.Address= "Av El sol 1232";
            user.PhoneNumber = "23323323";

        
            var result = serviceReference.UpdateUserInformation(user);
            Assert.AreEqual(result.PhoneNumber, "23323323");

        }
    }

}