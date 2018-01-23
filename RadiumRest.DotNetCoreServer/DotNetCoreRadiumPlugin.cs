using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using Newtonsoft.Json.Linq;

using RadiumRest.Core;
using RadiumRest.Core.Plugin;

using Microsoft.AspNetCore.Hosting;



namespace RadiumRest.Plugin.DotNetCore
{
    public class DotNetCoreRadiumPlugin : RadiumPlugin
    {
        internal static Kernel KernalInstance { get; set; }
        protected override void Listen()
        {
            object portNumber = null;
            KernalInstance = this.Kernel;
            if (Environment.Configuration.ContainsKey("server"))
            {
                ServerSettings = (JObject)Environment.Configuration["server"];
                var portJValue = ServerSettings.GetValue("port");
                if (portJValue != null)
                    portNumber = portJValue.ToString();

            }

            if (portNumber == null)
                portNumber = 9000;


            WebHost.CreateDefaultBuilder()
                .UseStartup<Startup>()
                .UseUrls("http://localhost:" + portNumber +"/")
                .Build()
                .Run();

        }

    }
}
