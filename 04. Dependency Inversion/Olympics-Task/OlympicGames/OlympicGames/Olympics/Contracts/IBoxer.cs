using OlympicGames.Olympics.Enums;

namespace OlympicGames.Olympics.Contracts
{
    public interface IBoxer : IOlympian
    {
        BoxingCategory Category { get; }

        int Wins { get; }

        int Losses { get; }
    }
}
