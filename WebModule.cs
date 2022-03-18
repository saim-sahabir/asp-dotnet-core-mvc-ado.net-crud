using AdoDotNet.Models;
using Autofac;

namespace AdoDotNet;

    public class WebModule :Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DataModel>().As<IDataModel>()
                .InstancePerLifetimeScope();
            builder.RegisterType<HomeModel>().AsSelf();
            base.Load(builder);
        }
    }
