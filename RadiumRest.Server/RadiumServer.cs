using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using RadiumRest.Core;


namespace RadiumRest.Server
{
    public class RadiumServer
    {
        public Kernel Kernel { get; internal set; }

        private Environment environment;
        private JObject serverSettings;

        public RadiumServer()
        {
            environment = new Environment();
            Kernel = new Kernel();

            environment.Load();
            Kernel.Initialize();
        }

        public void Start()
        {
            environment.Load();
            listen();
        }

        private void listen()
        {

            object portNumber = null;

            if (environment.Configuration.ContainsKey("server"))
            {
                serverSettings = (JObject)environment.Configuration["server"];
                var portJValue = serverSettings.GetValue("port");
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
