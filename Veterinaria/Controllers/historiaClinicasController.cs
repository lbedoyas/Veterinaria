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
    public class historiaClinicasController : Controller
    {
        private VeterinariaContext db = new VeterinariaContext();

        // GET: historiaClinicas
        [Authorize]
        public ActionResult Index()
        {
            var historiaClinicas = db.historiaClinicas.Include(h => h.Mascotas);
            return View(historiaClinicas.ToList());
        }

        // GET: historiaClinicas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            historiaClinica historiaClinica = db.historiaClinicas.Find(id);
            if (historiaClinica == null)
            {
                return HttpNotFound();
            }
            return View(historiaClinica);
        }

        // GET: historiaClinicas/Create
        public ActionResult Create()
        {
            ViewBag.idMascota = new SelectList(db.Mascotas, "idMascota", "nomMascota");
            return View();
        }

        // POST: historiaClinicas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idHistoriaClinica,tipoConsulta,vacuna,fecha,descConsulta,idMascota")] historiaClinica historiaClinica)
        {
            if (ModelState.IsValid)
            {
                db.historiaClinicas.Add(historiaClinica);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idMascota = new SelectList(db.Mascotas, "idMascota", "nomMascota", historiaClinica.idMascota);
            return View(historiaClinica);
        }

        // GET: historiaClinicas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            historiaClinica historiaClinica = db.historiaClinicas.Find(id);
            if (historiaClinica == null)
            {
                return HttpNotFound();
            }
            ViewBag.idMascota = new SelectList(db.Mascotas, "idMascota", "nomMascota", historiaClinica.idMascota);
            return View(historiaClinica);
        }

        // POST: historiaClinicas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idHistoriaClinica,tipoConsulta,vacuna,fecha,descConsulta,idMascota")] historiaClinica historiaClinica)
        {
            if (ModelState.IsValid)
            {
                db.Entry(historiaClinica).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idMascota = new SelectList(db.Mascotas, "idMascota", "nomMascota", historiaClinica.idMascota);
            return View(historiaClinica);
        }

        // GET: historiaClinicas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            historiaClinica historiaClinica = db.historiaClinicas.Find(id);
            if (historiaClinica == null)
            {
                return HttpNotFound();
            }
            return View(historiaClinica);
        }

        // POST: historiaClinicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            historiaClinica historiaClinica = db.historiaClinicas.Find(id);
            db.historiaClinicas.Remove(historiaClinica);
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
