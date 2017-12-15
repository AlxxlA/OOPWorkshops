using Bytes2you.Validation;
using Cosmetics.Products;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Cosmetics.Cart
{
    public class ShoppingCart
    {
        private readonly List<Product> productList;

        public ShoppingCart()
        {
            this.productList = new List<Product>();
        }

        public List<Product> ProductList
        {
            get { return this.productList; }
        }

        public void AddProduct(Product product)
        {
            Guard.WhenArgument(product, "Product").IsNull().Throw();
            this.ProductList.Add(product);
        }

        public void RemoveProduct(Product product)
        {
            Guard.WhenArgument(product, "Product").IsNull().Throw();
            this.ProductList.Remove(product);
        }

        public bool ContainsProduct(Product product)
        {
            Guard.WhenArgument(product, "Product").IsNull().Throw();
            return this.ProductList.Contains(product);
        }

        public decimal TotalPrice()
        {
            decimal totalPrice = 0;

            foreach (var product in this.ProductList)
            {
                totalPrice += product.Price;
            }

            return totalPrice;
        }
    }
}