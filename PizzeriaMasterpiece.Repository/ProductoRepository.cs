using PizzeriaMasterpiece.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaMasterpiece.Repository
{
    public class ProductoRepository
    {

        public async Task<ProductoDTO> GetProductInformation(int productId){
            using (var context = new PizzeriaMasterpieceEntities()){

                var result =  await context.Productoes
               .Where(p => p.IdProducto == productId)
               .Select(q => new ProductoDTO
               {
                   IdProducto = q.IdProducto,
                   TipoProducto_IdTipoProducto = q.TipoProducto_IdTipoProducto,
                   NombreProducto = q.NombreProducto,
                   Activo = q.Activo,
                   Precio = q.Precio,
                   Descripcion = q.Descripcion
               })
               .FirstOrDefaultAsync();
                return result;
            }
        }

        public async Task<ProductoDTO> InsertProductInformation(ProductoDTO Producto)
        {           
            using (var context = new PizzeriaMasterpieceEntities())
            {
                var product = new Producto();
                product.IdProducto =-1;
                product.NombreProducto = Producto.NombreProducto;
                product.TipoProducto_IdTipoProducto = Producto.TipoProducto_IdTipoProducto;                
                product.Activo = Producto.Activo;
                product.Precio = Producto.Precio;
                product.Descripcion = Producto.Descripcion;
                context.Productoes.Add(product);
                context.SaveChanges();
                return await GetProductInformation(product.IdProducto);
            }           
        }

        public List<ProductoDTO> ListAllProductInformation()
        {
            using (var context = new PizzeriaMasterpieceEntities())
            {
               var result = context.Productoes               
               .Select(q => new ProductoDTO
               {
                   IdProducto = q.IdProducto,
                   TipoProducto_IdTipoProducto = q.TipoProducto_IdTipoProducto,
                   NombreProducto = q.NombreProducto,
                   Activo = q.Activo,
                   Precio = q.Precio,
                   Descripcion = q.Descripcion
               })
               .ToList();
                return result;
            }
        }

    }
}
