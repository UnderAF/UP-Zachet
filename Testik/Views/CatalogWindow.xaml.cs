using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Testik.Views
{
    /// <summary>
    /// Логика взаимодействия для CatalogWindow.xaml
    /// </summary>
    public partial class CatalogWindow : Window
    {
        MyDbContext database = new MyDbContext();
        public CatalogWindow()
        {
            InitializeComponent();
            var products = database.Products.Include(p => p.Product_Category).ThenInclude(pc => pc.Category).ToList();
            var combos = database.Combos.ToList();
            ListProducts.ItemsSource = products.Cast<object>().Concat(combos).ToList();
        }
    }
}
