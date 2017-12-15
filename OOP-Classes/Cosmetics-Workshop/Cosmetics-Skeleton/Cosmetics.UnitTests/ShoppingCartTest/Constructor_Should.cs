using Cosmetics.Cart;
using Cosmetics.Common;
using Cosmetics.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Cosmetics.UnitTests.ShoppingCartTest
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void InitializeNewListOfProductsWhenCategoryIsCreated()
        {
            // Arrange, Act

            var category = new ShoppingCart();

            // Assert
            Assert.IsNotNull(category.ProductList);
        }
    }
}
