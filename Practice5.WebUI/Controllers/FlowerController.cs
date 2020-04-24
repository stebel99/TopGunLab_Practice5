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
using Practice5.WebUI.Repositories.Interfaces;

namespace Practice5.WebUI.Controllers
{
    public class FlowerController : Controller
    {
        private IFlowerRepository flowerRepository;
        public FlowerController(IFlowerRepository flowerRepository)
        {
            this.flowerRepository = flowerRepository;
        }
        // GET: Flowers
        public ActionResult Index()
        {
            return View(flowerRepository.GetFlowers());
        }

        // GET: Flowers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flower flower = flowerRepository.GetFlower(id.Value);
            if (flower == null)
            {
                return HttpNotFound();
            }
            ViewBag.NumberPl = flowerRepository.GetNumberPlantations(id.Value);
            ViewBag.NumberWa = flowerRepository.GetNumberWarehouses(id.Value);
            ViewBag.NumberSu = flowerRepository.GetNumberSupplies(id.Value);
            return View(flower);
        }

        // GET: Flowers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Flowers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Color")] Flower flower)
        {
            if (ModelState.IsValid)
            {
                flowerRepository.CreateFlower(flower);
                return RedirectToAction("Index");
            }

            return View(flower);
        }

        // GET: Flowers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flower flower = flowerRepository.GetFlower(id.Value);
            if (flower == null)
            {
                return HttpNotFound();
            }
            return View(flower);
        }

        // POST: Flowers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Color")] Flower flower)
        {
            if (ModelState.IsValid)
            {
                flowerRepository.UpdateFlower(flower);
                return RedirectToAction("Index");
            }
            return View(flower);
        }

        // GET: Flowers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flower flower = flowerRepository.GetFlower(id.Value);
            if (flower == null)
            {
                return HttpNotFound();
            }
            return View(flower);
        }

        // POST: Flowers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            flowerRepository.DeleteFlower(id);
            return RedirectToAction("Index");
        }
    }
}
