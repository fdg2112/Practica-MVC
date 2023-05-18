using Data;
using Entities;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Practica_EntityFramework
{
    /// <summary>
    /// Lógica de interacción para UpdateProduct.xaml
    /// </summary>
    public partial class UpdateProduct : Window
    {
        private readonly ProductsLogic productsLogic = new ProductsLogic();
        public UpdateProduct()
        {
            InitializeComponent();
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

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            int id = Convert.ToInt32(txtProductID.Text);
            if (productsLogic.Finded(id))
            {
                var products = productsLogic.GetOne(id);
                txtProductName.Text = products.ProductName;
                cmbSupplier.SelectedValue = products.SupplierID;
                cmbCategory.SelectedValue = products.CategoryID;
                txtQuantityPerUnit.Text = products.QuantityPerUnit;
                txtUnitPrice.Text = Convert.ToString(products.UnitPrice);
                txtUnitsInStock.Text = Convert.ToString(products.UnitsInStock);
                txtUnitsOnOrder.Text = Convert.ToString(products.UnitsOnOrder);
                txtReorderLevel.Text = Convert.ToString(products.ReorderLevel);
                chkDiscontinued.IsChecked = products.Discontinued;
            }
            else MessageBox.Show("No se encontró ninguna coincidencia con ese ID");
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = int.Parse(txtProductID.Text);
                if (productsLogic.Finded(id))
                {
                    productsLogic.Update(new Products
                    {
                        ProductID = int.Parse(txtProductID.Text),
                        ProductName = txtProductName.Text,
                        SupplierID = (int?)cmbSupplier.SelectedValue,
                        CategoryID = (int?)cmbCategory.SelectedValue,
                        QuantityPerUnit = txtQuantityPerUnit.Text,
                        UnitPrice = decimal.Parse(txtUnitPrice.Text),
                        UnitsInStock = short.Parse(txtUnitsInStock.Text),
                        UnitsOnOrder = short.Parse(txtUnitsOnOrder.Text),
                        ReorderLevel = short.Parse(txtReorderLevel.Text),
                        Discontinued = chkDiscontinued.IsChecked ?? false
                    });
                    MessageBox.Show("Producto modificado!");
                    this.Close();
                }
                else MessageBox.Show("No se ha podido modificar! No se ha podido encontrar un producto con ese ID");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = int.Parse(txtProductID.Text);
                if (productsLogic.Finded(id))
                {
                    productsLogic.Delete(id);
                    MessageBox.Show("Producto borrado!");
                    this.Close();
                } else MessageBox.Show("No se ha podido borrar! No se ha podido encontrar un producto con ese ID");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
