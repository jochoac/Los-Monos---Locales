using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Logica
{
    public class Mercancia
    {
        Conexion conec = new Conexion();

        //select Cod_producto as Codigo, Nombre_producto as Nombre, Marca, Existencia, Tipo from producto

        private string codigo, nombre, marca, tipo, bodega, pasillo;
        private long existencia;

        public string Codigo { get => Codigo1; set => Codigo1 = value; }
        public string Nombre { get => Nombre1; set => Nombre1 = value; }
        public string Marca { get => Marca1; set => Marca1 = value; }
        public string Tipo { get => Tipo1; set => Tipo1 = value; }
        public long Existencia { get => existencia; set => existencia = value; }
        public string Codigo1 { get => codigo; set => codigo = value; }
        public string Nombre1 { get => nombre; set => nombre = value; }
        public string Marca1 { get => marca; set => marca = value; }
        public string Tipo1 { get => tipo; set => tipo = value; }
        public string Bodega { get => bodega; set => bodega = value; }
        public string Pasillo { get => pasillo; set => pasillo = value; }

        public DataTable consultar_mercancia()
        {

            SqlConnection a = conec.conectar();
            a.Open();
            SqlCommand consultar = new SqlCommand("Select * from Consulta_Mercancia", a);
            SqlDataReader cons = consultar.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(cons);
            a.Close();
            return dt;
        }

        public bool Ingresar_producto()
        {
            try
            {
                SqlConnection a = conec.conectar();
                a.Open();
                SqlCommand Registro_producto = new SqlCommand("Insertar_Producto '" + Codigo + "','" + Nombre + "','" + Marca + "'," + Existencia + ",'" + Tipo + "','" + Bodega + "','" + Pasillo + "'", a);
                SqlDataReader reg = Registro_producto.ExecuteReader();

                if (reg.Read() == false)
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
            catch(Exception ex)
            {
                return false;
            }
        }

        public bool Actualizar_producto()
        {
            try
            {
                SqlConnection a = conec.conectar();
                a.Open();
                SqlCommand Registro_producto = new SqlCommand("Actualizar_Producto '" + Codigo + "','" + Nombre + "'," + Existencia + ",'" + Marca + "','" + Tipo + "','" + Bodega + "','" + Pasillo + "'", a);
                SqlDataReader reg = Registro_producto.ExecuteReader();

                if (reg.Read() == false)
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
            catch(Exception ex)
            {
                return false;
            }
        }

        public string  obtener_codigo()
        {
            SqlConnection a = conec.conectar();
            a.Open();
            SqlCommand sss = new SqlCommand("select Cod_producto from producto where Nombre_producto ='" + Nombre + "'", a);
            SqlDataReader dr = sss.ExecuteReader();
            if (dr.Read())
            {
                string cod = (string)dr["Cod_producto"];
                a.Close();
                return cod;
            }
            else
            {
                a.Close();
                return "";
            }
        }

        public string obtener_ultcodigo(string tipo)
        {
            SqlConnection a = conec.conectar();
            a.Open();
            SqlCommand sss = new SqlCommand("select top 1 Cod_producto from producto where Cod_producto like '" + tipo.Substring(0, 2) + "_%' order by Cod_Producto desc", a);
            SqlDataReader dr = sss.ExecuteReader();
            if (dr.Read())
            {
                string cod = (string)dr["Cod_producto"];
                a.Close();
                return cod;
            }
            else
            {
                a.Close();
                return "";
            }
        }

        public String generarCodigo(string last, string type)
        {
            string codigo = "";
            long num;
            Random r = new Random();
            num = r.Next(11, Int32.MaxValue);

            codigo = type.Substring(0, 3) + "_" + num;
            return codigo;
        }

        public long obtener_existencia()
        {
            SqlConnection a = conec.conectar();
            a.Open();
            SqlCommand sss = new SqlCommand("select Existencia from producto where Cod_producto ='" + Codigo + "'", a);
            SqlDataReader dr = sss.ExecuteReader();
            if (dr.Read())
            {
                long cod = (long)dr["Existencia"];
                a.Close();
                return cod;
            }
            else
            {
                a.Close();
                return 0;
            }
        }

        public string obtener_marca()
        {
            SqlConnection a = conec.conectar();
            a.Open();
            SqlCommand sss = new SqlCommand("select Marca from producto where Cod_producto ='" + Codigo + "'", a);
            SqlDataReader dr = sss.ExecuteReader();
            if (dr.Read())
            {
                string cod = (string)dr["Marca"];
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
