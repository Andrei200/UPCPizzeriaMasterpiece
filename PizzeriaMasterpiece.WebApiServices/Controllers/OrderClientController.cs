using PizzeriaMasterpiece.DTO;
using PizzeriaMasterpiece.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace PizzeriaMasterpiece.WebApiServices.Controllers
{
    public class OrderClientController : ApiController
    {

        public List<OrderDTO> Get(int id)
        {
            var orderRepository = new OrderRepository();
            return orderRepository.GetOrdersByClient(id);
        }

        public ResponseDTO Post(OrderDTO order)
        {
            try
            {
                MessageQueue messageQueue = null;
                if (MessageQueue.Exists(@".\Private$\PizzeriaMP"))
                {
                    // RECUPERAR LA COLA
                    messageQueue = new MessageQueue(@".\Private$\PizzeriaMP");
                    messageQueue.Label = "PizzeriaMP";
                }
                else
                {
                    // CREAR LA COLA
                    MessageQueue.Create(@".\Private$\PizzeriaMP");
                    messageQueue = new MessageQueue(@".\Private$\PizzeriaMP");
                    messageQueue.Label = "PizzeriaMP";
                }

                messageQueue.Send(order);
                var response = new ResponseDTO()
                {
                    Status = 1,
                    Message = "Pedido Registrado"
                };
                return response;
            }
            catch (Exception ex)
            {
                var response = new ResponseDTO()
                {
                    Status = 0,
                    Message = "A ocurrido un error"
                };
                return response;
            }
        }

    }
}
