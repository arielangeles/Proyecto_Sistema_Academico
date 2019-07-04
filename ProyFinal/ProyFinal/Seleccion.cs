using System;
using System.Collections.Generic;
using System.Text;

namespace ProyFinal
{
    public class Seleccion : Asignatura
    {
        private string materia;
        private string id;
        
        private Asignatura asignatura;
        private string horaInicio;
        private string horaFin;
        private string time;
        private byte seccion;
        private string aula;

        private string year;
        private string trimestre;
        private string periodo;

        public Seleccion()
        {
        }

        public string Periodo
        {
            get
            {
                return $"{this.trimestre}/{this.year}";
            }

        }
        public string Year
        {
            get
            {
                return this.year;
            }
            set
            {
                this.year = value;
            }
        }

        public string Trimestre
        {
            get
            {
                return this.trimestre;
            }
            set
            {
                this.trimestre = value;
            }
        }
        private string hora;
        public string Horario
        {
            get
            {
                hora = $"{this.horaInicio}/{this.horaFin}";

                if(this.time == "am")
                {
                    return $"{hora}" + " am";
                }
                else if(this.time == "pm")
                {
                    return $"{hora}" + " pm";
                }

                return hora;
            }
        }
        public string HoraInicio
        {
            get
            {
                return this.horaInicio;
            }
            set
            {
                this.horaInicio = value;
            }
        }
        public string HoraFin
        {
            get
            {
                return this.horaFin;
            }
            set
            {
                this.horaFin = value;
            }
        }
        public string Time
        {
            get
            {
                return this.time;
            }
            set
            {
                this.time = value;
            }
        }
        public string Materia
        {
            get
            {
                return this.materia;
            }
            set
            {
                this.materia = value;
            }
        }
        public string ID
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }
        public byte Seccion
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

        public string Aula
        {
            get
            {
                return this.aula;
            }
            set
            {
                this.aula = value;
            }
        }

    }


}
