using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Datos;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Diagnostics;
using GemBox.Spreadsheet;
using ClosedXML.Excel;
using System.Reflection;

namespace Logica
{
    public class Reportes
    {
        Conexion con = new Conexion();

        //PDFRegion
        #region
        public string PDF_venta(DataGridView Ta, string Nombreloc, string fecha, long codigo)
        {
            Document doc = new Document(PageSize.A5.Rotate(), 10, 10, 10, 10);
            string filename = "C:\\Users\\Los Monos\\Documents\\Facturas Los Monos\\Factura" + codigo + ".pdf";
            FileStream file = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
            PdfWriter.GetInstance(doc, file);
            doc.Open();
            Paragraph f = new Paragraph();
            f.Alignment = Element.ALIGN_CENTER;
            f.Add("LOS MONOS\n Cosmeticos y Accesorios \n\n");
            doc.Add(f);
            Chunk Linea2 = new Chunk("Local destino: " + Nombreloc, FontFactory.GetFont("Courier New", 12, BaseColor.DARK_GRAY));
            Chunk Linea3 = new Chunk("Fecha venta: " + fecha, FontFactory.GetFont("Courier New", 12, BaseColor.DARK_GRAY));

            /*2*/
            doc.Add(new Paragraph(Linea2));
            /*3*/
            doc.Add(new Paragraph(Linea3));
            doc.Add(new Paragraph("\n \n \n \n "));
            GenerarDocumento(doc, Ta);
            doc.Close();
            //Process.Start(filename);
            return filename;
        }

        public string PDF_Consolidado(DataGridView Ta, string Nombreloc, string fecha)
        {
            Random r = new Random();
            int s = r.Next(1, 1000);
            Document doc = new Document(PageSize.A5.Rotate(), 10, 10, 10, 10);
            string filename = "C:\\ProgramData\\Consolidado " + fecha + "_" +s + ".pdf";
            FileStream file = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
            PdfWriter.GetInstance(doc, file);
            doc.Open();
            Paragraph f = new Paragraph();
            f.Alignment = Element.ALIGN_CENTER;
            f.Add("LOS MONOS\n Cosmeticos y Accesorios \n\n");
            doc.Add(f);
            Chunk Linea2 = new Chunk("Local: " + Nombreloc, FontFactory.GetFont("Courier New", 12, BaseColor.DARK_GRAY));
            Chunk Linea3 = new Chunk("Fecha: " + fecha, FontFactory.GetFont("Courier New", 12, BaseColor.DARK_GRAY));

            /*2*/
            doc.Add(new Paragraph(Linea2));
            /*3*/
            doc.Add(new Paragraph(Linea3));
            doc.Add(new Paragraph("\n \n \n \n "));
            GenerarDocumento(doc, Ta);
            doc.Close();
            Process.Start(filename);
            return filename;
        }


        public DataGridView retorno(DataGridView v)
        {
            for (int i = 0; i < v.RowCount; i++)
            {
                string h = v.Rows[i].Cells[1].Value.ToString();
                for(int j = i+1;j<v.RowCount;j++)
                {
                    if (v.Rows[j].Cells[1].Value.ToString()==h)
                    {
                        int cant = int.Parse(v.Rows[i].Cells[2].Value.ToString());
                        cant += int.Parse(v.Rows[j].Cells[2].Value.ToString());
                        int prize = int.Parse(v.Rows[i].Cells[8].Value.ToString());
                        prize += int.Parse(v.Rows[j].Cells[8].Value.ToString());
                        v.Rows[i].Cells[2].Value = cant;
                        v.Rows[i].Cells[8].Value = prize;
                        v.Rows.Remove(v.Rows[j]);
                    }
                }
            }
            return v;
        }

        public void GenerarDocumento(Document document, DataGridView Table)
        {
            //se crea un objeto PdfTable con el numero de columnas del 
            //dataGridView
            PdfPTable datatable = new PdfPTable(Table.ColumnCount);
            //asignamos algunas propiedades para el diseño del pdf
            datatable.DefaultCell.Padding = 3;
            float[] headerwidths = TamañoColumnas(Table);
            datatable.SetWidths(headerwidths);
            datatable.WidthPercentage = 100;
            datatable.DefaultCell.BorderWidth = 2;
            datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            //SE GENERA EL ENCABEZADO DE LA TABLA EN EL PDF
            for (int i = 0; i < Table.ColumnCount; i++)
            {
                datatable.AddCell(Table.Columns[i].HeaderText);
            }
            datatable.HeaderRows = 1;
            datatable.DefaultCell.BorderWidth = 1;
            
            //SE GENERA EL CUERPO DEL PDF
            for (int i = 0; i < Table.RowCount; i++)
            {

                for (int j = 0; j < Table.ColumnCount; j++)
                {
                        datatable.AddCell(Table[j, i].Value.ToString());

                }
                datatable.CompleteRow();
            }
            //SE AGREGAR LA PDFPTABLE AL DOCUMENTO
            document.Add(datatable);
        }


