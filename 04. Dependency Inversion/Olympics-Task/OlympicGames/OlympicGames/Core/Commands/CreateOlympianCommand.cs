using System;
using System.Collections.Generic;
using OlympicGames.Core.Commands.Abstracts;
using OlympicGames.Core.Contracts;
using OlympicGames.Olympics.Contracts;

namespace OlympicGames.Core.Commands
{
    public abstract class CreateOlympianCommand : Command
    {
        protected CreateOlympianCommand(IOlympicCommittee committee, IOlympicsFactory factory)
            : base(committee, factory)
        {
        }

        protected string FirstName { get; private set; }

        protected string LastName { get; private set; }

        protected string Country { get; private set; }

        public override string Execute(IList<string> parameters)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException("Create command parameters cannot be null");
            }

            this.FirstName = parameters[0];
            this.LastName = parameters[1];
            this.Country = parameters[2];

            return string.Empty;
        }

        protected abstract IOlympian CreatePerson();
    }
}
