using POO1_EF_TrujilloMezaJhuli.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace POO1_EF_TrujilloMezaJhuli.dao
{
    internal interface ITransporteDao
    {
        int registrar(Transporte t);
        int eliminar(int id);
        int actualizar(Transporte t);
        Transporte obtenerTransporte(int id);
        List<Transporte> consultarTodo();
    }
}
