using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scz.Aop
{
    [Serializable]
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class LogAttribute : OnMethodBoundaryAspect
    {
        public string ActionName { get; set; }
        public override void OnEntry(MethodExecutionArgs eventArgs)
        {
            LoggingHelper.Writelog(ActionName + "开始执行");
        }

        public override void OnExit(MethodExecutionArgs eventArgs)
        {
            LoggingHelper.Writelog(ActionName + "成功完成");
        }

    }
}
