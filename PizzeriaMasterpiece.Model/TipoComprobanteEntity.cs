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
    
    public partial class TipoComprobanteEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TipoComprobanteEntity()
        {
            this.Pedidoes = new HashSet<PedidoEntity>();
        }
    
        public int IdTipoComprobante { get; set; }
        public string NombreTipoComprobante { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PedidoEntity> Pedidoes { get; set; }
    }
}
