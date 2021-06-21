using System;
using System.Collections.Generic;
using System.Data;
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

namespace Los_Monos
{
    /// <summary>
    /// Lógica de interacción para Gestión_de_datos.xaml
    /// </summary>
    public partial class Gestión_de_datos : Window
    {
        public Gestión_de_datos()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Menu abrir = new Menu();
            abrir.Show();
            Hide();
        }
        Mercancia mer = new Mercancia();
        Usuario usu = new Usuario();
        private void combo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataTable ne = new DataTable();

            if (combo.SelectedIndex == 1)
                ne = mer.consultar_mercancia();
            else if (combo.SelectedIndex==0)
                ne = usu.Consulta_usuarios();

            dataGrid.ItemsSource = ne.DefaultView;
        }
    }
}
