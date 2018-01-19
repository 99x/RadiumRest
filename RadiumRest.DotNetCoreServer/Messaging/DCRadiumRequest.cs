using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using RadiumRest.Core.Messaging;


namespace RadiumRest.DotNetCoreServer.Messsaging
{
    public class DCRadiumRequest : RadiumRequest
    {
        private Microsoft.AspNetCore.Http.HttpRequest req;
        public DCRadiumRequest(Microsoft.AspNetCore.Http.HttpRequest req)
        {
            this.req = req;
        }

        public string Scheme { get => this.req.Scheme; set => this.req.Scheme = value; }

        public HostString Host { get => this.req.Host; set => this.req.Host = value; }
        public PathString PathBase { get => this.req.PathBase; set => this.req.PathBase = value; }
        public QueryString QueryString { get => this.req.QueryString; set => this.req.QueryString = value; }

        public IQueryCollection Query => this.req.Query;
        
        public string Protocol { get => this.req.Protocol; set => this.req.Protocol = value; }

        public IHeaderDictionary Headers => this.req.Headers;

        public IRequestCookieCollection Cookies => this.req.Cookies;

        public Stream Body { get => this.req.Body; set => this.req.Body = value; }

        public override string ContentType { get => this.req.ContentType; set => this.req.ContentType = value; }
        public override string Method { get => this.req.Method; set => this.req.Method = value; }

        private RadiumRequestPath _path;
        public override RadiumRequestPath Path
        {
            get
            {
                if (this._path == null)
                    this._path = new DCRadiumRequestPath(this.req.Path);

                return this._path;
            }

            set => this._path = value;
        }


        public Task<IFormCollection> ReadFormAsync()
        {
            return this.req.ReadFormAsync();
        }

    }
}
