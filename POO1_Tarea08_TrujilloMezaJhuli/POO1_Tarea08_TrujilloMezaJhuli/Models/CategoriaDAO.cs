using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using POO1_Tarea08_TrujilloMezaJhuli.Entity;
using POO1_Tarea08_TrujilloMezaJhuli.Services;
using POO1_Tarea08_TrujilloMezaJhuli.DataBase;
using System.Diagnostics;

namespace POO1_Tarea08_TrujilloMezaJhuli.Models
{
    public class CategoriaDAO : IDaoCategoria<Categoria>
    {
        public List<Categoria> ListarCategoria()
        {
            List<Categoria> lista = new List<Categoria>();
            SqlConnection cn = AccesoBD.GetConnection();
            SqlCommand cmd = new SqlCommand("usp_Categoria_Listar", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Categoria cat = new Categoria()
                    {
                        IdCategoria = reader.GetInt32(0),
                        NombreCategoria = reader.GetString(1)
                    };
                    lista.Add(cat);
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