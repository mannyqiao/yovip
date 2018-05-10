


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
            builder.RegisterType<DefaultEnjoyHost>()
                .As<IEnjoyHost>();
            return builder.Build();
        }
        public static void Start(Action<ContainerBuilder> registrations)
        {
            var host = CreateHost(registrations);
        }

    }
}
