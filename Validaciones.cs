using System;

using System.Text.RegularExpressions;

namespace INTENTO2
{
    class Validaciones
    {
        public bool Vacio(string texto)
        {
            if (texto.Equals(""))
            {
                Console.WriteLine(" .... Deje de dar ENTER ....");
                return true;
            }
            else
                return false;
        }

        public bool Numero(string texto)
        {
            Regex regla = new Regex("[0-9]{1,9}(\\.[0-9]{0,2})?$");

            if (regla.IsMatch(texto))
                return true;
            else
            {
                Console.WriteLine(".....No Ingrese LETRAS !!!! .....");
                return false;
            }

        }


        public bool TipoTexto(string texto)
        {
            Regex regla = new Regex("^[a-zA-Z ]*$");

            if (regla.IsMatch(texto))
                return true;
            else
            {
                Console.WriteLine(" ... No ingrese NUMEROS !!!! ...");
                return false;
            }
        }

    }
}
