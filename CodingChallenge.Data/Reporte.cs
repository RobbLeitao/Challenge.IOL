/*
 * Refactorear la clase para respetar principios de programación orientada a objetos. Qué pasa si debemos soportar un nuevo idioma para los reportes, o
 * agregar más formas geométricas?
 *
 * Se puede hacer cualquier cambio que se crea necesario tanto en el código como en los tests. La única condición es que los tests pasen OK.
 *
 * TODO: Implementar Trapecio/Rectangulo, agregar otro idioma a reporting.
 * */

using CodingChallenge.Data.Enums;
using CodingChallenge.Data.Helpers;
using CodingChallenge.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodingChallenge.Data
{
    public class Reporte
    {
        public static string Imprimir(List<FormaGeometrica> formas, int lng)
        {
            var sb = new StringBuilder();
            Idiomas idioma;

            if (ReporteHelper.ValidarIdioma(lng))
                idioma = (Idiomas)lng;
            else
                throw new ArgumentOutOfRangeException(@"Idioma desconocido");

            if (!formas.Any())
            {
                if (Idiomas.Castellano.Equals(idioma))
                    sb.Append("<h1>Lista vacía de formas!</h1>");
                else
                    sb.Append("<h1>Empty list of shapes!</h1>");
            }
            else
            {
                // Hay por lo menos una forma
                // HEADER
                if (Idiomas.Castellano.Equals(idioma))
                    sb.Append("<h1>Reporte de Formas</h1>");
                else
                    // default es inglés
                    sb.Append("<h1>Shapes report</h1>");

                var numeroCuadrados = 0;
                var numeroCirculos = 0;
                var numeroTriangulos = 0;

                var areaCuadrados = 0m;
                var areaCirculos = 0m;
                var areaTriangulos = 0m;

                var perimetroCuadrados = 0m;
                var perimetroCirculos = 0m;
                var perimetroTriangulos = 0m;

                foreach(var item in formas)
                {
                    if (item.Tipo == (int)Formas.Cuadrado)
                    {
                        numeroCuadrados++;
                        areaCuadrados += ReporteHelper.CalcularArea((Formas)item.Tipo, item.Ancho);
                        perimetroCuadrados += ReporteHelper.CalcularPerimetro((Formas)item.Tipo, item.Ancho);
                    }
                    if (item.Tipo == (int)Formas.Circulo)
                    {
                        numeroCirculos++;
                        areaCirculos += ReporteHelper.CalcularArea((Formas)item.Tipo, item.Ancho);
                        perimetroCirculos += ReporteHelper.CalcularPerimetro((Formas)item.Tipo, item.Ancho);
                    }
                    if (item.Tipo == (int)Formas.TrianguloEquilatero)
                    {
                        numeroTriangulos++;
                        areaTriangulos += ReporteHelper.CalcularArea((Formas)item.Tipo, item.Ancho);
                        perimetroTriangulos += ReporteHelper.CalcularArea((Formas)item.Tipo, item.Ancho);
                    }
                }
                
                sb.Append(ReporteHelper.ObtenerLinea(numeroCuadrados, areaCuadrados, perimetroCuadrados, Formas.Cuadrado, idioma));
                sb.Append(ReporteHelper.ObtenerLinea(numeroCirculos, areaCirculos, perimetroCirculos, Formas.Circulo, idioma));
                sb.Append(ReporteHelper.ObtenerLinea(numeroTriangulos, areaTriangulos, perimetroTriangulos, Formas.TrianguloEquilatero, idioma));

                // FOOTER
                sb.Append("TOTAL:<br/>");
                sb.Append(numeroCuadrados + numeroCirculos + numeroTriangulos + " " + (idioma == Idiomas.Castellano ? "formas" : "shapes") + " ");
                sb.Append((Idiomas.Castellano.Equals(idioma) ? "Perimetro " : "Perimeter ") + (perimetroCuadrados + perimetroTriangulos + perimetroCirculos).ToString("#.##") + " ");
                sb.Append("Area " + (areaCuadrados + areaCirculos + areaTriangulos).ToString("#.##"));
            }

            return sb.ToString();
        }
    }
}
