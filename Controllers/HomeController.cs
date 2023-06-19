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

        [HttpGet]
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

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Register()
        {
            ViewBag.Message = "Your Register page.";

            return View();
        }
        
        [HttpPost]
        public ActionResult IniciarSesion(UserEnt entidad)
        {
           
            var resp = model.IniciarSesion(entidad);

            if (resp != null)
                return RedirectToAction("Index", "Home");
            else
                return View("Login");
        }

        [HttpPost]
        public ActionResult RegistrarUsuario(UserEnt entidad)
        {

          var resp =  model.RegistrarUsuario(entidad);

            if (resp > 0)
                return RedirectToAction("Login", "Home");
            else
                return View("Registro");
        }
    }
}