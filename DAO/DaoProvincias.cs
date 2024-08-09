using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAO;

namespace DAO
{
    public class DaoProvincias
    {
        AccesoDatos ds = new AccesoDatos();
        public DataTable GetProvincias()
        {
            return ds.ObtenerTabla("Provincias", "SELECT * FROM Provincias");
        }
    }
}
