using Autofac;
using OlympicGames.Core.Commands.Abstracts;
using OlympicGames.Core.Contracts;

namespace OlympicGames.Modules
{
    public class CommandsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Command>().As<ICommand>();
        }
    }
}
