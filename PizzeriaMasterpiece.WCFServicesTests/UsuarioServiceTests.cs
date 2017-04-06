using Microsoft.VisualStudio.TestTools.UnitTesting;

using PizzeriaMasterpiece.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaMasterpiece.Services.Tests
{
    [TestClass()]
    public class UsuarioServiceTests
    {
        [TestMethod()]
        public void GetUserInformationTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void InsertUserInformationTest()
        {
            var serviceReference = new WCFServicesTests.UsuarioServiceReference.UsuarioServiceClient();
            var user = new WCFServicesTests.UsuarioServiceReference.UsuarioRegistroDTO();
            user.Nombre = "Sandro";
            user.Apellido = "Gamio";
            user.DNI = "12457800";
            user.Correo = "agamio@gmail.com";
            user.Telefono = "998712457";
            user.Direccion = "Miraflores 515";
            user.Contrasena = "12345678";
            var result = serviceReference.InsertUserInformation(user);
            Assert.AreEqual(result.DNI, "12457800");
        }
    }
}