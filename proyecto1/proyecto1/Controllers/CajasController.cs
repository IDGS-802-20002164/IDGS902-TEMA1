using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace proyecto1.Controllers
{
    public class CajasController : Controller
    {
      
        public ActionResult Cajas(String Num1)
        {
            ViewBag.Num = Convert.ToInt32(Num1);
            return View();
        }

        public ActionResult Cajas2(string[] Nums1)
        {
            int suma = 0;
            int num;
            String res = "";

            for (int i = 0; i < Nums1.Length; i++)
            {

                if (int.TryParse(Nums1[i], out num))
                {
                    suma += num;
                }
            }

            int[] arreglo = new int[Nums1.Length];

            for (int i = 0; i < Nums1.Length; i++)
            {
                arreglo[i] = Convert.ToInt32(Nums1[i]);
            }

            var numerosRepetidos = arreglo
           .GroupBy(x => x) // Agrupa los elementos por su valor
           .Where(x => x.Count() > 1) // Filtra aquellos con un recuento mayor a 1
           .Select(x => x.Key);

            int maximo = arreglo.Max();
            int minimo = arreglo.Min();
            double prom = arreglo.Sum() / arreglo.Length;

            foreach (var numero in numerosRepetidos)
            {
                res += numero + ",";

            }
            ViewBag.p = "El/los numero/s que se repiten mas de una vez son " + res;
            ViewBag.sum = "La suma es: " + suma;
            ViewBag.max = "El numero mayor es : " + maximo;
            ViewBag.min = "El numero menor es : " + minimo;
            ViewBag.prom = "El promedio es : " + prom;


            return View("Cajas");

        }

    }
}
