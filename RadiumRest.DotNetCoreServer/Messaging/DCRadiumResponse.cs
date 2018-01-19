using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RadiumRest.Core.Messaging;

using Microsoft.AspNetCore.Http;

namespace RadiumRest.DotNetCoreServer.Messsaging
{
    public class DCRadiumResponse : RadiumResponse
    {

        private Microsoft.AspNetCore.Http.HttpResponse res;
        public DCRadiumResponse(Microsoft.AspNetCore.Http.HttpResponse res)
        {
            this.res = res;
        }


        public IHeaderDictionary Headers => this.res.Headers;

        public IResponseCookies Cookies => this.res.Cookies;

        public long? ContentLength { get => this.res.ContentLength; set => this.res.ContentLength = value; }

        public Stream Body { get => this.res.Body; set => this.res.Body = value; }
        public override string ContentType { get => this.res.ContentType; set => this.res.ContentType = value; }
        public override int StatusCode { get => this.res.StatusCode; set => this.res.StatusCode = value; }


        public void Redirect(string location)
        {
            this.res.Redirect(location);
        }


        public override Task WriteAsync(string text, CancellationToken token)
        {
            return this.res.WriteAsync(text, token);
        }

        public Task WriteAsync(byte[] data)
        {
            return this.res.WriteAsync(System.Text.Encoding.UTF8.GetString(data));
        }

        public Task WriteAsync(byte[] data, CancellationToken token)
        {
            return this.res.WriteAsync(System.Text.Encoding.UTF8.GetString(data), token);
        }

        public override Task WriteAsync(string text)
        {
            return this.res.WriteAsync(text);
        }
    }
}
