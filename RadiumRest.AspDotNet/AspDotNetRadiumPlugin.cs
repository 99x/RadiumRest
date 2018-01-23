using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Web;

using RadiumRest.Core;
using RadiumRest.Core.Plugin;

namespace RadiumRest.Plugin.AspDotNet
{
    public class AspDotNetRadiumPlugin: RadiumPlugin
    {
        public void Handle(HttpContext context)
        {
            Kernel kernel = RadiumAspService.Kernel;
            if (kernel == null)
            {
                kernel = new Kernel(Assembly.GetCallingAssembly());
                
                RadiumAspService.Kernel = kernel;
            }

            ServiceInvoker.Invoke(kernel, new Messaging.ASPRadiumContext(context));
        }

        protected override void Listen()
        {
            
        }
    }
}
