using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Microsoft.Owin;

using RadiumRest.Core.ServiceRepo;
using RadiumRest.Core.Messaging;

namespace RadiumRest.Core
{
    internal static class ServiceInvoker
    {

        internal static Task Invoke(Kernel kernel, IOwinContext context)
        {
            DefaultResponseBody responseBody = new DefaultResponseBody();

            var req = context.Request;
            var res = context.Response;


            string reqContentType = req.ContentType;
            if (reqContentType == null)
                reqContentType = "application/json";
            else
                reqContentType = reqContentType.ToLower();

            PathExecutionParams exeParams = ServiceRepository.Repo[req.Method, req.Path.Value];

            try
            {
                if (exeParams != null)
                {

                    Filters.FilterChainResponse chainResponse =  kernel.FilterManager.ExecuteChain();
                    bool isSuccess = chainResponse.LastResponse !=null ? chainResponse.LastResponse.Success : true;

                    if (!isSuccess)
                    {
                        res.ContentType = reqContentType;
                        responseBody.success = false; 
                        responseBody.result = chainResponse.LastResponse.Message;
                        responseBody.error = chainResponse.LastResponse.Error;
                        res.StatusCode = chainResponse.LastResponse.StatusCode;
                    }
                    else
                    {
                        RestResourceHandler newObj = (RestResourceHandler)Activator.CreateInstance(exeParams.ExecutionInfo.Type);
                        newObj.OContext = context;
                        newObj.DataBag = chainResponse.FilterResponse;
                        var exeMethod = exeParams.ExecutionInfo.Method;
                        List<object> activatorParams = new List<object>();
                        var methodParams = exeMethod.GetParameters();

                        foreach (var mParam in methodParams)
                        {
                            if (exeParams.Parameters.ContainsKey(mParam.Name))
                            {
                                var strValue = exeParams.Parameters[mParam.Name];
                                object convertedValue = Convert.ChangeType(strValue, mParam.ParameterType);
                                activatorParams.Add(convertedValue);
                            }
                            else
                            {
                                throw new ParameterMismatchException();
                            }
                        }

                        object output = exeMethod.Invoke(newObj, activatorParams.ToArray());
                        responseBody.success = true;
                        responseBody.result = output;
                        res.ContentType = reqContentType;
                    }

                }
                else
                {
                    res.ContentType = reqContentType;
                    responseBody.success = false;
                    responseBody.result = "404 Not Found";
                    res.StatusCode = 404;
                }
            }
            catch (Exception ex) 
            {
                res.ContentType = reqContentType;
                responseBody.success = false;
                responseBody.result = ex;
                res.StatusCode = 500;
            }

            var formatter = kernel.ResponseFormatter.GetFormatter(reqContentType);
            return res.WriteAsync(formatter.Format(responseBody));
        }

    }
}
