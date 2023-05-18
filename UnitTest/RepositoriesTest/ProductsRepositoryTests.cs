using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Logic.Repositories.Tests
{
    [TestClass()]
    public class ProductsRepositoryTests
    {
        [TestMethod]
        public void Test_ProductsWithOutStock_QuerySyntax()
        {
            // Arrange
            var productsLogic = new ProductsRepository();

            // Act
            var products = productsLogic.ProductsWithOutStock_QuerySyntax();

            // Assert
            Assert.IsNotNull(products);
            Assert.IsTrue(products.Any());
        }

        [TestMethod]
        public void Test_ProductsWithOutStock_MethodSyntax()
        {
            // Arrange
            var productsLogic = new ProductsRepository();

            // Act
            var products = productsLogic.ProductsWithOutStock_MethodSyntax();

            // Assert
            Assert.IsNotNull(products);
            Assert.IsTrue(products.Any());
        }

        [TestMethod]
        public void Test_ProductsWithStockAndPrice_QuerySyntax()
        {
            // Arrange
            var productsLogic = new ProductsRepository();

            // Act
            var products = productsLogic.ProductsWithStockAndPrice_QuerySyntax();

            // Assert
            Assert.IsNotNull(products);
            Assert.IsTrue(products.Any());
        }

        [TestMethod]
        public void Test_ProductsWithStockAndPrice_MethodSyntax()
        {
            // Arrange
            var productsLogic = new ProductsRepository();

            // Act
            var products = productsLogic.ProductsWithStockAndPrice_MethodSyntax();

            // Assert
            Assert.IsNotNull(products);
            Assert.IsTrue(products.Any());
        }

        [TestMethod]
        public void Test_ProductWithId789_QuerySyntax()
        {
            // Arrange
            var productsLogic = new ProductsRepository();

            // Act
            var product = productsLogic.ProductWithId789_QuerySyntax();

            // Assert
            Assert.IsNull(product);
        }

        [TestMethod]
        public void Test_ProductWithId789_MethodSyntax()
        {
            // Arrange
            var productsLogic = new ProductsRepository();

            // Act
            var product = productsLogic.ProductWithId789_MethodSyntax();

            // Assert
            Assert.IsNull(product);
        }


        [TestMethod]
        public void Test_GetProductsOrderedByName_QuerySyntax()
        {
            // Arrange
            var productsLogic = new ProductsRepository();

            // Act
            var products = productsLogic.GetProductsOrderedByName_QuerySyntax();

            // Assert
            Assert.IsNotNull(products);
            Assert.IsTrue(products.Any());
        }

        [TestMethod]
        public void Test_GetProductsOrderedByName_MethodSyntax()
        {
            // Arrange
            var productsLogic = new ProductsRepository();

            // Act
            var products = productsLogic.GetProductsOrderedByName_MethodSyntax();

            // Assert
            Assert.IsNotNull(products);
            Assert.IsTrue(products.Any());
        }

        [TestMethod]
        public void Test_GetProductsOrderedByStockInDescendingOrder_QuerySyntax()
        {
            // Arrange
            var productsLogic = new ProductsRepository();

            // Act
            var products = productsLogic.GetProductsOrderedByStockInDescendingOrder_QuerySyntax();

            // Assert
            Assert.IsNotNull(products);
            Assert.IsTrue(products.Any());
        }

        [TestMethod]
        public void Test_GetProductsOrderedByStockInDescendingOrder_MethodSyntax()
        {
            // Arrange
            var productsLogic = new ProductsRepository();

            // Act
            var products = productsLogic.GetProductsOrderedByStockInDescendingOrder_MethodSyntax();

            // Assert
            Assert.IsNotNull(products);
            Assert.IsTrue(products.Any());
        }

        [TestMethod]
        public void Test_GetDistinctCategories_QuerySyntax()
        {
            // Arrange
            var productsLogic = new ProductsRepository();

            // Act
            var categories = productsLogic.GetDistinctCategories_QuerySyntax();

            // Assert
            Assert.IsNotNull(categories);
            Assert.IsTrue(categories.Any());
        }

        [TestMethod]
        public void Test_GetDistinctCategories_MethodSyntax()
        {
            // Arrange
            var productsLogic = new ProductsRepository();

            // Act
            var categories = productsLogic.GetDistinctCategories_MethodSyntax();

            // Assert
            Assert.IsNotNull(categories);
            Assert.IsTrue(categories.Any());
        }

        [TestMethod]
        public void Test_GetFirstProduct_QuerySyntax()
        {
            // Arrange
            var productsLogic = new ProductsRepository();

            // Act
            var product = productsLogic.GetFirstProduct_QuerySyntax();

            // Assert
            Assert.IsNotNull(product);
        }

        [TestMethod]
        public void Test_GetFirstProduct_MethodSyntax()
        {
            // Arrange
            var productsLogic = new ProductsRepository();

            // Act
            var product = productsLogic.GetFirstProduct_MethodSyntax();

            // Assert
            Assert.IsNotNull(product);
        }

    }
}