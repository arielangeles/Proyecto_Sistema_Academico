using System;
using System.Collections.Generic;
using System.Text;

namespace ProyFinal
{
    public class Carrera : AreaAcademica
    {
        private string carrera;

        public string CarreraAsig
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

    }
}
