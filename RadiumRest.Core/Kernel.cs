using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

using RadiumRest.Core.ResourceRepo;
using RadiumRest.Core.Filters;
using RadiumRest.Core.Formatters;

namespace RadiumRest.Core
{
    public class Kernel
    {

        internal FilterManager FilterManager { get; private set; }
        internal ResponseFormatter ResponseFormatter { get; private set; }

        private Assembly callingAssembly;

        public Kernel(Assembly callingAssembly)
        {
            this.callingAssembly = callingAssembly;
            this.FilterManager = new FilterManager();
            this.ResponseFormatter = new ResponseFormatter();
        }

        public Kernel()
        {
            this.FilterManager = new FilterManager();
            this.ResponseFormatter = new ResponseFormatter();
        }
        public void Initialize()
        {
            Assembly asm;

            if (callingAssembly == null)
            {
                asm = Assembly.GetEntryAssembly();
                if (asm == null)
                    asm = Assembly.GetCallingAssembly();
            }
            else
            {
                asm = callingAssembly;
            }


            ResourceRepository.Initialize(asm);
        }

        public void RegisterFilter<T>() where T: AbstractFilter
        {
            FilterManager.Register<T>();
        }

        public void RegisterFormatter<T>() where T : AbstractFormatter
        {
            ResponseFormatter.Register<T>();
        }

        public void RegisterFormatter<T>(bool isDefault) where T : AbstractFormatter
        {
            ResponseFormatter.Register<T>(isDefault);
        }
    }
}
