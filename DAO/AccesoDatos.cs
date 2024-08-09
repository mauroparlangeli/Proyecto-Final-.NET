using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace DAO
{
    public class AccesoDatos
    {
        // guarda la ruta de la db
        String rutaBDClinica = "Data Source=DESKTOP-4BUD7K9\\SQLEXPRESS;Initial Catalog=dbClinica;Integrated Security=True";
    

    public AccesoDatos()
    {
    
    }

    private SqlConnection ObtenerConexion ()
    {
        //conexion con la db
        SqlConnection cn = new SqlConnection(rutaBDClinica);
        try
        {
            cn.Open();
            return cn;
        }
        catch(Exception ex)
        {
            return null;
        }

    }

    private SqlDataAdapter ObtenerAdaptador (String consultaSql, SqlConnection cn)
    {
        SqlDataAdapter adaptador;
        try
        {
            adaptador = new  SqlDataAdapter(consultaSql, cn);
            return adaptador;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

        public DataTable ObtenerTabla(String NombreTabla, String Sql)
        {
            DataSet ds = new DataSet();
            SqlConnection Conexion = ObtenerConexion();
            SqlDataAdapter adp = ObtenerAdaptador(Sql, Conexion);
            adp.Fill(ds, NombreTabla);
            Conexion.Close();
            return ds.Tables[NombreTabla];
        }


        public int EjecutarProcedimientoAlmacenado(SqlCommand Comando, String NombreSP)
        {
            int FilasCambiadas;
            SqlConnection Conexion = ObtenerConexion();
            SqlCommand cmd = new SqlCommand();
            cmd = Comando;
            cmd.Connection = Conexion;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = NombreSP;
            FilasCambiadas = cmd.ExecuteNonQuery();
            Conexion.Close();
            return FilasCambiadas;
        }

        public Boolean existe(String consulta)
        {
            Boolean estado = false;
            SqlConnection Conexion = ObtenerConexion();
            SqlCommand cmd = new SqlCommand(consulta, Conexion);
            SqlDataReader datos = cmd.ExecuteReader();
            if (datos.Read())
            {
                estado = true;
            }
            return estado;
        }

        public int ObtenerMaximo(String consulta)
        {
            int max = 0;
            SqlConnection Conexion = ObtenerConexion();
            SqlCommand cmd = new SqlCommand(consulta, Conexion);
            SqlDataReader datos = cmd.ExecuteReader();
            if (datos.Read())
            {
                max = Convert.ToInt32(datos[0].ToString());
            }
            return max;
        }
    }
}