﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO1_Tarea08_TrujilloMezaJhuli.Services
{
    public interface IDaoProveedor<T>
    {
        List<T> ListarProveedor();
    }
}
