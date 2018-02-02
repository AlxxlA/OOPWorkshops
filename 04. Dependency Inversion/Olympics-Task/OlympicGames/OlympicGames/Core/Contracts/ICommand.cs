using System.Collections.Generic;

namespace OlympicGames.Core.Contracts
{
    public interface ICommand
    {
        string Execute(IList<string> parameters);
    }
}
