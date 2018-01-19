using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Schema.Generation;

namespace RadiumRest.Core.Formatters
{
    public class JSONSchemaFormatter : AbstractFormatter
    {
        public override string Format(object input)
        {
            dynamic inp = input;
            var res = inp.result;
            JSchemaGenerator generator = new JSchemaGenerator();
            JSchema schema = generator.Generate(res.GetType());
            return schema.ToString();
        }

        public override string GetMimeType()
        {
            return "application/jsonschema";
        }
    }
}
