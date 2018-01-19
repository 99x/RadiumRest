using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

using RadiumRest.Core.Messaging;

namespace RadiumRest
{
    public class RestResourceHandler
    {
        protected RadiumRequest Request { get; private set; }

        protected RadiumResponse Response { get; private set; }

        private RadiumContext owinContext;
        internal RadiumContext OContext
        {
            set
            {
                this.owinContext = value;
                this.Request = value.Request;
                this.Response = value.Response;
            }
        }
        protected RadiumContext OwinContext
        {
            get
            {
                return this.owinContext;
            }
        }

        public Dictionary<string, object> DataBag { get; set; }
    }
}
