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
    
    public partial class ProductSupply
    {
        public int ProductSupplyId { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<int> ProductId { get; set; }
        public Nullable<int> SupplyId { get; set; }
    
        public virtual Product Product { get; set; }
        public virtual Supply Supply { get; set; }
    }
}
