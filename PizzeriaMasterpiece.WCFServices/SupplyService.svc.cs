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

    public class SupplyService : ISupplyServie
    {
        //public SupplyDTO GetSupplyById(int SupplyId)
        //{
        //    var supplyRepository = new SupplyRepository();
        //    return supplyRepository.GetSupplyById(SupplyId);
        //}

        //public SupplyDTO InsertSupplyInformation(SupplyDTO supply)
        //{
        //    var supplyRepository = new SupplyRepository();
        //    return supplyRepository.InsertSupply(supply);
        //}

        //public List<SupplyDTO> ListAllSupplyInformation()
        //{
        //    var supplyRepository = new SupplyRepository();
        //    return supplyRepository.GetSupplies();
        //}

        //public SupplyDTO UpdateSupplyInformation(SupplyDTO supply)
        //{
        //    var supplyRepository = new SupplyRepository();
        //    return supplyRepository.UpdateSupply(supply);
        //}
    }
}
