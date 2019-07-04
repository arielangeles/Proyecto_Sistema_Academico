using System;
using System.Collections.Generic;

namespace ProyFinal
{
    class Program
    {
        public static bool start = true, success, opcionValida, startAsign, startMenuStudent, startSelection, startStud, startMenuProfessor, startProf, startQualification; // Bools para cada menu
        public static string menu; // variable para el metodo MenuOption
        public static int result;
        public static void MenuOption()
        {
            Console.Write("\nInserte la opcion deseada: ");
            menu = Console.ReadLine();
            success = int.TryParse(menu, out result);
            if (success == true){}
            else
            {
                Console.WriteLine("Inserte una opcion valida");
                Console.ReadKey();
            }

        }  // Opcion para todos los menus
        public static void DefaultOption(bool start)
        {
            if (success == false){}
            else
            {
                Console.WriteLine("\nIngrese un numero que se encuentre en las opciones");
                Console.ReadKey();
            }

        } // Opcion default para todos los menus
        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                Console.WriteLine("|-----------------------------------------------------|");
                Console.WriteLine("|  ================================================   |");
                Console.WriteLine("|  ///// Bienvenido al Sistema Academico /////////    |");
                Console.WriteLine("|  ================================================   |");
                Console.WriteLine("|-----------------------------------------------------|");
                Console.WriteLine("|\t1. Sistema de estudiantes                     |\n" +
                                  "|\t2. Sistema de profesor                        |\n" +
                                  "|\t3. Registro de asignaturas                    |\n" +
                                  "|\t4. Salir                                      |");
                Console.WriteLine("|-----------------------------------------------------|");
                MenuOption(); 

