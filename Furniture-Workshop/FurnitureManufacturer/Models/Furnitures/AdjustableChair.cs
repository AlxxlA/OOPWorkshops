using FurnitureManufacturer.Interfaces;

namespace FurnitureManufacturer.Models.Furnitures
{
    public class AdjustableChair : Chair, IFurniture, IChair, IAdjustableChair
    {
        public AdjustableChair(string model, MaterialType materialType, decimal price, decimal height, int numberOfLegs) 
            : base(model, materialType, price, height, numberOfLegs)
        {
        }

        public void SetHeight(decimal height)
        {
            base.Height = height;
        }
    }
}