using System;
using System.Collections.Generic;
using System.Text;

namespace INTENTO2
{
    class pantallas
    {
        public void pantalla1()
        {
            for (int i = 1; i < 110; i++)
            {
                Console.SetCursorPosition(i, 0); Console.Write("▒");
                Console.SetCursorPosition(i, 22); Console.Write("═");
                Console.SetCursorPosition(i, 25); Console.Write("▒");

            }
            for (int i = 0; i <= 25; i++)

            {
                Console.SetCursorPosition(1, i); Console.Write("░");
                Console.SetCursorPosition(110, i); Console.Write("░");

            }

            Console.SetCursorPosition(10, 21); Console.Write(" PLAN DE MEJORAMIENTO");
            Console.SetCursorPosition(10, 23); Console.WriteLine("Centro de Gestión de Mercados, Logística y Tecnologías de la Información");
        }


        public void pantalla2()
        {

            for (int i = 1; i < 110; i++)
            {
                Console.SetCursorPosition(i, 0); Console.Write("▒");

                Console.SetCursorPosition(i, 25); Console.Write("▒");

            }
            for (int i = 0; i <= 25; i++)
            {
                Console.SetCursorPosition(1, i); Console.Write("░");
                Console.SetCursorPosition(110, i); Console.Write("░");

            }

        }


    }
}