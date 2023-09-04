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
                throw new InvalidOperationException("Idioma desconocido.");

            if (!formas.Any())
                sb.Append(ReporteHelper.TraducirIdioma(ReporteHelper.EMPTY, idioma));
            else
            {
                // Hay por lo menos una forma
                // HEADER
                sb.Append(ReporteHelper.TraducirIdioma(ReporteHelper.HEADER, idioma));

                var numeroCuadrados = 0;
                var numeroCirculos = 0;
                var numeroTriangulos = 0;
                var numeroPentagonos = 0;

                var areaCuadrados = 0m;
                var areaCirculos = 0m;
                var areaTriangulos = 0m;
                var areaPentagonos = 0m;

                var perimetroCuadrados = 0m;
                var perimetroCirculos = 0m;
                var perimetroTriangulos = 0m;
                var perimetroPentagonos = 0m;

                foreach (var item in formas)
                {
                    if (item.Tipo == (int)Formas.Cuadrado)
                    {
                        numeroCuadrados++;
                        areaCuadrados += ReporteHelper.CalcularArea((Formas)item.Tipo, item.Ancho);
                        perimetroCuadrados += ReporteHelper.CalcularPerimetro((Formas)item.Tipo, item.Ancho);
                    }
                    else if (item.Tipo == (int)Formas.Circulo)
                    {
                        numeroCirculos++;
                        areaCirculos += ReporteHelper.CalcularArea((Formas)item.Tipo, item.Ancho);
                        perimetroCirculos += ReporteHelper.CalcularPerimetro((Formas)item.Tipo, item.Ancho);
                    }
                    else if (item.Tipo == (int)Formas.TrianguloEquilatero)
                    {
                        numeroTriangulos++;
                        areaTriangulos += ReporteHelper.CalcularArea((Formas)item.Tipo, item.Ancho);
                        perimetroTriangulos += ReporteHelper.CalcularArea((Formas)item.Tipo, item.Ancho);
                    }
                    else if (item.Tipo == (int)Formas.Pentagono)
                    {
                        numeroPentagonos++;
                        areaPentagonos += ReporteHelper.CalcularArea((Formas)item.Tipo, item.Ancho);
                        perimetroPentagonos += ReporteHelper.CalcularArea((Formas)item.Tipo, item.Ancho);
                    }
                    else
                        throw new InvalidOperationException("Forma desconocida.");
                }
                
                sb.Append(ReporteHelper.ObtenerLinea(numeroCuadrados, areaCuadrados, perimetroCuadrados, Formas.Cuadrado, idioma));
                sb.Append(ReporteHelper.ObtenerLinea(numeroCirculos, areaCirculos, perimetroCirculos, Formas.Circulo, idioma));
                sb.Append(ReporteHelper.ObtenerLinea(numeroTriangulos, areaTriangulos, perimetroTriangulos, Formas.TrianguloEquilatero, idioma));
                sb.Append(ReporteHelper.ObtenerLinea(numeroPentagonos, areaPentagonos, perimetroPentagonos, Formas.Pentagono, idioma));

                // FOOTER
                sb.Append("TOTAL:<br/>");
                sb.Append(numeroCuadrados + numeroCirculos + numeroTriangulos + numeroPentagonos + " " + ReporteHelper.TraducirIdioma(ReporteHelper.TOTAL1, idioma) + " ");
                sb.Append(ReporteHelper.TraducirIdioma(ReporteHelper.TOTAL2, idioma) + " " + (perimetroCuadrados + perimetroTriangulos + perimetroCirculos + perimetroPentagonos).ToString("#.##") + " ");
                sb.Append("Area " + (areaCuadrados + areaCirculos + areaTriangulos + areaPentagonos).ToString("#.##"));
            }

            return sb.ToString();
        }
    }
}
