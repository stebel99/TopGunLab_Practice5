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
    public class TestController : Controller
    {
        private FlowerDbContext db = new FlowerDbContext();

        // GET: Test
        public ActionResult Index()
        {
            var plantationFlowers = db.PlantationFlowers.Include(p => p.Flower).Include(p => p.Plantation);
            return View(plantationFlowers.ToList());
        }

        // GET: Test/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlantationFlower plantationFlower = db.PlantationFlowers.Find(id);
            if (plantationFlower == null)
            {
                return HttpNotFound();
            }
            return View(plantationFlower);
        }

        // GET: Test/Create
        public ActionResult Create()
        {
            ViewBag.FlowerId = new SelectList(db.Flowers, "Id", "Name");
            ViewBag.PlantationId = new SelectList(db.Plantations, "Id", "Name");
            return View();
        }

        // POST: Test/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PlantationId,Amount,FlowerId")] PlantationFlower plantationFlower)
        {
            if (ModelState.IsValid)
            {
                db.PlantationFlowers.Add(plantationFlower);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FlowerId = new SelectList(db.Flowers, "Id", "Name", plantationFlower.FlowerId);
            ViewBag.PlantationId = new SelectList(db.Plantations, "Id", "Name", plantationFlower.PlantationId);
            return View(plantationFlower);
        }

        // GET: Test/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlantationFlower plantationFlower = db.PlantationFlowers.Find(id);
            if (plantationFlower == null)
            {
                return HttpNotFound();
            }
            ViewBag.FlowerId = new SelectList(db.Flowers, "Id", "Name", plantationFlower.FlowerId);
            ViewBag.PlantationId = new SelectList(db.Plantations, "Id", "Name", plantationFlower.PlantationId);
            return View(plantationFlower);
        }

        // POST: Test/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PlantationId,Amount,FlowerId")] PlantationFlower plantationFlower)
        {
            if (ModelState.IsValid)
            {
                db.Entry(plantationFlower).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FlowerId = new SelectList(db.Flowers, "Id", "Name", plantationFlower.FlowerId);
            ViewBag.PlantationId = new SelectList(db.Plantations, "Id", "Name", plantationFlower.PlantationId);
            return View(plantationFlower);
        }

        // GET: Test/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlantationFlower plantationFlower = db.PlantationFlowers.Find(id);
            if (plantationFlower == null)
            {
                return HttpNotFound();
            }
            return View(plantationFlower);
        }

        // POST: Test/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PlantationFlower plantationFlower = db.PlantationFlowers.Find(id);
            db.PlantationFlowers.Remove(plantationFlower);
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
