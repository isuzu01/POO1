using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace POO1_Tarea04_MVC_Web.Models
{
    public class AccesoData
    {
        // objeto sqlconection
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Negocios2022"].ConnectionString);

        //metodo que permite ejecutar el procedimiento almacenado creado en el sesrvidor
        public DataSet ProductoListar()
        {
            SqlDataAdapter da = new SqlDataAdapter("usp_ProductoListar",cn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
    }
}