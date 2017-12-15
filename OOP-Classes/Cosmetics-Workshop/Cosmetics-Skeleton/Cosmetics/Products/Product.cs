using Bytes2you.Validation;
using Cosmetics.Common;
using System;

namespace Cosmetics.Products
{
    public class Product
    {
        private readonly decimal price;
        private readonly string name;
        private readonly string brand;
        private readonly GenderType gender;

        public Product(string name, string brand, decimal price, GenderType gender)
        {
            // validate name
            Guard.WhenArgument(name, "Product name").IsNullOrWhiteSpace().Throw();
            Guard.WhenArgument(name.Length, "Product name length").IsLessThan(3).Throw();
            Guard.WhenArgument(name.Length, "Product name length").IsGreaterThan(10).Throw();

            // validate brand
            Guard.WhenArgument(brand, "Brand").IsNullOrWhiteSpace().Throw();
            Guard.WhenArgument(brand.Length, "Brand length").IsLessThan(2).Throw();
            Guard.WhenArgument(brand.Length, "Brand length").IsGreaterThan(10).Throw();

            // validate price
            Guard.WhenArgument(price, "Product price").IsLessThan(0).Throw();

            this.name = name;
            this.brand = brand;
            this.price = price;
            this.gender = gender;
        }

        public decimal Price => this.price;

        public string Name => this.name;

        public string Brand => this.brand;

        public GenderType Gender => this.gender;

        public string Print()
        {
            return $" #{this.Name} {this.Brand}\r\n #Price: ${this.Price}\r\n #Gender: {this.Gender}\r\n ===";
        }
    }
}