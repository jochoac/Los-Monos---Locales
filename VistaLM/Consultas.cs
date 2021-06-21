using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logica;
using System.Diagnostics;

namespace VistaLM
{
    public partial class Consultas : Form
    {
        public Consultas()
        {
            InitializeComponent();
        }
        public string user;
        private void Consultas_FormClosing(object sender, FormClosingEventArgs e)
        {
            Login m = new Login();
            m.Show();
        }

        private void Consultas_Load(object sender, EventArgs e)
        {
            dateTimePicker1.MaxDate = DateTime.Today;
            dateTimePicker1.Value = DateTime.Today;

            dateTimePicker2.MaxDate = DateTime.Today;
            dateTimePicker2.Value = DateTime.Today;

            comboBox1.SelectedIndex = 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
        Reportes rep = new Reportes();
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void grid_DataSourceChanged(object sender, EventArgs e)
        {
            if (grid.DataSource != null)
                pdfbutton.Visible = true;
            else
                pdfbutton.Visible = false;
        }

        private void buscartxt_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(comboBox1.Text == "Entregas" || comboBox1.Text == "Pedidos")
            {
                Detalle_EntPed det = new Detalle_EntPed();
                det.codtxt.Text = grid.CurrentRow.Cells[0].Value.ToString();
                if (comboBox1.Text == "Pedidos")
                {
                    det.pedido = true;
                    det.fechalbl.Text += grid.CurrentRow.Cells[2].Value.ToString().Substring(0, 10);
                    det.usutxt.Text = grid.CurrentRow.Cells[1].Value.ToString();
                    det.locallbl.Visible = false;
                }
                else if (comboBox1.Text == "Entregas")
                {
                    det.entrega = true;
                    det.locallbl.Text += grid.CurrentRow.Cells[1].Value.ToString();
                    det.usutxt.Text = grid.CurrentRow.Cells[2].Value.ToString();
                    det.fechalbl.Text += grid.CurrentRow.Cells[3].Value.ToString();
                }
                det.ShowDialog();
            }
            else
            {
                if(e.ColumnIndex > 2 && e.ColumnIndex <5)
                {
                    grid.Columns[3].ReadOnly = false;
                    grid.Columns[4].ReadOnly = false;
                }
                else 
                {
                    DialogResult result = MessageBox.Show("Desea eliminar esta entrega?", "Confirmación", MessageBoxButtons.YesNoCancel);
                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            en.Eliminar_3venta(grid.CurrentRow.Cells[0].Value.ToString(), grid.CurrentRow.Cells[1].Value.ToString(), grid.CurrentRow.Cells[2].Value.ToString());
                            MessageBox.Show("Item eliminado correctamente");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ha ocurrido un error al eliminar el ítem");
                        }
                    }
                }
                
            }
        }
        Local loc = new Local();
        private void pdfbutton_Click(object sender, EventArgs e)
        {
            string path = rep.PDF_Consolidado(rep.retorno(grid), user, DateTime.Now.ToLongDateString());

            MailMessage mmsg = new MailMessage();
            loc.Nombre_local = user;
            mmsg.To.Add(loc.obtenerCorreo());
            mmsg.From = new MailAddress("losmonosbodega@gmail.com");
            mmsg.Subject = "Consolidado diario";
            mmsg.Body = "Consolidado " + DateTime.Now.ToLongDateString();
            Attachment archivo = new Attachment(path);
            mmsg.Attachments.Add(archivo);
            SmtpClient client = new SmtpClient();
            client.Credentials = new NetworkCredential("losmonosbodega@gmail.com", "losmonos2018");
            client.Port = 587;
            client.EnableSsl = true;
            client.Host = "smtp.gmail.com";

            //client.Send(mmsg);

            correos s = new correos();
            s.path = path;
            s.ShowDialog();

            string mes = DateTime.Now.Month.ToString(), dia = DateTime.Now.Day.ToString();
            if (DateTime.Now.Month < 10)
                mes = "0" + DateTime.Now.Month;
            if (DateTime.Now.Day < 10)
                dia = "0" + DateTime.Now.Day;
            string fecha = DateTime.Now.Year + "-" + mes + "-" + dia;
            grid.DataSource = rep.Consolidado_dia(user, fecha);

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
           
        }

        private void comboBox1_DropDownClosed(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Entregas")
            {
                grid.DataSource = rep.Consultas("Entregas");
                pdfbutton.Visible = false;
                dateTimePicker1.Visible = false;
            }
            else if(comboBox1.Text == "Consolidado por fechas")
            {
                string m = dateTimePicker1.Value.Month.ToString(), d = dateTimePicker1.Value.Day.ToString();
                if (dateTimePicker1.Value.Month < 10)
                    m = "0" + dateTimePicker1.Value.Month;
                if (dateTimePicker1.Value.Day < 10)
                    d = "0" + dateTimePicker1.Value.Day;
                string f1 = dateTimePicker1.Value.Year + "-" + m + "-" + d;

                string m2 = dateTimePicker2.Value.Month.ToString(), d2 = dateTimePicker2.Value.Day.ToString();
                if (dateTimePicker2.Value.Month < 10)
                    m2 = "0" + dateTimePicker2.Value.Month;
                if (dateTimePicker2.Value.Day < 10)
                    d2 = "0" + dateTimePicker2.Value.Day;
                string f2 = dateTimePicker2.Value.Year + "-" + m2 + "-" + d2;

                grid.DataSource = rep.Consolidado_fechas(user, f1, f2);

                dateTimePicker1.Visible = true;
                dateTimePicker2.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
            }
            else if (comboBox1.Text == "Consolidado diario")
            {
                string mes = DateTime.Now.Month.ToString(), dia = DateTime.Now.Day.ToString();
                if (DateTime.Now.Month < 10)
                    mes = "0" + DateTime.Now.Month;
                if (DateTime.Now.Day < 10)
                    dia = "0" + DateTime.Now.Day;
                string fecha = DateTime.Now.Year + "-" + mes + "-" + dia;
                grid.DataSource = rep.Consolidado_dia(user, fecha);
                dateTimePicker1.Visible = true;
                label2.Visible = true;
                dateTimePicker2.Visible = false;
                label3.Visible = false;
            }
            else if (comboBox1.Text == "Historial general")
            {
                grid.DataSource = rep.Consulta_historial();
                dateTimePicker1.Visible = false;
            }

            if (comboBox1.Text == "Entregas" || comboBox1.Text == "Pedidos")
                detalletxt.Visible = true;
            else
                detalletxt.Visible = false;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            string m = dateTimePicker1.Value.Month.ToString(), d = dateTimePicker1.Value.Day.ToString();
            if (dateTimePicker1.Value.Month < 10)
                m = "0" + dateTimePicker1.Value.Month;
            if (dateTimePicker1.Value.Day < 10)
                d = "0" + dateTimePicker1.Value.Day;
            string f1 = dateTimePicker1.Value.Year + "-" + m + "-" + d;
            grid.DataSource = rep.Consolidado_dia(user, f1);
        }
        Entrega en = new Entrega();
        Historial historial = new Historial();
        private void button1_Click(object sender, EventArgs e)
        {
            if(comboBox1.Text== "Consolidado diario")
            {
                historial.Nombre_usu = user;
                historial.Fecha = DateTime.Now.ToShortDateString();
                historial.Hora = DateTime.Now.ToShortTimeString();
                for (int i = 0; i < grid.RowCount; i++)
                {
                    en.Cantidad = long.Parse(grid.Rows[i].Cells[3].Value.ToString());
                    en.mer.Nombre = grid.Rows[i].Cells[1].Value.ToString();
                    en.mer.Codigo = en.mer.obtener_codigo();
                    en.Verificado = grid.Rows[i].Cells[4].Value.ToString();
                    en.Codigo = long.Parse(grid.Rows[i].Cells[0].Value.ToString().Substring(4));
                    long cant_parcial = en.obtener_cant3();
                    en.Actualizar_3venta();
                    long cant_nueva = en.obtener_cant3();
                    if (cant_parcial != cant_nueva)
                    {
                        historial.Descripcion = "Actualizar datos producto " + en.mer.Nombre + " "+ en.mer.obtener_marca()+" nueva cantidad: " + cant_nueva;
                        historial.Cant_anterior = cant_parcial;
                        historial.Cant_actual = cant_nueva;
                        historial.Registrar_historial_productos();
                    }
                }
                MessageBox.Show("Datos actualizados");
            }
        }
        int rows=0;
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            
            int temp = rows;
            string mes = DateTime.Now.Month.ToString(), dia = DateTime.Now.Day.ToString();
            if (DateTime.Now.Month < 10)
                mes = "0" + DateTime.Now.Month;
            if (DateTime.Now.Day < 10)
                dia = "0" + DateTime.Now.Day;
            string fecha = DateTime.Now.Year + "-" + mes + "-" + dia;

            rows = rep.filas(fecha, user);
            if(rows>temp)
            {
                if (comboBox1.Text == "Consolidado diario")
                {
                    string mes1 = DateTime.Now.Month.ToString(), dia1 = DateTime.Now.Day.ToString();
                    if (DateTime.Now.Month < 10)
                        mes1 = "0" + DateTime.Now.Month;
                    if (DateTime.Now.Day < 10)
                        dia1 = "0" + DateTime.Now.Day;
                    string fecha1 = DateTime.Now.Year + "-" + mes1 + "-" + dia1;
                    grid.DataSource = rep.Consolidado_dia(user, fecha1);
                    dateTimePicker1.Visible = true;
                    MessageBox.Show("Nuevos pedidos!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                    
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string m = dateTimePicker1.Value.Month.ToString(), d = dateTimePicker1.Value.Day.ToString();
            if (dateTimePicker1.Value.Month < 10)
                m = "0" + dateTimePicker1.Value.Month;
            if (dateTimePicker1.Value.Day < 10)
                d = "0" + dateTimePicker1.Value.Day;
            string f1 = dateTimePicker1.Value.Year + "-" + m + "-" + d;

            string m2 = dateTimePicker2.Value.Month.ToString(), d2 = dateTimePicker2.Value.Day.ToString();
            if (dateTimePicker2.Value.Month < 10)
                m2 = "0" + dateTimePicker2.Value.Month;
            if (dateTimePicker2.Value.Day < 10)
                d2 = "0" + dateTimePicker2.Value.Day;
            string f2 = dateTimePicker2.Value.Year + "-" + m2 + "-" + d2;

            rep.excelv2(rep.Consolidado_fechas(user, f1, f2));
            /*if (grid.Rows.Count > 0)
            {
                Reportes r = new Reportes();
                r.ExportarDataGridViewExcel(grid);
            }*/
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            string m = dateTimePicker1.Value.Month.ToString(), d = dateTimePicker1.Value.Day.ToString();
            if (dateTimePicker1.Value.Month < 10)
                m = "0" + dateTimePicker1.Value.Month;
            if (dateTimePicker1.Value.Day < 10)
                d = "0" + dateTimePicker1.Value.Day;
            string f1 = dateTimePicker1.Value.Year + "-" + m + "-" + d;

            string m2 = dateTimePicker2.Value.Month.ToString(), d2 = dateTimePicker2.Value.Day.ToString();
            if (dateTimePicker2.Value.Month < 10)
                m2 = "0" + dateTimePicker2.Value.Month;
            if (dateTimePicker2.Value.Day < 10)
                d2 = "0" + dateTimePicker2.Value.Day;
            string f2 = dateTimePicker2.Value.Year + "-" + m2 + "-" + d2;

            grid.DataSource = rep.Consolidado_fechas(user, f1, f2);
        }

        private void grid_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void grid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            en.Actualizar_3venta(grid.CurrentRow.Cells[0].Value.ToString(),
                grid.CurrentRow.Cells[2].Value.ToString(),
                grid.CurrentRow.Cells[3].Value.ToString(),
                grid.CurrentRow.Cells[4].Value.ToString());
        }
    }
}
