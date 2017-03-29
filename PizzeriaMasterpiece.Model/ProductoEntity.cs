//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PizzeriaMasterpiece.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProductoEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProductoEntity()
        {
            this.PedidoDetalles = new HashSet<PedidoDetalleEntity>();
        }
    
        public int IdProducto { get; set; }
        public int TipoProducto_IdTipoProducto { get; set; }
        public string NombreProducto { get; set; }
        public Nullable<byte> Activo { get; set; }
        public Nullable<decimal> Precio { get; set; }
        public string Descripcion { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PedidoDetalleEntity> PedidoDetalles { get; set; }
        public virtual TipoProductoEntity TipoProducto { get; set; }
    }
}
