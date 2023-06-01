using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace proyecto1.Controllers
{
    public class ActividadesController : Controller
    {
        // GET: Actividades
        public ActionResult Index()
        {
            return View();
        }

        // GET: Actividades/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Actividades/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Actividades/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Actividades/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Actividades/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Actividades/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Actividades/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
