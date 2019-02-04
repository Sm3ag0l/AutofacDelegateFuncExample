using Autofac;
using Autofac.Features.OwnedInstances;
using AutofacDelegateFuncExample.DelegateFactory;
using AutofacDelegateFuncExample.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutofacDelegateFuncExample.Autofac
{
    public static class ContainerConfig
    {
        public static IContainer container;
        public static IContainer Config()
        {
            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterType<ApplicationStart>().As<IApplicationStart>();

            builder.RegisterType<Biscuit>().As<IDependency>().Named<IDependency>("biscuits");
            builder.RegisterType<Beans>().As<IDependency>().Named<IDependency>("beans");
            builder.RegisterType<Worker>().As<IDisposableDependency>().Named<IDisposableDependency>("owned");

            // Ordinary delegate factory.
            builder.Register<Func<String, IDependency>>(delegate (IComponentContext context)
            {
                IComponentContext cc = context.Resolve<IComponentContext>();

                return cc.ResolveNamed<IDependency>;
            });

            // Delegate factory that returns an 'owned' instance. This allows the component to be disposed.
            builder.Register<Func<String, Owned<IDisposableDependency>>>(delegate (IComponentContext context)
            {
                IComponentContext cc = context.Resolve<IComponentContext>();

                return cc.ResolveNamed<Owned<IDisposableDependency>>;

            }).Named<Func<String, Owned<IDisposableDependency>>>("disposable-factory");

            container = builder.Build();
            return container;
        }


    }
}
