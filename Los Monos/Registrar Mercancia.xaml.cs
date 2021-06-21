using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Logica;
using System.Data;

namespace Los_Monos
{
    /// <summary>
    /// Lógica de interacción para Registrar_Mercancia.xaml
    /// </summary>
    public partial class Registrar_Mercancia : Window
    {
        public Registrar_Mercancia()
        {
            InitializeComponent();
        }
        Mercancia mer = new Mercancia();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Menu abrir = new Menu ();
            abrir.Show();
            Hide();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataTable ne = mer.consultar_mercancia();
            dataGrid.ItemsSource = ne.DefaultView;
            txtcod.Focus();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (txtcod.Text == "" || txtname.Text == "" || txtmarca.Text == "" || txtexistencia.Text == "" || txtipo.Text == "")
            {
                MessageBox.Show("Por favor llena todos los datos correspondientes");
            }
            else
            {
                mer.Nombre = txtname.Text;
                mer.Codigo = txtcod.Text;
                mer.Existencia = long.Parse(txtexistencia.Text);
                mer.Marca = txtmarca.Text;
                mer.Tipo = txtipo.Text;
                if (mer.Ingresar_producto() == true)
                {
                    MessageBox.Show("Se ha ingresado el producto correctamente");
                    DataTable ne = mer.consultar_mercancia();
                    dataGrid.ItemsSource = ne.DefaultView;
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error al ingresar el producto, revisa tus datos");
                }
            }
            limpiar();
        }

        public void limpiar()
        {
            txtcod.Clear();
            txtname.Clear();
            txtmarca.Clear();
            txtexistencia.Clear();
            txtipo.Clear();
        }
    }
}
