using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin;

using RadiumRest.Core.Messaging;


namespace RadiumRest.Plugin.Owin
{
    public class OwinRadiumRequestPath: RadiumRequestPath
    {
        private PathString pStr;
        public OwinRadiumRequestPath(PathString path)
        {
            this.pStr = path;
        }

        public override string Value { get => pStr.Value; }
    }
}
