using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

using RadiumRest.Core.Messaging;

namespace RadiumRest.Plugin.AspDotNet.Messaging
{
    public class ASPRadiumResponse : RadiumResponse
    {
        private HttpResponse _response;
        public ASPRadiumResponse(HttpResponse response)
        {
            this._response = response;
        }

        public override string ContentType { get => this._response.ContentType; set => this._response.ContentType = value; }
        public override int StatusCode { get => this._response.StatusCode; set => this._response.StatusCode = value; }

        public override Task WriteAsync(string text, CancellationToken token)
        {
            this._response.Write(text);
            return new Task(() => {});
        }

        public override Task WriteAsync(string text)
        {
            this._response.Write(text);
            return new Task(() => {});
        }
    }
}
