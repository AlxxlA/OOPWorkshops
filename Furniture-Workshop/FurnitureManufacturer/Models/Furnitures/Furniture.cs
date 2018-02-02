using FurnitureManufacturer.Interfaces;

namespace FurnitureManufacturer.Models.Furnitures
{
    public abstract class Furniture : IFurniture
    {
        private readonly string model;
        private readonly MaterialType material;
        private readonly decimal price;
        private decimal height;

        protected Furniture(string model, MaterialType materialType, decimal price, decimal height)
        {
            Validator.CheckForNull(model, "Model");
            Validator.ValidateStringLength(model, "Model length", 3);
            Validator.CheckForNull(materialType, "Material type");
            Validator.ValidateDecimalIsLessThenOrEqual(price, "Price cannot be less than zero", 0);

            this.model = model;
            this.material = materialType;
            this.price = price;
            this.Height = height;
        }

        public string Model
        {
            get { return this.model; }
        }

        public MaterialType Material
        {
            get { return this.material; }
        }

        public decimal Price
        {
            get { return this.price; }
        }

        public decimal Height
        {
            get { return this.height; }
            protected set
            {
                Validator.ValidateDecimalIsLessThenOrEqual(value, "Height cannot be less than zero", 0);
                this.height = value;
            }
        }

        public override string ToString()
        {
            return $"Type: {this.GetType().Name}, Model: {this.Model}, Material: {this.Material}, Price: {this.Price}, Height: {this.Height}";
        }
    }
}