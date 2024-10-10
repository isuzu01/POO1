using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace POO1_T2_TrujilloMezaJhuli.DataBase
{
    public class AccesoDB
    {
        public static SqlConnection GetConnection()
        {
            SqlConnection cnx = new SqlConnection(
                ConfigurationManager.ConnectionStrings["VeterinariaDB"].ConnectionString);
            return cnx;
        }
    }
}