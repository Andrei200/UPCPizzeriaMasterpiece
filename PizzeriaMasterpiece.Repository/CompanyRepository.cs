﻿using PizzeriaMasterpiece.DTO;
using PizzeriaMasterpiece.Model;
using System.Collections.Generic;
using System.Linq;

namespace PizzeriaMasterpiece.Repository
{
    public class CompanyRepository
    {
        public CompanyDTO GetCompany(int companyId)
        {
            using (var context = new PizzeriaMasterpieceEntities())
            {
                var result = context.Companies.Where(p => p.CompanyId == companyId)
                    .Select(q => new CompanyDTO
                    {
                        CompanyId = q.CompanyId,
                        Name = q.Name,
                        RUC = q.RUC,
                        Address = q.Address,
                        PhoneNumber = q.PhoneNumber,
                    }).FirstOrDefault();

                return result;
            }
        }

        public int InsertCompany(CompanyDTO company)
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

                return newCompany.CompanyId;
            }
        }

        public List<CompanyDTO> GetCompanyList()
        {
            using (var context = new PizzeriaMasterpieceEntities())
            {
                var result = context.Companies
                .Select(q => new CompanyDTO
                {
                    CompanyId = q.CompanyId,
                    Name = q.Name,
                    RUC = q.RUC,
                    Address = q.Address,
                    PhoneNumber = q.PhoneNumber
                })
                .ToList();

                return result;
            }
        }

        public int UpdateCompany(CompanyDTO company)
        {
            using (var context = new PizzeriaMasterpieceEntities())
            {
                var currentCompany = context.Companies.Find(company.CompanyId);
                if (!string.IsNullOrWhiteSpace(company.Name)) currentCompany.Name = company.Name;
                if (!string.IsNullOrWhiteSpace(company.RUC)) currentCompany.Name = company.RUC;
                if (!string.IsNullOrWhiteSpace(company.Address)) currentCompany.Name = company.Address;
                if (!string.IsNullOrWhiteSpace(company.PhoneNumber)) currentCompany.Name = company.PhoneNumber;
                context.SaveChanges();
                return currentCompany.CompanyId;
            }
        }
    }
}