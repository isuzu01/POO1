using POO1_T2_TrujilloMezaJhuli.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Configuration;
using System.Web.Configuration;
using System.Web.UI.WebControls;
using POO1_T2_TrujilloMezaJhuli.DataBase;

namespace POO1_T2_TrujilloMezaJhuli.Dao.DaoImpl
{
    public class MascotaDaoImpl : IMascotaDao
    {
        public int ActualizarMascota(Mascota m)
        {
            int procesar = -1;
            SqlConnection con = AccesoDB.GetConnection();
            SqlCommand cmd = new SqlCommand("usp_Mascota_crud", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            try
            {
                con.Open();
                cmd.Parameters.AddWithValue("@indicador", "Actualizar");
                cmd.Parameters.AddWithValue("@IdMascota", m.Id_Mascota);
                cmd.Parameters.AddWithValue("@Nombre_Mascota", m.Nombre_Mascota);
                cmd.Parameters.AddWithValue("@Especie", m.Especie);
                cmd.Parameters.AddWithValue("@Raza", m.Raza);
                cmd.Parameters.AddWithValue("@Edad", m.Edad);
                cmd.Parameters.AddWithValue("@IdCliente", m.Id_Cliente);

                procesar = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error - actualizar : " + ex.ToString());
            }
            finally
            {
                con.Close();
            }
            return procesar;
        }

        public int EliminarMascota(int id)
        {
            int procesar = -1;
            SqlConnection con = AccesoDB.GetConnection();
            SqlCommand cmd = new SqlCommand("usp_Mascota_crud", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            try
            {
                con.Open();
                cmd.Parameters.AddWithValue("@indicador", "Eliminar");
                cmd.Parameters.AddWithValue("@IdMascota", id);
                cmd.Parameters.AddWithValue("@Nombre_Mascota", "");
                cmd.Parameters.AddWithValue("@Especie", "");
                cmd.Parameters.AddWithValue("@Raza", "");
                cmd.Parameters.AddWithValue("@Edad", 0);
                cmd.Parameters.AddWithValue("@IdCliente", 0);

                procesar = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error - Eliminar : " + ex.ToString());
            }
            finally
            {
                con.Close();
            }
            return procesar;
        }

        public List<Mascota> ListarTodo()
        {
            List<Mascota> lista = new List<Mascota>();
            SqlConnection con = AccesoDB.GetConnection();
            SqlCommand cmd = new SqlCommand("usp_Mascota_crud", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@indicador", "ConsultarTodo");
            cmd.Parameters.AddWithValue("@IdMascota", 0);
            cmd.Parameters.AddWithValue("@Nombre_Mascota", "");
            cmd.Parameters.AddWithValue("@Especie", "");
            cmd.Parameters.AddWithValue("@Raza", "");
            cmd.Parameters.AddWithValue("@Edad", 0);
            cmd.Parameters.AddWithValue("@IdCliente", 0);

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Mascota m = new Mascota()
                    {
                        Id_Mascota = reader.GetInt32(0),
                        Nombre_Mascota = reader.GetString(1),
                        Especie = reader.GetString(2),
                        Raza = reader.GetString(3),
                        Edad = reader.GetInt32(4),
                        Id_Cliente = reader.GetInt32(5),
                    };
                    lista.Add(m);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error - ListarTodo : " + ex.ToString());
            }
            finally
            {
                con.Close();
            }
            return lista;
        }

        public Mascota ObtenerMascota(int id)
        {

            Mascota mascota = null;
            SqlConnection con = AccesoDB.GetConnection();
            SqlCommand cmd = new SqlCommand("usp_Mascota_crud", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@indicador", "ConsultarXId");
            cmd.Parameters.AddWithValue("@IdMascota", id);
            cmd.Parameters.AddWithValue("@Nombre_Mascota", "");
            cmd.Parameters.AddWithValue("@Especie", "");
            cmd.Parameters.AddWithValue("@Raza", "");
            cmd.Parameters.AddWithValue("@Edad", 0);
            cmd.Parameters.AddWithValue("@IdCliente", 0);

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    mascota = new Mascota()
                    {
                        Id_Mascota = reader.GetInt32(0),
                        Nombre_Mascota = reader.GetString(1),
                        Especie = reader.GetString(2),
                        Raza = reader.GetString(3),
                        Edad = reader.GetInt32(4),
                        Id_Cliente = reader.GetInt32(5),
                    };
                }
            }
            catch (SqlException ex)
            {
                Debug.WriteLine("Error - otener  : " + ex.ToString());
            }
            finally
            {
                con.Close();
            }
            return  mascota;
            
        }

        public int RegistrarMascota(Mascota m)
        {

            int procesar = -1;
            SqlConnection con = AccesoDB.GetConnection();
            SqlCommand cmd = new SqlCommand("usp_Mascota_crud", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            try
            {
                con.Open();
                cmd.Parameters.AddWithValue("@indicador", "Insertar");
                cmd.Parameters.AddWithValue("@IdMascota", m.Id_Mascota);
                cmd.Parameters.AddWithValue("@Nombre_Mascota", m.Nombre_Mascota);
                cmd.Parameters.AddWithValue("@Especie", m.Especie);
                cmd.Parameters.AddWithValue("@Raza", m.Raza);
                cmd.Parameters.AddWithValue("@Edad", m.Edad);
                cmd.Parameters.AddWithValue("@IdCliente", m.Id_Cliente);

                procesar = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error - registrar : " + ex.ToString());
            }
            finally
            {
                con.Close();
            }
            return procesar;
        }
    }
}