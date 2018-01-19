using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadiumRest.Core.Messaging
{
    public abstract class RadiumRequest
    {
        public abstract string ContentType { get; set; }
        public abstract string Method { get; set; }

        public abstract RadiumRequestPath Path { get; set; }
    }
}
