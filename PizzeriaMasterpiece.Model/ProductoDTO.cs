using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaMasterpiece.Model
{
    public class ProductoDTO
    {
        public int IdProducto { get; set; }
        public int TipoProducto_IdTipoProducto { get; set; }
        public string NombreProducto { get; set; }
        public Nullable<byte> Activo { get; set; }
        public Nullable<decimal> Precio { get; set; }
        public string Descripcion { get; set; }
    }
    
}
