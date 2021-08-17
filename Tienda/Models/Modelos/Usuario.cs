using System;
using System.Collections.Generic;

#nullable disable

namespace Tienda.Models.Modelos
{
    public partial class Usuario
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastLogin { get; set; }
        public bool Status { get; set; }
        public string Role { get; set; }
    }
}
