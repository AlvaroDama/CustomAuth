using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using CustomAuth.Models;
using CustomAuth.Utility;

namespace CustomAuth.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Usuario model)
        {
            if (Membership.ValidateUser(model.Login, model.Password)) //el Membership es el CustomMembership porque los hemos relaccionado en el WebConfig
            {
                FormsAuthentication.RedirectFromLoginPage(model.Login, false); //El 2º parámetro son las cookies. Son persistentes (guardaría las credenciales de sesión)
                return null;
            }

            return View(model);
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}