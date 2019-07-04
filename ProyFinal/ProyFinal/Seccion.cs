using System;
using System.Collections.Generic;
using System.Text;

namespace ProyFinal
{
    public class Seccion
    {
        public static List<Estudiante> estudiantes;
        private byte seccion;
        static Seccion()
        {
            estudiantes = new List<Estudiante>();
        }

        public byte SeccionAsignatura
        {
            get
            {
                return this.seccion;
            }
            set
            {
                this.seccion = value;
            }
        }
        public static void AgregarEstudianteSec(Estudiante estudiante)
        {
            estudiantes.Add(estudiante);
        }
    }
}
