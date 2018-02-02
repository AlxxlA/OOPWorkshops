namespace FurnitureManufacturer.Interfaces
{
    public interface IAdjustableChair : IFurniture, IChair
    {
        void SetHeight(decimal height);
    }
}