using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace POO1_Tarea04_MVC_Web.Models
{
    public class AccesoDatos
    {
        // objeto sqlconnection
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionString["Negocios2022"].ConnectionString);
    }
}