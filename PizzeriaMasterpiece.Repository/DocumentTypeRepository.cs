using PizzeriaMasterpiece.DTO;
using PizzeriaMasterpiece.Model;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace PizzeriaMasterpiece.Repository
{
    public class DocumentTypeRepository
    {
        public async Task<List<ControlBaseDTO>> GetDocumentTypes()
        {
            using (var context = new PizzeriaMasterpieceEntities())
            {
                var result = await context.DocumentTypes
                    .Select(q => new ControlBaseDTO
                    {
                        Id = q.DocumentTypeId,
                        Code = q.Code,
                        Name = q.Name
                    }).ToListAsync();

                return result;
            }
        }
    }
}
