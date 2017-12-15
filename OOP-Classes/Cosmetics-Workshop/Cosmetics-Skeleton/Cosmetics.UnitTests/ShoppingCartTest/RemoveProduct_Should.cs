using Cosmetics.Cart;
using Cosmetics.Common;
using Cosmetics.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace Cosmetics.UnitTests.ShoppingCartTest
{
    [TestClass]
    public class ContainsProduct_Should
    {
        [TestMethod]
        public void ThrowWhenTheProductIsNull()
        {
            // Arrange, Act
            var cart = new ShoppingCart();

            // Act, Assert
            Assert.ThrowsException<ArgumentNullException>(() => cart.ContainsProduct(null));
        }

        [TestMethod]
        public void ReturnTrueWhenProductIFound()
        {
            // Arrange, Act
            var cart = new ShoppingCart();
            var productToAdd = new Mock<Product>(MockBehavior.Loose, new object[] { "name", "brand", 10m, GenderType.Men });

            cart.ProductList.Add(productToAdd.Object);
            cart.ProductList.Add(productToAdd.Object);

            // Act
            var isFound = cart.ContainsProduct(productToAdd.Object);

            //Assert
            Assert.IsTrue(isFound);
        }

        [TestMethod]
        public void ReturnFalseWhenProductIFound()
        {
            // Arrange, Act
            var cart = new ShoppingCart();
            var productToAdd = new Mock<Product>(MockBehavior.Loose, new object[] { "name", "brand", 10m, GenderType.Men });

            // Act
            var isFound = cart.ContainsProduct(productToAdd.Object);

            //Assert
            Assert.IsFalse(isFound);
        }
    }
}
