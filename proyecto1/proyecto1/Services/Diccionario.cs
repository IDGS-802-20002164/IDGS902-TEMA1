using proyecto1.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace proyecto1.Services
{
    public class Diccionario
    {
        public void GuardarArchivo(Traducctor palabraI)
        {
            var palabI = palabraI.PalabraIn.ToUpper();
            var palabE = palabraI.PalabraEs.ToUpper();
                ;


            var datos = palabI + ":" + palabE +  Environment.NewLine;
            var archivo = HttpContext.Current.Server.MapPath("~/App_Data/traducctor.txt");
            File.AppendAllText(archivo, datos);
        }
    }
}