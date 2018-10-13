using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PetSociety.Models;

namespace PetSociety.Controllers
{
    public class PetController : Controller
    {
        private hack_dbEntities db = new hack_dbEntities();

        // GET: Pet
        public ActionResult Index()
        {
            return View(db.T_Pet.ToList());
        }

        // GET: Pet/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Pet t_Pet = db.T_Pet.Find(id);
            if (t_Pet == null)
            {
                return HttpNotFound();
            }
            return View(t_Pet);
        }

        // GET: Pet/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pet/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PetID,Name,Type,TypeOthers,DOB,BloodType,Breed,Gender,Characteristic,CreatedOn,CreatedBy,ModifiedOn,ModifiedBy")] T_Pet t_Pet)
        {
            if (ModelState.IsValid)
            {
                t_Pet.ModifiedBy = "User1";
                t_Pet.ModifiedOn = DateTime.Now;
                t_Pet.CreatedBy = "User1";
                t_Pet.CreatedOn = DateTime.Now;
                t_Pet.PetID = Guid.NewGuid();
                db.T_Pet.Add(t_Pet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(t_Pet);
        }

        // GET: Pet/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Pet t_Pet = db.T_Pet.Find(id);
            ViewBag.Gender = new SelectList(db.T_LK_Gender, "ID", "Gender");
            ViewBag.PetType = new SelectList(db.T_LK_PetType, "ID", "PetType");
            if (t_Pet == null)
            {
                return HttpNotFound();
            }
            return View(t_Pet);
        }

        // POST: Pet/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PetID,Name,Type,TypeOthers,DOB,BloodType,Breed,Gender,Characteristic,CreatedOn,CreatedBy,ModifiedOn,ModifiedBy")] T_Pet t_Pet)
        {
            if (ModelState.IsValid)
            {
                t_Pet.ModifiedBy = "User1";
                t_Pet.ModifiedOn = DateTime.Now;
                db.Entry(t_Pet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(t_Pet);
        }

        // GET: Pet/Delete/5
        public ActionResult Delete(Guid? id)
        {
            T_Pet t_Pet = db.T_Pet.Find(id);
            db.T_Pet.Remove(t_Pet);
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
