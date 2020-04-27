using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Practice5.Domain;
using Practice5.Domain.Entities;
using Practice5.WebUI.Repositories.Interfaces;

namespace Practice5.WebUI.Controllers
{
    public class PlantationController : Controller
    {
        private IPlantationRepository plantationRepository;
        private IFlowerRepository flowerRepository;

        public PlantationController(IPlantationRepository plantationRepository, IFlowerRepository flowerRepository)
        {
            this.plantationRepository = plantationRepository;
            this.flowerRepository = flowerRepository;
        }

        // GET: Plantation
        public ActionResult Index()
        {
            return View(plantationRepository.GetPlantations());
        }

        // GET: Plantation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plantation plantation = plantationRepository.GetPlantation(id.Value);
            if (plantation == null)
            {
                return HttpNotFound();
            }
            ViewBag.FlowersInfo = plantationRepository.GetFlowersInPlantation(id.Value);
            
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
                plantationRepository.CreatePlantation(plantation);
                return RedirectToAction("Index");
            }

            return View(plantation);
        }

        public ActionResult AddFlowers() 
        {
            ViewBag.FlowerId = new SelectList(flowerRepository.GetFlowers(), "Id", "Name");
            ViewBag.PlantationId = new SelectList(plantationRepository.GetPlantations(), "Id", "Name");
            return View(new PlantationFlower());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddFlowers([Bind(Include = "Id,PlantationId,FlowerId,Amount")] PlantationFlower plantationflower)
        {
            if (ModelState.IsValid)
            {
                plantationRepository.CreatePlFl(plantationflower);
                return RedirectToAction("Index");
            }

            return View(plantationflower);
        }
        // GET: Plantation/Edit/5
        public ActionResult EditPlantationFlowers(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlantationFlower plantationFlower = plantationRepository.GetPlFl(id.Value);
            if (plantationFlower == null)
            {
                return HttpNotFound();
            }
            ViewBag.FlowerId = new SelectList(flowerRepository.GetFlowers(), "Id", "Name", plantationFlower.FlowerId);
            ViewBag.PlantationId = new SelectList(plantationRepository.GetPlantations(), "Id", "Name", plantationFlower.PlantationId);
            return View(plantationFlower);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPlantationFlowers([Bind(Include = "Id,PlantationId,Amount,FlowerId")] PlantationFlower plantationFlower)
        {
            if (ModelState.IsValid)
            {
                plantationRepository.UpdatePlFl(plantationFlower);
                return RedirectToAction("Index");
            }
            ViewBag.FlowerId = new SelectList(flowerRepository.GetFlowers(), "Id", "Name", plantationFlower.FlowerId);
            ViewBag.PlantationId = new SelectList(plantationRepository.GetPlantations(), "Id", "Name", plantationFlower.PlantationId);
            return View(plantationFlower);
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plantation plantation = plantationRepository.GetPlantation(id.Value);
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
                plantationRepository.UpdatePlantation(plantation);
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
            Plantation plantation = plantationRepository.GetPlantation(id.Value);
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
            plantationRepository.DeletePlantation(id);
            return RedirectToAction("Index");
        }

        public ActionResult DeletePlFl(int id)
        {
            PlantationFlower plantationFlower = plantationRepository.GetPlFl(id);
            if (plantationFlower == null)
            {
                return HttpNotFound();
            }
            plantationRepository.DeletePlFl(id);
            return RedirectToAction("Index");
        }
    }
}
