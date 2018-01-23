using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

using RadiumRest.Core.Messaging;

namespace RadiumRest.Plugin.AspDotNet.Messaging
{
    public class ASPRadiumContext : RadiumContext
    {
        public ASPRadiumContext(HttpContext context)
        {
            this.Request = new ASPRadiumRequest(context.Request);
            this.Response = new ASPRadiumResponse(context.Response);
        }
    }
}
