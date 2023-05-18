using Logic;
using System.Windows;

namespace Practica_EntityFramework
{
    /// <summary>
    /// Lógica de interacción para ProductsList.xaml
    /// </summary>
    public partial class ProductsList : Window
    {
        private readonly ProductsLogic _productsLogic;
        public ProductsList()
        {
            InitializeComponent();
            _productsLogic = new ProductsLogic();
            LoadProducts();
        }

        private void LoadProducts()
        {
            var products = _productsLogic.GetAll();
            dataGrid.ItemsSource = products;
            Loaded += ProductosWindow_Loaded;
        }

        private void ProductosWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Width = dataGrid.ActualWidth + 250;
        }
    }
}
