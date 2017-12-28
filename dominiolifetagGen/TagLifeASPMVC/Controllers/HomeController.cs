using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TagLifeASPMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string men)
        {
            ViewBag.Message = "Home LifeTag";
            ViewBag.Men = men;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult BusquedaInvitado(String busqueda)
        {
            ViewBag.Busqueda = busqueda;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Quienes somos?";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contactanos";

            return View();
        }
    }
}
