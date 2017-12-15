using System;
using Dealership.Common.Enums;
using Dealership.Contracts;

namespace Dealership.Models
{
    public class Car : Vehicle, ICar
    {
        private const int WheelsCount = 4;
        private int seats;

        public Car(string make, string model, decimal price, int seats)
            : base(make, model, price)
        {
            this.Wheels = WheelsCount;
            this.Seats = seats;
            this.Type = VehicleType.Car;
        }
        
        public int Seats
        {
            get { return this.seats; }
            private set
            {
                if (value < 1 || value > 10)
                {
                    throw new ArgumentException("Seats must be between 1 and 10!");
                }

                this.seats = value;
            }
        }

        protected override string AdditionalInfo()
        {
            return $"Seats: {this.Seats}";
        }
    }
}