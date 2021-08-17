using System;
using System.Collections.Generic;

#nullable disable

namespace Tienda.Models.Modelos
{
    public partial class AuthUser
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public string Email { get; set; }
        public string Pwd { get; set; }
        public string salt { get; set; }
        public byte[] Password { get; set; }
        public byte[] saltt { get; set; }
    }
}
