using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DAO;
using Entidades;

namespace Negocio
{
    public class NegocioMedicos
    {
        DaoMedicos daoMed = new DaoMedicos();

        public DataTable ObtenerEspecialidades()
        {
            return daoMed.obtenerEspecialidad();
        }

        public DataTable ObtenerMedicos()
        {
            return daoMed.getTablaMedico();
        }

        public Medico GetMedico(string legajo)
        {
            Medico med = new Medico();
            med.setLegajoMed(legajo);
            return daoMed.GetMedico(med);
        }

        public bool ExisteMedico(string Dni)
        {
            Medico med = new Medico();
            med.setDNIMed(Dni);
            return daoMed.ExisteMedico(med);
        }

        public Medico ObtenerMedicoXUsuario(string Id_Usuario)
        {
            Medico med = new Medico();
            med.setIdUsuario(Id_Usuario);
            return daoMed.ObtenerMedicoxIdUsuario(med);
        }

        public bool EliminarMedico(string legajo)
        {
            Medico med = new Medico();
            med.setLegajoMed(legajo);
            int op = daoMed.eliminarMedico(med);
            return op == 1;
        }

        public bool AgregarMedico(string legajo, string dni, string nombre, string apellido, char sexo, string nacionalidad, DateTime fechaNacimiento, string direccion, string idLocalidad, string correo, string telefono, string especialidad, bool estado)
        {
            int cantFilas = 0;
            Medico med = new Medico();
            med.setLegajoMed(legajo);
            med.setDNIMed(dni);
            med.setNombreMed(nombre);
            med.setApellidoMed(apellido);
            med.setSexoMed(sexo);
            med.setNacionalidadMed(nacionalidad);
            med.setFechaNacimientoMed(fechaNacimiento);
            med.setDireccion(direccion);
            med.setIdLocalidad(idLocalidad);
            med.setCorreoMed(correo);
            med.setTelefonoMed(telefono);
            med.setEspecialidad(especialidad);
            med.setEstado(estado);

            if (!daoMed.ExisteMedico(med))
            {
                cantFilas = daoMed.agregarMedico(med);
            }

            return cantFilas == 1;
        }

        public bool ModificarMedico(string legajo, string dni, string nombre, string apellido, char sexo, string nacionalidad, DateTime fechaNacimiento, string direccion, string idLocalidad, string correo, string telefono, string especialidad, string IdUsuario,bool estado)
        {
            int cantFilas = 0;
            Medico med = new Medico();
            med.setLegajoMed(legajo);
            med.setDNIMed(dni);
            med.setNombreMed(nombre);
            med.setApellidoMed(apellido);
            med.setSexoMed(sexo);
            med.setNacionalidadMed(nacionalidad);
            med.setFechaNacimientoMed(fechaNacimiento);
            med.setDireccion(direccion);
            med.setIdLocalidad(idLocalidad);
            med.setCorreoMed(correo);
            med.setTelefonoMed(telefono);
            med.setEspecialidad(especialidad);
            med.setIdUsuario(IdUsuario);
            med.setEstado(estado);

            cantFilas = daoMed.ModificarMedico(med);

            //if (daoMed.ExisteMedico(med))
            //{
            //    cantFilas = daoMed.ModificarMedico(med);
            //}

            return cantFilas == 1;
        }

        public DataTable GetDiasAtencion(string legajo)
        {
            Medico med = new Medico();
            med.setLegajoMed(legajo);
            return daoMed.GetDiasAtenciosMedicos(med);
        }

        public DataTable GetHorariosAtencion(string legajo, string diaSeleccionado)//obtiene los horarios de atencion del medico en el dia seleccionado
        {
            return daoMed.GetHorariosAtencion(legajo, diaSeleccionado);
        }

        public int ContarLegajos()
        {
            return daoMed.ContarLegajos();
        }

        public int VincularUsuarioMedico(Medico medico)
        {
            return daoMed.VincularUsuarioMedico(medico);
        }
    }
}
