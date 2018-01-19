using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

using RadiumRest.Core;
using RadiumRest.Core.Server;
using RadiumRest.Owin;

namespace RadiumRest.OwinServer
{
    public class OwinRadiumServer: RadiumServer
    {
        protected override void Listen()
        {
            object portNumber = null;

            if (Environment.Configuration.ContainsKey("server"))
            {
                ServerSettings = (JObject)Environment.Configuration["server"];
                var portJValue = ServerSettings.GetValue("port");
                if (portJValue != null)
                    portNumber = portJValue.ToString();

            }

            if (portNumber == null)
                portNumber = 9000;

            var handler = new RequestHandler(this.Kernel);
            using (Microsoft.Owin.Hosting.WebApp.Start("http://localhost:" + portNumber, handler.Configuration))
            {
                Console.WriteLine("Radium REST Server listeneing in port : " + portNumber);
                Console.ReadLine();
            }
        }

    }
}
