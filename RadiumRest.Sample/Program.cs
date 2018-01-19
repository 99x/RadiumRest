using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RadiumRest.Core;
using RadiumRest.Server;

namespace RadiumRest.Sample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var server = new RadiumServer();
            server.Start();
        }
    }
}
