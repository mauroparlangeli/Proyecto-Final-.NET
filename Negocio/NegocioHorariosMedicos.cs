using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Entidades;
using DAO;

namespace Negocio
{
    public class NegocioHorariosMedicos
    {
        DaoHorariosMedicos daoHorariosMedicos = new DaoHorariosMedicos();

        public NegocioHorariosMedicos() { }

        public DataTable getHorariosMedicos()
        {
            DataTable dt = daoHorariosMedicos.getHorariosMedicos();
            return dt;
        }

        public bool AgregarHorarioMedico(string legajo, int DiaSemana, TimeSpan HoraInicio, TimeSpan HoraFin)
        {
            HorariosMedicos horario = new HorariosMedicos();
            horario.Legajo_Med = legajo;
            horario.Dia = DiaSemana;
            horario.Hora_Inicio = HoraInicio;
            horario.Hora_Fin = HoraFin;
            return daoHorariosMedicos.AgregarHorarioMedico(horario) == 1;
        }
    }
}
