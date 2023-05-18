using Data;
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
using Logic;
using Entities;
using System.Text.RegularExpressions;

namespace Practica_EntityFramework
{
    /// <summary>
    /// Lógica de interacción para AddProducts.xaml
    /// </summary>
    public partial class AddProducts : Window
    {
        public AddProducts()
        {
            InitializeComponent();
        }

        public void ValidatePrice(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9,]+");
            string currentText = ((TextBox)sender).Text;
            string proposedText = currentText.Substring(0, ((TextBox)sender).SelectionStart) + e.Text + currentText.Substring(((TextBox)sender).SelectionStart + ((TextBox)sender).SelectionLength);
            int countCommas = proposedText.Count(c => c == ',');
            e.Handled = regex.IsMatch(e.Text) || countCommas > 1;
        }

        public void ValidateNumber(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var context = new NorthwindContext())
                {
                    var suppliers = context.Suppliers.Select(s => new { s.SupplierID, s.CompanyName }).ToList();
                    cmbSupplier.ItemsSource = suppliers;
                    cmbSupplier.DisplayMemberPath = "CompanyName";
                    cmbSupplier.SelectedValuePath = "SupplierID";
                    var category = context.Categories.Select(c => new { c.CategoryID, c.CategoryName }).ToList();
                    cmbCategory.ItemsSource = category;
                    cmbCategory.DisplayMemberPath = "CategoryName";
                    cmbCategory.SelectedValuePath = "CategoryID";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error al cargar los campos de la ventana... Detalle del error: " + ex.Message);
            }
        }

        public void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var product = new Products
                {
                    ProductName = txtProductName.Text,
                    SupplierID = cmbSupplier.SelectedValue != null && !string.IsNullOrEmpty(cmbSupplier.SelectedValue.ToString()) ? Convert.ToInt32(cmbSupplier.SelectedValue) : 0,
                    CategoryID = cmbCategory.SelectedValue != null && !string.IsNullOrEmpty(cmbCategory.SelectedValue.ToString()) ? Convert.ToInt32(cmbCategory.SelectedValue) : 0,
                    QuantityPerUnit = txtQuantityPerUnit.Text,
                    UnitPrice = !string.IsNullOrEmpty(txtUnitPrice.Text) ? Convert.ToDecimal(txtUnitPrice.Text) : 0,
                    UnitsInStock = string.IsNullOrEmpty(txtUnitsInStock.Text) ? (short?)null : Convert.ToInt16(txtUnitsInStock.Text),
                    UnitsOnOrder = string.IsNullOrEmpty(txtUnitsOnOrder.Text) ? (short?)null : Convert.ToInt16(txtUnitsOnOrder.Text),
                    ReorderLevel = string.IsNullOrEmpty(txtReorderLevel.Text) ? (short?)null : Convert.ToInt16(txtReorderLevel.Text),
                    Discontinued = chkDiscontinued.IsChecked ?? false
                };
                var productsLogic = new ProductsLogic();
                productsLogic.Add(product);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
