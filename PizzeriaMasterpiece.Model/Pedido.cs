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
    
    public partial class Pedido
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pedido()
        {
            this.PedidoDetalles = new HashSet<PedidoDetalle>();
        }
    
        public int IdPedido { get; set; }
        public int Usuario_IdUsuario { get; set; }
        public int TipoComprobante_IdTipoComprobante { get; set; }
        public int PedidoEstado_IdPedidoEstado { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
        public string NumeroComprobante { get; set; }
        public string Comentario { get; set; }
    
        public virtual PedidoEstado PedidoEstado { get; set; }
        public virtual TipoComprobante TipoComprobante { get; set; }
        public virtual Usuario Usuario { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PedidoDetalle> PedidoDetalles { get; set; }
    }
}