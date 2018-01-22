using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

using RadiumRest.Core;

namespace RadiumRest.AspDotNet
{
    public static class RadiumAspService
    {

        private static Kernel _kernel;
        internal static Kernel Kernel
        {
            get
            {
                return _kernel;
            }
            set
            {
                _kernel = value;
                _kernel.Initialize();
            }
        }


    }
}
