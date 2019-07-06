using System;
using System.Collections.Generic;
using System.Text;

namespace Clases
{
    public class Trimestre
    {
        public List<Registro> Registros { get; set; }
        public int NumTrimestre { get; set; }

        public Trimestre(List<Registro> registros, int numTrimestre)
        {
            Registros = registros;
            NumTrimestre = numTrimestre;
        }
    }
}
