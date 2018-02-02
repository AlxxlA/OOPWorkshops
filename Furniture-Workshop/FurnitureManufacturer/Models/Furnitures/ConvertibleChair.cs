using FurnitureManufacturer.Interfaces;

namespace FurnitureManufacturer.Models.Furnitures
{
    public class ConvertibleChair : Chair, IFurniture, IChair, IConvertibleChair
    {
        private State state;
        private readonly decimal initialHeight;

        public ConvertibleChair(string model, MaterialType materialType, decimal price, decimal height, int numberOfLegs)
            : base(model, materialType, price, height, numberOfLegs)
        {
            this.state = State.Normal;
            this.initialHeight = height;
        }

        public bool IsConverted { get; protected set; }

        public void Convert()
        {
            if (this.IsConverted)
            {
                this.state = State.Normal;
                this.Height = this.initialHeight;
            }
            else
            {
                this.state = State.Converted;
                this.Height = 0.10m;
            }

            this.IsConverted = !this.IsConverted;
        }

        public override string ToString()
        {
            return base.ToString() + $", State: {this.state}";
        }

        private enum State
        {
            Normal,
            Converted
        }
    }
}