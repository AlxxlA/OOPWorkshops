using System.Collections.Generic;
using OlympicGames.Olympics.Contracts;

namespace OlympicGames.Core.Contracts
{
    public interface IOlympicsFactory
    {
        IOlympian CreateBoxer(string firstName, string lastName, string country, string category, int wins, int losses);

        IOlympian CreateSprinter(string firstName, string lastName, string country, IDictionary<string, double> records);
    }
}
