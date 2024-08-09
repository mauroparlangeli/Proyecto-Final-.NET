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
    public class NegocioProvincias
    {
        public DataTable GetProvincias()
        {
            DaoProvincias daoProvincias = new DaoProvincias();
            return daoProvincias.GetProvincias();
        }   
    }
}
