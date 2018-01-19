using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RadiumRest.Core.ServiceRepo
{
    public class ParameterMismatchException: Exception
    {
        public ParameterMismatchException():base("Parameters Mismatch") 
        {
            
        }
    }
}
