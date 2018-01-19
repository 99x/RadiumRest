using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RadiumRest.Core.ServiceRepo
{
    internal class PathExecutionParams
    {
        private PathExecutionInfo executionInfo;
        internal PathExecutionInfo ExecutionInfo
        {
            get { return executionInfo; }
            set { executionInfo = value; }
        }

        private Dictionary<string, string> parameters;
        public Dictionary<string, string> Parameters
        {
            get { return parameters; }
            set { parameters = value; }
        }



    }
}
