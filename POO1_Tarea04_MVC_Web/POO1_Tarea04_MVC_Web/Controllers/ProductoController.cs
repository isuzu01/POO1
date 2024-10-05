using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using POO1_Tarea04_MVC_Web.Models;
using System.Data;

namespace POO1_Tarea04_MVC_Web.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto
        AccesoData obj = new AccesoData();
        public ActionResult Index()
        {
            DataSet tabla = obj.ProductoListar();
            List<Producto> proList = new List<Producto>();
            foreach (DataRow dr in tabla.Tables[0].Rows)
            {
                proList.Add(new Producto
                {
                    IdProducto = Convert.ToInt32(dr["IdProducto"]),
                    NomProducto = Convert.ToString(dr["NombreProducto"]),
                    PrecioUnidad = Convert.ToDouble(dr["PrecioUnidad"]),
                    NomCategoria = Convert.ToString(dr["NombreCategoria"]),
                    NomProveedor = Convert.ToString(dr["NombreCia"]),
                    Stock = Convert.ToInt32(dr["stock"]),
                });
            }
            return View(proList);
        }
    }
}