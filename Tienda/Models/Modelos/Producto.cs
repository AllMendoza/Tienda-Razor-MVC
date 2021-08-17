using System;
using System.Collections.Generic;

#nullable disable

namespace Tienda.Models.Modelos
{
    public partial class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Sku { get; set; }
        public bool Status { get; set; }
    }
}
