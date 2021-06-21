using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Logica
{
    public class Historial
    {
        string fecha, hora, nombre_usu, descripcion;
        long cant_anterior, cant_actual;

        public long Cant_anterior { get => cant_anterior; set => cant_anterior = value; }
        public long Cant_actual { get => cant_actual; set => cant_actual = value; }
        public string Fecha { get => fecha; set => fecha = value; }
        public string Hora { get => hora; set => hora = value; }
        public string Nombre_usu { get => nombre_usu; set => nombre_usu = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        Conexion c = new Conexion();

        public bool Registrar_historial()
        {
            try
            {
                SqlConnection a = c.conectar();
                a.Open();
                SqlCommand Registro_producto = new SqlCommand("Insert into historial(Nombre_usu, Descripcion, Fecha, Hora) values ('" + nombre_usu + "','" + descripcion + "','" + fecha + "','" + hora + "')", a);
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
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Registrar_historial_productos()
        {
            try
            {
                SqlConnection a = c.conectar();
                a.Open();
                SqlCommand Registro_producto = new SqlCommand("Insert into historial values ('" + nombre_usu + "','" + descripcion + "','" + fecha + "','" + hora + "'," + cant_anterior + "," + cant_actual + ")", a);
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
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
