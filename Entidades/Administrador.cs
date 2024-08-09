using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Administrador
    {
        public string legajo { get; set; }
        public string Nombre { get; set; }
        public string Contraseña { get; set; }
        public string IdUsuario { get; set; }

        public Administrador() { }

        public string getLegajo()
        {
            return legajo;
        }
    }
}
