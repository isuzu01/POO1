using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace POO1_EF_TrujilloMezaJhuli.Models
{
    public class Transporte
    {
        [DisplayName("Codigo Trasnporte")]
        [Required(ErrorMessage = "El Campo es onligatorio")]
        public int id_transporte {  get; set; }

        [Required(ErrorMessage = "El RUC es obligatorio")]
        [MinLength(11, ErrorMessage = "Minimo debe ser 11 caracteres")]
        [MaxLength(11, ErrorMessage = "MÁXIMO debe ser 11 caracteres")]
        public string ruc {  get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "MÁXIMO debe ser 50 caracteres")]
        public string proveedor {  get; set; }
        [Required]
        [MaxLength(150, ErrorMessage = "MÁXIMO debe ser 150 caracteres")]
        public string direccion {  get; set; }
        public string direccion2 {  get; set; }

        public string telefono {  get; set; }
        [Required]
        [MaxLength(80, ErrorMessage = "MÁXIMO debe ser 80 caracteres")]
        public string correo {  get; set; }
        [Required]
        [MaxLength(80, ErrorMessage = "MÁXIMO debe ser 80 caracteres")]
        public string contacto {  get; set; }
    }
}