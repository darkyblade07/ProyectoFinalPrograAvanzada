using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using ProyectoFinalPrograAvanzada.Entities;
using ProyectoFinalPrograAvanzada.Model;

namespace ProyectoFinalPrograAvanzada.Controllers
{
    public class HomeController : Controller
    {
        UserModel model = new UserModel();

        public ActionResult Index()
        {
            return View();
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

        public ActionResult Login()
        {
            ViewBag.Message = "Your Login page.";

            return View("Login");
        }
        public ActionResult Register()
        {
            ViewBag.Message = "Your Register page.";

            return View();
        }
        public ActionResult IniciarSesion(UserEnt entidad)
        {
            model.IniciarSesion(entidad);

            return RedirectToAction("Index", "Home");
        }
        public ActionResult RegistrarUsuario(UserEnt entidad)
        {
            model.RegistrarUsuario(entidad);

            return RedirectToAction("Login", "Home");
        }
    }
}