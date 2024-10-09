using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using POO1_Tarea07_TrujilloMezaJhuli.Models;

namespace POO1_Tarea07_TrujilloMezaJhuli.Controllers
{
    public class productoController : Controller
    {
        private Negocios2022Entities db = new Negocios2022Entities();

        // GET: producto
        public ActionResult Index(int p = 0)
        {
            var tb_productos = db.tb_productos.Include(t => t.tb_categorias).Include(t => t.tb_proveedores);

            int filas = 15;
            int n = tb_productos.Count();
            int pages = n % filas > 0 ? n / filas + 1: n / filas;

            ViewBag.pages = pages;
            ViewBag.p = p;
            return View(tb_productos.ToList().Skip(p * filas).Take(filas));
        }

        // GET: producto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_productos tb_productos = db.tb_productos.Find(id);
            if (tb_productos == null)
            {
                return HttpNotFound();
            }
            return View(tb_productos);
        }

        // GET: producto/Create
        public ActionResult Create()
        {
            ViewBag.IdCategoria = new SelectList(db.tb_categorias, "IdCategoria", "NombreCategoria");
            ViewBag.IdProveedor = new SelectList(db.tb_proveedores, "IdProveedor", "NombreCia");
            return View();
        }

        // POST: producto/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdProducto,NombreProducto,IdProveedor,IdCategoria,umedida,PrecioUnidad,UnidadesEnExistencia,Activo")] tb_productos tb_productos)
        {
            if (ModelState.IsValid)
            {
                db.tb_productos.Add(tb_productos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCategoria = new SelectList(db.tb_categorias, "IdCategoria", "NombreCategoria", tb_productos.IdCategoria);
            ViewBag.IdProveedor = new SelectList(db.tb_proveedores, "IdProveedor", "NombreCia", tb_productos.IdProveedor);
            return View(tb_productos);
        }

        // GET: producto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_productos tb_productos = db.tb_productos.Find(id);
            if (tb_productos == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCategoria = new SelectList(db.tb_categorias, "IdCategoria", "NombreCategoria", tb_productos.IdCategoria);
            ViewBag.IdProveedor = new SelectList(db.tb_proveedores, "IdProveedor", "NombreCia", tb_productos.IdProveedor);
            return View(tb_productos);
        }

        // POST: producto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdProducto,NombreProducto,IdProveedor,IdCategoria,umedida,PrecioUnidad,UnidadesEnExistencia,Activo")] tb_productos tb_productos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_productos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCategoria = new SelectList(db.tb_categorias, "IdCategoria", "NombreCategoria", tb_productos.IdCategoria);
            ViewBag.IdProveedor = new SelectList(db.tb_proveedores, "IdProveedor", "NombreCia", tb_productos.IdProveedor);
            return View(tb_productos);
        }

        // GET: producto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_productos tb_productos = db.tb_productos.Find(id);
            if (tb_productos == null)
            {
                return HttpNotFound();
            }
            return View(tb_productos);
        }

        // POST: producto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_productos tb_productos = db.tb_productos.Find(id);
            db.tb_productos.Remove(tb_productos);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
