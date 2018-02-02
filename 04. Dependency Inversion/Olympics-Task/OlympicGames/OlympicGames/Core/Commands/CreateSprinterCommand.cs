using System.Collections.Generic;
using System.Linq;
using OlympicGames.Core.Contracts;
using OlympicGames.Olympics.Contracts;

namespace OlympicGames.Core.Commands
{
    public class CreateSprinterCommand : CreateOlympianCommand, ICommand
    {
        public CreateSprinterCommand(IOlympicCommittee committee, IOlympicsFactory factory) : base(committee, factory)
        {
        }

        private IDictionary<string, double> records;

        public override string Execute(IList<string> parameters)
        {
            base.Execute(parameters);

            this.records = new Dictionary<string, double>();

            parameters = parameters.Skip(3).ToList();

            foreach (var recordItem in parameters)
            {
                var recordValue = recordItem.Split('/');
                this.records.Add(recordValue[0], double.Parse(recordValue[1]));
            }

            var olympian = this.CreatePerson();

            this.committee.Olympians.Add(olympian);

            return $"Created {olympian.GetType().Name}\n{olympian}";
        }

        protected override IOlympian CreatePerson()
        {
            return this.factory.CreateSprinter(this.FirstName, this.LastName, this.Country, this.records);
        }
    }
}
