using AutofacDelegateFuncExample.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutofacDelegateFuncExample.DelegateFactory
{
    public class Beans : IDependency
    {
        public string Message()
        {
            return "Beans For Everyone!";
        }
    }

    public class Biscuit : IDependency
    {
        public string Message()
        {
            return "Biscuits for all!";
        }
    }

    public class Worker : IDisposableDependency
    {
        public String Message()
        {
            return "Disposable thingy!";
        }

        public void Dispose()
        {
            // Disposed!
            Console.Error.WriteLine("I am disposed");
        }
    }
}
