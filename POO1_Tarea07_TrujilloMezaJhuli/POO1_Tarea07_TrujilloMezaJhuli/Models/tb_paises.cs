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
    
    public partial class tb_paises
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_paises()
        {
            this.tb_clientes = new HashSet<tb_clientes>();
            this.tb_proveedores = new HashSet<tb_proveedores>();
        }
    
        public string Idpais { get; set; }
        public string NombrePais { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_clientes> tb_clientes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_proveedores> tb_proveedores { get; set; }
    }
}
