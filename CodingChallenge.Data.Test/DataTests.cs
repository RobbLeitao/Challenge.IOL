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
        public void TestResumenListaVaciaFormasEnItaliano()
        {
            Assert.AreEqual("<h1>Elenco vuoto di forme!</h1>",
                Reporte.Imprimir(new List<FormaGeometrica>(), 3));
        }

        [TestMethod]
        public void TestResumenListaCuadradoIdiomaDesconocidoException()
        {
            var cuadrados = new List<FormaGeometrica> { new FormaGeometrica(1, 5) };
            var ex = Assert.ThrowsException<InvalidOperationException>(() => Reporte.Imprimir(cuadrados, 7));

            Assert.AreEqual("Idioma desconocido.", ex.Message);
        }

        [TestMethod]
        public void TestResumenListaFormaDesconocidaEnItalianoException()
        {
            var forma = new List<FormaGeometrica> { new FormaGeometrica(7, 5) };
            var ex = Assert.ThrowsException<InvalidOperationException>(() => Reporte.Imprimir(forma, 3));

            Assert.AreEqual("Forma desconocida.", ex.Message);
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

        [TestMethod]
        public void TestResumenListaConUnPentagonoEnCastellano()
        {
            var pentagono = new List<FormaGeometrica> { new FormaGeometrica(5, 5) };
            var resumen = Reporte.Imprimir(pentagono, 1);

            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Pentagono | Area 98,17 | Perimetro 98,17 <br/>TOTAL:<br/>1 formas Perimetro 98,17 Area 98,17", resumen);
        }

        [TestMethod]
        public void TestResumenListaConUnPentagonoEnItaliano()
        {
            var pentagono = new List<FormaGeometrica> { new FormaGeometrica(5, 5) };
            var resumen = Reporte.Imprimir(pentagono, 3);

            Assert.AreEqual("<h1>Rapporto sui moduli</h1>1 Pentagono | La zona 98,17 | Perimetro 98,17 <br/>TOTAL:<br/>1 forme Perimetro 98,17 Area 98,17", resumen);
        }

        [TestMethod]
        public void TestResumenListaConMasTiposEnItaliano()
        {
            var formas = new List<FormaGeometrica>
            {
                new FormaGeometrica(1, 5),
                new FormaGeometrica(3, 3),
                new FormaGeometrica(2, 4),
                new FormaGeometrica(1, 2),
                new FormaGeometrica(2, 9),
                new FormaGeometrica(3, 2.75m),
                new FormaGeometrica(2, 4.2m),
                new FormaGeometrica(5, 4),
                new FormaGeometrica(5, 5)
            };

            var resumen = Reporte.Imprimir(formas, 3);

            Assert.AreEqual(
                "<h1>Rapporto sui moduli</h1>2 Piazze | La zona 29 | Perimetro 28 <br/>2 Cerchi | La zona 13,01 | Perimetro 18,06 <br/>3 Triangoli | La zona 49,64 | Perimetro 49,64 <br/>2 Pentagoni | La zona 161,01 | Perimetro 161,01 <br/>TOTAL:<br/>9 forme Perimetro 256,71 Area 252,66",
                resumen);
        }

        [TestMethod]
        public void TestResumenListaConUnTrianguloEnIngles()
        {
            var triangulo = new List<FormaGeometrica> { new FormaGeometrica(2, 5) };
            var resumen = Reporte.Imprimir(triangulo, 2);

            Assert.AreEqual("<h1>Shapes report</h1>1 Triangle | Area 10,83 | Perimeter 10,83 <br/>TOTAL:<br/>1 shapes Perimeter 10,83 Area 10,83", resumen);
        }
    }
}