        public float[] TamañoColumnas(DataGridView dg)
        {
            float[] values = new float[dg.ColumnCount];
            for (int i = 0; i < dg.ColumnCount; i++)
            {
                values[i] = (float)dg.Columns[i].Width;
            }
            return values;
        }
        #endregion
        
        public DataTable listaProductos(string Tabla, string Nombre)
        {
            List<string> listica = new List<string>();
            SqlConnection a = con.conectar();
            a.Open();
            SqlCommand consultar = new SqlCommand("busca_" + Tabla + " '" + Nombre + "'", a);
            SqlDataReader ex = consultar.ExecuteReader();
            System.Data.DataTable dt = new System.Data.DataTable();
            dt.Load(ex);
            a.Close();
            return dt;
        }

        //ExcelRegion
        #region
        public string exportar_excel(DataGridView tabla)
        {
            SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");

            ExcelFile excel = new ExcelFile();
            ExcelWorksheet ws = excel.Worksheets.Add("Hello World");
            int indiceColumna = 0;

            foreach (DataGridViewColumn col in tabla.Columns)
            {
                indiceColumna++;
                ws.Cells[1, indiceColumna].Value = col.Name;
            }
            int indexFila = 0;
            foreach (DataGridViewRow row in tabla.Rows)
            {
                indexFila++;
                indiceColumna = 0;
                foreach (DataGridViewColumn col in tabla.Columns)
                {
                    indiceColumna++;
                    ws.Cells[indexFila + 1, indiceColumna].Value = row.Cells[col.Name].Value;
                }
            }
            Random r = new Random();
            int s = r.Next(1, 1000);
            excel.Save("C:\\ProgramData\\Reporte_" + s + ".xlsx");
            return "C:\\ProgramData\\Reporte_" + s + ".xlsx";
        }
        #endregion
        

        public DataTable busca(string Tabla, string Nombre)
        {
            SqlConnection a = con.conectar();
            a.Open();
            SqlCommand consultar = new SqlCommand("buscar_" + Tabla + " '" + Nombre + "'", a);
            SqlDataReader cons = consultar.ExecuteReader();
            System.Data.DataTable dt = new System.Data.DataTable();
            dt.Load(cons);
            a.Close();
            return dt;
        }

        public DataTable Consultas(string nom_consulta)
        {
            SqlConnection a = con.conectar();
            a.Open();
            SqlCommand consultar = new SqlCommand("Select * from Consulta_" + nom_consulta, a);
            SqlDataReader Consu = consultar.ExecuteReader();
            System.Data.DataTable Tabla = new System.Data.DataTable();
            Tabla.Load(Consu);
            a.Close();
            return Tabla;
        }

        public DataTable Consolidado_dia(string local, string fecha)
        {
            SqlConnection a = con.conectar();
            a.Open();
            SqlCommand consultar = new SqlCommand("resumen_dia '" + fecha +"','"+local+"'" , a);
            SqlDataReader Consu = consultar.ExecuteReader();
            System.Data.DataTable Tabla = new System.Data.DataTable();
            Tabla.Load(Consu);
            a.Close();
            return Tabla;
        }

        public DataTable Consolidado_fechas(string local, string fecha, string fecha2)
        {
            SqlConnection a = con.conectar();
            a.Open();
            SqlCommand consultar = new SqlCommand("resumen_fechas '" + fecha + "','" + fecha2 +"','" + local + "'", a);
            SqlDataReader Consu = consultar.ExecuteReader();
            System.Data.DataTable Tabla = new System.Data.DataTable();
            Tabla.Load(Consu);
            a.Close();
            return Tabla;
        }

        public DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            //Get all the properties by using reflection   
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names  
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {

                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }

            return dataTable;
        }

        public void exportExcel(DataTable dt)
        {
            XLWorkbook wb = new XLWorkbook();
            wb.Worksheets.Add(dt, "Reporte");
            SaveFileDialog fichero = new SaveFileDialog();
            fichero.Filter = "Excel (*.xlsx)|*.xlsx";
            if (fichero.ShowDialog() == DialogResult.OK)
            {
                wb.SaveAs(fichero.FileName);
            }
        }

