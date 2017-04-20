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

        public async Task<ProductoDTO> GetProduct(int productId)
        {
            using (var context = new PizzeriaMasterpieceEntities())
            {

                var result = await context.Productoes.Where(p => p.IdProducto == productId)
                    .Select(q => new ProductoDTO
                    {
                        IdProducto = q.IdProducto,
                        Descripcion = q.NombreProducto,
                        Precio = q.Precio,
                        NombreProducto = q.NombreProducto,
                        IdTipoProducto = q.IdProducto,
                        TipoProducto = q.TipoProducto.NombreTipoProducto
                    }).FirstOrDefaultAsync();

                return result;
            }
        }
        public async Task<ProductoDTO> InsertProduct(ProductoDTO producto)
        {           
            using (var context = new PizzeriaMasterpieceEntities())
            {
                var product = new Producto{
                    IdProducto = -1,
                    NombreProducto = producto.NombreProducto,
                    TipoProducto_IdTipoProducto = producto.IdTipoProducto,
                    Activo = 1,
                    Precio = producto.Precio,
                    Descripcion = producto.Descripcion
                };

                context.Productoes.Add(product);
                context.SaveChanges();

                return await GetProduct(product.IdProducto);
            }           
        }

        public async Task<List<ProductoDTO>> GetProductList()
        {
            using (var context = new PizzeriaMasterpieceEntities())
            {
               var result = await context.Productoes.Where(p => p.Activo == 1)
               .Select(q => new ProductoDTO
               {
                   IdProducto = q.IdProducto,
                   IdTipoProducto = q.TipoProducto_IdTipoProducto,
                   TipoProducto = q.TipoProducto.NombreTipoProducto,
                   NombreProducto = q.NombreProducto,
                   Precio = q.Precio,
                   Descripcion = q.Descripcion,
               })
               .ToListAsync();

               return result;
            }
        }

        public async Task<ProductoDTO> UpdateProduct(ProductoDTO producto)
        {
            using (var context = new PizzeriaMasterpieceEntities())
            {

                var product = await context.Productoes.FindAsync(producto.IdProducto);
                product.Descripcion = producto.Descripcion;
                product.Precio = producto.Precio;
                product.NombreProducto = producto.NombreProducto;
                context.SaveChanges();

                return await GetProduct(product.IdProducto);
            }
        }

    }
}
