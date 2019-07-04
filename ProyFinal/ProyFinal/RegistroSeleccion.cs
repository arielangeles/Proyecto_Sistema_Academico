using System;
using System.Collections.Generic;
using System.Text;

namespace ProyFinal
{
    public static class RegistroSeleccion
    {
        private static List<Seleccion> listaSeleccion;

        static RegistroSeleccion()
        {
            listaSeleccion = new List<Seleccion>();
        }

        public static void AgregarSeleccion(Seleccion seleccion)
        {
            listaSeleccion.Add(seleccion);
        }
        public static bool FinishSelection, respValida;
        public static void RegistrarSeleccion(Seleccion seleccion)
        {
            Console.Clear();
            Console.Write("Ingrese su ID: ");
            seleccion.ID = Console.ReadLine();
            if (RegistroEstudiante.ComprobarIdEstudiante(seleccion.ID))
            {
                Console.Write("\nIngrese el año: ");
                seleccion.Year = Console.ReadLine();

                Console.Write("Seleccione el periodo: ");
                Console.WriteLine("\n1. Febrero-Abril\n2. Mayo-Julio\n3. Agosto-Octubre\n4. Noviembre-Enero");
                Console.SetCursorPosition(23, 2);
                byte trim = byte.Parse(Console.ReadLine());
                seleccion.Trimestre = Trimestre.ObtenerTrim(trim);

                do
                {
                    FinishSelection = false;
                    Console.Clear();
                    
                    int i = 1;
                    foreach(Estudiante est in RegistroEstudiante.listaEstudiante)
                    {
                        foreach (Asignatura asignatura in RegistroAsignatura.listaAsignatura)
                        {
                            if (est.AreaAcad == asignatura.TipoArea)
                            {
                                Console.WriteLine($"{i}. {asignatura.Nombre} - {asignatura.Codigo}");
                                i++;
                            }

                        }
                    }
                    Console.Write("\nIndique la materia que desea seleccionar: ");
                    int selecMat = int.Parse(Console.ReadLine());
                    if(selecMat == i)
                    {
                        foreach(Asignatura asignatura in RegistroAsignatura.listaAsignatura)
                        {
                            seleccion.Materia = asignatura.Nombre;
                        }
                        
                    }

                    Console.Write("\nIngrese el profesor: ");
                    seleccion.Profesor = Console.ReadLine();
                    Console.Write("Ingrese la seccion: ");
                    seleccion.Seccion = byte.Parse(Console.ReadLine());
                    
                    Console.Write("Ingrese la hora de inicio: ");
                    seleccion.HoraInicio = Console.ReadLine();
                    Console.Write("Ingrese la hora de finalizacion: ");
                    seleccion.HoraFin = Console.ReadLine();
                    Console.Write("En la mañana o en la tarde? (am/pm): ");
                    seleccion.Time = Console.ReadLine().ToLower();
                    Console.Write("Ingrese el aula: ");
                    seleccion.Aula = Console.ReadLine();

                    Console.WriteLine("\nSeleccion guardada");
                    Console.ReadKey();
                    AgregarSeleccion(seleccion);


                    do
                    {
                        Console.Clear();
                        respValida = false;
                        Console.WriteLine("Desea seleccionar otra materia? ");
                        string respuesta = Console.ReadLine().ToLower();
                        if (respuesta == "si")
                        {
                            FinishSelection = false;
                        }
                        else if (respuesta == "no")
                        {
                            FinishSelection = true;
                        }
                        else
                        {
                            Console.WriteLine("Inserte una respuesta valida");
                            Console.ReadKey();
                            respValida = true;
                        }

                    } while (respValida);
                   

                } while (!FinishSelection);
                
            }
            else
            {
                Console.WriteLine("Ingrese un ID valido, porfavor");
                Console.ReadKey();
            }
        }
        public static bool startEditSel;
        public static void ModificarSeleccion()
        {
            Console.Write("Ingrese su ID: ");
            seleccion = Console.ReadLine();
            string periodo = ComprobarPeriodo();
            do
            {
                Console.WriteLine("{0,-10} {1, 30} {2,15} {3,30}", "Materia", "Seccion", "Horario", "Aula");
                foreach (Seleccion selec in listaSeleccion)
                {
                    if (seleccion == selec.ID && periodo == selec.Periodo)
                    {
                        Console.WriteLine("{0,-10} {1, 30} {2,15} {3,30}", selec.Materia, selec.Seccion, selec.Horario, selec.Aula);
                    }
                }Console.WriteLine("");

                string IdSel;
                Console.WriteLine("Introduzca la materia que desea modificar");
                IdSel = Console.ReadLine();

                if (ComprobarMateriaSeleccion(IdSel)) // Comprueba si la materia existe o esta registrado
                {
                    foreach (Seleccion seleccion in listaSeleccion) // Recorre la lista de estudiantes
                    {
                        if (IdSel == seleccion.Materia) // Verifica si el ID coincide con el de la lista
                        {

                            short edit;
                            Console.Write("\nElija la opcion a editar: ");
                            Console.WriteLine("----------------------------------");
                            Console.WriteLine("1. Materia\n2. Seccion\n3. Horario\n4. Aula");
                            Console.SetCursorPosition(26, 1);
                            edit = byte.Parse(Console.ReadLine());


                            switch (edit)
                            {
                                case 1:
                                    string NewName;
                                    Console.Write("Nuevo nombre: ");
                                    NewName = Console.ReadLine();
                                    seleccion.Materia = NewName;
                                    Console.Clear();
                                    break;

                                case 2:
                                    byte NewSection;
                                    Console.Write("Nueva seccion: ");
                                    NewSection = byte.Parse(Console.ReadLine());
                                    seleccion.Seccion = NewSection;
                                    Console.Clear();
                                    break;
                                case 3:
                                    string NewHorarioI, NewHorarioF;
                                    Console.Write("Nueva hora de inicio: ");
                                    NewHorarioI = Console.ReadLine();
                                    Console.Write("Nueva hora de finalizacion: ");
                                    NewHorarioF = Console.ReadLine();

                                    seleccion.HoraInicio = NewHorarioI;
                                    seleccion.HoraFin = NewHorarioF;

                                    Console.Clear();
                                    break;
                                case 4:
                                    string NewCourse;
                                    Console.Write("Nueva aula");
                                    NewCourse = Console.ReadLine();
                                    seleccion.Aula = NewCourse;
                                    break;

                                default:
                                    Program.DefaultOption(startEditSel);
                                    break;


                            }
                            Console.WriteLine("La materia ha sido modificada! ");
                            Console.ReadKey();
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Introduzca un ID valido");
                    startEditSel = true;
                }
            } while (startEditSel);
        }
        public static string seleccion;

        public static bool ComprobarMateriaSeleccion(string IdSel)
        {
            foreach (Seleccion selec in listaSeleccion)
            {
                if(IdSel == selec.Materia)
                {
                    return true;
                }
            }

            return false;
        }
        public static string ComprobarPeriodo()
        {
            Console.Write("Ingrese el año: ");
            string year = Console.ReadLine();
            Console.Write("Escoja el periodo: ");
            Console.WriteLine("1. Febrero-Abril\n2. Mayo-Julio\n3. Agosto-Octubre\n4. Noviembre-Enero");
            Console.SetCursorPosition(19, 1);
            byte trim = byte.Parse(Console.ReadLine());

            string period = Trimestre.ObtenerTrim(trim);

            return $"{period}/{year}";
        }
        public static void MostrarSeleccion()
        {
            Console.Write("Ingrese su ID: ");
            seleccion = Console.ReadLine();
            string periodo = ComprobarPeriodo();
            Console.WriteLine("{0,-10} {1, 25} {2,15} {3,30}", "Materia", "Seccion", "Horario", "Aula");
            foreach (Seleccion selec in listaSeleccion)
            {
                if(seleccion == selec.ID && periodo == selec.Periodo)
                {
                    Console.WriteLine("{0,-10} {1, 25} {2,15} {3,30}", selec.Materia, selec.Seccion, selec.Horario, selec.Aula);
                }
            }
            Console.ReadKey();
        }

        public static void EliminarSeleccion()
        {
            Console.Write("Ingrese su ID, por favor: ");
            seleccion = Console.ReadLine();
            Console.Clear();

            int borrado = listaSeleccion.RemoveAll(BuscarIdSeleccion);
            string periodo = ComprobarPeriodo();
            foreach(Seleccion seleccion in listaSeleccion)
            {
                if (periodo == seleccion.Periodo)
                {
                    if (borrado > 0)
                    {
                        Console.WriteLine("La seleccion ha sido eliminada!");
                    }
                    else
                    {
                        Console.WriteLine("Este ID de estudiante no existe!");
                    }
                }

            }
            
           
        }
        public static bool BuscarIdSeleccion(Seleccion selec)
        {
            if(seleccion == selec.ID)
            {
                return true;
            }

            return false;
        }

        public static void CalificarMateria()
        {
            Console.WriteLine("Ingrese la materia que desea calificar: ");
            string materia = Console.ReadLine();
            Console.WriteLine("Indique la seccion: ");
            byte seccion = byte.Parse(Console.ReadLine());

            foreach(Seleccion seleccion in listaSeleccion)
            {
                if(materia == seleccion.Materia && seccion == seleccion.Seccion)
                {
                    foreach(Estudiante estudiante in RegistroEstudiante.listaEstudiante)
                    {
                        Console.Write($"Ingrese la calificacion de {estudiante.Nombre} - {estudiante.ID}: ");
                        estudiante.Calificacion = int.Parse(Console.ReadLine());
                    }
                }
            }
        }
    }
}
