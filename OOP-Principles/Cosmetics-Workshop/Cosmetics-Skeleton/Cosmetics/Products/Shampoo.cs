using Bytes2you.Validation;
using Cosmetics.Common;
using Cosmetics.Contracts;
using System.Text;

namespace Cosmetics.Products
{
    public class Shampoo : Product, IShampoo
    {
        private readonly uint mililitres;
        private readonly UsageType usageType;

        public Shampoo(string name, string brand, decimal price, GenderType gender, uint mililitres, UsageType usageType)
            : base(name, brand, price, gender)
        {
            Guard.WhenArgument(mililitres, "mililitres").IsLessThan((uint)0).Throw();

            this.mililitres = mililitres;
            this.usageType = usageType;
        }

        public uint Militres => this.mililitres;

        public UsageType UsageType => this.usageType;

        public override string Print()
        {
            StringBuilder result = new StringBuilder();

            result.Append(base.Print());

            result.AppendLine($" #Milliliters: {this.Militres}");
            result.Append($" #Usage: {this.UsageType}");

            return result.ToString();
        }
    }
}