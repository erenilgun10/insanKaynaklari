using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using System.Data.Entity;
using insanKaynaklari.Entities;


namespace insanKaynaklari.Controllers
{
    public class HomeController : Controller    
    {
        private insanKaynaklariEntities db = new insanKaynaklariEntities();

        public ActionResult Index()
        {

            var workers = db.Workers.Include(w => w.Business)
                        .Include(w => w.Department)
                        .Include(w => w.Person)
                        .Include(w => w.UserRole)
                        .ToList();



            return View(workers);

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
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

    }
}
