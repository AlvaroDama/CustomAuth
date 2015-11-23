using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CustomAuth.Utility;

namespace CustomAuth.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var clave = ConfigurationManager.AppSettings["ClaveCifrado"];

            var cifrado = SeguridadUtility.Encrypt("Hola mundo", clave);

            var data = Convert.FromBase64String(cifrado);

            var descifre = SeguridadUtility.Decrypt(data, clave);

            return View();
        }
    }
}