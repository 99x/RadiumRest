using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace RadiumRest
{
    public static class RadiumService
    {
        public static T Create<T>() where T: RadiumRest.Core.Plugin.RadiumPlugin
        {
            return Activator.CreateInstance<T>();
        }

        public static void Use<T>() where T: RadiumRest.RestResourceHandler
        {

        }
    }
}
