using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutofacDelegateFuncExample.Interfaces
{
    public interface IDependency
    {
        String Message();
    }

    public interface IDisposableDependency : IDependency, IDisposable
    {

    }
}
