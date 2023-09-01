using System;
using CodingChallenge.Data;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodingChallenge.Data.Models;

namespace CodingChallenge.Data.Test
{
    [TestClass]
    public class DataTests
    {
        [TestMethod]
        public void TestResumenListaVacia()
        {
            Assert.AreEqual("<h1>Lista vacía de formas!</h1>",
                Reporte.Imprimir(new List<FormaGeometrica>(), 1));
        }

        [TestMethod]
        public void TestResumenListaVaciaFormasEnIngles()
        {
            Assert.AreEqual("<h1>Empty list of shapes!</h1>",
                Reporte.Imprimir(new List<FormaGeometrica>(), 2));
        }

        [TestMethod]
        public void TestResumenListaConUnCuadrado()
        {
            var cuadrados = new List<FormaGeometrica> { new FormaGeometrica(1, 5) };

            var resumen = Reporte.Imprimir(cuadrados, 1);

            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Cuadrado | Area 25 | Perimetro 20 <br/>TOTAL:<br/>1 formas Perimetro 20 Area 25", resumen);
        }

        [TestMethod]
        public void TestResumenListaConMasCuadrados()
        {
            var cuadrados = new List<FormaGeometrica>
            {
                new FormaGeometrica(1, 5),
                new FormaGeometrica(1, 1),
                new FormaGeometrica(1, 3)
            };

            var resumen = Reporte.Imprimir(cuadrados, 2);

            Assert.AreEqual("<h1>Shapes report</h1>3 Squares | Area 35 | Perimeter 36 <br/>TOTAL:<br/>3 shapes Perimeter 36 Area 35", resumen);
        }

        [TestMethod]
        public void TestResumenListaConMasTipos()
        {
            var formas = new List<FormaGeometrica>
            {
                new FormaGeometrica(1, 5),
                new FormaGeometrica(3, 3),
                new FormaGeometrica(2, 4),
                new FormaGeometrica(1, 2),
                new FormaGeometrica(2, 9),
                new FormaGeometrica(3, 2.75m),
                new FormaGeometrica(2, 4.2m)
            };

            var resumen = Reporte.Imprimir(formas, 2);

            Assert.AreEqual(
                "<h1>Shapes report</h1>2 Squares | Area 29 | Perimeter 28 <br/>2 Circles | Area 13,01 | Perimeter 18,06 <br/>3 Triangles | Area 49,64 | Perimeter 49,64 <br/>TOTAL:<br/>7 shapes Perimeter 95,7 Area 91,65",
                resumen);
        }

        [TestMethod]
        public void TestResumenListaConMasTiposEnCastellano()
        {
            var formas = new List<FormaGeometrica>
            {
                new FormaGeometrica(1, 5),
                new FormaGeometrica(3, 3),
                new FormaGeometrica(2, 4),
                new FormaGeometrica(1, 2),
                new FormaGeometrica(2, 9),
                new FormaGeometrica(3, 2.75m),
                new FormaGeometrica(2, 4.2m)
            };

            var resumen = Reporte.Imprimir(formas, 1);

            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>2 Cuadrados | Area 29 | Perimetro 28 <br/>2 Círculos | Area 13,01 | Perimetro 18,06 <br/>3 Triángulos | Area 49,64 | Perimetro 49,64 <br/>TOTAL:<br/>7 formas Perimetro 95,7 Area 91,65",
                resumen);
        }
    }
}
