using System.Collections.Generic;
using System.Linq;
using System.Text;
using OlympicGames.Core.Commands.Abstracts;
using OlympicGames.Core.Contracts;
using OlympicGames.Utils;

namespace OlympicGames.Core.Commands
{
    public class ListOlympiansCommand : Command, ICommand
    {
        public ListOlympiansCommand(IOlympicCommittee committee, IOlympicsFactory factory)
            : base(committee, factory)
        {
        }

        private string key;

        private string order;

        public override string Execute(IList<string> parameters)
        {
            if (parameters == null || parameters.Count == 0)
            {
                this.key = "firstname";
                this.order = "asc";
            }
            else if (parameters.Count == 1)
            {
                this.key = parameters[0];
                this.order = "asc";
            }
            else
            {
                if (parameters[1].ToLower() != "asc" && parameters[1].ToLower() != "desc")
                {
                    this.order = "asc";
                }
                else
                {
                    this.order = parameters[1];
                }
                this.key = parameters[0];
            }

            var stringBuilder = new StringBuilder();
            var sorted = this.committee.Olympians.ToList();

            if (sorted.Count == 0)
            {
                stringBuilder.AppendLine(GlobalConstants.NoOlympiansAdded);
                return stringBuilder.ToString();
            }

            stringBuilder.AppendLine(string.Format(GlobalConstants.SortingTitle, this.key, this.order));

            if (this.order.ToLower().Trim() == "desc")
            {
                sorted = this.committee.Olympians.OrderByDescending(x =>
                {
                    return x.GetType().GetProperties().FirstOrDefault(y => y.Name.ToLower() == this.key.ToLower()).GetValue(x, null);
                }).ToList();
            }
            else
            {
                sorted = this.committee.Olympians.OrderBy(x =>
                {
                    return x.GetType().GetProperties().FirstOrDefault(y => y.Name.ToLower() == this.key.ToLower()).GetValue(x, null);
                }).ToList();
            }

            foreach (var item in sorted)
            {
                stringBuilder.AppendLine(item.ToString());
            }

            return stringBuilder.ToString();
        }
    }
}
