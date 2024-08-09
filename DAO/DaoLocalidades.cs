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
    public class DaoLocalidades
    {
        AccesoDatos ds = new AccesoDatos();

        public DaoLocalidades() { }

        public DataTable getLocalidades()
        {
            string consulta = "Select * from Localidades";
            DataTable dt =  ds.ObtenerTabla("Localidades", consulta);
            return dt;
        }
        public DataTable GetLocalidadesPorProvincia(string Id_Provincia)
        {
            string consulta = "Select * from Localidades l inner join provincias prov on l.ID_provincias = prov.ID_provincia where Id_Provincia = '" + Id_Provincia + "'";
            DataTable dt = ds.ObtenerTabla("Localidades", consulta);
            return dt;
        }
        
        public DataTable GetProvinciaPorLocalidades(string Id_Localidad)
        {
            string consulta = "Select * from Provincias p inner join Localidades l on p.ID_provincia = l.ID_provincias where Id_Localidad = '" + Id_Localidad + "'";
            DataTable dt = ds.ObtenerTabla("Provincias", consulta);
            return dt;
        }
    }
}
