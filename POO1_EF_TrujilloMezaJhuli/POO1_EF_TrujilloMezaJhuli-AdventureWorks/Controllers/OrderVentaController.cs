using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POO1_EF_TrujilloMezaJhuli_AdventureWorks.Models;

namespace POO1_EF_TrujilloMezaJhuli_AdventureWorks.Controllers
{
    public class EmpleadoController : Controller
    {
        // GET: Empleado
        
        public ActionResult Inicio(string txtCliente = "", int cboProducto = 0, int cboVendedor = 0)
        {
            ViewBag.ComboProductos = new SelectList(filtrado("Producto"), "combo_id", "combo_des");
            ViewBag.ComboVendedores = new SelectList(filtrado("Vendedor"), "combo_id", "combo_des");

            List<OrdenVenta> ordenes = GetOrdenesVenta(txtCliente, cboProducto, cboVendedor);
            return View(ordenes);
        }


        public List<ComboGeneral> filtrado(string indicador)
        {
            List<ComboGeneral> listado = lista().Where(x => x.indicador.Equals(indicador)).ToList();
            return listado;
        }

        public List<ComboGeneral> lista()
        {
            List<ComboGeneral> lista = new List<ComboGeneral>();
            string cadenaConexion = ConfigurationManager.ConnectionStrings["AdventureWorks"].ConnectionString;

            using (SqlConnection con = new SqlConnection(cadenaConexion))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_formulario_combo", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ComboGeneral combo = new ComboGeneral
                        {
                            indicador = reader["indicador"].ToString(),
                            combo_id = Convert.ToInt32(reader["combo_id"]),
                            combo_des = reader["combo_des"].ToString()
                        };
                        lista.Add(combo);
                    }
                }
            }

            return lista;
        }


        public List<OrdenVenta> GetOrdenesVenta(string clienteNombre, int productoID, int vendedorID)
        {
            List<OrdenVenta> lista = new List<OrdenVenta>();
            string cadenaConexion = ConfigurationManager.ConnectionStrings["AdventureWorks"].ConnectionString;

            using (SqlConnection con = new SqlConnection(cadenaConexion))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("usp_consultar_OrdenVenta", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@clienteNombre", clienteNombre);
                cmd.Parameters.AddWithValue("@productoID", productoID);
                cmd.Parameters.AddWithValue("@vendedorID", vendedorID);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        OrdenVenta orden = new OrdenVenta
                        {
                            SalesOrderID = Convert.ToInt32(reader["SalesOrderID"]),
                            Cliente = reader["Cliente"].ToString(),
                            Vendedor = reader["Vendedor"].ToString(),
                            VendedorID = Convert.ToInt32(reader["VendedorID"]),
                            Producto = reader["Producto"].ToString(),
                            OrderDate = Convert.ToDateTime(reader["OrderDate"]),
                            TotalDue = Convert.ToDecimal(reader["TotalDue"])
                        };
                        lista.Add(orden);
                    }
                }
            }

            return lista;
        }
    }
}
        
    
