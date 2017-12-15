using Cosmetics.Cart;
using Cosmetics.Common;
using Cosmetics.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace Cosmetics.UnitTests.ShoppingCartTest
{
    [TestClass]
    public class AddProduct_Should
    {
        [TestMethod]
        public void ThrowWhenTheProductIsNull()
        {
            // Arrange, Act
            var cart = new ShoppingCart();

            // Act, Assert
            Assert.ThrowsException<ArgumentNullException>(() => cart.AddProduct(null));
        }

        [TestMethod]
        public void AddProductWhenProductIsValid()
        {
            // Arrange
            var cart = new ShoppingCart();
            var productToAdd = new Mock<Product>(MockBehavior.Loose, new object[] { "name", "brand", 10m, GenderType.Men });

            // Act
            cart.AddProduct(productToAdd.Object);
            cart.AddProduct(productToAdd.Object);

            //Assert
            Assert.AreEqual(2, cart.ProductList.Count);
        }
    }
}
