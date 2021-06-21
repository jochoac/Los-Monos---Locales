using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Datos
{
    public class Conexion
    {
        public SqlConnection conectar()
        {
            SqlConnection con = new SqlConnection("Connection String goes here");
            return con;
        }
    }
}
