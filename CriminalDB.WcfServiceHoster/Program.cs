using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriminalDB.WcfServiceHoster
{
    class Program
    {
        static void Main(string[] args)
        {
            Hoster host = new Hoster();

            host.Host();

            Console.WriteLine("The service is ready at {0}", host.BaseAddress);
            Console.WriteLine("Press <Enter> to stop the service.");
            Console.ReadLine();

            // Close the ServiceHost.
            host.Terminate();
        }
    }
}
