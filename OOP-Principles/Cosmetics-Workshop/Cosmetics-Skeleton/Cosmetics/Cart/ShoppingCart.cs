using Bytes2you.Validation;
using Cosmetics.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Cosmetics.Cart
{
    public class ShoppingCart : IShoppingCart
    {
        private readonly ICollection<IProduct> productList;

        public ShoppingCart()
        {
            this.productList = new List<IProduct>();
        }

        public ICollection<IProduct> ProductList
        {
            get { return this.productList; }
        }

        public void AddProduct(IProduct product)
        {
            Guard.WhenArgument(product, "Product").IsNull().Throw();

            this.productList.Add(product);
        }

        public void RemoveProduct(IProduct product)
        {
            Guard.WhenArgument(product, "Product").IsNull().Throw();

            this.productList.Remove(product);
        }

        public bool ContainsProduct(IProduct product)
        {
            Guard.WhenArgument(product, "Product").IsNull().Throw();

            return this.productList.Any(x => x.Name == product.Name);
        }

        public decimal TotalPrice()
        {
            return this.productList.Sum(x => x.Price);
        }
    }
}