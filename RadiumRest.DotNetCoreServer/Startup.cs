using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

using RadiumRest.Core;

namespace RadiumRest.DotNetCoreServer
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.Run(async (context) =>
            {
                await ServiceInvoker.Invoke(DotNetCoreServer.KernalInstance, new Messsaging.DCRadiumContext(context));
            });
        }
    }
}
