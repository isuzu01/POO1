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
    public class ClienteDaoImpl : IClienteDao
    {
        public int ActualizarCliente(Cliente c)
        {
            int procesar = -1;
            SqlConnection con = AccesoDB.GetConnection();
            SqlCommand cmd = new SqlCommand("usp_Cliente_crud", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            try
            {
                con.Open();
                cmd.Parameters.AddWithValue("@indicador", "Actualizar");
                cmd.Parameters.AddWithValue("@IdCliente", c.Id_Cliente);
                cmd.Parameters.AddWithValue("@Nombre_Cliente", c.Nombre_Cliente);
                cmd.Parameters.AddWithValue("@Direccion", c.Direccion);
                cmd.Parameters.AddWithValue("@Telefono", c.Telefono);
                cmd.Parameters.AddWithValue("@Email", c.Email);
                cmd.Parameters.AddWithValue("@FechaRegistro", c.Fecha_Registro);

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

        public int EliminarCliente(int id)
        {
            int procesar = -1;
            SqlConnection con = AccesoDB.GetConnection();
            SqlCommand cmd = new SqlCommand("usp_Cliente_crud", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            try
            {
                con.Open();
                cmd.Parameters.AddWithValue("@indicador", "Eliminar");
                cmd.Parameters.AddWithValue("@IdCliente", id);
                cmd.Parameters.AddWithValue("@Nombre_Cliente", "");
                cmd.Parameters.AddWithValue("@Direccion", "");
                cmd.Parameters.AddWithValue("@Telefono", "");
                cmd.Parameters.AddWithValue("@Email", "");
                cmd.Parameters.AddWithValue("@FechaRegistro", "");

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

        public int RegistrarCliente(Cliente c)
        {

            int procesar = -1;
            SqlConnection con = AccesoDB.GetConnection();
            SqlCommand cmd = new SqlCommand("usp_Cliente_crud", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            try
            {
                con.Open();
                cmd.Parameters.AddWithValue("@indicador", "Insertar");
                cmd.Parameters.AddWithValue("@IdCliente", c.Id_Cliente);
                cmd.Parameters.AddWithValue("@Nombre_Cliente", c.Nombre_Cliente);
                cmd.Parameters.AddWithValue("@Direccion", c.Direccion);
                cmd.Parameters.AddWithValue("@Telefono", c.Telefono);
                cmd.Parameters.AddWithValue("@Email", c.Email);
                cmd.Parameters.AddWithValue("@FechaRegistro", c.Fecha_Registro);

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

        public List<Cliente> ListarTodo()
        {
            List<Cliente> lista = new List<Cliente>();
            SqlConnection con = AccesoDB.GetConnection();
            SqlCommand cmd = new SqlCommand("usp_Cliente_crud", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@indicador", "ConsultarTodo");
            cmd.Parameters.AddWithValue("@IdCliente", 0);
            cmd.Parameters.AddWithValue("@Nombre_Cliente", "");
            cmd.Parameters.AddWithValue("@Direccion", "");
            cmd.Parameters.AddWithValue("@Telefono", "");
            cmd.Parameters.AddWithValue("@Email", "");
            cmd.Parameters.AddWithValue("@FechaRegistro", DBNull.Value);

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Cliente cli = new Cliente()
                    {
                        Id_Cliente = reader.GetInt32(0),
                        Nombre_Cliente = reader.GetString(1),
                        Direccion = reader.GetString(2),
                        Telefono = reader.GetString(3),
                        Email = reader.GetString(4),
                        Fecha_Registro = reader.GetDateTime(5).Date,
                    };
                    lista.Add(cli);
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

        public Cliente ObtenerClliente(int id)
        {

            Cliente cliente = null;
            SqlConnection con = AccesoDB.GetConnection();
            SqlCommand cmd = new SqlCommand("usp_Cliente_crud", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@indicador", "ConsultarXId");
            cmd.Parameters.AddWithValue("@IdCliente", id);
            cmd.Parameters.AddWithValue("@Nombre_Cliente", "");
            cmd.Parameters.AddWithValue("@Direccion", "");
            cmd.Parameters.AddWithValue("@Telefono", "");
            cmd.Parameters.AddWithValue("@Email", "");
            cmd.Parameters.AddWithValue("@FechaRegistro", "");

            try
            {
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    cliente = new Cliente()
                    {
                        Id_Cliente = reader.GetInt32(0),
                        Nombre_Cliente = reader.GetString(1),
                        Direccion = reader.GetString(2),
                        Telefono = reader.GetString(3),
                        Email = reader.GetString(4),
                        Fecha_Registro = reader.GetDateTime(5).Date
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
            return cliente;
        }
    }
}