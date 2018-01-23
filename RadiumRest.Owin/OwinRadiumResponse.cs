using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Owin;
using RadiumRest.Core.Messaging;


namespace RadiumRest.Owin
{
    public class OwinRadiumResponse : RadiumResponse, IOwinResponse
    {

        private IOwinResponse res;
        public OwinRadiumResponse(IOwinResponse res)
        {
            this.res = res;
        }

        public IDictionary<string, object> Environment => this.res.Environment;

        public IOwinContext Context => this.res.Context;

        public string ReasonPhrase { get => this.res.ReasonPhrase; set => this.res.ReasonPhrase = value; }
        public string Protocol { get => this.res.Protocol; set => this.res.Protocol = value; }

        public IHeaderDictionary Headers => this.res.Headers;

        public ResponseCookieCollection Cookies => this.res.Cookies;

        public long? ContentLength { get => this.res.ContentLength; set => this.res.ContentLength = value; }
        public DateTimeOffset? Expires { get => this.res.Expires; set => this.res.Expires = value; }
        public string ETag { get => this.res.ETag; set => this.res.ETag = value; }
        public Stream Body { get => this.res.Body; set => this.res.Body = value; }
        public override string ContentType { get => this.res.ContentType; set => this.res.ContentType = value; }
        public override int StatusCode { get => this.res.StatusCode; set => this.res.StatusCode = value; }

        public T Get<T>(string key)
        {
            return this.res.Get<T>(key);
        }

        public void OnSendingHeaders(Action<object> callback, object state)
        {
            this.res.OnSendingHeaders(callback, state);
        }

        public void Redirect(string location)
        {
            this.res.Redirect(location);
        }

        public IOwinResponse Set<T>(string key, T value)
        {
            return this.res.Set<T>(key, value);
        }

        public void Write(string text)
        {
            this.res.Write(text);
        }

        public void Write(byte[] data)
        {
            this.res.Write(data);
        }

        public void Write(byte[] data, int offset, int count)
        {
            this.res.Write(data, offset, count);
        }

        public override Task WriteAsync(string text, CancellationToken token)
        {
            return this.res.WriteAsync(text, token);
        }

        public Task WriteAsync(byte[] data)
        {
            return this.res.WriteAsync(data);
        }

        public Task WriteAsync(byte[] data, CancellationToken token)
        {
            return this.res.WriteAsync(data, token);
        }

        public Task WriteAsync(byte[] data, int offset, int count, CancellationToken token)
        {
            return this.res.WriteAsync(data, offset, count, token);
        }

        public override Task WriteAsync(string text)
        {
            return this.res.WriteAsync(text);
        }
    }
}
