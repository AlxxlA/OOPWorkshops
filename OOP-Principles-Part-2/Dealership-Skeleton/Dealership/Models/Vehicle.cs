using System;
using System.Collections.Generic;
using System.Text;
using Dealership.Common.Enums;
using Dealership.Contracts;

namespace Dealership.Models
{
    public abstract class Vehicle : IVehicle
    {
        private string make;
        private string model;
        private decimal price;

        protected Vehicle(string make, string model, decimal price)
        {
            this.Make = make;
            this.Model = model;
            this.Price = price;
            this.Comments = new List<IComment>();
        }

        public string Make
        {
            get { return this.make; }
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 2 || value.Length > 15)
                {
                    throw new ArgumentException("Make must be between 2 and 15 characters long!");
                }

                this.make = value;
            }
        }

        public string Model
        {
            get { return this.model; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Model must be not null!");
                }

                this.model = value;
            }
        }

        public virtual int Wheels { get; protected set; }

        public decimal Price
        {
            get { return this.price; }
            private set
            {
                if (value < 0 || value > 1000000.0m)
                {
                    throw new ArgumentException("Price must be between 0.0 and 1000000.0!");
                }

                this.price = value;
            }
        }

        public IList<IComment> Comments { get; }

        public VehicleType Type { get; protected set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"{this.Type}:");
            result.AppendLine($"  Make: {this.Make}");
            result.AppendLine($"  Model: {this.Model}");
            result.AppendLine($"  Wheels: {this.Wheels}");
            result.AppendLine($"  Price: ${this.Price}");
            result.AppendLine("  " + this.AdditionalInfo());

            if (this.Comments.Count == 0)
            {
                result.AppendLine("    --NO COMMENTS--");
            }
            else
            {
                result.AppendLine("    --COMMENTS--");

                foreach (var comment in this.Comments)
                {
                    result.Append(comment);
                }

                result.AppendLine("    --COMMENTS--");
            }

            return result.ToString();
        }

        protected abstract string AdditionalInfo();
    }
}