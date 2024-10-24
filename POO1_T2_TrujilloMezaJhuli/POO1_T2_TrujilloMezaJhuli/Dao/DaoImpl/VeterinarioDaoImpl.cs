using POO1_T2_TrujilloMezaJhuli.DataBase;
using POO1_T2_TrujilloMezaJhuli.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace POO1_T2_TrujilloMezaJhuli.Dao.DaoImpl
{
    public class VeterinarioDaoImpl : IVeterinarioDao
    {
        public int ActualizarVeterinario(Veterinario v)
        {
            int procesar = -1;
            SqlConnection con = AccesoDB.GetConnection();
            SqlCommand cmd = new SqlCommand("usp_Veterinario_crud", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            try
            {
                con.Open();
                cmd.Parameters.AddWithValue("@indicador", "Actualizar");
                cmd.Parameters.AddWithValue("@Id_Veterinario",v.Id_Veterinario);
                cmd.Parameters.AddWithValue("@Nombre_Veterinario", v.Nombre_Veterinario);
                cmd.Parameters.AddWithValue("@Especialidad", v.Especialidad);
                cmd.Parameters.AddWithValue("@Telefono", v.Telefono);
                cmd.Parameters.AddWithValue("@Email", v.Email);

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

        public int EliminarVeterinario(int id)
        {
            int procesar = -1;
            SqlConnection con = AccesoDB.GetConnection();
            SqlCommand cmd = new SqlCommand("usp_Veterinario_crud", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            try
            {
                con.Open();
                cmd.Parameters.AddWithValue("@indicador", "Eliminar");
                cmd.Parameters.AddWithValue("@Id_Veterinario", id);
                cmd.Parameters.AddWithValue("@Nombre_Veterinario", "");
                cmd.Parameters.AddWithValue("@Especialidad", "");
                cmd.Parameters.AddWithValue("@Telefono", "");
                cmd.Parameters.AddWithValue("@Email", "");

                procesar = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error - eliminar : " + ex.ToString());
            }
            finally
            {
                con.Close();
            }
            return procesar;
        }

        public List<Veterinario> ListarTodo()
        {

            List<Veterinario> lista = new List<Veterinario>();
            SqlConnection con = AccesoDB.GetConnection();
            SqlCommand cmd = new SqlCommand("usp_Veterinario_crud", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@indicador", "ConsultarTodo");
            cmd.Parameters.AddWithValue("@Id_Veterinario", 0);
            cmd.Parameters.AddWithValue("@Nombre_Veterinario", "");
            cmd.Parameters.AddWithValue("@Especialidad", "");
            cmd.Parameters.AddWithValue("@Telefono", "");
            cmd.Parameters.AddWithValue("@Email", "");

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Veterinario vet = new Veterinario()
                    {
                        Id_Veterinario = reader.GetInt32(0),
                        Nombre_Veterinario = reader.GetString(1),
                        Especialidad = reader.GetString(2),
                        Telefono = reader.GetString(3),
                        Email = reader.GetString(4),
                    };
                    lista.Add(vet);
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
                con.Close();
            }
            return lista;
        }

        public Veterinario ObtenerVeterinario(int id)
        {


            Veterinario veterinario = null;
            SqlConnection con = AccesoDB.GetConnection();
            SqlCommand cmd = new SqlCommand("usp_Veterinario_crud", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@indicador", "ConsultarXId");
            cmd.Parameters.AddWithValue("@Id_Veterinario", id);
            cmd.Parameters.AddWithValue("@Nombre_Veterinario", "");
            cmd.Parameters.AddWithValue("@Especialidad", "");
            cmd.Parameters.AddWithValue("@Telefono", "");
            cmd.Parameters.AddWithValue("@Email", "");

            try
            {
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    veterinario = new Veterinario()
                    {
                        Id_Veterinario = reader.GetInt32(0),
                        Nombre_Veterinario = reader.GetString(1),
                        Especialidad = reader.GetString(2),
                        Telefono = reader.GetString(3),
                        Email = reader.GetString(4),
                    };
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error - ListarTodo : " + ex.ToString());
            }
            finally
            {
                con.Close();
            }
            return veterinario;
        }

        public int RegistrarVeterinario(Veterinario v)
        {

            int procesar = -1;
            SqlConnection con = AccesoDB.GetConnection();
            SqlCommand cmd = new SqlCommand("usp_Veterinario_crud", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            try
            {
                con.Open();
                cmd.Parameters.AddWithValue("@indicador", "Insertar");
                cmd.Parameters.AddWithValue("@Id_Veterinario", v.Id_Veterinario);
                cmd.Parameters.AddWithValue("@Nombre_Veterinario", v.Nombre_Veterinario);
                cmd.Parameters.AddWithValue("@Especialidad", v.Especialidad);
                cmd.Parameters.AddWithValue("@Telefono", v.Telefono);
                cmd.Parameters.AddWithValue("@Email", v.Email);

                procesar = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error - insertar : " + ex.ToString());
            }
            finally
            {
                con.Close();
            }
            return procesar;
        }
    }
}