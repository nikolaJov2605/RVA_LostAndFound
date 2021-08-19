﻿using Common.Services;
using Front.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
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

namespace Front.Views
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();

            tbUsername.Text = "Unesite korisničko ime";
            tbUsername.Foreground = Brushes.LightSlateGray;

            tbPasswd.Text = "Unesite lozinku";
            tbPasswd.Foreground = Brushes.LightSlateGray;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            bool isValid = true;
            
            if (!FieldValidation.Validate(tbUsername.Text, "Unesite korisničko ime"))
            {
                isValid = false;
                tbUsername.Text = "Unesite korisničko ime";
                tbUsername.Foreground = new SolidColorBrush(Colors.Red);
            }
            if (!FieldValidation.Validate(tbPasswd.Text, "Unesite lozinku"))
            {
                isValid = false;
                tbPasswd.Text = "Unesite lozinku";
                tbPasswd.Foreground = new SolidColorBrush(Colors.Red);
            }

            if (isValid == true)
            {

                ChannelFactory<ISignIn> factory = new ChannelFactory<ISignIn>("UserSignIn");
                ISignIn proxy = factory.CreateChannel();

                if (proxy.SignIn(tbUsername.Text, tbPasswd.Text) == true)
                {
                    MainWindow mainWindow = new MainWindow(tbUsername.Text);
                    this.Close();
                    mainWindow.Show();
                }
            }
            else
                return;
        }

        private void tbUsername_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tbUsername.Text.Trim().Equals("Unesite korisničko ime"))
            {
                tbUsername.Text = "";
                tbUsername.Foreground = Brushes.Black;
            }
        }

        private void tbUsername_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbUsername.Text.Trim().Equals(string.Empty))
            {
                tbUsername.Text = "Unesite korisničko ime";
                tbUsername.Foreground = Brushes.LightSlateGray;
            }
        }

        private void tbPasswd_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tbPasswd.Text.Trim().Equals("Unesite lozinku"))
            {
                tbPasswd.Text = "";
                tbPasswd.Foreground = Brushes.Black;
            }
        }

        private void tbPasswd_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbPasswd.Text.Trim().Equals("Unesite lozinku"))
            {
                tbPasswd.Text = "Unesite lozinku";
                tbPasswd.Foreground = Brushes.Black;
            }
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Registracija registrationWindow = new Registracija();
            registrationWindow.Show();
        }
    }
}
