using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POOI_T1_TrujilloMezaJhuli.Models
{
    public class Asistente : Trabajador
    {
        public int hijos {  get; set; }
        public string grado {  get; set; }


        public override double Basico()
        {
            if (grado == "secundaria")
                return 950;
            else
                return 1500;
        }

        public override double Bonificacion()
        {
            return 0.0;
        }

        public double Escolaridad()
        {
            return hijos * 95;
        }

        public double BonificacionEspecial()
        {
            DateTime fecHoy = DateTime.Today;
            var diferencia = fecHoy.Year - fecContrato.Year;

            if (diferencia <= 1 )
                return Basico() * 0.05;
            else
                return Basico() * 0.1;
        }

        public override double Monto()
        {
            return Basico() + Bonificacion() + Escolaridad() + BonificacionEspecial();
        }

    }
}