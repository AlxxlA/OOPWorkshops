using System;
using System.Linq;
using OlympicGames.Core.Contracts;
using OlympicGames.IO.Contracts;

namespace OlympicGames.Core
{
    public class Engine : IEngine
    {
        private readonly ICommandParser parser;
        private readonly ICommandProcessor commandProcessor;
        private readonly IOlympicsFactory factory;
        private readonly IOlympicCommittee committee;
        private readonly IReader reader;
        private readonly IWriter writer;

        private const string Delimiter = "####################";

        public Engine(
            ICommandParser commandParser,
            ICommandProcessor commandProcessor,
            IOlympicCommittee committee,
            IOlympicsFactory factory,
            IReader reader,
            IWriter writer)
        {
            this.parser = commandParser;
            this.commandProcessor = commandProcessor;
            this.factory = factory;
            this.committee = committee;
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            string commandLine = null;

            while ((commandLine = this.reader.ReadLine()) != "end")
            {
                try
                {
                    var command = this.parser.ParseCommand(commandLine);
                    var parameters = commandLine.Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                    parameters = parameters.Skip(1).ToList();
                    if (command != null)
                    {
                        this.commandProcessor.ProcessSingleCommand(command, parameters);
                        this.writer.WriteLine(Delimiter);
                    }
                }
                catch (Exception ex)
                {
                    while (ex.InnerException != null)
                    {
                        ex = ex.InnerException;
                    }

                    this.writer.WriteLine($"ERROR: {ex.Message}");
                }
            }
        }
    }
}
