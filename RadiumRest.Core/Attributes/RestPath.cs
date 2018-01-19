using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RadiumRest
{
    [AttributeUsage(AttributeTargets.Method, Inherited = true)]
    public class RestPath : Attribute
    {
        private string method;
        public string Method
        {
            get { return method; }
            set { method = value; }
        }

        private string path;
        public string Path
        {
            get { return path; }
            set { path = value; }
        }

        public RestPath(string method, string path) 
        {
            this.method = method;
            this.path = path;
        }

        public RestPath(string method) 
        {
            this.method = method;
        }
    }
}
