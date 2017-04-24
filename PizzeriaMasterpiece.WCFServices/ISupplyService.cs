using PizzeriaMasterpiece.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaMasterpiece.WCFServices
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "ISupplyService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface ISupplyServie
    {
        [OperationContract]
        Task<SupplyDTO> GetSupplyById(int SupplyId);

        [OperationContract]
        Task<SupplyDTO> InsertSupplyInformation(SupplyDTO supply);

        [OperationContract]
        Task<SupplyDTO> UpdateSupplyInformation(SupplyDTO supply);

        [OperationContract]
        Task<List<SupplyDTO>> ListAllSupplyInformation();
    }
}
