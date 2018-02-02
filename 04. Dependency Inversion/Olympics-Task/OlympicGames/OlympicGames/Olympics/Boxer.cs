using System.Text;
using OlympicGames.Olympics.Contracts;
using OlympicGames.Olympics.Enums;
using OlympicGames.Utils;

namespace OlympicGames.Olympics
{
    public class Boxer : Olympian, IBoxer
    {
        private BoxingCategory category;
        private int wins;
        private int losses;

        public Boxer(string firstName, string lastName, string country, BoxingCategory category, int wins, int losses)
            : base(firstName, lastName, country)
        {
            this.Category = category;
            this.Wins = wins;
            this.Losses = losses;
        }

        public BoxingCategory Category
        {
            get
            {
                return this.category;
            }
            private set
            {
                this.category = value;
            }
        }

        public int Losses
        {
            get
            {
                return this.losses;
            }
            private set
            {
                value.ValidateMinAndMaxNumber(0, 100, "Losses");
                this.losses = value;
            }
        }

        public int Wins
        {
            get
            {
                return this.wins;
            }
            private set
            {
                value.ValidateMinAndMaxNumber(0, 100, "Wins");
                this.wins = value;
            }
        }

        protected override string PrintAdditionalInfo()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(string.Format("Category: {0}", this.Category));
            stringBuilder.AppendLine(string.Format("Wins: {0}", this.Wins));
            stringBuilder.AppendLine(string.Format("Losses: {0}", this.Losses));

            return stringBuilder.ToString();
        }
    }
}
