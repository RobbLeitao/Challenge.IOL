using CodingChallenge.Data.Enums;
using System;

namespace CodingChallenge.Data.Helpers
{
    public class ReporteHelper
    {
        public static string ObtenerLinea(int cantidad, decimal area, decimal perimetro, Formas tipo, Idiomas idioma)
        {
            if (cantidad > 0)
            {
                if (Idiomas.Castellano.Equals(idioma))
                    return $"{cantidad} {TraducirForma(tipo, cantidad, idioma)} | Area {area:#.##} | Perimetro {perimetro:#.##} <br/>";

                return $"{cantidad} {TraducirForma(tipo, cantidad, idioma)} | Area {area:#.##} | Perimeter {perimetro:#.##} <br/>";
            }

            return string.Empty;
        }

        public static string TraducirForma(Formas tipo, int cantidad, Idiomas idioma)
        {
            switch (tipo)
            {
                case Formas.Cuadrado:
                    if (Idiomas.Castellano.Equals(idioma)) return cantidad == 1 ? "Cuadrado" : "Cuadrados";
                    else return cantidad == 1 ? "Square" : "Squares";
                case Formas.Circulo:
                    if (Idiomas.Castellano.Equals(idioma)) return cantidad == 1 ? "Círculo" : "Círculos";
                    else return cantidad == 1 ? "Circle" : "Circles";
                case Formas.TrianguloEquilatero:
                    if (Idiomas.Castellano.Equals(idioma)) return cantidad == 1 ? "Triángulo" : "Triángulos";
                    else return cantidad == 1 ? "Triangle" : "Triangles";
            }

            return string.Empty;
        }

        public static decimal CalcularArea(Formas Tipo, decimal lado)
        {
            switch (Tipo)
            {
                case Formas.Cuadrado: 
                    return lado * lado;
                case Formas.Circulo: 
                    return (decimal)Math.PI * (lado / 2) * (lado / 2);
                case Formas.TrianguloEquilatero: 
                    return ((decimal)Math.Sqrt(3) / 4) * lado * lado;
                default:
                    throw new ArgumentOutOfRangeException(@"Forma desconocida");
            }
        }

        public static decimal CalcularPerimetro(Formas Tipo, decimal lado)
        {
            switch (Tipo)
            {
                case Formas.Cuadrado: 
                    return lado * 4;
                case Formas.Circulo: 
                    return (decimal)Math.PI * lado;
                case Formas.TrianguloEquilatero: 
                    return lado * 3;
                default:
                    throw new ArgumentOutOfRangeException(@"Forma desconocida");
            }
        }

        public static bool ValidarIdioma (int idioma)
        {
            switch (idioma)
            {
                case (int)Idiomas.Castellano:
                    return true;
                case (int)Idiomas.Ingles:
                    return true;
                default:
                    return false;
            }
        }
    }
}
