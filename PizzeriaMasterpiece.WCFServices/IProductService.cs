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
        Task<ProductDTO> GetProductInformation(int productId);

        [OperationContract]
        Task<ProductDTO> InsertProductInformation(ProductDTO product);

        [OperationContract]
        Task<ProductDTO> UpdateProductInformation(ProductDTO product);

        [OperationContract]
        Task<List<ProductDTO>> ListAllProductInformation();

        [OperationContract]
        Task<List<ProductDTO>> ListAllProductToSellInformation();        
    }
}
