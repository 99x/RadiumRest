using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;
using Newtonsoft.Json;
using System.IO;

namespace RadiumRest.Server
{
    internal class Environment
    {

        private const string configFileName = "radiumrest.json";

        private string executingPath;
        internal string ExecutingPath
        {
            get
            {
                if (this.executingPath == null)
                {
                    var asmLoc = Assembly.GetEntryAssembly().Location;
                    this.executingPath = asmLoc.Substring(0, asmLoc.LastIndexOf("\\"));
                }

                return this.executingPath;
            }
        }

        private Dictionary<string, object> configuration;
        internal Dictionary<string, object> Configuration
        {
            get
            {
                if (this.configuration == null)
                {
                    StreamReader reader = null;
                    try
                    {
                        var serializer = new JsonSerializer();
                        reader = new StreamReader(this.ExecutingPath + "\\" + configFileName);
                        this.configuration = (Dictionary<string, object>)serializer.Deserialize(reader, typeof(Dictionary<string, object>));
                    }
                    catch (Exception ex)
                    {
                        this.configuration = new Dictionary<string, object>();
                    }
                    finally
                    {
                        if (reader != null)
                            reader.Dispose();
                    }
                }

                return this.configuration;
            }

        }

        internal void Load()
        {
            var tmp = this.Configuration;
        }
    }
}
