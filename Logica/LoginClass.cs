using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using System.Data.SqlClient;
using System.Data;

namespace Logica
{
    public class LoginClass
    {
        Conexion a = new Conexion();


        public string loggear(string usuario, string contraseña)
        {
            int logueado = 0;
            string mensaje = "";
            SqlConnection com = a.conectar();
            com.Open();
            SqlCommand logear = new SqlCommand("loggin");
            logear.CommandType = CommandType.StoredProcedure;
            logear.Connection = com;
            logear.Parameters.Add("@nombre", usuario);
            logear.Parameters.Add("@contraseña", contraseña);
            SqlParameter logg = new SqlParameter("@logg", 0);
            logg.Direction = ParameterDirection.Output;
            logear.Parameters.Add(logg);
            SqlParameter Mss = new SqlParameter("@mensaje", SqlDbType.NVarChar);
            Mss.Size = 50;
            Mss.Direction = ParameterDirection.Output;
            logear.Parameters.Add(Mss);
            logear.ExecuteNonQuery();

            logueado = Int32.Parse(logear.Parameters["@logg"].Value.ToString());

            if (logueado > 0)
            {
                mensaje = logear.Parameters["@mensaje"].Value.ToString();
            }

            com.Close();
            return mensaje;
        }

        public string loggear_locales(string usuario, string contraseña)
        {
            int logueado = 0;
            string mensaje = "";
            SqlConnection com = a.conectar();
            com.Open();
            SqlCommand logear = new SqlCommand("loggin_locales");
            logear.CommandType = CommandType.StoredProcedure;
            logear.Connection = com;
            logear.Parameters.Add("@local", usuario);
            logear.Parameters.Add("@correo", contraseña);
            SqlParameter logg = new SqlParameter("@logg", 0);
            logg.Direction = ParameterDirection.Output;
            logear.Parameters.Add(logg);
            SqlParameter Mss = new SqlParameter("@mensaje", SqlDbType.NVarChar);
            Mss.Size = 50;
            Mss.Direction = ParameterDirection.Output;
            logear.Parameters.Add(Mss);
            logear.ExecuteNonQuery();

            logueado = Int32.Parse(logear.Parameters["@logg"].Value.ToString());

            if (logueado > 0)
            {
                mensaje = logear.Parameters["@mensaje"].Value.ToString();
            }

            com.Close();
            return mensaje;
        }
    }
}
