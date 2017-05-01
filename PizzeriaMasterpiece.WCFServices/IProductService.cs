using PizzeriaMasterpiece.DTO;
using PizzeriaMasterpiece.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaMasterpiece.WCFServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IProductoService" in both code and config file together.
    [ServiceContract]
    public interface IProductService
    {
        [OperationContract]
        ProductDTO GetProductInformation(int productId);

        [OperationContract]
        ProductDTO InsertProductInformation(ProductDTO product);

        [OperationContract]
        ProductDTO UpdateProductInformation(ProductDTO product);

        [OperationContract]
        List<ProductDTO> ListAllProductInformation();

        [OperationContract]
        List<SupplyProductDTO> ListAllProductBySupply(int supplyId);
    }
}