        public void excelv2(DataTable dt)
        {
            List<Consolidado> lista = new List<Consolidado>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Consolidado con = new Consolidado();
                con.Cod_entrega = dt.Rows[i]["Código"].ToString();
                con.Cod_producto = dt.Rows[i]["Código Producto"].ToString();
                con.Nom_producto = dt.Rows[i]["Nombre producto"].ToString();
                con.Cantidad = (long)dt.Rows[i]["Cantidad"];
                con.Fecha = dt.Rows[i]["Fecha"].ToString();
                con.Hora = dt.Rows[i]["Hora"].ToString();
                con.Local = dt.Rows[i]["Local"].ToString();
                con.Marca = dt.Rows[i]["Marca"].ToString();
                con.Precio = (long)dt.Rows[i]["Precio"];
                con.Subtotal = (long)dt.Rows[i]["Subtotal"];
                con.Verificado = dt.Rows[i]["Verificado?"].ToString();
                if (lista.Count == 0)
                {
                    lista.Add(con);
                }
                else
                {
                    if (lista.Last().Cod_producto == con.Cod_producto)
                    {
                        lista.Last().Cantidad += con.Cantidad;
                        lista.Last().Subtotal += con.Subtotal;
                    }
                    else
                    {
                        lista.Add(con);
                    }
                }
            }
            DataTable dd = ToDataTable(lista);
            XLWorkbook wb = new XLWorkbook();
            wb.Worksheets.Add(dd, "Reporte");
            SaveFileDialog fichero = new SaveFileDialog();
            fichero.Filter = "Excel (*.xlsx)|*.xlsx";
            if (fichero.ShowDialog() == DialogResult.OK)
            {
                wb.SaveAs(fichero.FileName);
            }
        }

        public DataTable detalle_e(string codigo)
        {
            SqlConnection a = con.conectar();
            a.Open();
            SqlCommand consultar = new SqlCommand("detalle '" + codigo +"'", a);
            SqlDataReader Consu = consultar.ExecuteReader();
            System.Data.DataTable Tabla = new System.Data.DataTable();
            Tabla.Load(Consu);
            a.Close();
            return Tabla;
        }
        public DataTable detalle_p(string codigo)
        {
            SqlConnection a = con.conectar();
            a.Open();
            SqlCommand consultar = new SqlCommand("detalle_p '" + codigo + "'", a);
            SqlDataReader Consu = consultar.ExecuteReader();
            System.Data.DataTable Tabla = new System.Data.DataTable();
            Tabla.Load(Consu);
            a.Close();
            return Tabla;
        }

        public DataTable historial_e(string text)
        {
            SqlConnection a = con.conectar();
            a.Open();
            SqlCommand consultar = new SqlCommand("buscar_historial_entregas '"+text+"'", a);
            SqlDataReader Consu = consultar.ExecuteReader();
            System.Data.DataTable Tabla = new System.Data.DataTable();
            Tabla.Load(Consu);
            a.Close();
            return Tabla;
        }

        public DataTable historial_p(string text)
        {
            SqlConnection a = con.conectar();
            a.Open();
            SqlCommand consultar = new SqlCommand("buscar_historial_pedidos '" + text + "'", a);
            SqlDataReader Consu = consultar.ExecuteReader();
            System.Data.DataTable Tabla = new System.Data.DataTable();
            Tabla.Load(Consu);
            a.Close();
            return Tabla;
        }

        public int filas(string fecha, string local)
        {
            SqlConnection C = con.conectar();
            C.Open();
            SqlCommand sss = new SqlCommand("select h = count(*) from entrega where Fecha_entrega = '"+fecha+"' and Nombre_local = '"+local+"'", C);
            SqlDataReader dr = sss.ExecuteReader();
            if (dr.Read())
            {
                int cod = (int)dr["h"];
                C.Close();
                return cod;
            }
            else
            {
                C.Close();
                return 0;
            }
        }


        public DataTable Consulta_historial()
        {
            SqlConnection a = con.conectar();
            a.Open();
            SqlCommand consultar = new SqlCommand("Select * from Historial", a);
            SqlDataReader Consu = consultar.ExecuteReader();
            System.Data.DataTable Tabla = new System.Data.DataTable();
            Tabla.Load(Consu);
            a.Close();
            return Tabla;
        }
    }
}
