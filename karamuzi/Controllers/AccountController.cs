using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace karamuzi.Controllers
{
    public class AccountController : Controller
    {
        Models.KaramuziModelContainer db = new Models.KaramuziModelContainer();

        //
        // GET: /Account/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            var user = new Models.NewUserModel() { Username = "sege", Password = "shaghale", ConfirmPassword = "shagale" };
            return View(user);
        }

        [HttpPost]
        public ActionResult Create(Models.NewUserModel model)
        {
            var user = db.Users.Create();
            user.Username = model.Username;

            var userPassword = db.UserPasswords.Create();
            userPassword.Password = Crypt.Hash(model.Password);

            user.UserPassword = userPassword;
            userPassword.User = user;

            db.Users.Add(user);
            db.UserPasswords.Add(userPassword);

            db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
