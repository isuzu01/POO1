using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO1_Tarea08_TrujilloMezaJhuli.Services
{
    public interface ICrudDaoProducto<T>
    {
        void InsetarProducto(T p);
        void ActualizarProducto(T p);
        void EliminarProducto(T p);
        List<T> ListarProducto();
        T BuscarProducto(int id);
    }
}
