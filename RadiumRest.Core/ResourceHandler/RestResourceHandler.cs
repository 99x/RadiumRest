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
        protected IOwinRequest Request { get; private set; }

        protected IOwinResponse Response { get; private set; }

        private IOwinContext owinContext;
        internal IOwinContext OContext
        {
            set
            {
                this.owinContext = value;
                this.Request = value.Request;
                this.Response = value.Response;
            }
        }
        protected IOwinContext OwinContext
        {
            get
            {
                return this.owinContext;
            }
        }

        public Dictionary<string, object> DataBag { get; set; }
    }
}
