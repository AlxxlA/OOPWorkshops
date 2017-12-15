using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Dealership.Common.Enums;
using Dealership.Contracts;

namespace Dealership.Models
{
    public class User : IUser
    {
        private string userName;
        private string firstName;
        private string lastName;
        private string password;

        public User(string username, string firstName, string lastName, string password, Role role)
        {
            this.Username = username;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Password = password;
            this.Role = role;
            this.Vehicles = new List<IVehicle>();
        }

        public string Username
        {
            get { return this.userName; }
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 2 || value.Length > 20)
                {
                    throw new ArgumentException("Username must be between 2 and 20 characters long!");
                }

                string pattern = "^[A-Za-z0-9]+$";

                Regex rgx = new Regex(pattern);

                if (!rgx.IsMatch(value))
                {
                    throw new ArgumentException("Username contains invalid symbols!");
                }

                this.userName = value;
            }
        }

        public string FirstName
        {
            get { return this.firstName; }
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 2 || value.Length > 20)
                {
                    throw new ArgumentException("Firstname must be between 2 and 20 characters long!");
                }

                this.firstName = value;
            }
        }

        public string LastName
        {
            get { return this.lastName; }
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 2 || value.Length > 20)
                {
                    throw new ArgumentException("Lastname must be between 2 and 20 characters long!");
                }

                this.lastName = value;
            }
        }

        public string Password
        {
            get { return this.password; }
            private set
            {

                if (string.IsNullOrEmpty(value) || value.Length < 5 || value.Length > 30)
                {
                    throw new ArgumentException("Password must be between 5 and 30 characters long!");
                }

                string pattern = "^[A-Za-z0-9@*_-]+$";

                Regex rgx = new Regex(pattern);

                if (!rgx.IsMatch(value))
                {
                    throw new ArgumentException("Password contains invalid symbols!");
                }

                this.password = value;
            }
        }

        public Role Role { get; }

        public IList<IVehicle> Vehicles { get; }

        public void AddVehicle(IVehicle vehicle)
        {
            if (this.Role == Role.Admin)
            {
                throw new InvalidOperationException("You are an admin and therefore cannot add vehicles!");
            }
            if (this.Vehicles.Count == 5 && this.Role != Role.VIP)
            {
                throw new InvalidOperationException("You are not VIP and cannot add more than 5 vehicles!");
            }
            if (vehicle == null)
            {
                throw new NullReferenceException("Vehicle shoud be not null");
            }

            this.Vehicles.Add(vehicle);
        }

        public void RemoveVehicle(IVehicle vehicle)
        {
            this.Vehicles.Remove(vehicle);
        }

        public void AddComment(IComment commentToAdd, IVehicle vehicleToAddComment)
        {

            vehicleToAddComment.Comments.Add(commentToAdd);
        }

        public void RemoveComment(IComment commentToRemove, IVehicle vehicleToRemoveComment)
        {
            if (commentToRemove.Author != this.Username)
            {
                throw new ArgumentException("You are not the author!");
            }

            vehicleToRemoveComment.Comments.Remove(commentToRemove);
        }

        public string PrintVehicles()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"--USER {this.Username}--");

            if (this.Vehicles.Count == 0)
            {
                result.AppendLine("--NO VEHICLES--");
            }
            else
            {
                for (int i = 0; i < this.Vehicles.Count; i++)
                {
                    result.Append($"{i + 1}. {this.Vehicles[i]}");
                }
            }

            return result.ToString().Trim();
        }

        public override string ToString()
        {
            return $"Username: {this.Username}, FullName: {this.FirstName} {this.LastName}, Role: {this.Role}";
        }
    }
}