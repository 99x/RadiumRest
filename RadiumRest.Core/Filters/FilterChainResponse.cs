using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadiumRest.Core.Filters
{
    internal class FilterChainResponse
    {
        internal Dictionary<string, object> FilterResponse { get; set; }
        internal FilterResponse LastResponse { get; set; }
    }
}
