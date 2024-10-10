using POO1_Tarea08_TrujilloMezaJhuli.Entity;
using POO1_Tarea08_TrujilloMezaJhuli.Services;
using POO1_Tarea08_TrujilloMezaJhuli.DataBase;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;

namespace POO1_Tarea08_TrujilloMezaJhuli.Models
{
    public class ProductoDAO : ICrudDaoProducto<Producto>
    {
        public void ActualizarProducto(Producto p)
        {
            SqlConnection cn = AccesoBD.GetConnection();
            SqlCommand cmd = new SqlCommand("usp_Producto_Actualizar", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IdProducto", p.IdProducto);
            cmd.Parameters.AddWithValue("@NombreProducto", p.NombreProduct);
            cmd.Parameters.AddWithValue("@IdProveedor", p.IdProveedor);
            cmd.Parameters.AddWithValue("@IdCategoria", p.IdCategoria);
            cmd.Parameters.AddWithValue("@umedida", p.umedida);
            cmd.Parameters.AddWithValue("@PrecioUnidad", p.PrecioUnidad);
            cmd.Parameters.AddWithValue("@Stock", p.Stock);

            try
            {
                cn.Open();
                bool iresult = cmd.ExecuteNonQuery() == 1 ? true : false;
            }
            catch(SqlException ex)
            {
                Debug.WriteLine("error" + ex.Message);
                throw ex;
            }
            finally
            {
                cn.Close();
            }
        }

        public Producto BuscarProducto(int id)
        {
            Producto pro = null;
            SqlConnection cn = AccesoBD.GetConnection();
            SqlCommand cmd = new SqlCommand("usp_Producto_Datos", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IdProducto", id);

            try
            {
                cn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    pro = new Producto()
                    {
                        IdProducto = reader.GetInt32(0),
                        NombreProduct = reader.GetString(1),
                        IdProveedor = reader.GetInt32(2),
                        IdCategoria = reader.GetInt32(3),
                        umedida = reader.GetString(4),
                        PrecioUnidad = reader.GetDecimal(5),
                        Stock = reader.GetInt16(6)
                    };

                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw ex;
            }
            finally
            {
                cn.Close();
            }
            return pro;
        }

        public void EliminarProducto(Producto p)
        {
            SqlConnection cn = AccesoBD.GetConnection();
            SqlCommand cmd = new SqlCommand("usp_Producto_Eliminar", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IdProducto", p.IdProducto);

            try
            {
                cn.Open();
                bool iresult = cmd.ExecuteNonQuery() == 1 ? true : false;
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
        }

        public void InsetarProducto(Producto p)
        {
            SqlConnection cn = AccesoBD.GetConnection();
            SqlCommand cmd = new SqlCommand("usp_Producto_Insertar", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NombreProducto", p.NombreProduct);
            cmd.Parameters.AddWithValue("@IdProveedor", p.IdProveedor);
            cmd.Parameters.AddWithValue("@IdCategoria", p.IdCategoria);
            cmd.Parameters.AddWithValue("@umedida", p.umedida);
            cmd.Parameters.AddWithValue("@PrecioUnidad", p.PrecioUnidad);
            cmd.Parameters.AddWithValue("@Stock", p.Stock);

            try
            {
                cn.Open();
                bool iresult = cmd.ExecuteNonQuery() == 1 ? true : false;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine("error : " + ex.Message);
                throw ex;
            }
            finally
            {
                cn.Close();
            }

        }

        public List<Producto> ListarProducto()
        {
            List<Producto> lista = new List<Producto>();
            SqlConnection cn = AccesoBD.GetConnection();
            SqlCommand cmd = new SqlCommand("usp_Producto_Listar", cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            try
            {
                cn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Producto pro = new Producto()
                    {
                        IdProducto = reader.GetInt32(0),
                        NombreProduct = reader.GetString(1),
                        IdProveedor = reader.GetInt32(2),
                        IdCategoria = reader.GetInt32(3),
                        umedida = reader.GetString(4),
                        PrecioUnidad = reader.GetDecimal(5),
                        Stock = reader.GetInt16(6)
                    };
                    lista.Add(pro);
                }
                reader.Close();
            }
            catch (SqlException ex)
            {
                Debug.WriteLine("error: " + ex.Message);
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