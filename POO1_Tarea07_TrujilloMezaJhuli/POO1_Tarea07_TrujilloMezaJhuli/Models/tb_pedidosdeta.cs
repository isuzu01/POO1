//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace POO1_Tarea07_TrujilloMezaJhuli.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tb_pedidosdeta
    {
        public Nullable<int> IdPedido { get; set; }
        public Nullable<int> IdProducto { get; set; }
        public decimal PrecioUnidad { get; set; }
        public short Cantidad { get; set; }
        public double Descuento { get; set; }
    
        public virtual tb_pedidoscabe tb_pedidoscabe { get; set; }
        public virtual tb_productos tb_productos { get; set; }
    }
}
