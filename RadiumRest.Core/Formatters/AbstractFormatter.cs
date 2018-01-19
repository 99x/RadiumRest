using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadiumRest.Core.Formatters
{
    public abstract class AbstractFormatter
    {
        public abstract string Format(object input);
        public abstract string GetMimeType();
    }
}
