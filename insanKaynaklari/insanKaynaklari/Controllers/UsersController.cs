using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using insanKaynaklari.Entities;

namespace insanKaynaklari.Controllers
{
    public class UsersController : Controller
    {
        private insanKaynaklariEntities db = new insanKaynaklariEntities();

        // GET: Users
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }


        // GET: Home/Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: Home/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User model)
        {
            if (ModelState.IsValid)
            {
                var user = db.Users.FirstOrDefault(u => u.Username == model.Username && u.Password == model.Password);

                if (user != null)
                {
                    FormsAuthentication.RedirectFromLoginPage(user.Username, false);
                    // Kullanıcı adını yazdır
                    ViewBag.UserName = user.Username;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Kullanıcı Adı ya da Şifre Hatalı");
                }
            }

            return View(model);
        }

        // GET: Home/Logout
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Home");
        }
        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }
 


        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
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
