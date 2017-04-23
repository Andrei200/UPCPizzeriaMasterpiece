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
        public async Task<List<SupplyDTO>> GetSupplies()
        {
            //devolver todos  los supply donde  [IsActive] sea  =1
            using (var context = new PizzeriaMasterpieceEntities())
            {
                var result = await context.Supplies.Where(t => t.IsActive == 1)
              .Select(s => new SupplyDTO
              {
                  SupplyId = s.SupplyId,
                  Code = s.Code,
                  Description = s.Description,
                  Name = s.Name,
                  Quantity = s.Quantity
              }).ToListAsync();
                return result;
            }
        }

        public async Task<SupplyDTO> UpdateSupply(SupplyDTO supply)
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
                return await GetSupplyById(currentSupply.SupplyId);

                //user id
                //cantidad
                //IsActive
                //nombre
                //descripcion

            }
        }


        public async Task<SupplyDTO> GetSupplyById(int supplyId)
        {

            // recuperar  el  suply deacuerdo al  id  consultado
            using (var context = new PizzeriaMasterpieceEntities())
            {
                var result = await context.Supplies.Where(w => w.SupplyId == supplyId)
                    .Select(a => new SupplyDTO
                    {

                        SupplyId = a.SupplyId,
                        Code = a.Code,
                        Description = a.Description,
                        Name = a.Name,
                        Quantity = a.Quantity,
                        IsActive=a.IsActive



                    }).FirstOrDefaultAsync();

                return result;
            }
        }



        public async Task<SupplyDTO> InsertSupply(SupplyDTO supply)
        {


            using (var context = new PizzeriaMasterpieceEntities())
            {
                // el id le  pongo  -1  pasar  todos los  demas  campos  menos  el  id 
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
                return await GetSupplyById(newSupply.SupplyId);

            }
        }





    }
}
