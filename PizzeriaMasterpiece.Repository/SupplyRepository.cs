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
   public class SupplyRepository
    {
        public List<SupplyDTO> GetSupplies()
        {
            using (var context = new PizzeriaMasterpieceEntities())
            {
                var result =  context.Supplies.Where(t => t.IsActive == 1)
              .Select(s => new SupplyDTO
              {
                  SupplyId = s.SupplyId,
                  Code = s.Code,
                  Description = s.Description,
                  Name = s.Name,
                  Quantity = s.Quantity
              }).ToList();
              return result;
            }
        }

        public int UpdateSupply(SupplyDTO supply)
        {
            using (var context = new PizzeriaMasterpieceEntities())
            {
                var currentSupply = context.Supplies.Find(supply.SupplyId);
                if (!string.IsNullOrWhiteSpace(supply.Name))   currentSupply.Name = supply.Name;
                if (!string.IsNullOrWhiteSpace(supply.Code)) currentSupply.Code = supply.Code;
                if (!string.IsNullOrWhiteSpace(supply.Description)) currentSupply.Description = supply.Description;
                if (supply.Quantity != null) currentSupply.Quantity = supply.Quantity;
                if (supply.IsActive != null) currentSupply.IsActive = supply.IsActive;
                context.SaveChanges();
                return currentSupply.SupplyId;
            }
        }


        public SupplyDTO GetSupplyById(int supplyId)
        {
            using (var context = new PizzeriaMasterpieceEntities())
            {
                var result = context.Supplies.Where(w => w.SupplyId == supplyId)
                    .Select(a => new SupplyDTO
                    {
                        SupplyId = a.SupplyId,
                        Code = a.Code,
                        Description = a.Description,
                        Name = a.Name,
                        Quantity = a.Quantity,
                        IsActive=a.IsActive
                    }).FirstOrDefault();

                return result;
            }
        }

        public SupplyDTO InsertSupply(SupplyDTO supply)
        {
            using (var context = new PizzeriaMasterpieceEntities())
            {
                var newSupply = new Supply
                {
                    SupplyId = -1,
                    Code = supply.Code,
                    Name = supply.Name,
                    Description = supply.Description,
                    Quantity= supply.Quantity,
                    IsActive = 1,
                };
                context.Supplies.Add(newSupply);
                context.SaveChanges();
                return GetSupplyById(newSupply.SupplyId);

            }
        }



    }
}
