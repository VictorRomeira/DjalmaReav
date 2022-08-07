using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DjalmaReav.Models
{
    public class Registro
    {
        public string id { get; set; }
        public string tamanho { get; set; }
        public string cor { get; set; }
        public string tipo { get; set; }
        public string estampa { get; set; }

        public string idusuario { get; set; }
    }
}