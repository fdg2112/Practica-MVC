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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Entities;
using Logic;
using UI_WPF;

namespace Practica_EntityFramework
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnShowProducts_Click(object sender, RoutedEventArgs e)
        {
            ProductsList productsWindow = new ProductsList();
            productsWindow.ShowDialog();
        }

        private void BtnAddProducts_Click(object sender, RoutedEventArgs e)
        {
            AddProducts addProducts = new AddProducts();
            addProducts.ShowDialog();
        }

        private void BtnModifyProducts_Click(object sender, RoutedEventArgs e)
        {
            UpdateProduct updateProduct = new UpdateProduct();
            updateProduct.ShowDialog();
        }

        private void BtnLinqQuerys_Click(object sender, RoutedEventArgs e)
        {
            QuerysLINQ querysLINQ = new QuerysLINQ();
            querysLINQ.ShowDialog();
        }
    }
}
