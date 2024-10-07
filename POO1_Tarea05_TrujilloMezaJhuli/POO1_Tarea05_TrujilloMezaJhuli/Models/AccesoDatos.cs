using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Diagnostics;

namespace POO1_Tarea05_TrujilloMezaJhuli.Models
{
    public class AccesoDatos
    {
         public SqlConnection con = new SqlConnection(
            ConfigurationManager.ConnectionStrings["Negocios2022"].ConnectionString);

        //metodo para listar clientes usando el procedimiento almacenado
        public List<Clientes> ClienteListar()
        {
            List<Clientes> listacli = new List<Clientes>();
            SqlCommand cmd = new SqlCommand("usp_cliente_listar", con);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Clientes cli = new Clientes()
                    {
                        IdCliente = reader.GetString(0),
                        NombreCliente = reader.GetString(1),
                        Direccion = reader.GetString(2),
                        NombrePais = reader.GetString(3),
                        Telefono = reader.GetString(4)
                    };
                    listacli.Add(cli);
                }
                reader.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex. Message); 
            }
            return listacli;
        }

        //metodo para listar Pedidos

        public List<Pedidos> PedidoListar()
        {
            List<Pedidos> listarped = new List<Pedidos>();
            SqlCommand cmd = new SqlCommand("usp_pedido_listar", con);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Pedidos ped = new Pedidos()
                    {
                        IdPedido = reader.GetInt32(0),
                        FechaPedido = reader.GetDateTime(1),
                        NombreCliente = reader.GetString(2),
                        DirCliente = reader.GetString(3),
                        Empleado = reader.GetString(4)
                    };
                    listarped.Add(ped);
                }
                reader.Close();
                con.Close();
            }

            catch(Exception ex)
            {
                Debug.WriteLine(ex. Message);
            }
            return listarped;
        }


        //metodo para listar producto
        public List<Producto> ProductoListar(string nomproducto)
        {
            List<Producto> listaProd = new List<Producto>();
            SqlCommand cmd = new SqlCommand("usp_producto_listar_nombre", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nombre", nomproducto);

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Producto pro = new Producto()
                    {
                        IdProducto = reader.GetInt32(0),
                        NombreProducto = reader.GetString(1),
                        PrecioUnidad = reader.GetDecimal(2),
                        NombreCategoria = reader.GetString(3),
                        NomProveedor = reader.GetString(4),
                        stock = reader.GetInt16(5)
                    };
                    listaProd.Add(pro);

                }
                reader.Close();
                con.Close();

            }
            catch (Exception ex)
            {
                Debug.WriteLine (ex. Message);
            }
            return listaProd;
        }


        //listar producto por categoria
        public List<Producto> ProductoXcategoriaLista(string nomcategoria)
        {
            List<Producto> listapro = new List<Producto>();
            SqlCommand cmd = new SqlCommand("usp_producto_x_categoria", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nomcategoria", nomcategoria);

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Producto pro = new Producto()
                    {
                        IdProducto = reader.GetInt32(0),
                        NombreProducto = reader.GetString(1),
                        PrecioUnidad = reader.GetDecimal(2),
                        NombreCategoria = reader.GetString(3),
                        NomProveedor = reader.GetString(4),
                        stock = reader.GetInt16(5)
                    };
                    listapro.Add(pro);
                }
                con.Close();
                reader.Close();
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return listapro;
        }

    }
}