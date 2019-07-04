using System;
using System.Collections.Generic;
using System.Text;

namespace ProyFinal
{
    public static class RegistroAsignatura
    {
        public static List<Asignatura> listaAsignatura;

        static RegistroAsignatura()
        {
            listaAsignatura = new List<Asignatura>();
        }

        public static void AgregarAsignatura(Asignatura asignatura)
        {
            listaAsignatura.Add(asignatura);
        }
        public static void MostrarAsignatura()
        {
            Console.WriteLine("{0,-10} {1, 20} {2,15} {3,30}", "Codigo", "Nombre", "Creditos", "Carrera");
            foreach (Asignatura asignatura in listaAsignatura)
            {
                Console.WriteLine("{0,-10} {1, 20} {2,15} {3,30}", asignatura.Codigo, asignatura.Nombre, asignatura.Creditos, asignatura.Carrera);
            }
            Console.ReadKey();

        }
        public static bool profe;
        public static void RegistrarAsignatura(Asignatura asignatura)
        {
            Console.Clear();
            Console.Write("Ingrese el nombre de la asignatura: ");
            asignatura.Nombre = Console.ReadLine();
            Console.Write("Ingrese el codigo de la materia: ");
            asignatura.Codigo = Console.ReadLine().ToUpper();
            Console.Write("Ingrese la cantidad de creditos que posee: ");
            asignatura.Creditos = byte.Parse(Console.ReadLine());
            Console.Write("Ingrese la carrera correspondiente");
            asignatura.CarreraAsig = Console.ReadLine();
            do
            {
                profe = true;
                Console.Write("Ingrese el profesor de la asignatura: "); // profesor de la asignatura
                asignatura.Profesor = Console.ReadLine().ToUpper();
            
                foreach (Profesor prof in RegistroProfesores.listaProfesor)
                {
                    if (asignatura.Profesor == prof.Nombre)
                    {
                        prof.SetAsignatura(asignatura.Nombre);
                        prof.CantidadMaterias++;
                        profe = false;
                    }
                   
                }

            } while (profe);

            asignatura.TipoArea = AreaAcademica.RegistrarAreaAcad();

            Console.WriteLine("\nNueva asignatura registrada!");
            Console.ReadKey();
            AgregarAsignatura(asignatura); // Agrega la informacion a la lista de Asignaturas

        }

        public static bool ComprobarCodigoAsignatura(string codigo)
        {
            foreach (Asignatura asignatura in listaAsignatura)
            {
                if (asignatura.Codigo == codigo)
                    return true;
            }

            return false;

        }
        public static bool startEditAsig;
        public static void EditarAsignatura()
        {
            do
            {
                Console.Write("Introduzca el codigo de la asignatura: ");
                string CodeAsig = Console.ReadLine();

                if (ComprobarCodigoAsignatura(CodeAsig))
                {
                    foreach (Asignatura asignatura in listaAsignatura)
                    {
                        if (CodeAsig == asignatura.Codigo)
                        {
                            short edit;
                            Console.Write("\nElija la opcion a editar: ");      
                            Console.WriteLine("----------------------------------");
                            Console.WriteLine("1. Nombre de la asignatura\n2. Carrera \n3. Cantidad de creditos\n");
                            Console.SetCursorPosition(26, 1);
                            edit = byte.Parse(Console.ReadLine());

                            Console.Clear();
                            switch (edit)
                            {
                                case 1:
                                    string NewName;
                                    Console.Write("Nuevo nombre de asignatura: ");
                                    NewName = Console.ReadLine();
                                    asignatura.Nombre = NewName;
                                    Console.Clear();
                                    break;

                                case 2:
                                    string NewCareer;
                                    Console.Write("Nueva carrera: ");
                                    NewCareer = Console.ReadLine();
                                    asignatura.CarreraAsig = NewCareer;
                                    Console.Clear();
                                    break;
                                case 3:
                                    byte NewCredits;
                                    Console.Write("Nueva cantidad de creditos: ");
                                    NewCredits = byte.Parse(Console.ReadLine());
                                    asignatura.Creditos = NewCredits;
                                    Console.Clear();
                                    break;


                                default:
                                    Program.DefaultOption(startEditAsig);
                                    break;


                            }
                            Console.WriteLine("La asignatura ha sido editada! ");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Introduzca un ID valido");
                    startEditAsig = true;
                }
            } while (startEditAsig);


        }
        public static string seleccion;
        public static bool BuscarCodigoAsignatura(Asignatura asignatura)
        {
            if(asignatura.Codigo == seleccion)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static void EliminarAsignatura()
        {
            Console.WriteLine("Introduzca el codigo de la asignatura: ");
            seleccion = Console.ReadLine().ToUpper();
            Console.Clear();

            int borrado = listaAsignatura.RemoveAll(BuscarCodigoAsignatura);

            if (borrado > 0)
            {
                Console.WriteLine("La asignatura ha sido eliminada");
            }
            else
            {
                Console.WriteLine("Inserte un codigo valido, porfavor");
            }
        }
    }
}
