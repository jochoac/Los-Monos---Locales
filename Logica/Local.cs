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
    public class Local
    {
        Conexion con = new Conexion();

        string nombre_local, correo_local, direccion_local;
        long telefono_local;

        public long Telefono_local { get => telefono_local; set => telefono_local = value; }
        public string Nombre_local { get => nombre_local; set => nombre_local = value; }
        public string Correo_local { get => correo_local; set => correo_local = value; }
        public string Direccion_local { get => direccion_local; set => direccion_local = value; }

        public string Registro_loc()
        {
            int contador;
            string mensaje;
            SqlConnection a = con.conectar();
            a.Open();
            SqlCommand Registro_Cliente = new SqlCommand("Registrar_loc");
            Registro_Cliente.CommandType = CommandType.StoredProcedure;
            Registro_Cliente.Connection = a;
            Registro_Cliente.Parameters.Add("@Nombre_local", Nombre_local);
            Registro_Cliente.Parameters.Add("@Correo_local", Correo_local);
            Registro_Cliente.Parameters.Add("@Telefono_local", Telefono_local);
            Registro_Cliente.Parameters.Add("@Direccion_local", Direccion_local);
            SqlParameter Contador = new SqlParameter("@Contador", 0);
            Contador.Direction = ParameterDirection.Output;
            Registro_Cliente.Parameters.Add(Contador);
            SqlParameter Mss = new SqlParameter("@mensaje", SqlDbType.NVarChar);
            Mss.Size = 50;
            Mss.Direction = ParameterDirection.Output;
            Registro_Cliente.Parameters.Add(Mss);
            Registro_Cliente.ExecuteNonQuery();

            contador = int.Parse(Registro_Cliente.Parameters["@Contador"].Value.ToString());

            if (contador > 0)
            {
                mensaje = Registro_Cliente.Parameters["@mensaje"].Value.ToString();
            }
            else
            {
                mensaje = "El local ha sido registrado exitosamente";
            }
            a.Close();
            return mensaje;
        }

        public List<string> fkLocal()
        {
            List<string> listica = new List<string>();
            SqlConnection a = con.conectar();
            a.Open();
            SqlCommand consultar = new SqlCommand("Select Nombre_local from tLocal", a);
            SqlDataReader ex = consultar.ExecuteReader();
            while (ex.Read())
            {
                Local ar = new Local();
                ar.Nombre_local = ex.GetString(0);
                listica.Add(ar.Nombre_local);
            }
            return listica;
        }

        public DataTable Consulta_local()
        {
            SqlConnection Cconexion = con.conectar();
            Cconexion.Open();
            SqlCommand Consulta_cli = new SqlCommand("Select * from vista_locales", Cconexion);
            SqlDataReader Con = Consulta_cli.ExecuteReader();
            DataTable Grid = new DataTable();
            Grid.Load(Con);
            Cconexion.Close();
            return Grid;
        }

        public string obtenerCorreo()
        {
            SqlConnection a = con.conectar();
            a.Open();
            SqlCommand sss = new SqlCommand("select Correo_local from tLocal where Nombre_Local = '" + Nombre_local + "'", a);
            SqlDataReader dr = sss.ExecuteReader();
            if (dr.Read())
            {
                string cod = (string)dr["Correo_local"];
                a.Close();
                return cod;
            }
            else
            {
                a.Close();
                return "";
            }
        }
    }
}
