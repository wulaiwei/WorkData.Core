using Autofac;
using CommonServiceLocator;
using System;

namespace WorkData.AutofacServiceLocator
{
    class Program
    {
        private static IServiceLocator _locator;
        static void Main(string[] args)
        {


            var builder = new ContainerBuilder();

            builder
                .RegisterType<SimpleLogger>()
                .Named<ILogger>(typeof(SimpleLogger).FullName)
                .SingleInstance()
                .As<ILogger>();


            var container = builder.Build();

            _locator = new AutofacServiceLocator(container);

            for (int i = 0; i < 10000000; i++)
                {
                    var log = _locator.GetInstance<ILogger>();
                    log.Get();
                }
        }
    }
}
