using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;

namespace Topshelf_Service_Example
{
    public class DependencyModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IService>().To<HeartbeatService>();
        }
    }
}
