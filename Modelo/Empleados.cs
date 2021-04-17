using System;
using System.Collections.Generic;

namespace INTENTO2.Modelo
{
    public partial class Empleados
    {
        public uint Cedula { get; set; }
        public string Nombre { get; set; }
        public int Salario { get; set; }
        public int Dias { get; set; }
        public int VacacionesPagar { get; set; }
    }
}
