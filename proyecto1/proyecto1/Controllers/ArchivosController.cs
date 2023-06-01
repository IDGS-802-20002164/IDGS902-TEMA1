using proyecto1.Models;
using proyecto1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace proyecto1.Controllers
{
    public class ArchivosController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Maestros maes)
        {
            var ope1 = new GuardaService();
            ope1.GuardarArchivo(maes);

            return View();
        }

        public ActionResult LeerDatos()
        {
            var arch = new LeerService();
            ViewBag.Archivos = arch.LeerArchivo();
            return View();
        }

    }
}
