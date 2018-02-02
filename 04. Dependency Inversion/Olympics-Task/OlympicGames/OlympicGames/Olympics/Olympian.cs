using System.Text;
using OlympicGames.Olympics.Contracts;
using OlympicGames.Utils;

namespace OlympicGames.Olympics
{
    public abstract class Olympian : IOlympian
    {
        private string firstName;
        private string lastName;
        private string country;

        protected Olympian(string firstName, string lastName, string country)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Country = country;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            private set
            {
                value.ValidateMinAndMaxLength(2, 20, "First name");
                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
            private set
            {
                value.ValidateMinAndMaxLength(2, 20, "Last name");
                this.lastName = value;
            }
        }

        public string Country
        {
            get
            {
                return this.country;
            }
            private set
            {
                value.ValidateMinAndMaxLength(3, 25, "Country");
                this.country = value;
            }
        }

        protected abstract string PrintAdditionalInfo();

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(string.Format("{0}: {1} {2} from {3}", this.GetType().Name.ToUpper(), this.FirstName, this.LastName, this.Country));
            stringBuilder.AppendLine(this.PrintAdditionalInfo());
            return stringBuilder.ToString();
        }
    }
}
