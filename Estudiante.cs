using System;
using System.IO;
using System.Collections.Generic;

namespace Clases
{
    public class Estudiante
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Carrera { get; set; }
        private string Password { get; set; }
        public int Trimestre { get; set; }

        public Estudiante(int id, string password, string nombre, string carrera)
        {
            this.ID = id;
            this.Nombre = nombre;
            this.Carrera = carrera;
            this.Password = password;
        }
        public static void CrearArchivo()
        {
            string filePath = Environment.CurrentDirectory + "\\Estudiantes.csv";

            if (!File.Exists(filePath))
            {
                File.AppendAllText(filePath, "ID" + "," + "Nombre" + "," + "Carrera" + "," + "Password" + Environment.NewLine);
            }
        }
        public static void AñadirEstudiante(Estudiante est)
        {
            string filePath = Environment.CurrentDirectory + "\\Estudiantes.csv";
            File.AppendAllText(filePath, est.ID + "," + est.Nombre + "," + est.Carrera + "," + est.Password + Environment.NewLine);
            Directory.CreateDirectory(Environment.CurrentDirectory + "\\" + est.ID);
        }
        public static void EliminarEstudiante(int id)
        {
            List<Estudiante> estudiantes = ObtenerListaEstudiantes();
            foreach (Estudiante est in estudiantes)
            {
                if (id == est.ID)
                {
                    estudiantes.Remove(est);
                    CrearArchivo();
                    for (int i = 0; i < estudiantes.Count; i++)
                    {
                        AñadirEstudiante(est);
                    }
                }

            }
        }
        public static List<Estudiante> ObtenerListaEstudiantes()
        {
            string filePath = Environment.CurrentDirectory + "\\Estudiantes.csv";
            List<Estudiante> estudiantes = new List<Estudiante>();
            string[] lineas = File.ReadAllLines(filePath);
            string[] datos;
            //Empezando desde la segunda linea lee los datos y guardarlo como elemento en la lista.
            for (int i = 1; i < lineas.Length; i++)
            {
                datos = lineas[i].Split(',');
                estudiantes.Add(new Estudiante(Int32.Parse(datos[0]), datos[3], datos[1], datos[2]));
            }
            return estudiantes;
        }
        public static bool VerificarEstudianteExiste(int id, string password)
        {
            bool estudianteExiste = false;

            foreach (Estudiante est in ObtenerListaEstudiantes())
            {
                if (est.ID == id)
                    if (est.Password == password)
                    {
                        estudianteExiste = true;
                        break;
                    }
            }
            return estudianteExiste;
        }
        public static bool VerificarIdExiste(int id)
        {
            bool idExiste = false;

            List<Estudiante> estTemp = ObtenerListaEstudiantes();
            for (int i = 0; i < estTemp.Count; i++)
            {
                if (estTemp[i].ID == id)
                {
                    idExiste = true;
                    break;
                }
            }
            return idExiste;

        }
        public static bool VerificarPasswordExiste(string password)
        {
            bool passwordExiste = false;

            foreach (Estudiante est in ObtenerListaEstudiantes())
            {
                if (est.Password == password)
                {
                    passwordExiste = true;
                    break;
                }
            }

            return passwordExiste;
        }
    }


}
