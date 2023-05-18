using Entities;
using Logic.Repositories;
using System.Collections.Generic;
using System.Windows;

namespace UI_WPF
{
    public partial class QuerysLINQ : Window
    {
        private CustomersRepository customersRepository;
        private ProductsRepository productsRepository;

        public QuerysLINQ()
        {
            InitializeComponent();
            customersRepository = new CustomersRepository();
            productsRepository = new ProductsRepository();
        }

        private void Btn1_Click(object sender, RoutedEventArgs e)
        {
            listResults.Items.Clear();
            listResults.Items.Add("-----------------");
            listResults.Items.Add("1. Query para devolver objeto customer");
            listResults.Items.Add("Ejecutando la consulta...");
            List<Customers> customers = customersRepository.GetAll_QuerySyntax();
            listResults.Items.Add("Resultados:");
            foreach (Customers customer in customers)
            {
                listResults.Items.Add($"CustomerID: {customer.CustomerID}, CompanyName: {customer.CompanyName}");
            }
        }

        private void Btn2_Click(object sender, RoutedEventArgs e)
        {
            listResults.Items.Clear();
            listResults.Items.Add("-----------------");
            listResults.Items.Add("2. Query para devolver todos los productos sin stock");
            listResults.Items.Add("Ejecutando la consulta...");
            List<Products> products = productsRepository.ProductsWithOutStock_QuerySyntax();
            listResults.Items.Add("Resultados:");
            foreach (Products product in products)
            {
                listResults.Items.Add($"Producto: {product.ProductName}");
            }
        }


        private void Btn3_Click(object sender, RoutedEventArgs e)
        {
            listResults.Items.Clear();
            listResults.Items.Add("-----------------");
            listResults.Items.Add("3. Query para devolver los productos con stock y precio mayor o igual a 3");
            listResults.Items.Add("Ejecutando la consulta...");
            List<Products> products = productsRepository.ProductsWithStockAndPrice_QuerySyntax();
            listResults.Items.Add("Resultados:");
            foreach (Products product in products)
            {
                listResults.Items.Add($"Producto: {product.ProductName}, Stock: {product.UnitsInStock}, Precio: {product.UnitPrice}");
            }
        }

        private void Btn4_Click(object sender, RoutedEventArgs e)
        {
            listResults.Items.Clear();
            listResults.Items.Add("-----------------");
            listResults.Items.Add("4. Query para devolver todos los customers de la Región WA");
            listResults.Items.Add("Ejecutando la consulta...");
            List<Customers> customers = customersRepository.RegionWA_QuerySyntax();
            listResults.Items.Add("Resultados:");
            foreach (Customers customer in customers)
            {
                listResults.Items.Add($"CustomerID: {customer.CustomerID}, CompanyName: {customer.CompanyName}");
            }
        }

        private void Btn5_Click(object sender, RoutedEventArgs e)
        {
            listResults.Items.Clear();
            listResults.Items.Add("-----------------");
            listResults.Items.Add("5. Query para devolver el primer elemento o nulo de una lista de productos donde el ID de producto sea igual a 789");
            listResults.Items.Add("Ejecutando la consulta...");
            Products product = productsRepository.ProductWithId789_QuerySyntax();
            listResults.Items.Add("Resultado:");
            if (product != null)
            {
                listResults.Items.Add($"Producto: {product.ProductName}");
            }
            else
            {
                listResults.Items.Add("No se encontró ningún producto con el ID 789.");
            }
        }
        private void Btn6_Click(object sender, RoutedEventArgs e)
        {
            listResults.Items.Clear();
            listResults.Items.Add("-----------------");
            listResults.Items.Add("6. Query para devolver los nombres de los Customers en mayúscula y minúscula");
            listResults.Items.Add("Ejecutando la consulta...");
            List<string> customerNames = customersRepository.CustomersNameUpperAndLowerList_QuerySyntax();
            listResults.Items.Add("Resultados:");
            foreach (string name in customerNames)
            {
                listResults.Items.Add(name);
            }
        }

