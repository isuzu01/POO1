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
    
    public partial class tb_pedidoscabe
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_pedidoscabe()
        {
            this.tb_pedidosdeta = new HashSet<tb_pedidosdeta>();
        }
    
        public int IdPedido { get; set; }
        public string IdCliente { get; set; }
        public Nullable<int> IdEmpleado { get; set; }
        public System.DateTime FechaPedido { get; set; }
        public Nullable<System.DateTime> FechaEntrega { get; set; }
        public Nullable<System.DateTime> FechaEnvio { get; set; }
        public string Envio { get; set; }
        public Nullable<decimal> Cargo { get; set; }
        public string Destinatario { get; set; }
        public string DireccionDestinatario { get; set; }
        public string CiudadDestinatario { get; set; }
        public string RegionDestinatario { get; set; }
        public string CodPostalDestinatario { get; set; }
        public string PaisDestinatario { get; set; }
    
        public virtual tb_clientes tb_clientes { get; set; }
        public virtual tb_empleados tb_empleados { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_pedidosdeta> tb_pedidosdeta { get; set; }
    }
}
