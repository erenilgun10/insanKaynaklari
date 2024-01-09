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
    public class GeneralSituationsController : Controller
    {
        private insanKaynaklariEntities db = new insanKaynaklariEntities();

        // GET: GeneralSituations
        public ActionResult Index()
        {
            return View(db.GeneralSituations.ToList());
        }

        // GET: GeneralSituations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GeneralSituation generalSituation = db.GeneralSituations.Find(id);
            if (generalSituation == null)
            {
                return HttpNotFound();
            }
            return View(generalSituation);
        }

        // GET: GeneralSituations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GeneralSituations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Married,ChildrenNum,NearPhone")] GeneralSituation generalSituation)
        {
            if (ModelState.IsValid)
            {
                db.GeneralSituations.Add(generalSituation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(generalSituation);
        }

        // GET: GeneralSituations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GeneralSituation generalSituation = db.GeneralSituations.Find(id);
            if (generalSituation == null)
            {
                return HttpNotFound();
            }
            return View(generalSituation);
        }

        // POST: GeneralSituations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Married,ChildrenNum,NearPhone")] GeneralSituation generalSituation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(generalSituation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(generalSituation);
        }

        // GET: GeneralSituations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GeneralSituation generalSituation = db.GeneralSituations.Find(id);
            if (generalSituation == null)
            {
                return HttpNotFound();
            }
            return View(generalSituation);
        }

        // POST: GeneralSituations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GeneralSituation generalSituation = db.GeneralSituations.Find(id);
            db.GeneralSituations.Remove(generalSituation);
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
