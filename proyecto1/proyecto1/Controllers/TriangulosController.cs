using proyecto1.Models;
using proyecto1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace proyecto1.Controllers
{
    public class TriangulosController : Controller
    {
        // GET: Triangulos
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Triangulo Medidas)
        {
            
            var distancia = new TrianguloService();
            
            double A = distancia.Distancia(Medidas.X1, Medidas.Y1, Medidas.X2, Medidas.Y2);
            double B = distancia.Distancia(Medidas.X1, Medidas.Y1, Medidas.X3, Medidas.Y3);
            double C = distancia.Distancia(Medidas.X2, Medidas.Y2, Medidas.X3, Medidas.Y3);

            double max = distancia.DistanciaMax(A,B,C);

            double suma = distancia.DistanciaSum(max,A,B,C);

            bool es = distancia.EsTriangulo(max, suma);

            if (es)
            {
                ViewBag.esTriangulo = "Es triangulo";
                ViewBag.TipoTriangulo = "El triangulo es: " + distancia.TipoTriangulo(A, B, C);
                ViewBag.Area = "El area es: " + distancia.Area(Medidas.X1, Medidas.Y1, Medidas.X2, Medidas.Y2, Medidas.X3, Medidas.Y3) + " Metros Cuadrados";
            }
            else
            {
                ViewBag.esTriangulo = "No es triangulo";
            }

            // ViewBag.A = "Lado A: " + Math.Round(A, 5);
            // ViewBag.B = "Lado B: " + Math.Round(B, 5);
            // ViewBag.C = "Lado C: " + Math.Round(C, 5);


            return View();
        }

    }
}
