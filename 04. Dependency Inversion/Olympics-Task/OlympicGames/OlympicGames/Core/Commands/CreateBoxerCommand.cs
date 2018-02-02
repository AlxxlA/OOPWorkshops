using System;
using System.Collections.Generic;
using System.Linq;
using OlympicGames.Core.Contracts;
using OlympicGames.Olympics.Contracts;
using OlympicGames.Utils;

namespace OlympicGames.Core.Commands
{
    public class CreateBoxerCommand : CreateOlympianCommand, ICommand
    {
        public CreateBoxerCommand(IOlympicCommittee committee, IOlympicsFactory factory)
            : base(committee, factory)
        {
        }

        private string category;

        private int wins;

        private int losses;

        public override string Execute(IList<string> parameters)
        {
            base.Execute(parameters);

            parameters = parameters.Skip(3).ToList();

            this.category = parameters[0];
            bool checkWins = int.TryParse(parameters[1], out this.wins);
            bool checkLosses = int.TryParse(parameters[2], out this.losses);

            if (!checkWins || !checkLosses)
            {
                throw new ArgumentException(GlobalConstants.WinsLossesMustBeNumbers);
            }

            var olympian = this.CreatePerson();

            this.committee.Olympians.Add(olympian);

            return $"Created {olympian.GetType().Name}\n{olympian}";
        }

        protected override IOlympian CreatePerson()
        {
            return this.factory.CreateBoxer(this.FirstName, this.LastName, this.Country, this.category, this.wins, this.losses);
        }
    }
}
