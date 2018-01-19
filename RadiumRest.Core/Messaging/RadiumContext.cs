using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadiumRest.Core.Messaging
{
    public class RadiumContext
    {
        public RadiumRequest Request { get; set; }
        public RadiumResponse Response { get; set; }
    }
}
