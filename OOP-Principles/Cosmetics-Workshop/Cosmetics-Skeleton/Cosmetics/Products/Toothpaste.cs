using Bytes2you.Validation;
using Cosmetics.Common;
using Cosmetics.Contracts;
using System.Text;

namespace Cosmetics.Products
{
    public class Toothpaste : Product, IToothpaste
    {
        private readonly string ingredients;

        public Toothpaste(string name, string brand, decimal price, GenderType gender, string ingredients)
            : base(name, brand, price, gender)
        {
            Guard.WhenArgument(ingredients, "ingredients").IsNull().Throw();
            this.ingredients = ingredients;
        }

        public string Ingredients
        {
            get { return this.ingredients; }
        }

        public override string Print()
        {
            StringBuilder result = new StringBuilder();

            result.Append(base.Print());

            result.AppendLine($" #Ingredients: {this.Ingredients}");

            return result.ToString();
        }
    }
}