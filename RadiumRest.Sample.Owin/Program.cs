using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RadiumRest;
using RadiumRest.Core;
using RadiumRest.Plugin.Owin;
using RadiumRest.Sample.CustomerMicroservice;

namespace RadiumRest.Sample.Owin
{
    public class Program
    {
        public static void Main(string[] args)
        {
            RadiumServer.Use<CustomerMicroservice.Resources.Customer.CustomerModel>();

            var server = RadiumServer.Create<OwinRadiumPlugin>();
            server.Start();
        }
    }
}
