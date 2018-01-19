using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Owin;
using Owin;

using RadiumRest.Core.Filters;

namespace RadiumRest.Core
{
    public class RequestHandler
    {
        private Kernel kernel;
        public RequestHandler(Kernel kernel)
        {
            this.kernel = kernel;
        }

        public void Configuration(IAppBuilder app)
        {
            app.Run(context =>
            {
                return ServiceInvoker.Invoke(this.kernel, context);
            });
        }
    }
}
