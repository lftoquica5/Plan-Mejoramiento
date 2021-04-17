using System;
using System.Linq;
using INTENTO2.Modelo;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;


namespace INTENTO2
{
    class Program
    {
        static List<Empleados> ListaEmpleados = new List<Empleados>();
        static Validaciones validar = new Validaciones();
        static pantallas pantallas = new pantallas();

        static void Main(string[] args)
        {
                        
            int opcion;
            int opcionMenu;

            do
            {
                pantallas.pantalla1();
                Console.SetCursorPosition(5, 2); Console.WriteLine("1. AGREGAR EMPLEADO");
                Console.SetCursorPosition(35, 2); Console.WriteLine("2. BUSCAR EMPLEADO");
                Console.SetCursorPosition(65, 2); Console.WriteLine("3. LISTAR EMPLEADO");
                Console.SetCursorPosition(95, 2); Console.WriteLine("0. SALIR");

                Console.SetCursorPosition(42, 7); Console.WriteLine("ELIJA UNA OPCION EN EL MENU");
                Console.SetCursorPosition(55, 10);
                opcion = Convert.ToInt32(Console.ReadLine());
                opcionMenu = Convert.ToInt32(opcion);


                switch (opcionMenu)
                {
                    case 1:
                        AgregarEmpleado();
                        break;
                    case 2:
                        BuscarEmpleado();
                        break;
                    case 3:
                        ListarEmpleados();
                        Console.Clear();
                        break;
                    case 0:
                        Console.WriteLine("saliendo de la aplicacion");
                        break;
                    default:
                        Console.WriteLine("la opcion no es valida");
                        break;

                }

            } while (opcionMenu > 0);


        }


        static void AgregarEmpleado()
        {
            Console.Clear();
            var baseDatos = new planmejoramientoContext();
            string ced, nom, dias;
            double salario1, diasVaca, div, vPagar;
            string sal;


            bool cedulaVal = false;
            bool nombreVal = false;
            bool salariooVal = false;
            bool diasVal = false;

            Console.Clear();
            pantallas.pantalla1();
            Console.SetCursorPosition(38, 2);
            Console.WriteLine(" ...... NUEVO EMPLEADO.....");

            do
            {
                Console.SetCursorPosition(15, 3);
                Console.Write(" Digite cedula del empleado: ");
                ced = Console.ReadLine();
                if (!validar.Vacio(ced))
                    if (validar.Numero(ced))
                        cedulaVal = true;
            } while (!cedulaVal);

            if (Existe(Convert.ToInt32(ced)))
            {

                Console.SetCursorPosition(15, 5);
                Console.WriteLine("El empleado ya exsiste");
                Console.WriteLine(" OPRIMA ENTER PARA VOLVER AL MENU PRINCIPAL");
                Console.ReadKey();
                Console.Clear();

            }

            else
            {

                do
                {
                    Console.SetCursorPosition(15, 4);
                    Console.Write(" Digite el nombre del empleado: ");
                    nom = Console.ReadLine();
                    if (!validar.Vacio(nom))
                        if (validar.TipoTexto(nom))
                            nombreVal = true;


                } while (!nombreVal);


                do
                {
                    Console.SetCursorPosition(15, 5);
                    Console.Write(" Digite el salario del Empleado: ");
                    sal = Console.ReadLine();
                    if (!validar.Vacio(sal))
                        if (validar.Numero(sal))
                            salariooVal = true;
                    salario1 = double.Parse(sal);

                } while (!salariooVal);

                do
                {
                    Console.SetCursorPosition(15, 6);
                    Console.WriteLine("Digite el # de dias de vacaciones");
                    dias = (Console.ReadLine());
                    if (validar.Vacio(dias))
                        if (validar.Numero(dias))
                            diasVal = true;
                    diasVaca = double.Parse(dias);

                } while (diasVal);


                div = salario1 / 30;
                vPagar = div * diasVaca;


                Empleados AUX = new Empleados();
                AUX.Cedula = (uint)Convert.ToInt32(ced);
                AUX.Nombre = nom;
                AUX.Salario = (int)Convert.ToInt32(sal);
                AUX.Dias = (int)Convert.ToInt32(dias);
                AUX.VacacionesPagar = (int)Convert.ToInt32(vPagar);


                baseDatos.Empleados.Add(AUX);
                ListaEmpleados.Add(AUX);
                baseDatos.SaveChanges();
                Console.WriteLine (" OPRIMA ENTER PARA VOLVER AL MENU PRINCIPAL");
                Console.ReadKey();
                Console.Clear();

            }
        }

