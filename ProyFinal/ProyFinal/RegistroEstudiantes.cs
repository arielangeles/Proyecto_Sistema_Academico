using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ProyFinal
{
    public static class RegistroEstudiante
    {
        public static List<Estudiante> listaEstudiante;

        static RegistroEstudiante()
        {
            listaEstudiante = new List<Estudiante>();
        }

        public static void AgregarEstudiante(Estudiante est)
        {
            listaEstudiante.Add(est);
        }

        public static void RegistrarEstudiante(Estudiante est)
        {
            
            Console.Write("\nIngrese su ID: ");
            est.ID = Console.ReadLine();
            Console.Write("Ingrese su nombre: ");
            est.Nombre = Console.ReadLine();
            Console.Write("Ingrese la contraseña: ");
            est.Password = Console.ReadLine();
            Console.Write("Ingrese su correo: ");
            est.Correo = Console.ReadLine();   
            Console.Write("Ingrese la carrera que cursa: ");
            est.Carrera = Console.ReadLine();

            est.AreaAcad = AreaAcademica.RegistrarAreaAcad();

            Console.WriteLine("\nNuevo estudiante registrado!");
            Console.ReadKey();
            AgregarEstudiante(est);
            foreach(Estudiante estudent in listaEstudiante)
            {
                Asignatura.AgregarEstudianteAsig(est);
            }
            
            string[] r = File.ReadAllLines("Estudiantes.csv");
            foreach (var linea in r)
            {
                char delimiter = ',';
                string[] datos = linea.Split(delimiter);
            }
            File.WriteAllText("Estudiantes.csv", "ID" + ',' + "Nombre" + ',' + "Carrera" + ',' + "Correo\n");
            foreach(Estudiante estudiante in listaEstudiante)
            {
                File.AppendAllText("Estudiantes.csv", estudiante.ID + ',' + estudiante.Nombre + ',' + estudiante.Carrera + ',' + estudiante.Correo + "\n");
            }
            
        }

        public static void MostrarEstudiante()
        {
            Console.WriteLine("{0,-10} {1, 20} {2,20} {3,30}", "ID", "Nombre", "Carrera", "Correo");
            foreach (Estudiante est in listaEstudiante)
            {
                Console.WriteLine("{0,-10} {1, 20} {2,20} {3,30}", est.ID, est.Nombre, est.Carrera, est.Correo);
            }
            Console.ReadKey();
        }

        public static string seleccion;
        public static bool BuscarIdEstudiante(Estudiante est)
        {
            if (est.ID == seleccion)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool ComprobarIdEstudiante(string id)
        {
            foreach(Estudiante estudiante in listaEstudiante)
            {
                if (estudiante.ID == id)
                    return true;
            }

            return false;
            
        }

        public static void EliminarEstudiante()
        {
            Console.Write("Inserte el ID del estudiante que desea borrar: ");
            seleccion = Console.ReadLine();
            Console.Clear();

            int borrado = listaEstudiante.RemoveAll(BuscarIdEstudiante);

            if (borrado > 0)
            {
                Console.WriteLine("El estudiante ha sido eliminado!");
            }
            else
            {
                Console.WriteLine("Este ID de estudiante no existe!");
            }
        }

        public static bool startEditEst;
        public static void EditarEstudiante()
        {
            do
            {
                string IdEst;
                Console.Write("Introduzca su ID: ");
                IdEst = Console.ReadLine();

                if (ComprobarIdEstudiante(IdEst)) // Comprueba si el ID existe o esta registrado
                {
                    foreach(Estudiante estudiante in listaEstudiante) // Recorre la lista de estudiantes
                    {
                        if (IdEst == estudiante.ID) // Verifica si el ID coincide con el de la lista
                        {
                            Console.Clear();
                            short edit;
                            Console.Write("\nElija la opcion a editar: ");
                            Console.WriteLine("\n----------------------------------");
                            Console.WriteLine("1. Nombre\n2. Correo\n3. Carrera\n");
                            Console.SetCursorPosition(26, 1);
                            edit = byte.Parse(Console.ReadLine());

                            Console.Clear();
                            switch (edit)
                            {
                                case 1:
                                    string NewName;
                                    Console.Write("Nuevo nombre: ");
                                    NewName = Console.ReadLine();
                                    estudiante.Nombre = NewName;
                                    Console.Clear();
                                    break;

                                case 2:
                                    string NewMail;
                                    Console.Write("Nuevo correo: ");
                                    NewMail = Console.ReadLine();
                                    estudiante.Correo = NewMail;
                                    Console.Clear();
                                    break;
                                case 3:
                                    string NewCarreer;
                                    Console.Write("Nueva carrera: ");
                                    NewCarreer = Console.ReadLine();
                                    estudiante.Carrera = NewCarreer;
                                    Console.Clear();
                                    break;


                                default:
                                    Program.DefaultOption(startEditEst);
                                    break;


                            }
                            Console.WriteLine("El estudiante ha sido editado! ");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Introduzca un ID valido");
                    startEditEst = true; 
                }
            } while (startEditEst);
           

        }
    }
}
