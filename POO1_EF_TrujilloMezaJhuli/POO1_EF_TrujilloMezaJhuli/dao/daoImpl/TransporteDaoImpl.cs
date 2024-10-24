using POO1_EF_TrujilloMezaJhuli.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace POO1_EF_TrujilloMezaJhuli.dao.daoImpl
{
    public class TransporteDaoImpl : ITransporteDao
    {
        public int actualizar(Transporte t)
        {

            SqlConnection con = null;
            SqlCommand cmd = null;
            int procesar = -1;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_VENTAS"].ConnectionString);
                con.Open();
                cmd = new SqlCommand("usp_Transporte_crud", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@indicador", "Actualizar");
                cmd.Parameters.AddWithValue("@id_transporte", t.id_transporte);
                cmd.Parameters.AddWithValue("@ruc", t.ruc);
                cmd.Parameters.AddWithValue("@proveedor", t.proveedor);
                cmd.Parameters.AddWithValue("@direccion", t.direccion);
                cmd.Parameters.AddWithValue("@direccion2", t.direccion2);
                cmd.Parameters.AddWithValue("@telefono", t.telefono);
                cmd.Parameters.AddWithValue("@correo", t.correo);
                cmd.Parameters.AddWithValue("@contacto", t.contacto);
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

        public List<Transporte> consultarTodo()
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader reader = null;
            List<Transporte> lista = new List<Transporte>();
            try
            {
                con = new SqlConnection(
                    ConfigurationManager.ConnectionStrings["BD_VENTAS"].ConnectionString);
                con.Open();


                cmd = new SqlCommand("usp_Transporte_crud", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@indicador", "ConsultarTodo");
                cmd.Parameters.AddWithValue("@id_transporte", 0);
                cmd.Parameters.AddWithValue("@ruc", "");
                cmd.Parameters.AddWithValue("@proveedor", "");
                cmd.Parameters.AddWithValue("@direccion", "");
                cmd.Parameters.AddWithValue("@direccion2", "");
                cmd.Parameters.AddWithValue("@telefono", "");
                cmd.Parameters.AddWithValue("@correo", "");
                cmd.Parameters.AddWithValue("@contacto", "");
                reader = cmd.ExecuteReader();
                Transporte objTransp;
                while (reader.Read())
                {
                    objTransp = new Transporte()
                    {
                        id_transporte = reader.GetInt32(0),
                        ruc = reader.GetString(1),
                        proveedor = reader.GetString(2),
                        direccion = reader.GetString(3),
                        direccion2 = reader.GetString(4),
                        telefono = reader.GetString(5),
                        correo = reader.GetString(6),
                        contacto = reader.GetString(7)
                    };
                    lista.Add(objTransp);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {

            }
            return lista;
        }

        public int eliminar(int id)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            int procesar = -1;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_VENTAS"].ConnectionString);
                con.Open();
                cmd = new SqlCommand("usp_Transporte_crud", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@indicador", "Eliminar");
                cmd.Parameters.AddWithValue("@id_transporte", id);
                cmd.Parameters.AddWithValue("@ruc", "");
                cmd.Parameters.AddWithValue("@proveedor", "");
                cmd.Parameters.AddWithValue("@direccion", "");
                cmd.Parameters.AddWithValue("@direccion2", "");
                cmd.Parameters.AddWithValue("@telefono", "");
                cmd.Parameters.AddWithValue("@correo", "");
                cmd.Parameters.AddWithValue("@contacto", "");
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

        public Transporte obtenerTransporte(int id)
        {

            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader reader = null;
            Transporte objTransp = null;
            try
            {
                con = new SqlConnection(
                    ConfigurationManager.ConnectionStrings["BD_VENTAS"].ConnectionString);
                con.Open();
                cmd = new SqlCommand("usp_Transporte_crud", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@indicador", "ConsultarXId");
                cmd.Parameters.AddWithValue("@id_transporte", id);
                cmd.Parameters.AddWithValue("@ruc", "");
                cmd.Parameters.AddWithValue("@proveedor", "");
                cmd.Parameters.AddWithValue("@direccion", "");
                cmd.Parameters.AddWithValue("@direccion2", "");
                cmd.Parameters.AddWithValue("@telefono", "");
                cmd.Parameters.AddWithValue("@correo", "");
                cmd.Parameters.AddWithValue("@contacto", "");

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    objTransp = new Transporte()
                    {
                        id_transporte = reader.GetInt32(0),
                        ruc = reader.GetString(1),
                        proveedor = reader.GetString(2),
                        direccion = reader.GetString(3),
                        direccion2 = reader.GetString(4),
                        telefono = reader.GetString(5),
                        correo = reader.GetString(6),
                        contacto = reader.GetString(7)
                    };
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("obtenerPais-Error : " + ex);
            }
            finally
            {
                reader.Close();
                con.Close();
            }
            return objTransp;
        }

        public int registrar(Transporte t)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            int procesar = -1;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_VENTAS"].ConnectionString);
                con.Open();
                cmd = new SqlCommand("usp_Transporte_crud", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@indicador", "Insertar");
                cmd.Parameters.AddWithValue("@id_transporte", t.id_transporte);
                cmd.Parameters.AddWithValue("@ruc", t.ruc);
                cmd.Parameters.AddWithValue("@proveedor", t.proveedor);
                cmd.Parameters.AddWithValue("@direccion", t.direccion);
                cmd.Parameters.AddWithValue("@direccion2", t.direccion2);
                cmd.Parameters.AddWithValue("@telefono", t.telefono);
                cmd.Parameters.AddWithValue("@correo", t.correo);
                cmd.Parameters.AddWithValue("@contacto", t.contacto);
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