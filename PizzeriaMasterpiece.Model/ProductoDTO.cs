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
        public int IdTipoProducto { get; set; }
        public string TipoProducto { get; set; }
        public string NombreProducto { get; set; }
        public int? Activo { get; set; }
        public decimal? Precio { get; set; }
        public string Descripcion { get; set; }
    }
    
}
