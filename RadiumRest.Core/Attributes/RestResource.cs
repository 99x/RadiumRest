using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RadiumRest
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class RestResource : Attribute
    {
        private string path;
        public string Path
        {
            get { return path; }
            set { path = value; }
        }

        public RestResource(string path) 
        {
            this.path = path;
        }
    }
}
