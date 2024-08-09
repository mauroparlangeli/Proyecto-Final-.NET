using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Turnos
    {
        private int Nro_Turno;
        private string DNI_Paciente;
        private string Legajo_Med;
        private string fecha;
        private string horario;
        private string Obvservaciones;
        private bool Asistencia;

        public Turnos() { }

        public int GetNro_Turno()
        {
            return Nro_Turno;
        }

        public void setNro_Turno(int NroTurno)
        {
            Nro_Turno = NroTurno;
        }

        public string GetDNI_Paciente()
        {
            return DNI_Paciente;
        }

        public void setDNI_Paciente(string DNIPaciente)
        {
            DNI_Paciente = DNIPaciente;
        }

        public string GetLegajo_Med()
        {
            return Legajo_Med;
        }

        public void setLegajo_Med(string LegajoMed)
        {
            Legajo_Med = LegajoMed;
        }

        public string Getfecha()
        {
            return fecha;
        }

        public void setfecha(string Fecha)
        {
            fecha = Fecha;
        }

        public string Gethorario()
        {
            return horario;
        }

        public void sethorario(string Horario)
        {
            horario = Horario;
        }

        public string GetObvservaciones()
        {
            return Obvservaciones;
        }

        public void setObvservaciones(string obvservaciones)
        {
            Obvservaciones = obvservaciones;
        }

        public bool GetAsistencia()
        {
            return Asistencia;
        }

        public void setAsistencia(bool asistencia)
        {
            Asistencia = asistencia;
        }


    }




}
