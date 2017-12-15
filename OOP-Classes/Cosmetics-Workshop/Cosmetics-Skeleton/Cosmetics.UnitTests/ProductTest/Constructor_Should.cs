using Cosmetics.Common;
using Cosmetics.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Cosmetics.UnitTests.ProductTest
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void ThrowWhenTheNameIsSmallerThanMinValue()
        {
            // Arrange, Act, Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Product("1", "brand", 10m, GenderType.Men));
        }

        [TestMethod]
        public void ThrowWhenTheNameIsLargerThanMaxValue()
        {
            // Arrange, Act, Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Product(new string('a', 11), "brand", 10m, GenderType.Men));

        }

        [TestMethod]
        public void ThrowWhenTheBrandIsSmallerThanMinValue()
        {
            // Arrange, Act, Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Product("name", "b", 10m, GenderType.Men));
        }

        [TestMethod]
        public void ThrowWhenTheBrandIsLargerThanMaxValue()
        {
            // Arrange, Act, Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Product("name", new string('a', 11), 10m, GenderType.Men));
        }

        [TestMethod]
        public void ThrowWhenPriceIsNegative()
        {
            // Arrange, Act, Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Product("name", "brand", -1m, GenderType.Men));
        }

        [TestMethod]
        public void CreateProductWhenValidValuesArePassed()
        {
            // Arrange, Act

            var category = new Product("name", "brand", 10m, GenderType.Women);

            // Assert
            Assert.IsInstanceOfType(category, typeof(Product));
        }

        [TestMethod]
        public void InitializeNewListOfProductsWhenCategoryIsCreated()
        {
            // Arrange, Act

            var category = new Category("test");

            // Assert
            Assert.IsNotNull(category.Products);
        }
    }
}
