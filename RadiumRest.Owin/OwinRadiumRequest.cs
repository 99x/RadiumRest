using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.Owin;
using RadiumRest.Core.Messaging;

namespace RadiumRest.Plugin.Owin
{
    public class OwinRadiumRequest : RadiumRequest, IOwinRequest
    {
        private IOwinRequest req;
        public OwinRadiumRequest(IOwinRequest req)
        {
            this.req = req;
        }

        public IDictionary<string, object> Environment => this.req.Environment;

        public IOwinContext Context => this.req.Context;

        public string Scheme { get => this.req.Scheme; set => this.req.Scheme = value; }

        public bool IsSecure => this.req.IsSecure;

        public HostString Host { get => this.req.Host; set => this.req.Host = value; }
        public PathString PathBase { get => this.req.PathBase; set => this.req.PathBase = value; }
        public QueryString QueryString { get => this.req.QueryString; set => this.req.QueryString = value; }

        public IReadableStringCollection Query => this.req.Query;

        public Uri Uri => this.req.Uri;

        public string Protocol { get => this.req.Protocol; set => this.req.Protocol = value; }

        public IHeaderDictionary Headers => this.req.Headers;

        public RequestCookieCollection Cookies => this.req.Cookies;

        public string CacheControl { get => this.req.CacheControl; set => this.req.CacheControl = value; }
        public string MediaType { get => this.req.MediaType; set => this.req.MediaType = value; }
        public string Accept { get => this.req.Accept; set => this.req.Accept = value; }
        public Stream Body { get => this.req.Body; set => this.req.Body = value; }
        public CancellationToken CallCancelled { get => this.req.CallCancelled; set => this.req.CallCancelled = value; }
        public string LocalIpAddress { get => this.req.LocalIpAddress; set => this.req.LocalIpAddress = value; }
        public int? LocalPort { get => this.req.LocalPort; set => this.req.LocalPort = value; }
        public string RemoteIpAddress { get => this.req.RemoteIpAddress; set => this.req.RemoteIpAddress = value; }
        public int? RemotePort { get => this.req.RemotePort; set => this.req.RemotePort = value; }
        public IPrincipal User { get => this.req.User; set => this.req.User = value; }
        public override string ContentType { get => this.req.ContentType; set => this.req.ContentType = value; }
        public override string Method { get => this.req.Method; set => this.req.Method = value; }

        private RadiumRequestPath _path;
        public override RadiumRequestPath Path
        {
            get
            {
                if (this._path == null)
                    this._path = new OwinRadiumRequestPath(this.req.Path);

                return this._path;
            }

            set => this._path = value;
        }
        PathString IOwinRequest.Path { get => this.req.Path; set => this.req.Path = value; }

        public T Get<T>(string key)
        {
            return this.req.Get<T>(key);
        }

        public Task<IFormCollection> ReadFormAsync()
        {
            return this.req.ReadFormAsync();
        }

        public IOwinRequest Set<T>(string key, T value)
        {
            return this.req.Set<T>(key, value);
        }
    }
}
