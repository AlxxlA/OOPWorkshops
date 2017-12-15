using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetics.UnitTests.CategoryTest
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void ThrowWhenTheNameIsSmallerThanMinValue()
        {
            // Arrange, Act, Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Category("1"));
        }

        [TestMethod]
        public void ThrowWhenTheNameIsLargerThanMaxValue()
        {
            // Arrange, Act, Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Category(new string('a', 16)));
        }

        [TestMethod]
        public void CreateCategoryWhenNameIsValid()
        {
            // Arrange, Act

            var category = new Category("test");

            // Assert
            Assert.IsInstanceOfType(category, typeof(Category));
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
