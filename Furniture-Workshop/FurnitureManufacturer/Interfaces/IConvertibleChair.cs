namespace FurnitureManufacturer.Interfaces
{
    public interface IConvertibleChair : IFurniture, IChair
    {
        bool IsConverted { get; }

        void Convert();
    }
}