using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.C7
{
    class C7Test
    {
        public DateTime Max_Local_Function(IList<DateTime> values)
        {
            var callCount = 0;

            DateTime MaxDate(DateTime left, DateTime right)
            {
                callCount++; //变量callCount被闭包。
                return (left > right) ? left : right;
            }

            var result = values.First();
            foreach (var item in values.Skip(1))
            {
                result = MaxDate(result, item);
            }

            return result;
        }
    }
}
