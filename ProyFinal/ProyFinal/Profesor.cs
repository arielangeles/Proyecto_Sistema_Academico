using System;
using System.Collections.Generic;
using System.Text;

namespace ProyFinal
{
    public class Profesor : Usuario
    {
        private string materia;
        private List<string> listaMateria;
        private short cantidadMaterias;
        
        public Profesor()
        {
            this.listaMateria = new List<string>();
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

        public short CantidadMaterias
        {
            get
            {
                return this.cantidadMaterias;
            }
            set
            {
                this.cantidadMaterias = value;
            }
        }
        public void SetAsignatura(string asignatura)
        {
            this.listaMateria.Add(asignatura);
        }
        public List<string> GetAsignatura()
        {
            return this.listaMateria;
        }

        
    }
}
