using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

using RadiumRest.Core.ServiceRepo;
using RadiumRest.Core.Filters;
using RadiumRest.Core.Formatters;

namespace RadiumRest.Core
{
    public class Kernel
    {

        internal FilterManager FilterManager { get; private set; }
        internal ResponseFormatter ResponseFormatter { get; private set; }

        public Kernel()
        {
            this.FilterManager = new FilterManager();
            this.ResponseFormatter = new ResponseFormatter();
        }
        public void Initialize()
        {
            ServiceRepository.Initialize(Assembly.GetEntryAssembly());
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
