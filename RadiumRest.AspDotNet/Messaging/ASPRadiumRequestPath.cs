using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

using RadiumRest.Core.Messaging;

namespace RadiumRest.AspDotNet.Messaging
{
    public class ASPRadiumRequestPath: RadiumRequestPath
    {
        private string _value;
        public ASPRadiumRequestPath(string path)
        {
            this._value = path;
        }

        public override string Value => this._value;
    }
}
