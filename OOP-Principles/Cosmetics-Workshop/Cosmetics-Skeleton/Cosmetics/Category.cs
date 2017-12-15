using Bytes2you.Validation;
using Cosmetics.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cosmetics
{
    public class Category : ICategory
    {
        private readonly string name;
        private readonly ICollection<IProduct> products;

        public Category(string name)
        {
            Guard.WhenArgument(name.Length, "CategoryName length").IsLessThan(2).IsGreaterThan(15).Throw();
            Guard.WhenArgument(name, "CategoryName").IsNull().Throw();

            this.name = name;
            this.products = new List<IProduct>();
        }

        public ICollection<IProduct> Products => this.products;

        public string Name => this.name;

        public void AddProduct(IProduct product)
        {
            Guard.WhenArgument(product, "Product").IsNull().Throw();

            this.products.Add(product);
        }

        public void RemoveProduct(IProduct product)
        {
            Guard.WhenArgument(product, "Product").IsNull().Throw();

            var productFound = this.products.FirstOrDefault(x => x.Name == product.Name);

            Guard.WhenArgument(productFound, "ProductFound").IsNull().Throw();

            if (productFound != null)
            {
                this.products.Remove(productFound);
            }
        }

        public string Print()
        {
            if (!this.products.Any())
            {
                return $"#Category: {this.Name}\r\n #No product in this category";
            }

            var strBuilder = new StringBuilder();
            strBuilder.AppendLine($"#Category: {this.Name}");

            foreach (var product in this.products)
            {
                strBuilder.AppendLine(product.Print());
            }

            return strBuilder.ToString();
        }
    }
}