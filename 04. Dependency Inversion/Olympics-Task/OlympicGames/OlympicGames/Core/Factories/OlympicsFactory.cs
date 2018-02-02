using System;
using System.Collections.Generic;
using OlympicGames.Core.Contracts;
using OlympicGames.Olympics.Contracts;
using OlympicGames.Olympics;
using OlympicGames.Olympics.Enums;

namespace OlympicGames.Core.Factories
{
    public class OlympicsFactory : IOlympicsFactory
    {
        public IOlympian CreateBoxer(string firstName, string lastName, string country, string category, int wins, int losses)
        {
            return new Boxer(firstName, lastName, country, (BoxingCategory)Enum.Parse(typeof(BoxingCategory), category, true), wins, losses);
        }

        public IOlympian CreateSprinter(string firstName, string lastName, string country, IDictionary<string, double> records)
        {
            return new Sprinter(firstName, lastName, country, records);
        }
    }
}
