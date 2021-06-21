using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Logica
{
    public class Entrega
    {
        Conexion con = new Conexion();
        public Mercancia mer = new Mercancia();
        public Usuario usu = new Usuario();
        public Local loc = new Local();
        private long codigo, cantidad,subtotal,total;
        private string verificado;

        public long Codigo { get => Codigo1; set => Codigo1 = value; }
        public long Cantidad { get => Cantidad1; set => Cantidad1 = value; }
        public long Codigo1 { get => codigo; set => codigo = value; }
        public long Cantidad1 { get => cantidad; set => cantidad = value; }
        public string Verificado { get => verificado; set => verificado = value; }
        public long Total { get => total; set => total = value; }
        public long Subtotal { get => subtotal; set => subtotal = value; }

        public bool Registrar_entrega()
        {
            SqlConnection a = con.conectar();
            a.Open();
            SqlCommand Registro_Venta = new SqlCommand("Registrar_entrega '" + usu.Nombre_usu + "','" + loc.Nombre_local + "'", a);
            SqlDataReader Actu = Registro_Venta.ExecuteReader();
            if (Actu.Read() == false)
            {
                a.Close();
                return true;
            }
            else
            {
                a.Close();
                return false;
            }
        }

        public bool Registrar_3venta()
        {
            SqlConnection a = con.conectar();
            a.Open();
            SqlCommand Reg_3 = new SqlCommand("registrar_3entrega '" + Codigo1 + "','" + mer.Codigo + "',"+Cantidad1, a);
            SqlDataReader Reg = Reg_3.ExecuteReader();
            if (Reg.Read())
            {
                a.Close();
                return false;
            }
            else
            {
                a.Close();
                return true;
            }
        }

        public bool Actualizar_3venta()
        {
            SqlConnection a = con.conectar();
            a.Open();
            SqlCommand Reg_3 = new SqlCommand("Actualizar_3entrega '" + Codigo1 + "','" + mer.Codigo + "'," + Cantidad1 + ",'" + verificado + "'", a);
            SqlDataReader Reg = Reg_3.ExecuteReader();
            if (Reg.Read())
            {
                a.Close();
                return false;
            }
            else
            {
                a.Close();
                return true;
            }
        }

        public bool Eliminar_3venta(string cod_e, string nom_p, string cant)
        {
            int code = int.Parse(cod_e.Substring(4));
            mer.Nombre = nom_p;

            long cnt = long.Parse(cant);
            SqlConnection a = con.conectar();
            a.Open();
            SqlCommand Reg_3 = new SqlCommand("Eliminar_3entrega " + code + ",'" + mer.obtener_codigo() + "',"+cant, a);
            SqlDataReader Reg = Reg_3.ExecuteReader();
            if (Reg.Read())
            {
                a.Close();
                return false;  
            }
            else
            {
                a.Close();
                return true;
            }
        }
        public bool Actualizar_3venta(string cod_e, string nom_p, string cant, string verificado)
        {
            int code = int.Parse(cod_e.Substring(4));
            mer.Nombre = nom_p;
            long cnt = long.Parse(cant);
            SqlConnection a = con.conectar();
            a.Open();
            SqlCommand Reg_3 = new SqlCommand("Actualizar_3entrega " + code + ",'" + mer.obtener_codigo() + "'," + cant + ",'" +verificado+ "'", a);
            SqlDataReader Reg = Reg_3.ExecuteReader();
            if (Reg.Read())
            {
                a.Close();
                return false;
            }
            else
            {
                a.Close();
                return true;
            }
        }

        public long obtener_ultcodigo()
        {
            SqlConnection C = con.conectar();
            C.Open();
            SqlCommand sss = new SqlCommand("select Top 1 Codigo_entrega from Entrega Order by Codigo_entrega Desc ", C);
            SqlDataReader dr = sss.ExecuteReader();
            if (dr.Read())
            {
                long cod = (long)dr["Codigo_entrega"];
                C.Close();
                return cod;
            }
            else
            {
                C.Close();
                return 0;
            }
        }

        
        public long obtener_cant3()
        {
            SqlConnection C = con.conectar();
            C.Open();
            SqlCommand sss = new SqlCommand("select cantidad_producto from detalle_entrega where codigo_entrega = "+Codigo1+" and codigo_producto = '"+mer.Codigo+"'", C);
            SqlDataReader dr = sss.ExecuteReader();
            if (dr.Read())
            {
                long cod = (long)dr["Cantidad_producto"];
                C.Close();
                return cod;
            }
            else
            {
                C.Close();
                return 0;
            }
        }
    }
}
