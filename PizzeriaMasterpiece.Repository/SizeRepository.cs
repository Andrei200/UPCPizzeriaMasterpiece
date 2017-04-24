﻿using PizzeriaMasterpiece.DTO;
using PizzeriaMasterpiece.Model;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace PizzeriaMasterpiece.Repository
{
    public class SizeRepository
    {
        public async Task<List<ControlBaseDTO>> GetSizes()
        {
            using (var context = new PizzeriaMasterpieceEntities())
            {
                var result = await context.Sizes
                    .Select(q => new ControlBaseDTO
                    {
                        Id = q.SizeId,
                        Code = q.Code,
                        Name = q.Name,
                    }).ToListAsync();

                return result;
            }
        }
    }
}