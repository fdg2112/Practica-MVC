using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Logic.Repositories.Tests
{
    [TestClass()]
    public class CustomersRepositoryTests
    {
        [TestMethod()]
        public void GetAll_QuerySyntaxTest()
        {
            // Arrange
            var customersLogic = new CustomersRepository();

            // Act
            var customers = customersLogic.GetAll_QuerySyntax();

            // Assert
            Assert.IsNotNull(customers);
            Assert.IsTrue(customers.Any());
        }

        [TestMethod]
        public void Test_GetAll_MethodSyntax()
        {
            // Arrange
            var customersLogic = new CustomersRepository();

            // Act
            var customers = customersLogic.GetAll_MethodSyntax();

            // Assert
            Assert.IsNotNull(customers);
            Assert.IsTrue(customers.Any());
        }

        [TestMethod]
        public void Test_RegionWA_QuerySyntax()
        {
            // Arrange
            var customersLogic = new CustomersRepository();

            // Act
            var customers = customersLogic.RegionWA_QuerySyntax();

            // Assert
            Assert.IsNotNull(customers);
            Assert.IsTrue(customers.Any());
        }

        [TestMethod]
        public void Test_RegionWA_MethodSyntax()
        {
            // Arrange
            var customersLogic = new CustomersRepository();

            // Act
            var customers = customersLogic.RegionWA_MethodSyntax();

            // Assert
            Assert.IsNotNull(customers);
            Assert.IsTrue(customers.Any());
        }

        [TestMethod]
        public void Test_GetCustomersFromWAWithOrdersAfter1997_QuerySyntax()
        {
            // Arrange
            var customersLogic = new CustomersRepository();

            // Act
            var customers = customersLogic.GetCustomersFromWAWithOrdersAfter1997_QuerySyntax();

            // Assert
            Assert.IsNotNull(customers);
            Assert.IsTrue(customers.Any());
        }

        [TestMethod]
        public void Test_GetCustomersFromWAWithOrdersAfter1997_MethodSyntax()
        {
            // Arrange
            var customersLogic = new CustomersRepository();

            // Act
            var customers = customersLogic.GetCustomersFromWAWithOrdersAfter1997_MethodSyntax();

            // Assert
            Assert.IsNotNull(customers);
            Assert.IsTrue(customers.Any());
        }

        [TestMethod]
        public void Test_GetFirstThreeCustomersFromWA_QuerySyntax()
        {
            // Arrange
            var customersLogic = new CustomersRepository();

            // Act
            var customers = customersLogic.GetFirstThreeCustomersFromWA_QuerySyntax();

            // Assert
            Assert.IsNotNull(customers);
            Assert.IsTrue(customers.Any());
            Assert.IsTrue(customers.Count <= 3);
        }

        [TestMethod]
        public void Test_GetFirstThreeCustomersFromWA_MethodSyntax()
        {
            // Arrange
            var customersLogic = new CustomersRepository();

            // Act
            var customers = customersLogic.GetFirstThreeCustomersFromWA_MethodSyntax();

            // Assert
            Assert.IsNotNull(customers);
            Assert.IsTrue(customers.Any());
            Assert.IsTrue(customers.Count <= 3);
        }
    }
}