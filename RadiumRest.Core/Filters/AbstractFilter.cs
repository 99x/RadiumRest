using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadiumRest.Core.Filters
{
    public abstract class AbstractFilter
    {
        public Dictionary<string, object> DataBag { get; internal set; }
        public FilterResponse FilterResponse { get; private set; }
        public AbstractFilter()
        {
            this.FilterResponse = new FilterResponse()
            {
                Success = true,
                ContentType = "application/json",
                Message = "",
                StatusCode = 200
            };
        }
        public abstract void Process();

    }
}
