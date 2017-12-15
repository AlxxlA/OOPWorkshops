using System.Text;
using Bytes2you.Validation;
using Cosmetics.Common;
using Cosmetics.Contracts;

namespace Cosmetics.Products
{
    public abstract class Product : IProduct
    {
        private readonly string name;
        private readonly string brand;
        private readonly decimal price;
        private readonly GenderType gender;

        protected Product(string name, string brand, decimal price, GenderType gender)
        {
            Guard.WhenArgument(name, "name").IsNullOrEmpty().Throw();
            Guard.WhenArgument(name.Length, "name length").IsLessThan(3).Throw();
            Guard.WhenArgument(name.Length, "name length").IsGreaterThan(10).Throw();

            Guard.WhenArgument(brand, "brand").IsNullOrEmpty().Throw();
            Guard.WhenArgument(brand.Length, "brand length").IsLessThan(2).Throw();
            Guard.WhenArgument(brand.Length, "brand length").IsGreaterThan(10).Throw();

            Guard.WhenArgument(price, "Price").IsLessThan(0).Throw();

            this.name = name;
            this.brand = brand;
            this.price = price;
            this.gender = gender;
        }

        public string Name => this.name;

        public string Brand => this.brand;

        public decimal Price => this.price;

        public GenderType Gender => this.gender;

        public virtual string Print()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"#{this.Name} {this.Brand}");
            result.AppendLine($" #Price: ${this.Price}");
            result.AppendLine($" #Gender: {this.Gender}");
            return result.ToString();
        }
    }
}