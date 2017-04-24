using PizzeriaMasterpiece.DTO;
using PizzeriaMasterpiece.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaMasterpiece.Repository
{
    class SizeRepository
    {
        // crear  listado  de  todos  los Size  sin parametro de  entrada 
        public async Task<SizeDTO> GetSize()
        {
            using (var context = new PizzeriaMasterpieceEntities())
            {
                var result = await context.Sizes
                    .Select(q => new SizeDTO
                    {

                        SizeId = q.SizeId,
                        Code = q.Code,
                        Name = q.Name,
                    }).FirstOrDefaultAsync();

                return result;
            }
        }
    }
}
