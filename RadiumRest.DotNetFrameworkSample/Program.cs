using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RadiumRest.Core;
using RadiumRest.Plugin.Owin;
using RadiumRest.CustomerMicroservice;

namespace RadiumRest.Sample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var tmp = new CustomerMicroservice.Resources.Customer.CustomerModel();
            var server = new OwinRadiumPlugin();
            server.Start();
        }
    }
}
