using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace RadiumRest.Core.Filters
{
    internal class FilterManager
    {

        List<Type> filterChain;

        public FilterManager()
        {
            this.filterChain = new List<Type>();
        }

        internal void Register<T>() where T: AbstractFilter
        {
            this.filterChain.Add(typeof(T));
        }

        internal FilterChainResponse ExecuteChain()
        {
            Dictionary<string, object> filterInputs = new Dictionary<string, object>();

            FilterChainResponse outData = new FilterChainResponse();
            outData.FilterResponse = filterInputs;

            foreach (Type filterType in filterChain)
            {
                try
                {
                    AbstractFilter filterObj = (AbstractFilter)Activator.CreateInstance(filterType);
                    filterObj.DataBag = filterInputs;
                    outData.LastResponse = filterObj.FilterResponse;
                    filterObj.Process();

                    if (!filterObj.FilterResponse.Success)
                        break;
                }
                catch (Exception ex)
                {
                    outData.LastResponse.Error = ex;
                    outData.LastResponse.StatusCode = 500;
                    outData.LastResponse.Success = false;
                    outData.LastResponse.Message = "Internal Server Error";
                    break;
                }
            }

            return outData;
        }
    }
}
