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
    /// Lógica de interacción para Entregas.xaml
    /// </summary>
    public partial class Entregas : Window
    {
        public Entregas()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Menu men = new Menu();
            men.Show();
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtbuscar.Focus();
        } 

        Mercancia mer = new Mercancia();
        Reportes rep = new Reportes();
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtbuscar.Text != "")
                listBox.ItemsSource = rep.listaProductos("producto", txtbuscar.Text);

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Registrar_Click(object sender, RoutedEventArgs e)
        {
            
        }

    }
}

