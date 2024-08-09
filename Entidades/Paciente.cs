using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Paciente
    {
        private string DNI_Pa;
        private string Nombre_Pa;
        private string Apellido_Pa;
        private char Sexo_Pa;
        private string Nacionalidad_Pa;
        private DateTime Fecha_Nacimiento_Pa;
        private string Direccion_Pa;
        private string ID_Localidad;
        private string Correo_Pa;
        private string Telefono_Pa;
        private string Id_Usuario;
        private bool estado;

        public Paciente() { }

        public string getDNIPa()
        {
            return DNI_Pa;
        }

        public void setDNIPa(string dniPa)
        {
            DNI_Pa = dniPa;
        }

        public string getNombrePa()
        {
            return Nombre_Pa;
        }

        public void setNombrePa(string nombrePa)
        {
            Nombre_Pa = nombrePa;
        }

        public string getApellidoPa()
        {
            return Apellido_Pa;
        }

        public void setApellidoPa(string apellidoPa)
        {
            Apellido_Pa = apellidoPa;
        }

        public char getSexoPa()
        {
            return Sexo_Pa;
        }

        public void setSexoPa(char sexoPa)
        {
            Sexo_Pa = sexoPa;
        }

        public string getNacionalidadPa()
        {
            return Nacionalidad_Pa;
        }

        public void setNacionalidadPa(string nacionalidadPa)
        {
            Nacionalidad_Pa = nacionalidadPa;
        }

        public DateTime getFechaNacimientoPa()
        {
            return Fecha_Nacimiento_Pa;
        }

        public void setFechaNacimientoPa(DateTime fechaNacimientoPa)
        {
            Fecha_Nacimiento_Pa = fechaNacimientoPa;
        }

        public string getDireccionPa()
        {
            return Direccion_Pa;
        }

        public void setDireccionPa(string direccionPa)
        {
            Direccion_Pa = direccionPa;
        }

        public string getIDLocalidad()
        {
            return ID_Localidad;
        }

        public void setIDLocalidad(string idLocalidad)
        {
            ID_Localidad = idLocalidad;
        }

        public string getCorreoPa()
        {
            return Correo_Pa;
        }

        public void setCorreoPa(string correoPa)
        {
            Correo_Pa = correoPa;
        }

        public string getTelefonoPa()
        {
            return Telefono_Pa;
        }

        public void setTelefonoPa(string telefonoPa)
        {
            Telefono_Pa = telefonoPa;
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
