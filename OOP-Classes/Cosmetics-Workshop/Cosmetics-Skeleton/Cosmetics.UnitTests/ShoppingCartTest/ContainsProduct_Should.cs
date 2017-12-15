using Cosmetics.Cart;
using Cosmetics.Common;
using Cosmetics.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace Cosmetics.UnitTests.ShoppingCartTest
{
    [TestClass]
    public class RemoveProduct_Should
    {
        [TestMethod]
        public void ThrowWhenTheProductIsNull()
        {
            // Arrange, Act
            var cart = new ShoppingCart();

            // Act, Assert
            Assert.ThrowsException<ArgumentNullException>(() => cart.RemoveProduct(null));
        }

        [TestMethod]
        public void RemoveProductWhenProductIsValid()
        {
            // Arrange, Act
            var cart = new ShoppingCart();
            var productToAdd = new Mock<Product>(MockBehavior.Loose, new object[] { "name", "brand", 10m, GenderType.Men });

            cart.ProductList.Add(productToAdd.Object);
            cart.ProductList.Add(productToAdd.Object);

            // Act
            cart.RemoveProduct(productToAdd.Object);

            //Assert
            Assert.AreEqual(1, cart.ProductList.Count);
        }
    }
}
