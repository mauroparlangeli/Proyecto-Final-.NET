using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using System.Data;
using Entidades;

namespace Negocio
{
    public class NegocioTurnos
    {
        DaoTurnos daoTur = new DaoTurnos();
        Turnos tur = new Turnos();
        DaoPacientes daoPac = new DaoPacientes();
        DaoMedicos daoMed = new DaoMedicos();
       
        public DataTable obtenerTablaTurnos()
        {
            return daoTur.getTablaTurnos();
        }

        public Turnos obtenerTurno(int nroTurno)
        {
            tur.setNro_Turno(nroTurno);
            return daoTur.GetTurnos(tur);
        }

        public bool ExisteTurno(Turnos Turno)
        {
            return daoTur.ExisteTurno(Turno);
        }
        public bool TurnoOcupado(Turnos Turno)
        {
            return daoTur.TurnoOcupado(Turno);
        }

        public DataTable obtenerEspecialidad()
        {
            return daoMed.obtenerEspecialidad();
        }

        public DataTable obtenerMedico(string id)
        {
            return daoMed.obtenerMedicoXEspecialidad(id);
        }

        public bool agregarTurno(Turnos turno)
        {
            return daoTur.agregarTurno(turno);
        }

        public bool ModificarTurno(int Nro_Turno, string DNI_Paciente, string Legajo_Med, string fecha, string horario, string Obvservaciones, bool Asistencia)
        {
            Turnos turnos = new Turnos();
            turnos.setNro_Turno(Nro_Turno);
            turnos.setDNI_Paciente(DNI_Paciente);
            turnos.setLegajo_Med(Legajo_Med);
            turnos.setfecha(fecha);
            turnos.sethorario(horario);
            turnos.setObvservaciones(Obvservaciones);
            turnos.setAsistencia(Asistencia);
            return daoTur.ModificarTurno(turnos);
        }

    }
}
