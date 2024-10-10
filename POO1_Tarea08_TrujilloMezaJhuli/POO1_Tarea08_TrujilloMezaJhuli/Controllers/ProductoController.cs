using System;
using System.Configuration;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using POO1_Tarea08_TrujilloMezaJhuli.Entity;
using POO1_Tarea08_TrujilloMezaJhuli.Models;

namespace POO1_Tarea08_TrujilloMezaJhuli.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto

        CategoriaDAO daocategoria = new CategoriaDAO();
        ProveedorDAO daoproveedor = new ProveedorDAO();
        ProductoDAO daoproducto = new ProductoDAO();
        public ActionResult Index()
        {
            var productos = daoproducto.ListarProducto();
            return View(productos);
        }

        public ActionResult Details(int id)
        {
            return View(daoproducto.BuscarProducto(id));
        }

        public ActionResult Create()
        {
            ViewBag.Categorias = new SelectList(daocategoria.ListarCategoria(), "IdCategoria", "NombreCategoria");
            ViewBag.Proveedores = new SelectList(daoproveedor.ListarProveedor(), "IdProveedor", "NomProveedor");

            return View();
        }

        [HttpPost]
        public ActionResult Create(Producto pro)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ViewBag.Categorias = new SelectList(daocategoria.ListarCategoria(), "IdCategoria", "NombreCategoria");
                    ViewBag.Proveedores = new SelectList(daoproveedor.ListarProveedor(), "IdProveedor", "NomProveedor");

                    pro.IdProducto = pro.IdProducto;

                    daoproducto.InsetarProducto(pro);
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            catch
            {
                Debug.WriteLine("error");
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            Producto pro = daoproducto.BuscarProducto(id);
            ViewBag.Categorias = new SelectList(daocategoria.ListarCategoria(), "IdCategoria", "NombreCategoria", pro.IdCategoria);
            ViewBag.Proveedores = new SelectList(daoproveedor.ListarProveedor(), "IdProveedor", "NomProveedor", pro.IdProveedor);

            return View(daoproducto.BuscarProducto(id));
        }

        [HttpPost]
        public ActionResult Edit(Producto pro)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ViewBag.Categorias = new SelectList(daocategoria.ListarCategoria(), "IdCategoria", "NombreCategoria", pro.IdCategoria);
                    ViewBag.Proveedores = new SelectList(daoproveedor.ListarProveedor(), "IdProveedor", "NomProveedor", pro.IdProveedor);

                    daoproducto.ActualizarProducto(pro);
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            Producto producto = daoproducto.BuscarProducto(id);
            if(producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Producto producto = daoproducto.BuscarProducto(id);
            daoproducto.EliminarProducto(producto);
            return RedirectToAction("Index");
        }

    }
}