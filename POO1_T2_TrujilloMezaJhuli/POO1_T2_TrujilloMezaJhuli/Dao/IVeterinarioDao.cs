using POO1_T2_TrujilloMezaJhuli.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO1_T2_TrujilloMezaJhuli.Dao
{
    internal interface IVeterinarioDao
    {
        int ActualizarVeterinario(Veterinario v);
        int RegistrarVeterinario(Veterinario v);
        int EliminarVeterinario(int id);
        Veterinario ObtenerVeterinario(int id);
        List<Veterinario> ListarTodo();
    }
}
