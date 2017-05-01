using PizzeriaMasterpiece.DTO;
using PizzeriaMasterpiece.Model;
using System.Collections.Generic;
using System.Linq;

namespace PizzeriaMasterpiece.Repository
{
    public class DocumentTypeRepository
    {
        public List<ControlBaseDTO> GetDocumentTypes()
        {
            using (var context = new PizzeriaMasterpieceEntities())
            {
                var result =  context.DocumentTypes
                    .Select(q => new ControlBaseDTO
                    {
                        Id = q.DocumentTypeId,
                        Code = q.Code,
                        Name = q.Name
                    }).ToList();

                return result;
            }
        }
    }
}
