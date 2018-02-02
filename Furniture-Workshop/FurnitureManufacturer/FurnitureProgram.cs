using FurnitureManufacturer.Engine;
using FurnitureManufacturer.Models;

namespace FurnitureManufacturer
{
    public class FurnitureProgram
    {
        public static void Main()
        {
            var deleteMe = new DoNotDeleteMe();

            if (deleteMe != null)
            {
                FurnitureManufacturerEngine.Instance.Start();
            }
        }
    }
}
