using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RadiumRest.Core.Formatters
{
    public class JSONFormatter : AbstractFormatter
    {
        public override string Format(object input)
        {
            var serializerSettings = new JsonSerializerSettings();
            serializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
            return JsonConvert.SerializeObject(input, serializerSettings);
        }

        public override string GetMimeType()
        {
            return "application/json";
        }
    }
}
