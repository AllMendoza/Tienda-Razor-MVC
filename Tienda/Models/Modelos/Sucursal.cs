using System;
using System.Collections.Generic;

#nullable disable

namespace Tienda.Models.Modelos
{
    public partial class Sucursal
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public bool Status { get; set; }
    }
}
