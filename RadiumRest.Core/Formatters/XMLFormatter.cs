using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;

namespace RadiumRest.Core.Formatters
{
    public class XMLFormatter : AbstractFormatter
    {
        public override string Format(object input)
        {
            string outData;

            if (input !=null)
            using (MemoryStream stream1 = new MemoryStream())
            {
                DataContractSerializer serializer = new DataContractSerializer(input.GetType());
                serializer.WriteObject(stream1, input);
                using (StreamReader sr = new StreamReader(stream1))
                {
                    outData = sr.ReadToEnd();
                }
            }


            return "";
        }

        public override string GetMimeType()
        {
            return "application/xml";
        }
    }

}
