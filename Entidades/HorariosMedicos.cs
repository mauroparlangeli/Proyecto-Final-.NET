using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class HorariosMedicos
    {
        public string Legajo_Med { get; set; }
        public int Dia { get; set; }
        public TimeSpan Hora_Inicio { get; set; }
        public TimeSpan Hora_Fin { get; set; }

        public HorariosMedicos()
        {
        }
    }
}
