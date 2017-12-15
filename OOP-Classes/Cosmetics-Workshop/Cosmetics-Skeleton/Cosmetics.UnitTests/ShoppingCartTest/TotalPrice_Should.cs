using Cosmetics.Cart;
using Cosmetics.Common;
using Cosmetics.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace Cosmetics.UnitTests.ShoppingCartTest
{
    [TestClass]
    public class TotalPrice_Should
    {
        [TestMethod]
        public void ReturnThePriceOfTheProducts()
        {
            // Arrange, Act

            var cart = new ShoppingCart();

            var productToAdd = new Mock<Product>(MockBehavior.Loose, new object[] { "name", "brand", 10m, GenderType.Men });
            cart.AddProduct(productToAdd.Object);
            cart.AddProduct(productToAdd.Object);

            // Act
            var price = cart.TotalPrice();

            // Assert
            Assert.AreEqual(20, price);
        }
    }
}
