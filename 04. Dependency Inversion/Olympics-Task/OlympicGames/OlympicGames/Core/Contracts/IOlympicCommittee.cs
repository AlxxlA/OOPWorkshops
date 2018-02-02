using System.Collections.Generic;
using OlympicGames.Olympics.Contracts;

namespace OlympicGames.Core.Contracts
{
    public interface IOlympicCommittee
    {
        ICollection<IOlympian> Olympians { get; }
    }
}
