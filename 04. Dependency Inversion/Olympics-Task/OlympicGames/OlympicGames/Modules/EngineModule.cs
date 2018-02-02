using Autofac;
using OlympicGames.Core;
using OlympicGames.Core.Contracts;

namespace OlympicGames.Modules
{
    public class EngineModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Engine>().As<IEngine>();
        }
    }
}
