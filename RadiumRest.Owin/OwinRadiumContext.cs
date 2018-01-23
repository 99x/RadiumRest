using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using RadiumRest.Core.Messaging;

namespace RadiumRest.Plugin.Owin
{
    public class OwinRadiumContext : RadiumContext
    {
        private Microsoft.Owin.IOwinContext _ctx;
        public OwinRadiumContext(Microsoft.Owin.IOwinContext context) :base()
        {
            this._ctx = context;
            this.Request = new OwinRadiumRequest(context.Request);
            this.Response = new OwinRadiumResponse(context.Response);
        }
        

    }
}
