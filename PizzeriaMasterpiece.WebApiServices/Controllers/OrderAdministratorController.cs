using PizzeriaMasterpiece.DTO;
using PizzeriaMasterpiece.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PizzeriaMasterpiece.WebApiServices.Controllers
{
    public class OrderAdministratorController : ApiController
    {
        // GET: api/OrderAdministrator
        public List<OrderWorkerDTO> Get()
        {
            MessageQueue messageQueue = null;
            var orderRepository = new OrderRepository();
            if (MessageQueue.Exists(@".\Private$\PizzeriaMP"))
            {
                messageQueue = new MessageQueue(@".\Private$\PizzeriaMP");
                var messages = messageQueue.GetAllMessages();
                foreach (var item in messages)
                {
                    messageQueue.Formatter = new XmlMessageFormatter(new Type[] { typeof(OrderDTO) });
                    Message message = messageQueue.Receive();
                    OrderDTO order = (OrderDTO)message.Body;

                    orderRepository.InsertOrder(order);
                }
            }
            var criteria = new OrderSearchCriteriaDTO()
            {
                OrderStatusId = 1
            };
            var result = orderRepository.GetOrdersByCriteria(criteria);
            return result;
        }

        // GET: api/OrderAdministrator/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/OrderAdministrator
        public void Post([FromBody]string value)
        {

        }


        // PUT: api/OrderAdministrator/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/OrderAdministrator/5
        public void Delete(int id)
        {
        }

    }
}
