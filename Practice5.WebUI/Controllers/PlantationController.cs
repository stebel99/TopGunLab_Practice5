using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Practice5.Domain;
using Practice5.Domain.Entities;

namespace Practice5.WebUI.Controllers
{
    public class PlantationController : Controller
    {
        private FlowerDbContext db = new FlowerDbContext();

        // GET: Plantation
        public ActionResult Index()
        {
            return View(db.Plantations.ToList());
        }

        // GET: Plantation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plantation plantation = db.Plantations.Find(id);
            if (plantation == null)
            {
                return HttpNotFound();
            }
            return View(plantation);
        }

        // GET: Plantation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Plantation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Adress")] Plantation plantation)
        {
            if (ModelState.IsValid)
            {
                db.Plantations.Add(plantation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(plantation);
        }

        // GET: Plantation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plantation plantation = db.Plantations.Find(id);
            if (plantation == null)
            {
                return HttpNotFound();
            }
            return View(plantation);
        }

        // POST: Plantation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Adress")] Plantation plantation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(plantation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(plantation);
        }

        // GET: Plantation/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plantation plantation = db.Plantations.Find(id);
            if (plantation == null)
            {
                return HttpNotFound();
            }
            return View(plantation);
        }

        // POST: Plantation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Plantation plantation = db.Plantations.Find(id);
            db.Plantations.Remove(plantation);
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
