using System;
using System.Collections.Generic;

#nullable disable

namespace Tienda.Models.Modelos
{
    public partial class Error
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Mensaje { get; set; }
        public int Codigo { get; set; }
    }
}
