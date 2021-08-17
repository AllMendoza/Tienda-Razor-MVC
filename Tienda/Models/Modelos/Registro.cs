using System;
using System.Collections.Generic;

#nullable disable

namespace Tienda.Models.Modelos
{
    public partial class Registro
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Movimiento { get; set; }
        public string DatoAnterior { get; set; }
        public string DatoCambiado { get; set; }
        public DateTime Date { get; set; }
    }
}
