using FurnitureManufacturer.Interfaces;

namespace FurnitureManufacturer.Models.Furnitures
{
    public class Chair : Furniture, IFurniture, IChair
    {
        private readonly int numberOfLegs;

        public Chair(string model, MaterialType materialType, decimal price, decimal height, int numberOfLegs)
            : base(model, materialType, price, height)
        {
            Validator.ValidateInt32IsLessThen(numberOfLegs, "Number of legs cannot be less then zero.", 0);

            this.numberOfLegs = numberOfLegs;
        }

        public int NumberOfLegs
        {
            get { return this.numberOfLegs; }
        }

        public override string ToString()
        {
            return base.ToString() + $", Legs: {this.numberOfLegs}";
        }
    }
}