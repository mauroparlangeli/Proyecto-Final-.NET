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
    public class NegocioPacientes
    {
        DaoPacientes daoPac = new DaoPacientes();
        Paciente paciente = new Paciente();

        public DataTable getPacientesEstadoTrue()
        {
            return daoPac.getPacientesEstadoTrue();
        }

        public DataTable getPacientes()
        {
            return daoPac.getPacientes();
        }

        public bool eliminarPaciente(string dni)
        {
            
            paciente.setDNIPa(dni);
            int op = daoPac.eliminarPaciente(paciente);
            if (op == 1)
                return true;
            else
                return false;
        }

        public DataTable FiltrarPacientesPorNombre(string nombre)
        {
            return daoPac.FiltrarPacientesPorNombre(nombre);
        }


        public DataTable obtenerLocalidades()
        {
            return daoPac.getLocalidades();
        }

        public bool agregarPaciente(string dni, string nombre, string apellido, char sexo, string nacionalidad, DateTime fechaNacimiento, string direccion, string idLocalidad, string correo, string telefono, string idUsuario)
        {
            int cantFilas = 0;
            Paciente pac = new Paciente();
            pac.setDNIPa(dni);
            pac.setNombrePa(nombre);
            pac.setApellidoPa(apellido);
            pac.setSexoPa(sexo);
            pac.setNacionalidadPa(nacionalidad);
            pac.setFechaNacimientoPa(fechaNacimiento);
            pac.setDireccionPa(direccion);
            pac.setIDLocalidad(idLocalidad);
            pac.setCorreoPa(correo);
            pac.setTelefonoPa(telefono);
            pac.setIdUsuario(idUsuario);
            pac.setEstado(true);

            if (!daoPac.ExistePaciente(pac))
            {
                cantFilas = daoPac.agregarPaciente(pac);
            }

            return cantFilas == 1;
        }

        public bool ModificarPaciente(string dni, string nombre, string apellido, char sexo, string nacionalidad, DateTime fechaNacimiento, string direccion, string idLocalidad, string correo, string telefono)
        {
            paciente.setDNIPa(dni);
            paciente.setNombrePa(nombre);
            paciente.setApellidoPa(apellido);
            paciente.setSexoPa(sexo);
            paciente.setNacionalidadPa(nacionalidad);
            paciente.setFechaNacimientoPa(fechaNacimiento);
            paciente.setDireccionPa(direccion);
            paciente.setIDLocalidad(idLocalidad);
            paciente.setCorreoPa(correo);
            paciente.setTelefonoPa(telefono);

            int cantFilas = daoPac.modificarPaciente(paciente);
            if (cantFilas == 1)
                return true;
            else
                 return false;
        }

        public bool ExistePaciente(string Dni)
        {
            paciente.setDNIPa(Dni);
            return daoPac.ExistePaciente(paciente);
        }
    }
}
