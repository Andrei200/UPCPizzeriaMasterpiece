﻿using PizzeriaMasterpiece.DTO;
using PizzeriaMasterpiece.Model;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
namespace PizzeriaMasterpiece.Repository
{
    public class OrderStatusRepository
    {
        public List<ControlBaseDTO> GeOrderStatusList()
        {
            using (var context = new PizzeriaMasterpieceEntities())
            {
                var result = context.OrderStatus
                    .Select(q => new ControlBaseDTO
                    {
                        Id = q.OrderStatusId,
                        Code = q.Code,
                        Name = q.Name,
                    }).ToList();

                return result;
            }
        }


    }
}