using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using POO1_T2_TrujilloMezaJhuli.Models;

namespace POO1_T2_TrujilloMezaJhuli.Dao
{
    internal interface IClienteDao
    {
        int ActualizarCliente(Cliente c);
        int RegistrarCliente(Cliente c);
        int EliminarCliente(int id);
        Cliente ObtenerClliente(int id);
        List<Cliente> ListarTodo();
    }
}
