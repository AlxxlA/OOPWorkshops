using Autofac;
using OlympicGames.Core.Contracts;
using OlympicGames.Core.Providers;

namespace OlympicGames.Modules
{
    public class ProvidersModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CommandParser>().As<ICommandParser>();
            builder.RegisterType<CommandProcessor>().As<ICommandProcessor>();
            builder.RegisterType<OlympicCommittee>().As<IOlympicCommittee>().SingleInstance();
        }
    }
}