        private void Btn7_Click(object sender, RoutedEventArgs e)
        {
            listResults.Items.Clear();
            listResults.Items.Add("-----------------");
            listResults.Items.Add("7. Query para devolver el join entre Customers y Orders donde los customers sean de la Región WA y la fecha de orden sea mayor a 1/1/1997");
            listResults.Items.Add("Ejecutando la consulta...");
            List<Customers> customers = customersRepository.GetCustomersFromWAWithOrdersAfter1997_QuerySyntax();
            listResults.Items.Add("Resultados:");
            foreach (Customers customer in customers)
            {
                listResults.Items.Add($"CustomerID: {customer.CustomerID}, CompanyName: {customer.CompanyName}");
            }
        }

        private void Btn8_Click(object sender, RoutedEventArgs e)
        {
            listResults.Items.Clear();
            listResults.Items.Add("-----------------");
            listResults.Items.Add("8. Query para devolver los primeros 3 Customers de la Región WA");
            listResults.Items.Add("Ejecutando la consulta...");
            List<Customers> customers = customersRepository.GetFirstThreeCustomersFromWA_MethodSyntax();
            listResults.Items.Add("Resultados:");
            foreach (Customers customer in customers)
            {
                listResults.Items.Add($"CustomerID: {customer.CustomerID}, CompanyName: {customer.CompanyName}");
            }
        }

        private void Btn9_Click(object sender, RoutedEventArgs e)
        {
            listResults.Items.Clear();
            listResults.Items.Add("-----------------");
            listResults.Items.Add("9. Query para devolver la lista de productos ordenados por nombre");
            listResults.Items.Add("Ejecutando la consulta...");
            List<Products> products = productsRepository.GetProductsOrderedByName_MethodSyntax();
            listResults.Items.Add("Resultados:");
            foreach (Products product in products)
            {
                listResults.Items.Add($"ProductID: {product.ProductID}, ProductName: {product.ProductName}");
            }
        }

        private void Btn10_Click(object sender, RoutedEventArgs e)
        {
            listResults.Items.Clear();
            listResults.Items.Add("-----------------");
            listResults.Items.Add("10. Query para devolver la lista de productos ordenados por unidad en stock de mayor a menor");
            listResults.Items.Add("Ejecutando la consulta...");
            List<Products> products = productsRepository.GetProductsOrderedByStockInDescendingOrder_MethodSyntax();
            listResults.Items.Add("Resultados:");
            foreach (Products product in products)
            {
                listResults.Items.Add($"ProductID: {product.ProductID}, ProductName: {product.ProductName}, UnitsInStock: {product.UnitsInStock}");
            }
        }

        private void Btn11_Click(object sender, RoutedEventArgs e)
        {
            listResults.Items.Clear();
            listResults.Items.Add("-----------------");
            listResults.Items.Add("11. Query para devolver las distintas categorías asociadas a los productos");
            listResults.Items.Add("Ejecutando la consulta...");
            List<string> categories = productsRepository.GetDistinctCategories_MethodSyntax();
            listResults.Items.Add("Resultados:");
            foreach (string category in categories)
            {
                listResults.Items.Add(category);
            }
        }

        private void Btn12_Click(object sender, RoutedEventArgs e)
        {
            listResults.Items.Clear();
            listResults.Items.Add("-----------------");
            listResults.Items.Add("12. Query para devolver el primer elemento de una lista de productos");
            listResults.Items.Add("Ejecutando la consulta...");
            Products product = productsRepository.GetFirstProduct_MethodSyntax();
            listResults.Items.Add("Resultado:");
            if (product != null)
            {
                listResults.Items.Add($"Producto: {product.ProductName}");
            }
            else
            {
                listResults.Items.Add("No se encontraron productos.");
            }
        }
        private void Btn13_Click(object sender, RoutedEventArgs e)
        {
            listResults.Items.Clear();
            listResults.Items.Add("-----------------");
            listResults.Items.Add("13. Query para devolver los customers con la cantidad de órdenes asociadas");
            listResults.Items.Add("Ejecutando la consulta...");
            List<string> customerOrderCounts = customersRepository.GetCustomersWithOrderCount_MethodSyntax();
            listResults.Items.Add("Resultados:");
            foreach (string customerOrderCount in customerOrderCounts)
            {
                listResults.Items.Add(customerOrderCount);
            }
        }

    }
}
