using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace RadiumRest.Core.ServiceRepo
{
    internal class ServiceRepository
    {

        internal static ServiceRepository Repo;

        private Dictionary<string, Dictionary<string, PathExecutionInfo>> pathExecutionInfo;

        internal PathExecutionParams this[string method, string reqUrl]
        {
            get
            {
                return getExecutionParams(method, reqUrl);
            }
        }

        private PathExecutionParams getExecutionParams(string method, string reqUrl)
        {
            PathExecutionParams executionParams = null;
            bool isFound = false;
            Dictionary<string, string> variables = null;
            PathExecutionInfo executionInfo = null;

            string[] urlSplit = reqUrl.Split('/');

            if (pathExecutionInfo.ContainsKey(method))
            {

                variables = new Dictionary<string, string>();

                foreach (KeyValuePair<string, PathExecutionInfo> onePath in pathExecutionInfo[method])
                {
                    string[] definedPathSplit = onePath.Key.Split('/');

                    if (definedPathSplit.Length == urlSplit.Length)
                    {
                        variables.Clear();
                        isFound = true;

                        for (int i = 0; i < definedPathSplit.Length; i++)
                        {
                            if (definedPathSplit[i].StartsWith("@"))
                                variables.Add(definedPathSplit[i].Substring(1), urlSplit[i]);
                            else
                            {
                                if (definedPathSplit[i] != urlSplit[i])
                                {
                                    isFound = false;
                                    break;
                                }
                            }
                        }

                    }

                    if (isFound)
                    {
                        executionInfo = onePath.Value;
                        break;
                    }
                }
            }

            if (isFound)
            {
                executionParams = new PathExecutionParams();
                executionParams.ExecutionInfo = executionInfo;
                executionParams.Parameters = variables;
            }

            return executionParams;
        }



        internal void AddExecutionInfo(string method, string reqUrl, PathExecutionInfo value)
        {
            Dictionary<string, PathExecutionInfo> methodDic;

            if (!pathExecutionInfo.ContainsKey(method))
            {
                methodDic = new Dictionary<string, PathExecutionInfo>();
                pathExecutionInfo.Add(method, methodDic);
            }
            else methodDic = pathExecutionInfo[method];

            if (!methodDic.ContainsKey(reqUrl))
                methodDic.Add(reqUrl, value);
        }

        internal ServiceRepository()
        {
            this.pathExecutionInfo = new Dictionary<string, Dictionary<string, PathExecutionInfo>>();
        }


        internal static void Initialize(Assembly callingAssembly)
        {
            Repo = new ServiceRepository();

            var ignoreAssemblies = new string[] {"RadiumRest.Core", "RadiumRest.Selfhost", "mscorlib"};
            var referencedAssemblies = callingAssembly.GetReferencedAssemblies();
            var currentAsm = Assembly.GetExecutingAssembly().GetName();

            var scanAssemblies = new List<AssemblyName>() { callingAssembly.GetName()};

            foreach (var asm in referencedAssemblies)
            {
                if (asm == currentAsm)
                    continue;

                if (!ignoreAssemblies.Contains(asm.Name))
                    scanAssemblies.Add(asm);
            }

            foreach (var refAsm in scanAssemblies)
            {
                try
                {
                    var asm = Assembly.Load(refAsm.FullName);


                    foreach (var typ in asm.GetTypes())
                    {
                        if (typ.IsSubclassOf(typeof(RestResourceHandler)))
                        {
                            var classAttribObj = typ.GetCustomAttributes(typeof(RestResource), false).FirstOrDefault();
                            string baseUrl;
                            if (classAttribObj != null)
                            {
                                var classAttrib = (RestResource)classAttribObj;
                                baseUrl = classAttrib.Path;
                                baseUrl = baseUrl.StartsWith("/") ? baseUrl : "/" + baseUrl;
                            }
                            else baseUrl = "";

                            var methods = typ.GetMethods();


                            foreach (var method in methods)
                            {
                                var methodAttribObject = method.GetCustomAttributes(typeof(RestPath), false).FirstOrDefault();

                                if (methodAttribObject != null)
                                {
                                    var methodAttrib = (RestPath)methodAttribObject;
                                    string finalUrl = baseUrl + (methodAttrib.Path == null ? "" : methodAttrib.Path);
                                    
                                    var finalMethod = methodAttrib.Method;

                                    PathExecutionInfo exeInfo = new PathExecutionInfo();
                                    exeInfo.Type = typ;
                                    exeInfo.Method = method;
                                    Repo.AddExecutionInfo(finalMethod, finalUrl, exeInfo);
                                }
                            }
                        }

                    }
                }
                catch (Exception ex)
                {
                }
            }
        }
    }
}
