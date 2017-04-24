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

        public async Task<CompanyDTO> InsertCompany(CompanyDTO company)
        {
            using (var context = new PizzeriaMasterpieceEntities())
            {
                var newCompany = new Company
                {
                    CompanyId = -1,
                    Name = company.Name,
                    RUC = company.RUC,
                    Address = company.Address,
                    PhoneNumber = company.PhoneNumber,
                };

                context.Companies.Add(newCompany);
                context.SaveChanges();

                return await GetCompany(newCompany.CompanyId);
            }
        }

        public async Task<List<CompanyDTO>> GetCompanyList()
        {
            using (var context = new PizzeriaMasterpieceEntities())
            {
                var result = await context.Companies
                .Select(q => new CompanyDTO
                {
                    CompanyId = q.CompanyId,
                    Name = q.Name,
                    RUC = q.RUC,
                    Address = q.Address,
                    PhoneNumber = q.PhoneNumber
                })
                .ToListAsync();

                return result;
            }
        }

        public async Task<CompanyDTO> UpdateCompany(CompanyDTO company)
        {
            using (var context = new PizzeriaMasterpieceEntities())
            {
                var currentCompany = await context.Companies.FindAsync(company.CompanyId);
                if (!string.IsNullOrWhiteSpace(company.Name)) currentCompany.Name = company.Name;
                if (!string.IsNullOrWhiteSpace(company.RUC)) currentCompany.Name = company.RUC;
                if (!string.IsNullOrWhiteSpace(company.Address)) currentCompany.Name = company.Address;
                if (!string.IsNullOrWhiteSpace(company.PhoneNumber)) currentCompany.Name = company.PhoneNumber;
                context.SaveChanges();
                return await GetCompany(currentCompany.CompanyId);
            }
        }
    }
}
