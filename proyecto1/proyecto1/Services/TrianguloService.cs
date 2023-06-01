using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace proyecto1.Services
{
    public class TrianguloService
    {
        public double Distancia(double x1, double y1, double x2, double y2)
        {
            double A = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));

            return A;
        }

        public double DistanciaMax(double A, double B, double C)
        {
            double max = Math.Max(A, Math.Max(B, C));

            return max;
        }

        public double DistanciaSum(double max, double A, double B, double C)
        {
            double suma;
            if (max == A)
            {
                suma = B + C;

            }
            else if (max == B)
            {
                 suma = A + C;
            }
            else
            {
                 suma = A + B;
            }

            return suma;
        }

        public Boolean EsTriangulo(double max, double suma)
        {
            
            Boolean eS =  false;

            if (max < suma)
            {
                eS = true;
            }
            else
            {
                eS = false;
            }

            return eS;
        }

        public String TipoTriangulo(double A, double B, double C)
        {
            String tipoTriangulo;

            if (Math.Round(A, 2) == Math.Round(B, 2))
            {
                if (Math.Round(B, 2) == Math.Round(C, 2))
                {
                    tipoTriangulo = "Equilatero";
                }
                else
                {
                    tipoTriangulo = "Isoseles";
                }
            }
            else if (Math.Round(B, 2) == Math.Round(C, 2))
            {
                tipoTriangulo = "Isoseles";
            }
            else if (Math.Round(A, 2) == Math.Round(C, 2))
            {
                tipoTriangulo = "Isoseles";
            }
            else
            {
                tipoTriangulo = "Escaleno";
            }

            return tipoTriangulo;
        }

        public double Area(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            double area = Math.Abs((x1 * (y2 - y3) + x2 * (y3 - y1) + x3 * (y1 - y2)) / 2);

            return area;
        }
    }
}