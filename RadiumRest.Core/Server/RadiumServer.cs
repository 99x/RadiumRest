using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

using RadiumRest.Core;

namespace RadiumRest.Core.Server
{
    public abstract class RadiumServer
    {
        public Kernel Kernel { get; internal set; }

        protected Environment Environment { get; private set; }
        protected JObject ServerSettings { get; set; }

        public RadiumServer()
        {
            this.Environment = new Environment();
            this.Kernel = new Kernel();

            this.Environment.Load();
            this.Kernel.Initialize();
        }

        public RadiumServer(bool useLazyInitializing)
        {

        }

        protected void Initialize(Kernel kernel)
        {
            this.Environment = new Environment();
            this.Kernel = kernel;

            this.Environment.Load();
            this.Kernel.Initialize();
        }

        public void Start()
        {
            this.Environment.Load();
            this.Listen();
        }

        protected abstract void Listen();
    }
}
