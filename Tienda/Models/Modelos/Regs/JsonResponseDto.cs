using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tienda.Models.Modelos.Regs
{
    public class JsonResponseDto
    {
        public int code { get; set; }
        public dynamic message { get; set; }
        public dynamic data { get; set; }
    }
}
