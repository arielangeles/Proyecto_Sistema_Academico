using System;
using System.Collections.Generic;
using System.Text;

namespace ProyFinal
{
    public static class Trimestre
    {
        public static string ObtenerTrim(byte trim)
        {
            switch (trim)
            {
                case 1:
                    return "Febrero-Abril";
                case 2:
                    return "Mayo-Julio";
                case 3:
                    return "Agosto-Octubre";
                case 4:
                    return "Noviembre-Enero";
                default:
                    throw new Exception();
            }
        }
    }
}
