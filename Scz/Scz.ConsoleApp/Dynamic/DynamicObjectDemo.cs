using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace Scz.ConsoleApp
{
   public class DynamicObjectDemo:DynamicObject
    {
       Dictionary<string,object> Properties = new Dictionary<string, object>();
       private Dictionary<string, object> Methods = new Dictionary<string, object>();

       public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
       {
           if (!Methods.Keys.Contains(binder.Name))
           {
               Methods.Add(binder.Name,null);
           }

           if(args!=null)
           {
               Methods[binder.Name] = args;
           }

           StringBuilder sb = new StringBuilder();
           foreach (var item in args)
           {
               sb.Append(item);
           }

           result = sb.ToString();
           return true;
       }
       public override bool TrySetMember(SetMemberBinder binder, object value)
       {
           if(!Properties.Keys.Contains(binder.Name))
           {
               Properties.Add(binder.Name,value.ToString());
           }
           return true;
       }

       public override bool TryGetMember(GetMemberBinder binder, out object result)
       {
           return Properties.TryGetValue(binder.Name, out result);
       }
    }
}
