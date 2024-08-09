using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entidades;

namespace DAO
{
    public class DaoHorariosMedicos
    {
        AccesoDatos ds = new AccesoDatos();
        public DaoHorariosMedicos() { }

        public DataTable getHorariosMedicos()
        {
            string consulta = "Select * from HorariosMedicos";
            DataTable dt = ds.ObtenerTabla("HorariosMedicos", consulta);
            return dt;
        }

        public int AgregarHorarioMedico(HorariosMedicos horario)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosHorarioMedico(ref comando, horario);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spAgregarHorarioMedico");
        }

        private void ArmarParametrosHorarioMedico(ref SqlCommand Comando, HorariosMedicos horario)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@Legajo_Med", SqlDbType.Char, 6);
            SqlParametros.Value = horario.Legajo_Med;
            SqlParametros = Comando.Parameters.Add("@Dia_Semana", SqlDbType.TinyInt);
            SqlParametros.Value = horario.Dia;
            SqlParametros = Comando.Parameters.Add("@Hora_Inicio", SqlDbType.Time);
            SqlParametros.Value = horario.Hora_Inicio;
            SqlParametros = Comando.Parameters.Add("@Hora_Fin", SqlDbType.Time);
            SqlParametros.Value = horario.Hora_Fin;
        }
    }
}
