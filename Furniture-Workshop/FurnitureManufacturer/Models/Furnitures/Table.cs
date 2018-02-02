using FurnitureManufacturer.Interfaces;

namespace FurnitureManufacturer.Models.Furnitures
{
    public class Table : Furniture, IFurniture, ITable
    {
        private readonly decimal length;
        private readonly decimal width;

        public Table(string model, MaterialType materialType, decimal price, decimal height, decimal length, decimal width)
            : base(model, materialType, price, height)
        {
            Validator.ValidateDecimalIsLessThenOrEqual(length, "Length cannot be less than zero.", 0);
            Validator.ValidateDecimalIsLessThenOrEqual(width, "Width cannot be less than zero.", 0);

            this.length = length;
            this.width = width;
        }

        public decimal Length
        {
            get { return this.length; }
        }

        public decimal Width
        {
            get { return this.width; }
        }
        public decimal Area
        {
            get { return this.length * this.width; }
        }

        public override string ToString()
        {
            return base.ToString() + $", Length: {this.length}, Width: {this.width}, Area: {this.Area}";
        }
    }
}