using PizzeriaMasterpiece.Model;
using PizzeriaMasterpiece.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaMasterpiece.WCFServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ProductoService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ProductoService.svc or ProductoService.svc.cs at the Solution Explorer and start debugging.
    public class ProductoService : IProductoService
    {
        public async Task<ProductoDTO> GetProductInformation(int ProductoId)
        {
            var productoRepository = new ProductoRepository();
            return await productoRepository.GetProductInformation(ProductoId);
        }

        public async Task<ProductoDTO> InsertProductInformation(ProductoDTO Producto)
        {
            var productoRepository = new ProductoRepository();
            return await productoRepository.InsertProductInformation(Producto);
        }

        public List<ProductoDTO> ListAllProductInformation()
        {
            var productoRepository = new ProductoRepository();
            return productoRepository.ListAllProductInformation();
        }
    }
}
