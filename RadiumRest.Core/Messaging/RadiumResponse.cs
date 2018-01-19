using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace RadiumRest.Core.Messaging
{
    public abstract class RadiumResponse
    {
        public abstract string ContentType { get; set; }
        public abstract int StatusCode { get; set; }

        public abstract Task WriteAsync(string text, CancellationToken token);
        public abstract Task WriteAsync(string text);

    }
}
