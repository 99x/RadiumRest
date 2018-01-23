﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using RadiumRest;
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
            RadiumServer.Use<RadiumRest.Sample.CustomerMicroservice.Resources.Customer.CustomerModel>();

            var server = RadiumServer.Create<AspDotNetRadiumPlugin>();
            server.Handle(context);
        }
    }
}