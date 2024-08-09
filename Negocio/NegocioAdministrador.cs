using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Entidades;

namespace Negocio
{
    public class NegocioAdministrador
    {
        DaoAdministradores daoAdministradores = new DaoAdministradores();

        public NegocioAdministrador() { }

        public DataTable getAdministradores()
        {
            DataTable dt = daoAdministradores.getAdministradores();
            return dt;
        }

        public Administrador getAdministrador(string Id_Usuario)
        {
            return daoAdministradores.GetAdministrador(Id_Usuario);
        }
    }
}
