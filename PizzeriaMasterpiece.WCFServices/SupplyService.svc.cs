using PizzeriaMasterpiece.WCFServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using PizzeriaMasterpiece.DTO;
using System.Threading.Tasks;
using PizzeriaMasterpiece.Repository;

namespace PizzeriaMasterpiece.WCFServices
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "SupplyService" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione SupplyService.svc o SupplyService.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class SupplyService : ISupplyServie
    {
        public async Task<SupplyDTO> GetSupplyById(int SupplyId)
        {
            var supplyRepository = new SupplyRepository();
            return await supplyRepository.GetSupplyById(SupplyId);
        }

        public async Task<SupplyDTO> InsertSupplyInformation(SupplyDTO supply)
        {
            var supplyRepository = new SupplyRepository();
            return await supplyRepository.InsertSupply(supply);
        }

        public async Task<List<SupplyDTO>> ListAllSupplyInformation()
        {
            var supplyRepository = new SupplyRepository();
            return await supplyRepository.GetSupplies();
        }

        public async Task<SupplyDTO> UpdateSupplyInformation(SupplyDTO supply)
        {
            var supplyRepository = new SupplyRepository();
            return await supplyRepository.UpdateSupply(supply);
        }
    }
}
