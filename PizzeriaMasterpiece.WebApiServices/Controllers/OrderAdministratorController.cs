using PizzeriaMasterpiece.DTO;
using PizzeriaMasterpiece.Repository;
using System;
using System.Collections.Generic;
using System.Messaging;
using System.Web.Http;

namespace PizzeriaMasterpiece.WebApiServices.Controllers
{
    public class OrderAdministratorController : ApiController
    {
        public List<OrderWorkerDTO> Get()
        {
            try
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
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}