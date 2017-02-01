using CriminalDB.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace CriminalDB.ServicesHost
{
    class Program
    {
        private static ServiceHost host;

        static void Main(string[] args)
        {
            host = new ServiceHost(typeof(CriminalDBService));
            host.Open();

            Console.WriteLine("Press any key to shutdown the Criminal DB Service...");
            Console.ReadLine();

            host.Close();
        }
    }
}
