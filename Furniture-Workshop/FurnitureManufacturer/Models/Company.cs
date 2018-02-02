using FurnitureManufacturer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FurnitureManufacturer.Models
{
    public class Company : ICompany
    {
        private readonly string name;
        private readonly string registrationNumber;
        private readonly ICollection<IFurniture> furnitures;

        public Company(string name, string registrationNumber)
        {
            Validator.CheckForNull(name, "Name cannot be null");
            Validator.ValidateInt32IsLessThen(name.Length, "Name length cannnot be less then 5.", 5);
            Validator.CheckForNull(registrationNumber, "Register number cannnot be null");
            Validator.ValidateInt32IsLessThen(registrationNumber.Length, "Register number shoud be exact 10 symbols", 10);
            Validator.ValidateInt32IsGreaterThen(registrationNumber.Length, "Register number shoud be exact 10 symbols", 10);

            this.name = name;
            this.registrationNumber = registrationNumber;
            this.furnitures = new List<IFurniture>();
        }

        public string Name => this.name;

        public string RegistrationNumber => this.registrationNumber;

        public ICollection<IFurniture> Furnitures => this.furnitures;

        public void Add(IFurniture furniture)
        {
            Validator.CheckForNull(furniture, "Furniture cannot be null");
            this.furnitures.Add(furniture);
        }

        public string Catalog()
        {
            var ordered = this.furnitures.OrderBy(x => x.Price).ThenBy(x => x.Model);

            var strBuilder = new StringBuilder();

            strBuilder.AppendLine(string.Format(
                "{0} - {1} - {2} {3}",
                this.Name,
                this.RegistrationNumber,
                this.Furnitures.Count != 0 ? this.Furnitures.Count.ToString() : "no",
                this.Furnitures.Count != 1 ? "furnitures" : "furniture"
            ));

            foreach (var furniture in ordered)
            {
                strBuilder.AppendLine(furniture.ToString());
            }

            return strBuilder.ToString().Trim();
        }

        public IFurniture Find(string model)
        {
            var furniture = this.furnitures.FirstOrDefault(x => String.Equals(x.Model, model, StringComparison.CurrentCultureIgnoreCase));
            return furniture;
        }

        public void Remove(IFurniture furniture)
        {
            this.furnitures.Remove(furniture);
        }
    }
}