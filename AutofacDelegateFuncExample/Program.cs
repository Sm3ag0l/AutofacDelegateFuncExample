using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutofacDelegateFuncExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = Autofac.ContainerConfig.Config();

            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<IApplicationStart>();

                app.Run();
            }
        }
    }
}
