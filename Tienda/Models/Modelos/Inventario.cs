using System;
using System.Collections.Generic;

#nullable disable

namespace Tienda.Models.Modelos
{
    public partial class Inventario
    {
        public int Id { get; set; }
        public int IdSucursal { get; set; }
        public int IdProducto { get; set; }
        public bool Status { get; set; }
    }
}
