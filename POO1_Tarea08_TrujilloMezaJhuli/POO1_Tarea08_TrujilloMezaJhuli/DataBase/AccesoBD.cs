using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.SqlClient;
using System.Configuration;

namespace POO1_Tarea08_TrujilloMezaJhuli.DataBase
{
    public class AccesoBD
    {

        public static SqlConnection GetConnection()
        {
            SqlConnection cnx = new SqlConnection(
                ConfigurationManager.ConnectionStrings["Negocios2022"].ConnectionString);
            return cnx;
        }
    }
}