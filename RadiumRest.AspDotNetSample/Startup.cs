﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using RadiumRest.AspDotNet;

namespace RadiumRest.AspDotNetSample
{
    public class Startup : IHttpHandler
    {
        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            var tmp = new RadiumRest.CustomerMicroservice.Resources.Customer.CustomerModel();
            var requestHandler = new ASPRequestHandler();
            requestHandler.Handle(context);
        }
    }
}