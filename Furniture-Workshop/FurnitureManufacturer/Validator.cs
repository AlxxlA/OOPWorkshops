using System;

namespace FurnitureManufacturer
{
    public static class Validator
    {
        public static void CheckForNull(object value, string message)
        {
            if (value == null)
            {
                throw new ArgumentNullException(message);
            }
        }

        public static void ValidateStringLength(string str, string message, int min = 0, int max = int.MaxValue)
        {
            if (str.Length < min || str.Length > max)
            {
                throw new ArgumentException(message);
            }
        }

        public static void ValidateDecimalIsLessThenOrEqual(decimal number, string message, decimal min)
        {
            if (number <= min)
            {
                throw new ArgumentException(message);
            }
        }

        public static void ValidateInt32IsLessThenOrEqual(int number, string message, int min)
        {
            if (number <= min)
            {
                throw new ArgumentException(message);
            }
        }

        public static void ValidateDecimalIsLessThen(decimal number, string message, decimal min)
        {
            if (number < min)
            {
                throw new ArgumentException(message);
            }
        }

        public static void ValidateInt32IsLessThen(int number, string message, int min)
        {
            if (number < min)
            {
                throw new ArgumentException(message);
            }
        }

        public static void ValidateInt32IsGreaterThen(int number, string message, int max)
        {
            if (number > max)
            {
                throw new ArgumentException(message);
            }
        }
    }
}