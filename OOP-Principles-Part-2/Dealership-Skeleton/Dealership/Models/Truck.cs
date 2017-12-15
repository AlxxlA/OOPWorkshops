using System;
using Dealership.Common.Enums;
using Dealership.Contracts;

namespace Dealership.Models
{
    public class Truck : Vehicle, ITruck
    {
        private const int WheelsCount = 8;
        private int weightCapacity;

        public Truck(string make, string model, decimal price, int weightCapacity)
            : base(make, model, price)
        {
            this.Wheels = WheelsCount;
            this.WeightCapacity = weightCapacity;
            this.Type = VehicleType.Truck;
        }

        public int WeightCapacity
        {
            get { return this.weightCapacity; }
            private set
            {
                if (value < 1 || value > 100)
                {
                    throw new ArgumentException("Weight capacity must be between 1 and 100!");
                }

                this.weightCapacity = value;
            }
        }

        protected override string AdditionalInfo()
        {
            return $"Weight Capacity: {this.WeightCapacity}t";
        }
    }
}