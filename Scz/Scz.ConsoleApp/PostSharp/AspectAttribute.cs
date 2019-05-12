using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PostSharp.Aspects;

namespace Scz.ConsoleApp
{
    [Serializable]
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class MyAspectAttribute : OnMethodBoundaryAspect
    {
        public override void OnEntry(MethodExecutionArgs args)
        {
            args.Arguments[0] = "jing dong!";
            args.FlowBehavior = FlowBehavior.Continue;
        }

        public override void OnSuccess(MethodExecutionArgs args)
        {
            Console.WriteLine("Success !");
        }

        public override void OnExit(MethodExecutionArgs args)
        {
            Console.WriteLine("Exit!");
        }

        public override void OnException(MethodExecutionArgs args)
        {
            base.OnException(args);
        }
    }
}
