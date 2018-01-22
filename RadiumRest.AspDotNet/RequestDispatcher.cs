using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;


using RadiumRest.Core;

namespace RadiumRest.AspDotNet
{
    public class RequestDispatcher : IHttpHandler
    {

        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            ServiceInvoker.Invoke(RadiumAspService.Kernel, new Messaging.ASPRadiumContext(context));
        }
    }
}
