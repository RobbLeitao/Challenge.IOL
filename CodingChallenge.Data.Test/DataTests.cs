using System;
using CodingChallenge.Data;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodingChallenge.Data.Test
{
    [TestClass]
    public class DataTests
    {
        [TestMethod]
        public void TestResumenListaVacia()
        {
            Assert.AreEqual("<h1>Lista vacía de formas!</h1>",
                Reporte.Imprimir(new List<Reporte>(), 1));
        }

        [TestMethod]
        public void TestResumenListaVaciaFormasEnIngles()
        {
            Assert.AreEqual("<h1>Empty list of shapes!</h1>",
                Reporte.Imprimir(new List<Reporte>(), 2));
        }

        [TestMethod]
        public void TestResumenListaConUnCuadrado()
        {
            var cuadrados = new List<Reporte> { new Reporte(Reporte.Cuadrado, 5) };

            var resumen = Reporte.Imprimir(cuadrados, Reporte.Castellano);

            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Cuadrado | Area 25 | Perimetro 20 <br/>TOTAL:<br/>1 formas Perimetro 20 Area 25", resumen);
        }

        [TestMethod]
        public void TestResumenListaConMasCuadrados()
        {
            var cuadrados = new List<Reporte>
            {
                new Reporte(Reporte.Cuadrado, 5),
                new Reporte(Reporte.Cuadrado, 1),
                new Reporte(Reporte.Cuadrado, 3)
            };

            var resumen = Reporte.Imprimir(cuadrados, Reporte.Ingles);

            Assert.AreEqual("<h1>Shapes report</h1>3 Squares | Area 35 | Perimeter 36 <br/>TOTAL:<br/>3 shapes Perimeter 36 Area 35", resumen);
        }

        [TestMethod]
        public void TestResumenListaConMasTipos()
        {
            var formas = new List<Reporte>
            {
                new Reporte(Reporte.Cuadrado, 5),
                new Reporte(Reporte.Circulo, 3),
                new Reporte(Reporte.TrianguloEquilatero, 4),
                new Reporte(Reporte.Cuadrado, 2),
                new Reporte(Reporte.TrianguloEquilatero, 9),
                new Reporte(Reporte.Circulo, 2.75m),
                new Reporte(Reporte.TrianguloEquilatero, 4.2m)
            };

            var resumen = Reporte.Imprimir(formas, Reporte.Ingles);

            Assert.AreEqual(
                "<h1>Shapes report</h1>2 Squares | Area 29 | Perimeter 28 <br/>2 Circles | Area 13,01 | Perimeter 18,06 <br/>3 Triangles | Area 49,64 | Perimeter 51,6 <br/>TOTAL:<br/>7 shapes Perimeter 97,66 Area 91,65",
                resumen);
        }

        [TestMethod]
        public void TestResumenListaConMasTiposEnCastellano()
        {
            var formas = new List<Reporte>
            {
                new Reporte(Reporte.Cuadrado, 5),
                new Reporte(Reporte.Circulo, 3),
                new Reporte(Reporte.TrianguloEquilatero, 4),
                new Reporte(Reporte.Cuadrado, 2),
                new Reporte(Reporte.TrianguloEquilatero, 9),
                new Reporte(Reporte.Circulo, 2.75m),
                new Reporte(Reporte.TrianguloEquilatero, 4.2m)
            };

            var resumen = Reporte.Imprimir(formas, Reporte.Castellano);

            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>2 Cuadrados | Area 29 | Perimetro 28 <br/>2 Círculos | Area 13,01 | Perimetro 18,06 <br/>3 Triángulos | Area 49,64 | Perimetro 51,6 <br/>TOTAL:<br/>7 formas Perimetro 97,66 Area 91,65",
                resumen);
        }
    }
}
