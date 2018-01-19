using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadiumRest.Core.Formatters
{
    public class ResponseFormatter
    {
        private Dictionary<string, AbstractFormatter> Formatters { get; set; }
        private AbstractFormatter defaultFormatter;

        public ResponseFormatter()
        {
            this.Formatters = new Dictionary<string, AbstractFormatter>();
        }

        internal void Register<T>() where T : AbstractFormatter
        {
            var fObj = (AbstractFormatter)Activator.CreateInstance(typeof(T));
            Formatters.Add(fObj.GetMimeType(), fObj);
            if (defaultFormatter == null)
                defaultFormatter = fObj;
        }

        internal void Register<T>(bool isDefault) where T : AbstractFormatter
        {
            var fObj = (AbstractFormatter)Activator.CreateInstance(typeof(T));
            Formatters.Add(fObj.GetMimeType(), fObj);
            if (isDefault)
                defaultFormatter = fObj;
        }

        internal AbstractFormatter GetFormatter(string contentType)
        {
            AbstractFormatter outData = null;
            if (Formatters.ContainsKey(contentType))
                outData = Formatters[contentType];
            else
            {
                if (defaultFormatter == null)
                    Register<JSONFormatter>();

                return defaultFormatter;
                        
            }

            return outData;
        }
    }
}
