namespace OlympicGames.Core.Contracts
{
    public interface ICommandFactory
    {
        ICommand Create(string commandName);
    }
}
