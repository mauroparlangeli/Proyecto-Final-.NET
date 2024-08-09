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
    public class DaoEspecialidad
    {
        AccesoDatos ds = new AccesoDatos();

        public DaoEspecialidad() { }

        public DataTable getEspecialidades()
        {
            string consulta = "Select * from Especialidades";
            DataTable dt = ds.ObtenerTabla("Especialidades", consulta);
            return dt;
        }
    }
}
