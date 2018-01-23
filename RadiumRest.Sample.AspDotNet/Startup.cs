using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using RadiumRest.Plugin.AspDotNet;

namespace RadiumRest.Sample.AspDotNet
{
    public class Startup : IHttpHandler
    {
        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            var tmp = new RadiumRest.Sample.CustomerMicroservice.Resources.Customer.CustomerModel();
            var requestHandler = new AspDotNetRadiumPlugin();
            requestHandler.Handle(context);
        }
    }
}