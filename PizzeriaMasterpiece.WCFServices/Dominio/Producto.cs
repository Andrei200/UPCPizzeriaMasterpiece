using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PizzeriaMasterpiece.WCFServices.Dominio
{
    [DataContract]
    public class Producto
    {
        [DataMember]
        public int IdProducto { get; set; }
        [DataMember]
        public int TipoProducto_IdTipoProducto { get; set; }
        [DataMember]
        public string NombreProducto { get; set; }
        [DataMember]
        public int Activo { get; set; }
        [DataMember]
        public double Precio { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
    }
}