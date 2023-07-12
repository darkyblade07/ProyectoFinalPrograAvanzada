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

            try
            {

                var resp = model.IniciarSesion(entidad);

                if (resp != null)
                {
                    Session["NombreUsuario"] = resp.Name;

                    return RedirectToAction("Index", "Home");
                }
                else
                {

                    ViewBag.MsjPantalla = "Couldn't validate your request";

                    return View("Login");
                }
            }
            catch (Exception ex)
            {
                return View("Error");
            }

        }


        [HttpPost]
        public ActionResult RegistrarUsuario(UserEnt entidad)
        {
            try
            {
                
                
                var resp = model.RegistrarUsuario(entidad);

                if (resp > 0)
                    return RedirectToAction("Login", "Home");
                else
                {
                    ViewBag.MsjPantalla = "Couldn't validate your request";
                    return View("Registro");
                }
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }
    }

    }