        static void BuscarEmpleado()
        {
         
            Console.Clear();
            pantallas.pantalla2();
            var baseDatos = new planmejoramientoContext();
            var Empleados = baseDatos.Empleados.ToList();
            string ced;
            bool cedulaVal = false;

            do
            {

                Console.Clear();
                pantallas.pantalla2();
                Console.SetCursorPosition(38, 2);
                Console.WriteLine("---------BUSCAR EMPLEADO---------");
                Console.SetCursorPosition(5, 4);
                Console.WriteLine("DIGITE LA CEDULA DEL EMPLEADO: C.C ");
                Console.SetCursorPosition(5, 5);
                ced = (Console.ReadLine());
                if (!validar.Vacio(ced))
                    if (validar.Numero(ced))
                        cedulaVal = true;
            } while (!cedulaVal);

            if (Existe(Convert.ToInt32(ced)))
            {
                Console.Clear();
                pantallas.pantalla2();
                Console.SetCursorPosition(38, 3);
                Console.WriteLine("--------EMPLEADO ENCONTRADO--------");

                Empleados myEmpleado = ObtenerDatos(Convert.ToInt32(ced));

                Console.SetCursorPosition(6, 6);
                Console.WriteLine("\t Cedula: " + myEmpleado.Cedula);
                Console.SetCursorPosition(5, 9);
                Console.WriteLine("\t Nombre: " + myEmpleado.Nombre);
                Console.SetCursorPosition(5, 10);
                Console.WriteLine("\t Salario: $" + myEmpleado.Salario);
                Console.SetCursorPosition(5, 11);
                Console.WriteLine("\t Dias: " + myEmpleado.Dias);
                Console.SetCursorPosition(5, 12);
                Console.WriteLine("\t Pago Vacaciones: $" + myEmpleado.VacacionesPagar);


            }

            else
            {
                Console.SetCursorPosition(38, 14);
                Console.WriteLine("el empleado no existe");
            }

            Console.SetCursorPosition(5, 20);
            Console.WriteLine(" OPRIMA ENTER PARA VOLVER AL MENU PRINCIPAL");
            Console.ReadKey();
            Console.Clear();
        }

        static bool Existe(int ced)
        {
            Console.Clear();
           var baseDatos = new planmejoramientoContext();
           var Empleados = baseDatos.Empleados.ToList();
            bool aux = false;
            foreach (var myEmpleado in Empleados)
            {
                if (myEmpleado.Cedula == ced)
                    aux = true;
            }
            return aux;
        }
     
        static Empleados ObtenerDatos(int ced)
        {
            var baseDatos = new planmejoramientoContext();
            List<Empleados> Empleados = baseDatos.Empleados.ToList();
            foreach (Empleados ObjetoEmpleados in Empleados)
            {
                if (ObjetoEmpleados.Cedula == ced)
                    return ObjetoEmpleados;
            }
            return null;
        }
        static void ListarEmpleados()
        {

            Console.Clear();
            int y = 5;
            var db = new planmejoramientoContext();
            var empleados = db.Empleados.ToList();


            Console.Clear();
            Console.SetCursorPosition(38, 2);
            Console.WriteLine(" ...... LISTA EMPLEADOS....."); Console.SetCursorPosition(38, 2);

            Console.SetCursorPosition(1, y); Console.Write("CEDULA ");
            Console.SetCursorPosition(20, y); Console.Write("NOMBRE ");
            Console.SetCursorPosition(60, y); Console.WriteLine("SALARIO ");
            Console.SetCursorPosition(75, y); Console.WriteLine("DIAS ");
            Console.SetCursorPosition(100, y); Console.WriteLine("PAGO VACACIONAL");


            foreach (var myEmpleado in empleados)
            {
                y++;
                Console.WriteLine();

                    
                Console.SetCursorPosition(1, y); Console.WriteLine( myEmpleado.Cedula);
                Console.SetCursorPosition(20, y); Console.WriteLine(myEmpleado.Nombre);
                Console.SetCursorPosition(60, y); Console.WriteLine(myEmpleado.Salario);
                Console.SetCursorPosition(75, y); Console.WriteLine( myEmpleado.Dias);
                Console.SetCursorPosition(100, y); Console.WriteLine( myEmpleado.VacacionesPagar);

            }

            Console.WriteLine("\n");
            Console.WriteLine();
            Console.WriteLine(" OPRIMA ENTER PARA VOLVER AL MENU PRINCIPAL");
            Console.ReadKey(); 

               
        }



    }
}

