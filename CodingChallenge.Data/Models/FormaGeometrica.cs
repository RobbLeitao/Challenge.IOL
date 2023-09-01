using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Models
{
    public class FormaGeometrica
    {
        private int Tipo;
        private decimal Ancho;

        public FormaGeometrica(int tipo, decimal ancho)
        {
            Tipo = tipo;
            Ancho = ancho;
        }
    }
}
