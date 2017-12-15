using System;
using Dealership.Common.Enums;
using Dealership.Contracts;

namespace Dealership.Models
{
    public class Motorcycle : Vehicle, IMotorcycle
    {
        private const int WheelsCount = 2;
        private string category;

        public Motorcycle(string make, string model, decimal price, string category)
            : base(make, model, price)
        {
            this.Wheels = WheelsCount;
            this.Category = category;
            this.Type = VehicleType.Motorcycle;
        }

        public string Category
        {
            get { return this.category; }
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 3 || value.Length > 10)
                {
                    throw new ArgumentException("Category must be between 3 and 10 characters long!");
                }

                this.category = value;
            }
        }

        protected override string AdditionalInfo()
        {
            return $"Category: {this.Category}";
        }
    }
}