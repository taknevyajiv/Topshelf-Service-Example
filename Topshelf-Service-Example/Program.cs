using Topshelf;
using Topshelf.Ninject;

namespace Topshelf_Service_Example
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(x =>
            {
                x.UseNinject(new DependencyModule());

                x.Service<IService>(s =>
                {
                    s.ConstructUsingNinject();
                    s.WhenStarted(myService => myService.Start());
                    s.WhenStopped(myService => myService.Stop());
                });

                x.RunAsLocalSystem();

                x.SetDescription("This service prints a heartbeat message every 10 seconds.");
                x.SetDisplayName("Heartbeat service");
                x.SetServiceName("HeartbeatService");
            });
        }
    }
}
