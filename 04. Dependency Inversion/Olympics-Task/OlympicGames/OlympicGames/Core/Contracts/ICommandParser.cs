namespace OlympicGames.Core.Contracts
{
    public interface ICommandParser
    {
        ICommand ParseCommand(string commandLine);
    }
}
