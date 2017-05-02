using PizzeriaMasterpiece.DTO;
using PizzeriaMasterpiece.Model;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace PizzeriaMasterpiece.Repository
{
    public class SizeRepository
    {
        public List<ControlBaseDTO> GetSizes()
        {
            using (var context = new PizzeriaMasterpieceEntities())
            {
                var result = context.Sizes
                    .Select(q => new ControlBaseDTO
                    {
                        Id = q.SizeId,
                        Code = q.Code,
                        Name = q.Name,
                    }).ToList();

                return result;
            }
        }
    }
}