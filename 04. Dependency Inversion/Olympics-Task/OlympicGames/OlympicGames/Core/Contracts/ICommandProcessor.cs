using System.Collections.Generic;

namespace OlympicGames.Core.Contracts
{
    public interface ICommandProcessor
    {
        void ProcessSingleCommand(ICommand command, IList<string> parameters);
    }
}
