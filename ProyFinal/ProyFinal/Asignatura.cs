using System;
using System.Collections.Generic;
using System.Text;

namespace ProyFinal
{
    public class Asignatura
    {
        private string nombre;
        private string codigo;
        private Carrera carrera;
        private string carreraAsig;
        private TipoAreaAcad tipoArea;
        private static List<Estudiante> listaEstudiante;
        private string profesor;

        private byte creditos;
        public Asignatura()
        {
          
        }
        static Asignatura()
        {
            listaEstudiante = new List<Estudiante>();
        }
        public static void AgregarEstudianteAsig(Estudiante estudiante)
        {
            listaEstudiante.Add(estudiante);
        }
  
        public string Profesor
        {
            get
            {
                return this.profesor;
            }
            set
            {
                this.profesor = value;
            }
        }
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = value;
            }
        }

        public string Codigo
        {
            get
            {
                return this.codigo;
            }
            set
            {
                
                this.codigo = value;
                value = value.Substring(0, 6);
            }
        }

        public Carrera Carrera
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

        public string CarreraAsig
        {
            get
            {
                return this.carreraAsig;
            }
            set
            {
                this.carreraAsig = value;
            }
        }

        public TipoAreaAcad TipoArea
        {
            get
            {
                return this.tipoArea;
            }
            set
            {
                this.tipoArea = value;
            }
        }

        public byte Creditos
        {
            get
            {
                return this.creditos;
            }
            set
            {
                this.creditos = value;
            }
        }

    }
}
