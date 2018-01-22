using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

using RadiumRest.Core.Messaging;

namespace RadiumRest.AspDotNet.Messaging
{
    public class ASPRadiumRequest : RadiumRequest
    {

        private HttpRequest _request;
        private ASPRadiumRequestPath _reqPath;
        public ASPRadiumRequest(HttpRequest request)
        {
            this._request = request;
            this._reqPath = new ASPRadiumRequestPath(this._request.Path);
            
        }

        public override string ContentType { get => this._request.ContentType; set => this._request.ContentType = value; }
        public override string Method { get => this._request.HttpMethod; set { } }
        public override RadiumRequestPath Path { get => this._reqPath; set  { } }
    }
}
