using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RadiumRest.Core.Messaging
{
    public class DefaultResponseBody
    {
        public bool success
        {
            get;set;
        }

        public object result
        {
            get;set;
        }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Exception error
        {
            get;set;
        }

    }
}
