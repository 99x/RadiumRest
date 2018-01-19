using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RadiumRest.Core;
using RadiumRest.DotNetCoreServer;
using RadiumRest.CustomerMicroservice;

namespace RadiumRest.Sample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var tmp = new CustomerMicroservice.Resources.Customer.CustomerModel();
            var server = new DotNetCoreServer.DotNetCoreServer();
            server.Start();
        }
    }
}
