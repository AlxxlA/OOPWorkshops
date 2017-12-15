using Bytes2you.Validation;
using Cosmetics.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cosmetics
{
    public class Category
    {
        private readonly string name;
        private readonly List<Product> products;

        public Category(string name)
        {
            // validate name
            Guard.WhenArgument(name, "Category name").IsNullOrWhiteSpace().Throw();
            Guard.WhenArgument(name.Length, "Category name length").IsLessThan(2).Throw();
            Guard.WhenArgument(name.Length, "Category name length").IsGreaterThan(15).Throw();

            this.name = name;
            this.products = new List<Product>();
        }

        public string Name
        {
            get { return this.name; }
        }

        public List<Product> Products
        {
            get { return this.products; }
        }

        public virtual void AddProduct(Product product)
        {
            Guard.WhenArgument(product, "Product").IsNull().Throw();
            this.Products.Add(product);
        }

        public virtual void RemoveProduct(Product product)
        {
            if (this.Products.IndexOf(product) == -1)
            {
                throw new ArgumentNullException("Product does not exist in current category.");
            }

            this.Products.Remove(product);
        }

        public string Print()
        {
            var productsSorted = this.Products.OrderBy(x => x.Brand).ThenByDescending(x => x.Price);

            var strBuilder = new StringBuilder();

            strBuilder.Append($"#Category: {this.Name}\r\n");

            if (this.Products.Count == 0)
            {
                strBuilder.Append(" #No product in this category");
            }
            else
            {
                foreach (var product in productsSorted)
                {
                    strBuilder.AppendLine(product.Print());
                }
            }

            return strBuilder.ToString();
        }
    }
}