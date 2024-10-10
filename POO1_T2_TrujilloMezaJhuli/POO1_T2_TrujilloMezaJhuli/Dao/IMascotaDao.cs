using POO1_T2_TrujilloMezaJhuli.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO1_T2_TrujilloMezaJhuli.Dao
{
    internal interface IMascotaDao
    {
        int ActualizarMascota(Mascota c);
        int RegistrarMascota(Mascota c);
        int EliminarMascota(int id);
        Mascota ObtenerMascota(int id);
        List<Mascota> ListarTodo();
    }
}
