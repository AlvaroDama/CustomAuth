using System;
using System.Collections.Generic;
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
            var cifrado = SeguridadUtility.Encrypt("Hola mundo", "CuantasCosasVamosAponerParaquelocojaCoMoClave");

            var data = Convert.FromBase64String(cifrado);

            var descifre = SeguridadUtility.Decrypt(data, "CuantasCosasVamosAponerParaquelocojaCoMoClave");
            return View();
        }
    }
}