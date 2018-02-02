using Autofac;
using OlympicGames.Core.Commands;
using OlympicGames.Core.Contracts;
using OlympicGames.Core.Factories;

namespace OlympicGames.Modules
{
    public class CommandFactoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CommandFactory>().As<ICommandFactory>();
            builder.RegisterType<CreateBoxerCommand>().Named<ICommand>("createboxer");
            builder.RegisterType<CreateSprinterCommand>().Named<ICommand>("createsprinter");
            builder.RegisterType<ListOlympiansCommand>().Named<ICommand>("listolympians");
        }
    }
}
