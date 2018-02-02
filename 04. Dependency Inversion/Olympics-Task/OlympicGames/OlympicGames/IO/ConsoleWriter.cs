using System;
using OlympicGames.IO.Contracts;

namespace OlympicGames.IO
{
    public class ConsoleWriter : IWriter
    {
        public void Write(object obj)
        {
            Console.Write(obj);
        }

        public void WriteLine(object obj)
        {
            Console.WriteLine(obj);
        }
    }
}
