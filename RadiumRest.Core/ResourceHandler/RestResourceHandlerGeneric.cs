using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RadiumRest
{
    public abstract class RestResourceHandlerGeneric <T> : RestResourceHandler
    {
        [RestPath("GET", "/@skip/@take")]
        public abstract T GetAll(int skip, int take);

        [RestPath("POST")]
        public abstract void Insert();

        [RestPath("PUT")]
        public abstract void Update();

        [RestPath("DELETE")]
        public abstract void Delete();
    }
}
