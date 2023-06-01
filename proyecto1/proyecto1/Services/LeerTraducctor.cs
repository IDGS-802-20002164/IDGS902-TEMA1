using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace proyecto1.Services
{
    public class LeerTraducctor
    {
        public Array LeerArchivo()
        {
            Array traducDatos = null;
            var datos = HttpContext.Current.Server.MapPath("~/App_Data/traducctor.txt");

            if (File.Exists(datos))
            {
                traducDatos = File.ReadAllLines(datos);
            }
            return traducDatos;
        }
       
        
    }
}