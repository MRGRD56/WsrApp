using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Pipelines;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace WsrApp.Server.Helpers
{
    internal static class MethodHelper
    {
        //https://stackoverflow.com/questions/22598323/movenext-instead-of-actual-method-task-name
        private static MethodBase GetAsyncMethod(MethodBase asyncMethod)
        {
            var generatedType = asyncMethod.DeclaringType;
            var originalType = generatedType.DeclaringType;
            var matchingMethods =
                from methodInfo in originalType.GetMethods()
                let attr = methodInfo.GetCustomAttribute<AsyncStateMachineAttribute>()
                where attr != null && attr.StateMachineType == generatedType
                select methodInfo;

            // If this throws, the async method scanning failed.
            var foundMethod = matchingMethods.Single();
            return foundMethod;
        }

        internal static string GetParametersString(MethodBase method)
        {
            var parameters = method.GetParameters();
            var result = "[Parameters] \n";

            var parametersStrings = parameters.ToList().Select(x => $"{x.Name}: {x.ParameterType.Name}");
            result += string.Join("; \n", parametersStrings) + ".";

            return result;
        }

        internal static string GetCurrentSyncParametersString()
        {
            var stackTrace = new StackTrace();
            var method = stackTrace.GetFrame(1).GetMethod();
            return GetParametersString(method);
        }

        internal static string GetCurrentAsyncParametersString()
        {
            var stackTrace = new StackTrace();
            var method = stackTrace.GetFrame(1).GetMethod();
            return GetParametersString(GetAsyncMethod(method));
        }
    }
}
