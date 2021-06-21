using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Datos;
using System.Data.SqlClient;

namespace Logica
{
    public class Usuario
    {
        Conexion con = new Conexion();
        private string nombre_usu, nombre_E, password, correo_usu, cargo_usu, estado_usu;
        private long id_e, telefono_e;

        public string Nombre_usu { get => nombre_usu; set => nombre_usu = value; }
        public string Nombre_E { get => nombre_E; set => nombre_E = value; }
        public string Password { get => password; set => password = value; }
        public string Correo_usu { get => correo_usu; set => correo_usu = value; }
        public string Cargo_usu { get => cargo_usu; set => cargo_usu = value; }
        public string Estado_usu { get => estado_usu; set => estado_usu = value; }
        public long Id_e { get => id_e; set => id_e = value; }
        public long Telefono_e { get => telefono_e; set => telefono_e = value; }

        public DataTable Consulta_usuarios()
        {
            SqlConnection Cconexion = con.conectar();
            Cconexion.Open();
            SqlCommand registro_empleado = new SqlCommand("Select * from vista_usuarios", Cconexion);
            SqlDataReader Regis = registro_empleado.ExecuteReader();
            DataTable Grid = new DataTable();
            Grid.Load(Regis);
            Cconexion.Close();
            return Grid;
        }
        public string Registro_usu()
        {
            int contador;
            string mensaje;
            SqlConnection a = con.conectar();
            a.Open();
            SqlCommand Registro_Empleado = new SqlCommand("Registrar_usu");
            Registro_Empleado.CommandType = CommandType.StoredProcedure;
            Registro_Empleado.Connection = a;
            Registro_Empleado.Parameters.Add("@Nombre_usu", nombre_usu);
            Registro_Empleado.Parameters.Add("@Nombre_Empleado", nombre_E);
            Registro_Empleado.Parameters.Add("@Contraseña_usu", id_e);
            Registro_Empleado.Parameters.Add("@Cargo_usu", cargo_usu);
            Registro_Empleado.Parameters.Add("@ID_usu", id_e);
            Registro_Empleado.Parameters.Add("@Telefono_usu", telefono_e);
            Registro_Empleado.Parameters.Add("@Estado_usu", "Activo");
            Registro_Empleado.Parameters.Add("@Correo_usu", correo_usu);
            SqlParameter Contador = new SqlParameter("@Contador", 0);
            Contador.Direction = ParameterDirection.Output;
            Registro_Empleado.Parameters.Add(Contador);
            SqlParameter Mss = new SqlParameter("@mensaje", SqlDbType.NVarChar);
            Mss.Size = 50;
            Mss.Direction = ParameterDirection.Output;
            Registro_Empleado.Parameters.Add(Mss);
            Registro_Empleado.ExecuteNonQuery();

            contador = Int32.Parse(Registro_Empleado.Parameters["@Contador"].Value.ToString());

            if (contador > 0)
            {
                mensaje = Registro_Empleado.Parameters["@mensaje"].Value.ToString();
                return mensaje;
            }
            mensaje = "El usuario ha sido registrado correctamente";
            a.Close();
            return mensaje;
        }

        public void cambiarContraseña(string newpass)
        {
            SqlConnection Cconexion = con.conectar();
            Cconexion.Open();
            SqlCommand registro_empleado = new SqlCommand("update Usuario set Contraseña = '"+newpass+"' where Nombre_usu= '"+nombre_usu+"'", Cconexion);
            SqlDataReader Regis = registro_empleado.ExecuteReader();
            Cconexion.Close();
        }

        public string obtener_cargo()
        { 
            SqlConnection C = con.conectar();
            C.Open();
            SqlCommand sss = new SqlCommand("select Cargo from Usuario where Nombre_usu= '"+nombre_usu+"'", C);
            SqlDataReader dr = sss.ExecuteReader();
            if (dr.Read())
            {
                string cod = (string)dr["Cargo"];
                C.Close();
                return cod.ToUpper();
            }
            else
            {
                C.Close();
                return "";
            }
        }
    }
}
