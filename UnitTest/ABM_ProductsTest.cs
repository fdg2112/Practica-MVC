using Data;
using Entities;
using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;

namespace Logic.Tests
{
    [TestClass()]
    public class ABM_ProductsTest
    {
        [TestMethod()]
        public void GetAllTest()
        {
            // Arrange
            var productList = new List<Products>
            {
                new Products { ProductID = 2, ProductName = "Chai" },
                new Products { ProductID = 3, ProductName = "Chang" },
                new Products { ProductID = 4, ProductName = "Aniseed Syrup" },
            };

            var mockSet = new Mock<DbSet<Products>>();
            mockSet.As<IQueryable<Products>>().Setup(m => m.Provider).Returns(productList.AsQueryable().Provider);
            mockSet.As<IQueryable<Products>>().Setup(m => m.Expression).Returns(productList.AsQueryable().Expression);
            mockSet.As<IQueryable<Products>>().Setup(m => m.ElementType).Returns(productList.AsQueryable().ElementType);
            mockSet.As<IQueryable<Products>>().Setup(m => m.GetEnumerator()).Returns(productList.GetEnumerator());

            var mockContext = new Mock<NorthwindContext>();
            mockContext.Setup(c => c.Products).Returns(mockSet.Object);

            var productsLogic = new ProductsLogic(mockContext.Object);

            // Act
            var result = productsLogic.GetAll();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Any());
        }

        [TestMethod]
        public void AddTest()
        {
            // Arrange
            var mockSet = new Mock<DbSet<Products>>();

            var mockContext = new Mock<NorthwindContext>();
            mockContext.Setup(m => m.Products).Returns(mockSet.Object);

            var productsLogic = new ProductsLogic(mockContext.Object);
            var product = new Products
            {
                ProductName = "Test Product",
                CategoryID = 1,
                SupplierID = 1,
                QuantityPerUnit = "AA",
                UnitPrice = 10.0M,
                UnitsInStock = 100,
                ReorderLevel = 0,
                UnitsOnOrder = 0,
                Discontinued = false
            };

            // Act
            productsLogic.Add(product);

            // Assert
            mockSet.Verify(m => m.Add(It.IsAny<Products>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [TestMethod()]
        public void DeleteTest()
        {
            // Arrange
            var mockSet = new Mock<DbSet<Products>>();

            var mockContext = new Mock<NorthwindContext>();
            mockContext.Setup(m => m.Products).Returns(mockSet.Object);

            var productsLogic = new ProductsLogic(mockContext.Object);
            var product = new Products
            {
                ProductID = 1,
                ProductName = "Test Product",
                CategoryID = 1,
                SupplierID = 1,
                QuantityPerUnit = "AA",
                UnitPrice = 10.0M,
                UnitsInStock = 100,
                ReorderLevel = 0,
                UnitsOnOrder = 0,
                Discontinued = false
            };

            productsLogic.Add(product);

            mockSet.Setup(m => m.Find(It.IsAny<object[]>()))
                   .Throws(new InvalidOperationException("Fake exception"));

            // Act and Assert
            Assert.ThrowsException<Exception>(() => productsLogic.Delete(product.ProductID));
        }

        [TestMethod()]
        public void UpdateTest()
        {

            // Arrange
            var mockSet = new Mock<DbSet<Products>>();
            var mockContext = new Mock<NorthwindContext>();
            mockContext.Setup(m => m.Products).Returns(mockSet.Object);
            var productsLogic = new ProductsLogic(mockContext.Object);
            var product = new Products
            {
                ProductID = 1,
                ProductName = "Test Product",
                CategoryID = 1,
                SupplierID = 1,
                QuantityPerUnit = "AA",
                UnitPrice = 10.0M,
                UnitsInStock = 100,
                ReorderLevel = 0,
                UnitsOnOrder = 0,
                Discontinued = false
            };
            productsLogic.Add(product);
            var newProduct = new Products()
            {
                ProductID = 1,
                ProductName = "New Test Product",
                CategoryID = 2,
                SupplierID = 2,
                QuantityPerUnit = "BB",
                UnitPrice = 20.0M,
                UnitsInStock = 200,
                ReorderLevel = 0,
                UnitsOnOrder = 0,
                Discontinued = false
            };
            mockSet.Setup(m => m.Find(It.IsAny<int>())).Returns(product);

            // Act
            productsLogic.Update(newProduct);

            // Assert
            var result = productsLogic.GetOne(1);
            Assert.AreEqual(newProduct.ProductName, result.ProductName);
            Assert.AreEqual(newProduct.CategoryID, result.CategoryID);
            Assert.AreEqual(newProduct.SupplierID, result.SupplierID);
            Assert.AreEqual(newProduct.QuantityPerUnit, result.QuantityPerUnit);
            Assert.AreEqual(newProduct.UnitPrice, result.UnitPrice);
            Assert.AreEqual(newProduct.UnitsInStock, result.UnitsInStock);
            Assert.AreEqual(newProduct.ReorderLevel, result.ReorderLevel);
            Assert.AreEqual(newProduct.UnitsOnOrder, result.UnitsOnOrder);
            Assert.AreEqual(newProduct.Discontinued, result.Discontinued);
        }
    }
}