                switch (result)
                {
                    case 1:
                        MenuEstudiante();
                        break;
                    case 2:
                        MenuProfesor();
                        break;
                    case 3:
                        RegistroDeAsignatura();
                        break;
                    case 4:
                        start = false;
                        break;
                    default:
                        DefaultOption(start);
                        break;
                }
            } while (start);
        }

        public static void MenuEstudiante()
        {

                do
                {
                    Console.Clear();
                    Console.WriteLine("================================================");
                    Console.WriteLine("||||| Bienvenido al sistema de Estudiantes |||||");
                    Console.WriteLine("================================================");
                    Console.WriteLine("1. Registro de estudiantes\n2. Seleccion\n3. Preseleccion\n4. Evaluacion Profesoral\n5. Volver al inicio");
                    MenuOption();

                    switch (result)
                    {
                        case 1:
                            RegistroDeEstudiantes();
                            break;
                        case 2:
                            Seleccion();
                            break;
                        case 3:
                            //Preseleccion();
                            break;
                        case 4:
                            //EvaluacionProfesoral();
                            break;
                        case 5:
                            startMenuStudent = false;
                            break;
                        default:
                            DefaultOption(startMenuStudent);
                            break;
                    }

                } while (startMenuStudent);

            
        }
        public static void RegistroDeEstudiantes()
        {
            do
            {
                startStud = true;
                Console.Clear();
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine("||||| Bienvenido al registro de Estudiantes |||||");
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine("1. Ver lista de estudiantes\n2. Registrar Estudiante\n3. Editar estudiante\n4. Eliminar Estudiante\n5. Volver atras\n6. Volver al inicio");
                MenuOption();


                switch (result)
                {
                    case 1:
                        RegistroEstudiante.MostrarEstudiante(); // Muestra lista de estudiantes
                        break;
                    case 2:
                        Estudiante estudiante = new Estudiante();
                        RegistroEstudiante.RegistrarEstudiante(estudiante); // Registra cada estudiante
                        break;
                    case 3:
                        RegistroEstudiante.EditarEstudiante(); // Edita cada informacion de cada estudiante
                        break;
                    case 4:
                        RegistroEstudiante.EliminarEstudiante(); // Elimina estudiante seleccionado
                        break;
                    case 5:
                        startMenuStudent = true;
                        startStud = false;
                        break;
                    case 6:
                        startStud = false;
                        break;
                    default:
                        DefaultOption(startStud);
                        break;
                }

            } while (startStud);

       
        }
        public static void MenuProfesor()
        {
            do
            {
                startMenuProfessor = true;
                Console.Clear();
                Console.WriteLine("================================================");
                Console.WriteLine(@"\\\\\ Bienvenido al sistema de profesores \\\\\");
                Console.WriteLine("================================================");
                Console.WriteLine("1. Listado de profesores\n2. Registro de profesores\n3. Sistema de calificaciones\n4. Ver Evaluacion Profesoral\n5. Volver al inicio");
                MenuOption();

                switch (result)
                {
                    case 1:
                        RegistroProfesores.MostrarProfesor();
                        break;
                    case 2:
                        RegistroDeProfesores();
                        break;
                    case 3:
                        SistemaCalificaciones();
                        break;
                    case 4:
                        //MostrarEvaluacionProfesoral();
                        break;
                    case 5:
                        startMenuProfessor = false;
                        break;
                    default:
                        DefaultOption(startMenuProfessor);
                        break;
                }

            } while (startMenuProfessor);


        }

        public static void SistemaCalificaciones()
        {
            do
            {
                startQualification = true;
                Console.Clear();
                Console.WriteLine("----------------------------------------------------");
                Console.WriteLine(@"\\\\\ Bienvenido al sistema de calificaciones \\\\\");
                Console.WriteLine("----------------------------------------------------");
                Console.WriteLine("1. Listado de calificaciones\n2. Calificar materia\n3. Volver al inicio");
                MenuOption();

                switch (result)
                {
                    case 1:
                        //RegistroProfesores.MostrarProfesor();
                        break;
                    case 2:
                        RegistroSeleccion.CalificarMateria();
                        break;
                    case 3:
                        //SistemaCalificaciones();
                        break;
                    case 4:
                        //MostrarEvaluacionProfesoral();
                        break;
                    case 5:
                        startQualification = false;
                        break;
                    default:
                        DefaultOption(startMenuProfessor);
                        break;
                }

            } while (startQualification);
        }
        public static void RegistroDeAsignatura()
        {
            do
            {
                startAsign = true;
                Console.Clear();
                Console.WriteLine("------------------------------------------");
                Console.WriteLine("Bienvenido al registro de Asignaturas");
                Console.WriteLine("------------------------------------------");
                Console.WriteLine("1. Ver lista de asignaturas\n2. Registrar asignatura\n3. Editar asignatura\n4. Eliminar asignatura\n5. Volver al inicio");
                MenuOption();

                switch (result)
                {
                    case 1:
                        RegistroAsignatura.MostrarAsignatura();
                        break;
                    case 2:
                        Asignatura asignatura = new Asignatura();
                        RegistroAsignatura.RegistrarAsignatura(asignatura);
                        break;
                    case 3:
                        RegistroAsignatura.EditarAsignatura();
                        break;
                    case 4:
                        RegistroAsignatura.EliminarAsignatura();
                        break;
                    case 5:
                        startAsign = false;
                        break;
                    default:
                        DefaultOption(startAsign);
                        break;
                }
            } while (startAsign);
        }
        public static void RegistroDeProfesores()
        {
            do
            {
                startProf = true;
                Console.Clear();
                Console.WriteLine("------------------------------------------");
                Console.WriteLine("\tBienvenido al registro de profesores");
                Console.WriteLine("------------------------------------------");
                Console.WriteLine("1. Registrar profesor\n2. Editar profesor\n3. Eliminar profesor\n4. Volver atras\n5. Volver al inicio");
                MenuOption();


                switch (result)
                {
                    case 1:
                        Profesor profesor = new Profesor();
                        RegistroProfesores.RegistrarProfesor(profesor);
                        break;
                    case 2:
                        RegistroProfesores.EditarProfesor();
                        break;
                    case 3:
                        RegistroProfesores.EliminarProfesor();
                        break;
                    case 4:
                        startProf = false;
                        break;
                    case 5:
                        startProf = false;
                        startMenuProfessor = false;
                        break;
                    default:
                        DefaultOption(startProf);
                        break;
                }

            } while (startProf);
        }
        public static void Seleccion()
        {
            do
            {
                startSelection = true;
                Seleccion seleccion = new Seleccion();
                Console.Clear();
                Console.WriteLine("\tBienvenido al sistema de seleccion");
                Console.WriteLine("1. Ver seleccion\n2. Registrar seleccion\n3. Modificar seleccion\n4. Eliminar seleccion\n5. Volver atras");
                MenuOption();
                Console.Clear();

                switch (result)
                {
                    case 1:
                        RegistroSeleccion.MostrarSeleccion();
                        break;
                    case 2:
                        RegistroSeleccion.RegistrarSeleccion(seleccion);
                        break;
                    case 3:
                        RegistroSeleccion.ModificarSeleccion();
                        break;
                    case 4:
                        RegistroSeleccion.EliminarSeleccion();
                        break;
                    case 5:
                        startMenuStudent = true;
                        startSelection = false;
                        break;

                }

            } while (startSelection);
            
        }


    }
}
