using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace RadiumRest.Core.ServiceRepo
{
    internal class PathExecutionInfo
    {
        private MethodInfo method;
        public MethodInfo Method
        {
            get { return method; }
            set { method = value; }
        }

        private Type type;
        public Type Type
        {
            get { return type; }
            set { type = value; }
        }
    }
}
