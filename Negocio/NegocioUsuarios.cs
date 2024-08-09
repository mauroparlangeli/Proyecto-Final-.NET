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
    public class NegocioUsuarios
    {

        public bool validarUsuario(string NombreUsuario, string contraseña)
        {
            DAOusuarios DAOusuarios = new DAOusuarios();
            return DAOusuarios.validarUsuario(NombreUsuario, contraseña);
        }

        public bool getTipoUsuario(string NombreUsuario)
        {
            DAOusuarios DAOusuarios = new DAOusuarios();
            return DAOusuarios.getTipoUsuario(NombreUsuario);
        }

        public bool ExisteUsuario(string NombreUsuario)
        {
            DAOusuarios DAOusuarios = new DAOusuarios();
            return DAOusuarios.ExisteUsuario(NombreUsuario);
        }

        public bool agregarUsuario(string NombreUsuario, string contraseña, string Tipo)
        {
            bool TipoUsuario = false;
            int IdUsuario = ContarUsuarios() + 1;
            DAOusuarios DAOusuarios = new DAOusuarios();

            Usuarios usuario = new Usuarios();
            usuario.IdUsuario = IdUsuario.ToString();
            usuario.NombreUsuario = NombreUsuario;
            usuario.Contraseña = contraseña;
            usuario.TipoUsuario = TipoUsuario;

            DAOusuarios.agregarUsuario(usuario);//crear usuario
            return true;
        }

        //public bool crearUsuarioMedico

        public int ContarUsuarios()
        {
            DAOusuarios DAOusuarios = new DAOusuarios();
            return DAOusuarios.ContarUsuarios();
        }

        public Usuarios GetUsuario(string NombreUsuario)
        {
            DAOusuarios DAOusuarios = new DAOusuarios();
            return DAOusuarios.GetUsuario(NombreUsuario);
        }


    }
}

