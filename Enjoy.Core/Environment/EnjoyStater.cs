


namespace Enjoy.Core
{
    using System;
    using Autofac;
    public static class EnjoyStater
    {
        public static IEnjoyHost CreateHost(Action<ContainerBuilder> registrations)
        {
            var container = CreateContainer(registrations);
            return container.Resolve<IEnjoyHost>();
        }
        public static IContainer CreateContainer(Action<ContainerBuilder> registrations)
        {
            var builder = new ContainerBuilder();
            registrations(builder);
            builder.RegisterType<DefaultExtensionLoader>().AsSelf().As<IExtensionLoader>().SingleInstance();
            builder.RegisterType<DefaultHostEnvironment>().AsSelf().As<HostEnvironment>().As<IHostEnvironment>().SingleInstance();

            builder.RegisterType<DefaultEnjoyHost>().AsSelf().As<IEnjoyHost>().SingleInstance();
            return builder.Build();
        }
        public static void Start(Action<ContainerBuilder> registrations)
        {
            var host = CreateHost(registrations);
        }

    }
}
