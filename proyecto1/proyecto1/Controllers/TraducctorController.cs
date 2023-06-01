using proyecto1.Models;
using proyecto1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace proyecto1.Controllers
{
    public class TraducctorController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Traducctor palabra)
        {
            var ope1 = new Diccionario();
            ope1.GuardarArchivo(palabra);

            return View();
        }

        public ActionResult LeerDatos()
        {
            var arch = new LeerTraducctor();
            ViewBag.Archivos = arch.LeerArchivo();

            return View();
        }

        [HttpPost]

        public ActionResult LeerDatos(String Palabra, String opcion)
        {
            var arch = new LeerTraducctor();
            ViewBag.Archivos = arch.LeerArchivo();
            HashSet<string> ArchivosEnIngles = new HashSet<string>();
            HashSet<string> ArchivosEnEspanol = new HashSet<string>();

            foreach (string item in arch.LeerArchivo())
            {
                string[] palabras = item.Split(':');
                if (palabras.Length > 1)
                {
                    string palabraEspanol = palabras[1].Trim(); // Obtener la palabra en español
                    ArchivosEnEspanol.Add(palabraEspanol);
                    string palabraIngles = palabras[0].Trim(); // Obtener la palabra en inglés
                    ArchivosEnIngles.Add(palabraIngles);
                }
            }
            // Si quiere traducir a español
            if (opcion == "opcion2")
            {
                List<string> archivosFiltrados = new List<string>();
                string traduccion = null;
                bool siguiente = false;
            
                foreach (string item in arch.LeerArchivo())
                {
                    foreach (string item2 in item.Split(':'))
                    {
                        if (siguiente)
                        {
                            traduccion = item2;
                            siguiente = false;
                        }
                        if (Palabra.ToUpper() == item2)
                        {
                            siguiente = true;
                        }
                    }
                }
                if (traduccion == null)
                {
                    // Validar si la opción seleccionada es "Inglés" pero la palabra ingresada es en inglés
                    if (opcion == "opcion1" && ArchivosEnIngles.Contains(Palabra.ToUpper()))
                    {
                        ViewBag.ArchivosFiltrados = "No se puede traducir del inglés al inglés";
                    }
                    else
                    {
                        ViewBag.ArchivosFiltrados = "No se puede traducir";
                    }
                }
                else
                {
                    ViewBag.ArchivosFiltrados = traduccion;
                }
            }
            // Si quiere traducir a ingles
            if (opcion == "opcion1")
            {
                List<string> archivosFiltrados = new List<string>();
                string valorAnterior = null;
                foreach (string item in arch.LeerArchivo())
                {
                    foreach (string item2 in item.Split(':'))
                    {
                        if (Palabra.ToUpper() == item2 && valorAnterior != null)
                        {
                            archivosFiltrados.Add(valorAnterior);
                        }
                        valorAnterior = item2;
                    }
                }
                if (archivosFiltrados.Count == 0)
                {
                    ViewBag.ArchivosFiltrados = "No se encontró";
                }
                else
                {
                    ViewBag.ArchivosFiltrados = archivosFiltrados.FirstOrDefault() ?? "No se encontró";
                }
            }
            // Validar si la opción seleccionada es "Español" pero la palabra ingresada es en español
            if (opcion == "opcion2" && ArchivosEnEspanol.Contains(Palabra.ToUpper()))
            {
                ViewBag.ArchivosFiltrados = "No se puede traducir";
            }
            if (opcion == "opcion1" && ArchivosEnIngles.Contains(Palabra.ToUpper()))
            {
                ViewBag.ArchivosFiltrados = "No se puede traducir ";
            }
            return View();
        }
    }
}
