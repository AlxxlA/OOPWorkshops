using Autofac;
using OlympicGames.IO;
using OlympicGames.IO.Contracts;

namespace OlympicGames.Modules
{
    public class IOModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ConsoleReader>().As<IReader>();
            builder.RegisterType<ConsoleWriter>().As<IWriter>();
        }
    }
}
