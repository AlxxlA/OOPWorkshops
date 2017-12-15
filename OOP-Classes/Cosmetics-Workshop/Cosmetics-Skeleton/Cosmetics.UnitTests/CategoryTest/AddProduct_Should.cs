using Cosmetics.Common;
using Cosmetics.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace Cosmetics.UnitTests.CategoryTest
{
    [TestClass]
    public class AddProduct_Should
    {
        [TestMethod]
        public void ThrowWhenTheProductIsNull()
        {
            // Arrange, Act
            var category = new Category("test");

            // Act, Assert
            Assert.ThrowsException<ArgumentNullException>(() => category.AddProduct(null));
        }

        [TestMethod]
        public void AddProductWhenProductIsValid()
        {
            // Arrange
            var category = new Category("test");
            var productToAdd = new Mock<Product>(MockBehavior.Loose, new object[] { "name", "brand", 10m, GenderType.Men });

            // Act
            category.AddProduct(productToAdd.Object);
            category.AddProduct(productToAdd.Object);

            //Assert
            Assert.AreEqual(2, category.Products.Count);
        }
    }
}
