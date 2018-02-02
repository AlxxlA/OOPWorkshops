using System;
using System.Collections.Generic;
using System.Linq;
using OlympicGames.Core.Contracts;
using OlympicGames.IO.Contracts;

namespace OlympicGames.Core.Providers
{
    public class CommandProcessor : ICommandProcessor
    {
        private readonly IWriter writer;

        public CommandProcessor(IWriter writer)
        {
            this.writer = writer;
        }

        public void ProcessSingleCommand(ICommand command, IList<string> parameters)
        {
            var result = command.Execute(parameters);
            var normalizedOutput = this.NormalizeOutput(result);
            this.writer.WriteLine(normalizedOutput);
        }

        private string NormalizeOutput(string commandOutput)
        {
            var list = commandOutput.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).ToList().Where(x => !string.IsNullOrWhiteSpace(x));

            return string.Join("\r\n", list);
        }
    }
}