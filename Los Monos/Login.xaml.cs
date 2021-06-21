﻿using System;
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

namespace Los_Monos
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            txtusu.Focus();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LoginClass l = new LoginClass();
            if (txtusu.Text == "" | txtpass.Password == "")
            {
                MessageBox.Show("Por favor ingrese todos los datos");
            }
            else
            {
                string mensaje = l.loggear(txtusu.Text, txtpass.Password);
                if (mensaje != "")
                {
                    MessageBox.Show(mensaje);
                    Menu abrir = new Menu();
                    abrir.Show();
                    Hide();
                }
                else
                    MessageBox.Show("Error al iniciar sesión\nVerifique su Nombre de Ususario o Contraseña");
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            App.Current.Shutdown();
        }
    }
}
