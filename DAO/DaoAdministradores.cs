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
    public class DaoAdministradores
    {
        AccesoDatos ds = new AccesoDatos();

        public DaoAdministradores() { }

        public DataTable getAdministradores()
        {
            string consulta = "Select * from Administradores";
            DataTable dt =  ds.ObtenerTabla("Administradores", consulta);
            return dt;
        }

        public Administrador GetAdministrador(string IdUsuario)
        {
            string consulta = "Select * from Administrador where Id_Usuario = '" + IdUsuario + "'";
            DataTable dt = ds.ObtenerTabla("Administradores", consulta);
            Administrador admin = new Administrador();
            admin.legajo = dt.Rows[0][0].ToString();
            admin.Nombre = dt.Rows[0][1].ToString();
            admin.Contraseña = dt.Rows[0][2].ToString();
            admin.IdUsuario = dt.Rows[0][3].ToString();
            return admin;
        }
    }
}
