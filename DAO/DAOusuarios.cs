using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DAOusuarios
    {
        AccesoDatos ds = new AccesoDatos();

        public Usuarios GetUsuario(string NombreUsuario)
        {
            string consulta = "Select * from usuarios where Nombre_Usuario = '" + NombreUsuario + "'";
            DataTable tabla = ds.ObtenerTabla("usuarios", consulta);

            if (tabla.Rows.Count > 0)
            {
                Usuarios usuarios = new Usuarios();
                usuarios.IdUsuario = tabla.Rows[0][0].ToString();
                usuarios.NombreUsuario = tabla.Rows[0][1].ToString();
                usuarios.Contraseña = tabla.Rows[0][2].ToString();
                usuarios.TipoUsuario = Convert.ToBoolean(tabla.Rows[0][3]);
                return usuarios;
            }
            else
            {
                return null;
            }
        }

        public bool validarUsuario(string NombreUsuario, string contraseña)
        {
            string consulta = "Select * from usuarios where Nombre_Usuario = '" + NombreUsuario + "'";
            return ds.existe(consulta);
        }

        public bool ExisteUsuario(string NombreUsuario)
        {
            string consulta = "Select * from usuarios where Nombre_Usuario = '" + NombreUsuario + "'";
            return ds.existe(consulta);
        }

        public bool getTipoUsuario(string NombreUsuario)
        {
            string consulta = "Select Tipo_Usuario from usuarios where Nombre_Usuario = '" + NombreUsuario + "'";
            return Convert.ToBoolean(ds.ObtenerTabla("usuarios", consulta).Rows[0][0]);

        }

        public int ContarUsuarios()
        {
            string consulta = "Select count(*) from usuarios";
            return Convert.ToInt32(ds.ObtenerTabla("usuarios", consulta).Rows[0][0]);
        }

        public int agregarUsuario(Usuarios usuario)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosUsuario(ref comando, usuario);
            return ds.EjecutarProcedimientoAlmacenado(comando, "SpAgregarUsuario");
        }

        private void ArmarParametrosUsuario(ref SqlCommand Comando, Usuarios Usuario)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@Id_Usuario", SqlDbType.Char, 6);
            SqlParametros.Value = Usuario.IdUsuario.ToString();
            SqlParametros = Comando.Parameters.Add("@Nombre_Usuario", SqlDbType.VarChar, 20);
            SqlParametros.Value = Usuario.NombreUsuario;
            SqlParametros = Comando.Parameters.Add("@contrasena_usuario", SqlDbType.VarChar, 20);
            SqlParametros.Value = Usuario.Contraseña;
            SqlParametros = Comando.Parameters.Add("@Tipo_Usuario", SqlDbType.Bit);
            SqlParametros.Value = Usuario.TipoUsuario;
        }
    }
}
