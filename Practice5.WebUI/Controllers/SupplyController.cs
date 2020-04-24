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
    public class SupplyController : Controller
    {
        private FlowerDbContext db = new FlowerDbContext();

        // GET: Supply
        public ActionResult Index()
        {
            var supplies = db.Supplies.Include(s => s.Plantation).Include(s => s.Warehouse);
            return View(supplies.ToList());
        }

        // GET: Supply/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supply supply = db.Supplies.Find(id);
            if (supply == null)
            {
                return HttpNotFound();
            }
            return View(supply);
        }

        // GET: Supply/Create
        public ActionResult Create()
        {
            ViewBag.PlantationId = new SelectList(db.Plantations.Include(x=>x.PlantationFlowers), "Id", "Name");
            ViewBag.WarehouseId = new SelectList(db.Warehouses, "Id", "Name");
            return View();
        }

        // POST: Supply/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PlantationId,WarehouseId,ScheduledDate,ClosedDate,Status")] Supply supply)
        {
            if (ModelState.IsValid)
            {
                db.Supplies.Add(supply);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PlantationId = new SelectList(db.Plantations, "Id", "Name", supply.PlantationId);
            ViewBag.WarehouseId = new SelectList(db.Warehouses, "Id", "Name", supply.WarehouseId);
            return View(supply);
        }

        // GET: Supply/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supply supply = db.Supplies.Find(id);
            if (supply == null)
            {
                return HttpNotFound();
            }
            ViewBag.PlantationId = new SelectList(db.Plantations, "Id", "Name", supply.PlantationId);
            ViewBag.WarehouseId = new SelectList(db.Warehouses, "Id", "Name", supply.WarehouseId);
            return View(supply);
        }

        // POST: Supply/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PlantationId,WarehouseId,ScheduledDate,ClosedDate,Status")] Supply supply)
        {
            if (ModelState.IsValid)
            {
                db.Entry(supply).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PlantationId = new SelectList(db.Plantations, "Id", "Name", supply.PlantationId);
            ViewBag.WarehouseId = new SelectList(db.Warehouses, "Id", "Name", supply.WarehouseId);
            return View(supply);
        }

        // GET: Supply/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supply supply = db.Supplies.Find(id);
            if (supply == null)
            {
                return HttpNotFound();
            }
            return View(supply);
        }

        // POST: Supply/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Supply supply = db.Supplies.Find(id);
            db.Supplies.Remove(supply);
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
