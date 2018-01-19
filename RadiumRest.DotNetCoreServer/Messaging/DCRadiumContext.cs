using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using RadiumRest.Core.Messaging;

namespace RadiumRest.DotNetCoreServer.Messsaging
{
    public class DCRadiumContext : RadiumContext
    {
        
        public DCRadiumContext(Microsoft.AspNetCore.Http.HttpContext context) :base()
        {
            this.Request = new DCRadiumRequest(context.Request);
            this.Response = new DCRadiumResponse(context.Response);
        }
        

    }
}
