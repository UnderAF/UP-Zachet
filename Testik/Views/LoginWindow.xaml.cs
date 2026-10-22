using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Testik.Views;

namespace Testik
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        MyDbContext database = new MyDbContext();
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (LoginInput.Text == "" || LoginInput.Text == null || PasswordInput.Text == "" || PasswordInput.Text == null) return;
            foreach (var item in database.Users.ToList())
            {
                if(LoginInput.Text == item.Login && PasswordInput.Text == item.Password)
                {
                    Window window = new CatalogWindow();
                    this.Close();
                    window.Show();
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window window = new GuestWindow();
            this.Close();
            window.Show();
        }
    }
}
