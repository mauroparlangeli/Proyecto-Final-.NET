using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAO;
using Entidades;

namespace Negocio
{
    public class NegocioLocalidades
    {
        DaoLocalidades daoLoc = new DaoLocalidades();

        public NegocioLocalidades() { }

        public DataTable getLocalidades()
        {
            DataTable dt = daoLoc.getLocalidades();
            return dt;
        }

        public DataTable GetLocalidadesPorProvincia(string Id_Provincia)
        {
            return daoLoc.GetLocalidadesPorProvincia(Id_Provincia);
        }

        public DataTable GetProvinciaPorLocalidades(string Id_Localidad)
        {
            return daoLoc.GetProvinciaPorLocalidades(Id_Localidad);
        }
    }
}
