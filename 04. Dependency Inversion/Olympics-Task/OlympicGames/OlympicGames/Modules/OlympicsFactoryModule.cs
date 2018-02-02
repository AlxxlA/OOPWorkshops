using Autofac;
using OlympicGames.Core.Contracts;
using OlympicGames.Core.Factories;

namespace OlympicGames.Modules
{
    public class OlympicsFactoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<OlympicsFactory>().As<IOlympicsFactory>();
        }
    }
}
