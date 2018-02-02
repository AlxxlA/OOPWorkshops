using System.Collections.Generic;
using OlympicGames.Core.Contracts;

namespace OlympicGames.Core.Commands.Abstracts
{
    public abstract class Command : ICommand
    {
        protected readonly IOlympicCommittee committee;
        protected readonly IOlympicsFactory factory;

        protected Command(IOlympicCommittee committee, IOlympicsFactory factory)
        {
            this.committee = committee;
            this.factory = factory;
        }

        public abstract string Execute(IList<string> parameters);
    }
}
