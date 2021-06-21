using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using System.Data;
using System.Data.SqlClient;

namespace Logica
{
    public class Pedido
    {

        Conexion con = new Conexion();
        //Atributos
        private long codigo_pedido,cantidad_productos;
        private string fecha_pedido;
        public Usuario usu = new Usuario();
        public Mercancia mer = new Mercancia();

        public long Codigo_pedido { get => codigo_pedido; set => codigo_pedido = value; }
        public long Cantidad_productos { get => cantidad_productos; set => cantidad_productos = value; }
        public string Fecha_pedido { get => fecha_pedido; set => fecha_pedido = value; }

        public bool RegistrarPedido()
        {
            SqlConnection a = con.conectar();
            a.Open();
            SqlCommand Registro_Pedido = new SqlCommand("Registrar_Pedido '" + usu.Nombre_usu + "'", a);
            SqlDataReader Actu = Registro_Pedido.ExecuteReader();
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

        public bool Registrar_3pedido()
        {
            SqlConnection a = con.conectar();
            a.Open();
            SqlCommand Reg_3 = new SqlCommand("registrar_3pedido " + codigo_pedido + ",'" + mer.Codigo + "'," + cantidad_productos, a);
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
            SqlConnection a = con.conectar();
            a.Open();
            SqlCommand sss = new SqlCommand("select Top 1 Codigo_pedido from Pedido Order by Codigo_pedido Desc ", a);
            SqlDataReader dr = sss.ExecuteReader();
            if (dr.Read())
            {
                long cod = (long)dr["Codigo_Pedido"];
                a.Close();
                return cod;
            }
            else
            {
                a.Close();
                return 0;
            }
        }
    }
}
