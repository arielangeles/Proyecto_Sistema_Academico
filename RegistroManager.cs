using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Clases
{
    public static class RegistroManager
    {
        public static List<Registro> registros = new List<Registro>();

        //Guarda la informacion de los registros basado en el Trimestre
        public static int GuardarTrimestreEspecifico(int idEstudiante, int trimestre)
        {
            //Carpeta donde se guardara la informacion del estudiante por trimestre
            string filePath = Environment.CurrentDirectory + "\\" + idEstudiante;

            int PeriodValue = trimestre;

            filePath += "\\Trimestre" + PeriodValue + ".csv";

            if (File.Exists(filePath))
                File.Delete(filePath);

            File.AppendAllText(filePath, "Materia" + "," + "Creditos" + "," + "Nota" + Environment.NewLine);
            foreach (Registro reg in registros)
            {
                File.AppendAllText(filePath, reg.subject + "," + reg.credValue + "," + reg.grade + Environment.NewLine);
            }

            registros.Clear();

            return PeriodValue;
        }
        public static int GuardarTrimestre(int idEstudiante)
        {
            //Carpeta donde se guardara la informacion del estudiante por trimestre
            string filePath = Environment.CurrentDirectory + "\\" + idEstudiante;

            int PeriodValue = DeterminarCantidadArchivos(filePath) + 1;

            filePath += "\\Trimestre" + PeriodValue + ".csv";

            File.AppendAllText(filePath, "Materia" + "," + "Creditos" + "," + "Nota" + Environment.NewLine);
            foreach (Registro reg in registros)
            {
                File.AppendAllText(filePath, reg.subject + "," + reg.credValue + "," + reg.grade + Environment.NewLine);
            }

            RegistroManager.registros.Clear();


            return PeriodValue;
        }
        public static int DeterminarCantidadArchivos(string directorio)
        {
            string[] files = Directory.GetFiles(directorio, "*.csv");
            return files.Length;
        }
        public static string ObtenerPathDeArchivo(int id, int trimestre)
        {
           string path = Environment.CurrentDirectory + "\\" + id + "\\" + "Trimestre" + trimestre + ".csv";
           return path;
        }
        //Llena la lista de registros en base a un archivo
        public static void LlenarListaRegistro(string path)
        {
            List<Registro> regs = new List<Registro>();
            string[] lineas = File.ReadAllLines(path);
            string[] data;

            for (int i = 1; i < lineas.Length; i++)
            {
                data = lineas[i].Split(',');
                regs.Add(new Registro(data[0], data[1], Int16.Parse(data[2])));
            }

            registros = regs;
        }

        public static List<Trimestre> ObtenerTodosRegistros(int idEstudiante)
        {
            string filePath = Environment.CurrentDirectory + "\\" + idEstudiante;
            string[] files = Directory.GetFiles(filePath, "*.csv");
            string[] lineas;
            string[] data;
            List<Registro> reg = new List<Registro>();
            List<Trimestre> trimestres = new List<Trimestre>();

            for (int i = 0; i < files.Length; i++)
            {
                lineas = File.ReadAllLines(filePath + "\\" + "Trimestre"+(i+1)+".csv");
                for (int j = 1; j < lineas.Length; j++)
                {
                    data = lineas[i+1].Split(',');
                    reg.Add(new Registro(data[0], data[1], short.Parse(data[2])));
                }
                trimestres.Add(new Trimestre(reg, (i + 1)));
            }

            return trimestres;
        }
        public static List<Registro> ObtenerRegistrosTrimestre(int id, int trimestre)
        {
            List<Registro> registros = new List<Registro>();
            string filePath = Environment.CurrentDirectory + "\\" + id;
            filePath += "\\Trimestre" + trimestre + ".csv";
            string[] lineas = File.ReadAllLines(filePath);
            string[] data;

            for (int i = 1; i < lineas.Length; i++)
            {
                data = lineas[i].Split(',');
                registros.Add(new Registro(data[0], data[1], Int16.Parse(data[2])));
            }

            return registros;
        }
    }

}
