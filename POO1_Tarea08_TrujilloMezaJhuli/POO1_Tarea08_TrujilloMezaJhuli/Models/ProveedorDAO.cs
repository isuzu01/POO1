using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using POO1_Tarea08_TrujilloMezaJhuli.DataBase;
using POO1_Tarea08_TrujilloMezaJhuli.Entity;
using POO1_Tarea08_TrujilloMezaJhuli.Services;
using System.Diagnostics;

namespace POO1_Tarea08_TrujilloMezaJhuli.Models
{
    public class ProveedorDAO : IDaoProveedor<Proveedor>
    {
        public List<Proveedor> ListarProveedor()
        {
            List<Proveedor> lista = new List<Proveedor>();
            SqlConnection cn = AccesoBD.GetConnection();
            SqlCommand cmd = new SqlCommand("usp_Proveedor_Listar", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Proveedor prv = new Proveedor()
                    {
                        IdPRoveedor = reader.GetInt32(0),
                        NomProveedor = reader.GetString(1)
                    };
                    lista.Add(prv);
                }
                reader.Close();
            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.Message);
                throw ex;
            }
            finally
            {
                cn.Close();
            }
            return lista;
        }
    }
}