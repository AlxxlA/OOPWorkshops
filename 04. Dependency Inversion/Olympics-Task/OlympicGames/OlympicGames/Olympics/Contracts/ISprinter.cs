using System.Collections.Generic;

namespace OlympicGames.Olympics.Contracts
{
    public interface ISprinter : IOlympian
    {
        IDictionary<string, double> PersonalRecords { get; }
    }
}
