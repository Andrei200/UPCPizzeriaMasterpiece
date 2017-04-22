using PizzeriaMasterpiece.DTO;
using PizzeriaMasterpiece.Model;
using System;
using System.Collections.Generic;
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


                return null;
            }
        }

        public async Task<SupplyDTO> UpdateSupply(SupplyDTO supply)
        {


            using (var context = new PizzeriaMasterpieceEntities())
            {
                //user id
                //cantidad
                //IsActive
                //nombre
                //descripcion


                return null;
            }
        }


        public async Task<SupplyDTO> GetSupplyById(int supplyId)
        {

            // recuperar  el  suply deacuerdo al  id  consultado
            using (var context = new PizzeriaMasterpieceEntities())
            {



                return null;
            }
        }



        public async Task<SupplyDTO> InsertSupply(SupplyDTO supply)
        {


            using (var context = new PizzeriaMasterpieceEntities())
            {
                // el id le  pongo  -1  pasar  todos los  demas  campos  menos  el  id 



                return null;
            }
        }





    }
}
