using CodingChallenge.Data.Enums;
using System;

namespace CodingChallenge.Data.Helpers
{
    public class ReporteHelper
    {
        public const string EMPTY = "EMPTY";
        public const string HEADER = "HEADER";

        public static string ObtenerLinea(int cantidad, decimal area, decimal perimetro, Formas tipo, Idiomas idioma)
        {
            string result;
            if(cantidad.Equals(0))
                result = string.Empty;
            else
            {
                if (Idiomas.Castellano.Equals(idioma))
                    result = $"{cantidad} {TraducirForma(tipo, cantidad, idioma)} | Area {area:#.##} | Perimetro {perimetro:#.##} <br/>";
                else if (Idiomas.Ingles.Equals(idioma))
                    result = $"{cantidad} {TraducirForma(tipo, cantidad, idioma)} | Area {area:#.##} | Perimeter {perimetro:#.##} <br/>";
                else
                    result = $"{cantidad} {TraducirForma(tipo, cantidad, idioma)} | La zona {area:#.##} | Perimetro {perimetro:#.##} <br/>";
            }

            return result;
        }

        public static string TraducirForma(Formas tipo, int cantidad, Idiomas idioma)
        {
            switch (tipo)
            {
                case Formas.Cuadrado:
                    if (Idiomas.Castellano.Equals(idioma)) 
                        return cantidad == 1 ? "Cuadrado" : "Cuadrados";
                    else if (Idiomas.Ingles.Equals(idioma)) 
                        return cantidad == 1 ? "Square" : "Squares";
                    else
                        return cantidad == 1 ? "Piazza" : "Piazze"; // Italiano
                case Formas.Circulo:
                    if (Idiomas.Castellano.Equals(idioma)) 
                        return cantidad == 1 ? "Círculo" : "Círculos";
                    else if (Idiomas.Ingles.Equals(idioma))
                        return cantidad == 1 ? "Circle" : "Circles";
                    else 
                        return cantidad == 1 ? "Cerchio" : "Cerchi"; // Italiano
                case Formas.TrianguloEquilatero:
                    if (Idiomas.Castellano.Equals(idioma)) 
                        return cantidad == 1 ? "Triángulo" : "Triángulos";
                    else if (Idiomas.Ingles.Equals(idioma))
                        return cantidad == 1 ? "Triangle" : "Triangles";
                    else
                        return cantidad == 1 ? "Triangolo" : "Triangoli"; // Italiano
                case Formas.Pentagono:
                    if (Idiomas.Castellano.Equals(idioma))
                        return cantidad == 1 ? "Rectangulo" : "Rectangulos";
                    else if (Idiomas.Ingles.Equals(idioma))
                        return cantidad == 1 ? "Rectangle" : "Rectangles";
                    else
                        return cantidad == 1 ? "Rettangolo" : "Rettangoli"; // Italiano    
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
                case Formas.Pentagono:
                    return CalcularPerimetro(Formas.Pentagono, lado) * ((decimal)Math.PI * (lado / 2)) / 2;
                default:
                    throw new InvalidOperationException("Forma desconocida");
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
                case Formas.Pentagono:
                    return lado * 5;
                default:
                    throw new InvalidOperationException("Forma desconocida");
            }
        }

        public static bool ValidarIdioma(int idioma)
        {
            switch (idioma)
            {
                case (int)Idiomas.Castellano:
                    return true;
                case (int)Idiomas.Ingles:
                    return true;
                case (int)Idiomas.Italiano:
                    return true;
                default:
                    return false;
            }
        }

        public static string TraducirIdioma(string type, Idiomas idioma)
        {
            switch (type)
            {
                case EMPTY:
                    return idioma.Equals(Idiomas.Castellano) ? "<h1>Lista vacía de formas!</h1>"
                        : idioma.Equals(Idiomas.Ingles) ? "<h1>Empty list of shapes!</h1>"
                        : "<h1>Elenco vuoto di forme!</h1>"; // Italiano
                case HEADER:
                    return idioma.Equals(Idiomas.Castellano) ? "<h1>Reporte de Formas</h1>"
                        : idioma.Equals(Idiomas.Ingles) ? "<h1>Shapes report</h1>"
                        : "<h1>Rapporto sui moduli</h1>"; // Italiano
                default:
                    return string.Empty;
            }
        }
    }
}
