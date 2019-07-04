using System;
using System.Collections.Generic;
using System.Text;

namespace ProyFinal
{
    public class AreaAcademica
    {
        private TipoAreaAcad tipoAreaAcademica; 

        public TipoAreaAcad TipoAreaAcademica
        {
            get
            {
                return this.tipoAreaAcademica;
            }
            set
            {
                this.tipoAreaAcademica = value;
            }
        }
        public static TipoAreaAcad ObtenerArea(byte area)
        {
            

            switch (area)
            {
                case 1:
                    return TipoAreaAcad.CBA;
                case 2:
                    return TipoAreaAcad.CS;
                case 3:
                    return TipoAreaAcad.CSH;
                case 4:
                    return TipoAreaAcad.ING;
                case 5:
                    return TipoAreaAcad.ECO;
                default:
                    Console.WriteLine("Ingrese un numero que se encuentre en las opciones");
                    return 0;

            }
        }

        public static TipoAreaAcad RegistrarAreaAcad()
        {
            Console.WriteLine("\n1. Ciencias Basicas y Ambientales (CBA)\n2. Ciencias de la salud (CS)\n3. Ciencias sociales y humanidades (CSH)\n4. Ingenierias (ING)\n5. Economia y negocios (ECO)");
            Console.Write("\nIngrese el area academica a la que pertenece: ");
            byte area = byte.Parse(Console.ReadLine());

            return ObtenerArea(area);
        }
    }
}
