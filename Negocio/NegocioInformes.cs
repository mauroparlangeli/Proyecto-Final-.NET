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
    public class NegocioInformes
    {
        DaoInformes InformesDao = new DaoInformes();
        public DataTable ObtenerCantidadPacientesPorLocalidad()
        {
            DataTable informe = InformesDao.ObtenerCantidadPacientesPorLocalidad();
            return informe;
        }

        public DataTable ObtenerPromedioEdadPacientes()
        {
            DataTable informe = InformesDao.ObtenerPromedioEdadPacientes();
            return informe;
        }
        public DataTable ObtenerTurnosMedicos(string legajo)
        {
            DataTable informe = InformesDao.ObtenerTurnosMedicos(legajo);
            return informe;
        }
        public DataTable ObtenerPacientesDadosDeBaja()
        {
            DataTable informe = InformesDao.ObtenerPacientesDadosDeBaja();
            return informe;
        }
        public DataTable ObtenerMedicosDadosDeBaja()
        {
            DataTable informe = InformesDao.ObtenerMedicosDadosDeBaja();
            return informe;
        }
    }
}
