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
  public  class CompanyRepository
    {
        // crear  listado  de  todas  las companys sin parametro de  entrada 

        public async Task<CompanyDTO> GetCompany(int companyId)
        {
            using (var context = new PizzeriaMasterpieceEntities())
            {
                var result = await context.Companies.Where(p => p.CompanyId == companyId)
                    .Select(q => new CompanyDTO
                    {
                        CompanyId = q.CompanyId,
                        Name = q.Name,
                        RUC = q.RUC,
                        Address = q.Address,
                        PhoneNumber = q.PhoneNumber,
                    }).FirstOrDefaultAsync();

                return result;
            }
        }
    }
}
