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
            //SqlConnection con = new SqlConnection("Persist Security Info=False;User ID=Monos;Password=Monos56++;Initial Catalog=Los_Monos;Server=192.168.0.32,1433");
            //SqlConnection con = new SqlConnection("Server=tcp:losmonos.database.windows.net,1433;Initial Catalog=losmonos;Persist Security Info=False;User ID=monos;Password=Colombia2018*;MultipleActiveResultSets=False;TrustServerCertificate=False;Connection Timeout=1000;");
            SqlConnection con = new SqlConnection("Data source=DESKTOP-USQ1V2V\\SQLEXPRESS;Initial Catalog= Los_Monos;integrated security= true");
            return con;
        }
    }
}
