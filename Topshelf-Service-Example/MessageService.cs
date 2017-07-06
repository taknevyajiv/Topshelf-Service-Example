using System;
using System.IO;
using System.Timers;

namespace Topshelf_Service_Example
{
    public class HeartbeatService : IService
    {
        Timer timer;

        public HeartbeatService()
        {
            timer = new Timer();
        }

        private void DoWork(object sender, ElapsedEventArgs e)
        {
            using (StreamWriter writer = new StreamWriter(@"C:\TopShelf\service.txt", true))
            {
                writer.WriteLine("The service is still running at " + DateTime.Now.ToLongTimeString());
            }
        }

        public void Start()
        {
            Console.WriteLine("Starting service...");

            timer.Interval = 10000;
            timer.Elapsed += new ElapsedEventHandler(DoWork);
            timer.Start();

        }

        public void Stop()
        {
            Console.WriteLine("Stopping the service...");
            timer.Stop();
        }
    }
}
