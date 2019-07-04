using System;
using System.Collections.Generic;
using System.Text;

namespace ProyFinal
{
    public static class RegistroProfesores
    {
        public static List<Profesor> listaProfesor;
        private static List<string> listaMaterias;

        static RegistroProfesores()
        {
            listaProfesor = new List<Profesor>();
            listaMaterias = new List<string>();
            
        }

        public static void AgregarProfesor(Profesor prof)
        {
            listaProfesor.Add(prof);
        }
        public static byte cant;
        public static void RegistrarProfesor(Profesor prof)
        {
            Console.Clear();
            Console.Write("\nIngrese su ID: ");
            prof.ID = Console.ReadLine();
            Console.Write("\nIngrese su nombre: ");
            prof.Nombre = Console.ReadLine().ToUpper();
            Console.Write("\nIngrese su correo: ");
            prof.Correo = Console.ReadLine();
            prof.AreaAcad = AreaAcademica.RegistrarAreaAcad();

            Console.WriteLine("\nNuevo profesor registrado!");
            Console.ReadKey();
            AgregarProfesor(prof);
        }

   
        public static void MostrarProfesor()
        {
            Console.WriteLine("Introduzca su ID porfavor: ");
            string profId = Console.ReadLine();
            Console.WriteLine("{0,-10} {1, 20} {2,15} {3,30} {4,20}", "ID", "Nombre", "Area" ,"Correo", "# de Materias");
           
            foreach (Profesor prof in listaProfesor)
            {
                Console.WriteLine("{0,-10} {1, 20} {2,15} {3,30} {4,20}", prof.ID, prof.Nombre, prof.AreaAcad ,prof.Correo, prof.CantidadMaterias);

            }

            Console.WriteLine("{0, -10}", "\nLista de Materias");
            foreach (Profesor prof in listaProfesor)
            {
                if (profId == prof.ID)
                {
                    foreach(string list in prof.GetAsignatura())
                    {
                        Console.WriteLine("{0,-10}", list);

                    }    
                   
                }
   
            }
            Console.ReadKey();
               
        }
        public static bool startEditProf;
        public static string response;
        public static void MostrarMaterias()
        {
            Console.WriteLine("{0,-10} ", "\nMaterias");
            foreach (string mat in listaMaterias)
            {
                Console.WriteLine("{0,-10} ", mat);
            }
        }
        public static void EditarProfesor()
        {
            do
            {

                string IdProf;
                Console.Write("Introduzca su ID: ");
                IdProf = Console.ReadLine();

                if (ComprobarIdProfesor(IdProf)) // Comprueba si el ID existe o esta registrado
                {
                    foreach(Profesor profesor in listaProfesor) // Recorre la lista de estudiantes
                    {
                        if (IdProf == profesor.ID) // Verifica si el ID coincide con el de la lista
                        {
                            short edit;
                            Console.Write("\nElija la opcion a editar: ");
                            edit = byte.Parse(Console.ReadLine());
                            Console.WriteLine("----------------------------------");
                            Console.WriteLine("1. Nombre\n2. Apellido\n3. Carrera\n");

                            Console.Clear();
                            switch (edit)
                            {
                                case 1:
                                    string NewName;
                                    Console.Write("Nuevo nombre: ");
                                    NewName = Console.ReadLine();
                                    profesor.Nombre = NewName;
                                    Console.Clear();
                                    break;

                                case 2:
                                    string NewMail;
                                    Console.Write("Nuevo correo: ");
                                    NewMail = Console.ReadLine();
                                    profesor.Correo = NewMail;
                                    Console.Clear();
                                    break;
                                case 3:
                                    string NewCarreer;
                                    do
                                    {
                                        MostrarMaterias();
                                        Console.WriteLine("Que materia desea modificar? ");
                                        int x = int.Parse(Console.ReadLine()) - 1;
                                        Console.Write("Nueva materia: ");
                                        NewCarreer = Console.ReadLine();
                                        listaMaterias[x] = NewCarreer;
                                        Console.WriteLine("Desea modificar otra materia?");
                                        response = Console.ReadLine();
                                        Console.Clear();

                                    } while (response.ToLower() == "si");
                                    
                                    break;


                                default:
                                    Program.DefaultOption(startEditProf);
                                    break;


                            }
                            Console.WriteLine("El estudiante ha sido editado! ");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Introduzca un ID valido");
                    startEditProf = true;
                }
            } while (startEditProf);

        }
        public static string seleccion;
        public static bool ComprobarIdProfesor(string prof)
        {
            foreach (Profesor profesor in listaProfesor)
            {
                if (profesor.ID == prof)
                    return true;
            }

            return false;
        }
        public static bool BuscarIdProfesor(Profesor prof)
        {
            if (prof.ID == seleccion)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void EliminarProfesor()
        {
            Console.Write("Inserte el ID del profesor que desea borrar: ");
            seleccion = Console.ReadLine();
            Console.Clear();

            int borrado = listaProfesor.RemoveAll(BuscarIdProfesor);

            if (borrado > 0)
            {
                Console.WriteLine("El profesor ha sido eliminado!");
            }
            else
            {
                Console.WriteLine("Este ID de profesor no existe!");
            }

        }

        
    }
}
