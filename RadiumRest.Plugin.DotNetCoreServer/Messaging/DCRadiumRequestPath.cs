using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RadiumRest.Core.Messaging;

namespace RadiumRest.Plugin.DotNetCore.Messsaging
{
    public class DCRadiumRequestPath: RadiumRequestPath
    {
        private Microsoft.AspNetCore.Http.PathString pStr;
        public DCRadiumRequestPath(Microsoft.AspNetCore.Http.PathString path)
        {
            this.pStr = path;
        }

        public override string Value { get => pStr.Value; }
    }
}
