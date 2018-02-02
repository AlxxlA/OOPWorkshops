using System;
using System.Reflection;
using Autofac;
using OlympicGames.Core.Contracts;
using OlympicGames.Modules;

namespace OlympicGames
{
    public class StartUp
    {
        public static void Main()
        {
            var builder = new ContainerBuilder();

            //builder.RegisterModule<CommandsModule>();
            //builder.RegisterModule<OlympicsFactoryModule>();
            //builder.RegisterModule<CommandFactoryModule>();
            //builder.RegisterModule<ProvidersModule>();
            //builder.RegisterModule<IOModule>();
            //builder.RegisterModule<EngineModule>();

            // find and execute Load method of all classes that inherit Autofac.Module
            builder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());

            var container = builder.Build();

            var engine = container.Resolve<IEngine>();

            engine.Run();
        }
    }
}
