//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace POO1_Tarea06_TrujilloMezaJhuli.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tb_empleados
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_empleados()
        {
            this.tb_pedidoscabe = new HashSet<tb_pedidoscabe>();
        }
    
        public int IdEmpleado { get; set; }
        public string ApeEmpleado { get; set; }
        public string NomEmpleado { get; set; }
        public System.DateTime FecNac { get; set; }
        public string DirEmpleado { get; set; }
        public Nullable<int> idDistrito { get; set; }
        public string fonoEmpleado { get; set; }
        public Nullable<int> idCargo { get; set; }
        public System.DateTime FecContrata { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_pedidoscabe> tb_pedidoscabe { get; set; }
    }
}
