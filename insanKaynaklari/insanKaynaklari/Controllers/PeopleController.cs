﻿using System;
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
    public class PeopleController : Controller
    {
        private insanKaynaklariEntities db = new insanKaynaklariEntities();

        // GET: People
        public ActionResult Index()
        {
            var people = db.People.Include(p => p.Education).Include(p => p.GeneralSituation);
            return View(people.ToList());
        }

        // GET: People/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.People.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // GET: People/Create
        public ActionResult Create()
        {
            ViewBag.EducationId = new SelectList(db.Educations, "Id", "Status");
            ViewBag.GeneralSituationId = new SelectList(db.GeneralSituations, "Id", "Married");
            return View();
        }

        // POST: People/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NAME,SURNAME,BIRTHDAY,ADDRESS,GeneralSituationId,EducationId")] Person person)
        {
            if (ModelState.IsValid)
            {
                db.People.Add(person);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EducationId = new SelectList(db.Educations, "Id", "Status", person.EducationId);
            ViewBag.GeneralSituationId = new SelectList(db.GeneralSituations, "Id", "Married", person.GeneralSituationId);
            return View(person);
        }

        // GET: People/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.People.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            ViewBag.EducationId = new SelectList(db.Educations, "Id", "Status", person.EducationId);
            ViewBag.GeneralSituationId = new SelectList(db.GeneralSituations, "Id", "Married", person.GeneralSituationId);
            return View(person);
        }

        // POST: People/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NAME,SURNAME,BIRTHDAY,ADDRESS,GeneralSituationId,EducationId")] Person person)
        {
            if (ModelState.IsValid)
            {
                db.Entry(person).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EducationId = new SelectList(db.Educations, "Id", "Status", person.EducationId);
            ViewBag.GeneralSituationId = new SelectList(db.GeneralSituations, "Id", "Married", person.GeneralSituationId);
            return View(person);
        }

        // GET: People/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = db.People.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: People/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Person person = db.People.Find(id);
            db.People.Remove(person);
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
