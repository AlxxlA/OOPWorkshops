using System;
using OlympicGames.IO.Contracts;

namespace OlympicGames.IO
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
