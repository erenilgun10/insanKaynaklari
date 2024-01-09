using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using insanKaynaklari.Entities;

namespace insanKaynaklari.Controllers
{
    public class WorkersController : Controller
    {
        private insanKaynaklariEntities db = new insanKaynaklariEntities();

        // GET: Workers
        public ActionResult Index()
        {
            var workers = db.Workers.Include(w => w.Business).Include(w => w.Department).Include(w => w.Person).Include(w => w.UserRole);
            return View(workers.ToList());
        }

        // GET: Workers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Worker worker = db.Workers.Find(id);
            if (worker == null)
            {
                return HttpNotFound();
            }
            return View(worker);
        }

        // GET: Workers/Create
        public ActionResult Create()
        {
            ViewBag.BusinessId = new SelectList(db.Businesses, "Id", "Name");
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name");
            ViewBag.PersonId = new SelectList(db.People, "ID", "NAME");
            ViewBag.RoleId = new SelectList(db.UserRoles, "RoleId", "RoleName");
            return View();
        }

        // POST: Workers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Salary,PersonId,BusinessId,DepartmentId,RoleId")] Worker worker)
        {
            if (ModelState.IsValid)
            {
                db.Workers.Add(worker);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BusinessId = new SelectList(db.Businesses, "Id", "Name", worker.BusinessId);
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name", worker.DepartmentId);
            ViewBag.PersonId = new SelectList(db.People, "ID", "NAME", worker.PersonId);
            ViewBag.RoleId = new SelectList(db.UserRoles, "RoleId", "RoleName", worker.RoleId);
            return View(worker);
        }

        // GET: Workers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Worker worker = db.Workers.Find(id);
            if (worker == null)
            {
                return HttpNotFound();
            }
            ViewBag.BusinessId = new SelectList(db.Businesses, "Id", "Name", worker.BusinessId);
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name", worker.DepartmentId);
            ViewBag.PersonId = new SelectList(db.People, "ID", "NAME", worker.PersonId);
            ViewBag.RoleId = new SelectList(db.UserRoles, "RoleId", "RoleName", worker.RoleId);
            return View(worker);
        }

        // POST: Workers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Salary,PersonId,BusinessId,DepartmentId,RoleId")] Worker worker)
        {
            if (ModelState.IsValid)
            {
                db.Entry(worker).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BusinessId = new SelectList(db.Businesses, "Id", "Name", worker.BusinessId);
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name", worker.DepartmentId);
            ViewBag.PersonId = new SelectList(db.People, "ID", "NAME", worker.PersonId);
            ViewBag.RoleId = new SelectList(db.UserRoles, "RoleId", "RoleName", worker.RoleId);
            return View(worker);
        }

        // GET: Workers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Worker worker = db.Workers.Find(id);
            if (worker == null)
            {
                return HttpNotFound();
            }
            return View(worker);
        }

        // POST: Workers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Worker worker = db.Workers.Find(id);
            db.Workers.Remove(worker);
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
