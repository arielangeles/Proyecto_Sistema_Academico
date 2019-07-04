using System;
using System.Collections.Generic;
using System.Text;

namespace ProyFinal
{
    public abstract class Usuario
    {
        private string iD;
        private string nombre;
        private string correo;
        private string password;
        private TipoAreaAcad areaAcad;

        public string Password
        {
            get
            {
                return this.password;
            }
            set
            {
                this.password = value;
            }
        }
        public string ID
        {
            get
            {
                return this.iD;
            }
            set
            {
                this.iD = value;
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

        public string Correo
        {
            get
            {
                return this.correo;
            }
            set
            {
                this.correo = value;
            }
        }
        public TipoAreaAcad AreaAcad
        {
            get
            {
                return this.areaAcad;
            }
            set
            {
                this.areaAcad = value;
            }
        }

    }
}
