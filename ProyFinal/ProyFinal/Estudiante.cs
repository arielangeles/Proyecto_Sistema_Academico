using System;
using System.Collections.Generic;
using System.Text;

namespace ProyFinal
{
    public class Estudiante : Usuario
    {
        
        private string carrera;
        private int calificacion;

        public string Carrera
        {
            get
            {
                return this.carrera;
            }
            set
            {
                this.carrera = value;
            }
        }

        public int Calificacion
        {
            get
            {
                return this.calificacion;
            }
            set
            {
                if(value > 100)
                {
                    value = 100;
                }
                this.calificacion = value;
            }
        }

    }
}
