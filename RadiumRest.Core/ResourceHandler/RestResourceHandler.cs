using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

using Microsoft.Owin;

namespace RadiumRest
{
    public class RestResourceHandler
    {
        protected OwinContext OwinContext { get; set; }
        public Dictionary<string, object> DataBag { get; set; }
    }
}
