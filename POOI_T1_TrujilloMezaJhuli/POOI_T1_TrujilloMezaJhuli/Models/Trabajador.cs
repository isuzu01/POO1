using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace POOI_T1_TrujilloMezaJhuli.Models
{
    public class Trabajador
    {
        public string dniTrab {  get; set; }
        public string apeTrab {  get; set; }
        public string nomTrab {  get; set; }
        public DateTime fecContrato {  get; set; }
        public string categoriaTrab {  get; set; }


        //•	Defina el método Básico
        public virtual double Basico()
        {
            
            DateTime fecHoy = DateTime.Today;
            var diferencia = fecHoy.Year - fecContrato.Year;


            if (diferencia <= 3)
                return 1000;
            else if (diferencia > 3 && diferencia <= 5)
                return 1500;
            else if (diferencia > 5 && diferencia <= 10)
                return 2500;
            else
                return 3500;
        }

        //•	Defina el método Bonificación 
        public virtual double Bonificacion()
        {
            if (categoriaTrab == "A" || categoriaTrab == "B" || categoriaTrab == "C")
                return Basico() * 0.1;
            else
                return Basico() * 0.15;
        }

        //•	Defina el método Monto()
        public virtual double Monto()
        {
            return Basico() + Bonificacion();
        }





    }
}