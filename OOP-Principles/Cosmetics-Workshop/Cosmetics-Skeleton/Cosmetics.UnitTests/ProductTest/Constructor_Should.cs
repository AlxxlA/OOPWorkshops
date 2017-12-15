using Cosmetics.Common;
using Cosmetics.Contracts;
using Cosmetics.Products;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Cosmetics.UnitTests.ProductTest
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void ThrowWhenTheNameIsNull()
        {
            // Arrange, Act, Assert
            Assert.ThrowsException<ArgumentNullException>(() => new Shampoo(null, "brand", 10m, GenderType.Men, 10, UsageType.EveryDay));
        }

        [TestMethod]
        public void ThrowWhenTheBrandIsNull()
        {
            // Arrange, Act, Assert
            Assert.ThrowsException<ArgumentNullException>(() => new Shampoo("name", null, 10m, GenderType.Men, 10, UsageType.EveryDay));
        }

        [TestMethod]
        public void ThrowWhenTheNameIsSmallerThanMinValue()
        {
            // Arrange, Act, Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Shampoo("1", "brand", 10m, GenderType.Men, 10, UsageType.EveryDay));
        }

        [TestMethod]
        public void ThrowWhenTheNameIsLargerThanMaxValue()
        {
            // Arrange, Act, Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Shampoo(new string('a', 11), "brand", 10m, GenderType.Men, 10, UsageType.EveryDay));

        }

        [TestMethod]
        public void ThrowWhenTheBrandIsSmallerThanMinValue()
        {
            // Arrange, Act, Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Shampoo("name", "b", 10m, GenderType.Men, 10, UsageType.EveryDay));
        }

        [TestMethod]
        public void ThrowWhenTheBrandIsLargerThanMaxValue()
        {
            // Arrange, Act, Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Shampoo("name", new string('a', 11), 10m, GenderType.Men, 10, UsageType.EveryDay));
        }

        [TestMethod]
        public void ThrowWhenPriceIsNegative()
        {
            // Arrange, Act, Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Shampoo("name", "brand", -1m, GenderType.Men, 10, UsageType.EveryDay));
        }

        [TestMethod]
        public void CreateShampooWhenValidValuesArePassed()
        {
            // Arrange, Act

            var shampoo = new Shampoo("name", "brand", 10m, GenderType.Women, 10, UsageType.EveryDay);

            // Assert
            Assert.IsInstanceOfType(shampoo, typeof(IProduct));
        }

        [TestMethod]
        public void ThrowWhenNullIngredientsArePassed()
        {
            // Arrange, Act, Assert
            Assert.ThrowsException<ArgumentNullException>(()=> new Toothpaste("name", "brand", 10m, GenderType.Women, null));
        }

        [TestMethod]
        public void CreateToothpasteWhenValidValuesArePassed()
        {
            // Arrange, Act
            var toothpaste = new Toothpaste("name", "brand", 10m, GenderType.Women, "ingredients");

            // Assert
            Assert.IsInstanceOfType(toothpaste, typeof(IProduct));
        }
    }
}
