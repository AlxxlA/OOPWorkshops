using System.Collections.Generic;
using System.Linq;
using System.Text;
using OlympicGames.Olympics.Contracts;
using OlympicGames.Utils;

namespace OlympicGames.Olympics
{
    public class Sprinter : Olympian, ISprinter
    {
        public Sprinter(string firstName, string lastName, string country, IDictionary<string, double> records)
            : base(firstName, lastName, country)
        {
            this.PersonalRecords = records;
        }

        public IDictionary<string, double> PersonalRecords { get; private set; }

        protected override string PrintAdditionalInfo()
        {
            var stringBuilder = new StringBuilder();

            if (!this.PersonalRecords.Any())
            {
                stringBuilder.AppendLine(GlobalConstants.NoPersonalRecordsSet);
                return stringBuilder.ToString();
            }
            else
            {
                stringBuilder.AppendLine(GlobalConstants.PersonalRecords);

                foreach (var record in this.PersonalRecords)
                {
                    stringBuilder.AppendLine(string.Format("{0}m: {1}s", record.Key, record.Value));
                }
            }

            return stringBuilder.ToString();
        }
    }
}
