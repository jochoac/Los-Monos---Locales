using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logica;

namespace VistaLM
{
    public partial class Detalle_EntPed : Form
    {
        public Detalle_EntPed()
        {
            InitializeComponent();
        }

        public bool entrega = false, pedido = false;
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
        Reportes re = new Reportes();
        Entrega en = new Entrega();
        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < grid.RowCount; i++)
            {
                en.Cantidad = long.Parse(grid.Rows[i].Cells[1].Value.ToString());
                en.mer.Nombre = grid.Rows[i].Cells[0].Value.ToString();
                en.mer.Codigo = en.mer.obtener_codigo();
                en.Codigo = long.Parse(codtxt.Text.Substring(4));
                en.Actualizar_3venta();
            }

            if (entrega)
                grid.DataSource = re.detalle_e(codtxt.Text);
            else if (pedido)
                grid.DataSource = re.detalle_p(codtxt.Text);
            grid.ClearSelection();
        }

        private void grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Entrega en = new Entrega();
            DialogResult result = MessageBox.Show("Desea eliminar esta entrega?", "Confirmación", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Yes)
            {
                try
                {
                    en.Eliminar_3venta(codtxt.Text, grid.CurrentRow.Cells[0].Value.ToString(), grid.CurrentRow.Cells[1].Value.ToString());
                    MessageBox.Show("Item eliminado correctamente");
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Ha ocurrido un error al eliminar el ítem");
                }
                
            }            
        }

        private void detalletxt_Click(object sender, EventArgs e)
        {

        }

        private void Detalle_EntPed_Load(object sender, EventArgs e)
        {
            if (entrega)
                grid.DataSource = re.detalle_e(codtxt.Text);
            else if (pedido)
                grid.DataSource = re.detalle_p(codtxt.Text);
            grid.ClearSelection();
        }
    }
}
