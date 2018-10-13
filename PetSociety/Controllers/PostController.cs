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
    public class PostController : Controller
    {
        private hack_dbEntities db = new hack_dbEntities();

        // GET: Post
        public ActionResult Index()
        {
            var t_Post = db.T_Post.Include(t => t.T_Pet).Include(t => t.T_Photo).Include(t => t.T_User);
            return View(t_Post.ToList());
        }

        // GET: Post/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Post t_Post = db.T_Post.Find(id);
            if (t_Post == null)
            {
                return HttpNotFound();
            }
            return View(t_Post);
        }

        // GET: Post/Create
        public ActionResult Create()
        {
            //ViewBag.PetID = new SelectList(db.T_Pet, "PetID", "Name");
            //ViewBag.PhotoID = new SelectList(db.T_Photo, "PhotoID", "Name");
            //ViewBag.UserID = new SelectList(db.T_User, "UserID", "Username");
            T_Post newPost = new T_Post
            {
                IsDeleted = false,
                CreatedOn = DateTime.Now,
                CreatedBy = "Test1",
                ModifiedOn = DateTime.Now,
                ModifiedBy = "Test1"
            };
            return View(newPost);
        }

        // POST: Post/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PostID,Title,Desciption,TimeSlotStart,TimeSlotEnd,PhotoID,UserID,PetID,IsDeleted,CreatedOn,CreatedBy,ModifiedOn,ModifiedBy")] T_Post t_Post)
        {
            if (ModelState.IsValid)
            {
                t_Post.PostID = Guid.NewGuid();
                db.T_Post.Add(t_Post);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PetID = new SelectList(db.T_Pet, "PetID", "Name", t_Post.PetID);
            ViewBag.PhotoID = new SelectList(db.T_Photo, "PhotoID", "Name", t_Post.PhotoID);
            ViewBag.UserID = new SelectList(db.T_User, "UserID", "Username", t_Post.UserID);
            return View(t_Post);
        }

        // GET: Post/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_Post t_Post = db.T_Post.Find(id);
            if (t_Post == null)
            {
                return HttpNotFound();
            }
            else
            {
                t_Post.ModifiedOn = DateTime.Now;
                t_Post.ModifiedBy = "SomeoneElse";
            }
            return View(t_Post);
        }

        // POST: Post/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PostID,Title,Desciption,TimeSlotStart,TimeSlotEnd,PhotoID,UserID,PetID,IsDeleted,CreatedOn,CreatedBy,ModifiedOn,ModifiedBy")] T_Post t_Post)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_Post).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PetID = new SelectList(db.T_Pet, "PetID", "Name", t_Post.PetID);
            ViewBag.PhotoID = new SelectList(db.T_Photo, "PhotoID", "Name", t_Post.PhotoID);
            ViewBag.UserID = new SelectList(db.T_User, "UserID", "Username", t_Post.UserID);
            return View(t_Post);
        }

        // GET: Post/Delete/5
        public ActionResult Delete(Guid? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //T_Post t_Post = db.T_Post.Find(id);
            //if (t_Post == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(t_Post);
            T_Post t_Post = db.T_Post.Find(id);
            db.T_Post.Remove(t_Post);
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
