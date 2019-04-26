using Autofac;
using Autofac.Features.OwnedInstances;
using AutofacDelegateFuncExample.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutofacDelegateFuncExample
{
    public class ApplicationStart : IApplicationStart
    {
        IDependency _beans;
        Func<string, IDependency> factory;

        public void Run()
        {
            OrdinaryWork();
            Console.ReadKey();
        }

        // ToDo finish and test this Construktor
        public ApplicationStart(Func<string, IDependency> func)
        {
            factory = func;
        }

        /// <summary>
        /// 
        /// </summary>
        public void OrdinaryWork()
        {
            //Code bevore Constructor Injection
            //Func<String, IDependency> factory = Autofac.ContainerConfig.container.Resolve<Func<String, IDependency>>();

            IDependency biscuits = factory("biscuits");
            Console.Error.WriteLine(biscuits.Message());

            IDependency beans = factory("beans");
            Console.Error.WriteLine(beans.Message());

            Console.Error.WriteLine(biscuits.Message());
        }

        /// <summary>
        /// 
        /// </summary>
        public void DisposableWork()
        {
            // Code bevore Constructor Injection
            Func<String, Owned<IDisposableDependency>> factory = Autofac.ContainerConfig.container.ResolveNamed<Func<String, Owned<IDisposableDependency>>>("disposable-factory");

            using (Owned<IDisposableDependency> item = factory("owned"))
            {
                Console.Error.WriteLine(item.Value.Message());
            }
        }
    }
}
