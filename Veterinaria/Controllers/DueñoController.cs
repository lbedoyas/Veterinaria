using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Veterinaria.Models;

namespace Veterinaria.Controllers
{
    public class DueñoController : Controller
    {
        private VeterinariaContext db = new VeterinariaContext();

        // GET: Dueño
        public ActionResult Index()
        {
            return View(db.Dueño.ToList());
        }

        // GET: Dueño/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dueño dueño = db.Dueño.Find(id);
            if (dueño == null)
            {
                return HttpNotFound();
            }
            return View(dueño);
        }

        // GET: Dueño/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dueño/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idDueño,nomDueño,apeDueño,telefono,direccion")] Dueño dueño)
        {
            if (ModelState.IsValid)
            {
                db.Dueño.Add(dueño);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dueño);
        }

        // GET: Dueño/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dueño dueño = db.Dueño.Find(id);
            if (dueño == null)
            {
                return HttpNotFound();
            }
            return View(dueño);
        }

        // POST: Dueño/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idDueño,nomDueño,apeDueño,telefono,direccion")] Dueño dueño)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dueño).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dueño);
        }

        // GET: Dueño/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dueño dueño = db.Dueño.Find(id);
            if (dueño == null)
            {
                return HttpNotFound();
            }
            return View(dueño);
        }

        // POST: Dueño/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dueño dueño = db.Dueño.Find(id);
            db.Dueño.Remove(dueño);
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
