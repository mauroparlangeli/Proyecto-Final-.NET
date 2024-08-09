using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Medico
    {
        private string Legajo_Med { get; set;}
        private string DNI_Med;
        private string Nombre_Med;
        private string Apellido_Med;
        private char Sexo_Med;
        private string Nacionalidad_Med;
        private DateTime Fecha_Nacimiento_Med;
        private string Dirección_Med;
        private string Id_Localidad;
        private string Correo_Med;
        private string Telefono_Med;
        private string Especialidad;
        private string Id_Usuario;
        private bool estado;

        public Medico() { }

        public string getLegajoMed()
        {
            return Legajo_Med;
        }

        public void setLegajoMed(string legajoMed)
        {
            Legajo_Med = legajoMed;
        }

        public string getDNIMed()
        {
            return DNI_Med;
        }

        public void setDNIMed(string dniMed)
        {
            DNI_Med = dniMed;
        }

        public string getNombreMed()
        {
            return Nombre_Med;
        }

        public void setNombreMed(string nombreMed)
        {
            Nombre_Med = nombreMed;
        }

        public string getApellidoMed()
        {
            return Apellido_Med;
        }

        public void setApellidoMed(string apellidoMed)
        {
            Apellido_Med = apellidoMed;
        }

        public char getSexoMed()
        {
            return Sexo_Med;
        }

        public void setSexoMed(char sexoMed)
        {
            Sexo_Med = sexoMed;
        }

        public string getNacionalidadMed()
        {
            return Nacionalidad_Med;
        }

        public void setNacionalidadMed(string nacionalidadMed)
        {
            Nacionalidad_Med = nacionalidadMed;
        }

        public DateTime getFechaNacimientoMed()
        {
            return Fecha_Nacimiento_Med;
        }

        public void setFechaNacimientoMed(DateTime fechaNacimientoMed)
        {
            Fecha_Nacimiento_Med = fechaNacimientoMed;
        }

        public string getDireccion()
        {
            return Dirección_Med;
        }

        public void setDireccion(string direccion)
        {
            Dirección_Med = direccion;
        }

        public string getIdLocalidad()
        {
            return Id_Localidad;
        }

        public void setIdLocalidad(string idLocalidad)
        {
            Id_Localidad = idLocalidad;
        }

        public string getCorreoMed()
        {
            return Correo_Med;
        }

        public void setCorreoMed(string correoMed)
        {
            Correo_Med = correoMed;
        }

        public string getTelefonoMed()
        {
            return Telefono_Med;
        }

        public void setTelefonoMed(string telefonoMed)
        {
            Telefono_Med = telefonoMed;
        }

        public string getEspecialidad()
        {
            return Especialidad;
        }

        public void setEspecialidad(string especialidad)
        {
            Especialidad = especialidad;
        }

        public string getIdUsuario()
        {
            return Id_Usuario;
        }

        public void setIdUsuario(string idUsuario)
        {
            Id_Usuario = idUsuario;
        }

        public bool getEstado()
        {
            return estado;
        }

        public void setEstado(bool estado)
        {
            this.estado = estado;
        }

    }
}

