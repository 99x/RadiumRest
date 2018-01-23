using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RadiumRest;
using RadiumRest.Core;
using RadiumRest.Plugin.DotNetCore;
using RadiumRest.Sample.CustomerMicroservice;

namespace RadiumRest.Sample.DotNetCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            RadiumService.Use<CustomerMicroservice.Resources.Customer.CustomerService>();

            var server = RadiumService.Create<DotNetCoreRadiumPlugin>();
            server.Start();
        }
    }
}
