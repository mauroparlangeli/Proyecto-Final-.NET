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
    public class NegocioEspecialidades
    {
        DaoEspecialidad daoEsp = new DaoEspecialidad();

        public NegocioEspecialidades() { }

        public DataTable getEspecialidades()
        {
            DataTable dt = daoEsp.getEspecialidades();
            return dt;
        }
    }
}
