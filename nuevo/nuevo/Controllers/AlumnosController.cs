using nuevo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace nuevo.Controllers
{
    public class AlumnosController : Controller
    {
        public ActionResult Index()
        {
            using (AlumnosDbContext dbAlumno = new AlumnosDbContext())
            {
                // select * from alumnos
                return View(dbAlumno.Alumnos.ToList());
            }

        }



        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Alumnos alum)
        {
            using (AlumnosDbContext dbAlumno = new AlumnosDbContext())
            {
                dbAlumno.Alumnos.Add(alum);
                dbAlumno.SaveChanges();

            }
            return RedirectToAction("Index");
        }
    }
}