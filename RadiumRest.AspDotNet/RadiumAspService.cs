using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                if (_kernel == null)
                {
                    _kernel = new Kernel();
                    _kernel.Initialize();
                }

                return _kernel;
            }
            set
            {
                _kernel = value;
            }
        }
    }
}
