using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    /// <summary>
    /// 元组例子
    /// </summary>
    public class TupleDemo
    {
        public static void Output()
        {
            //1 member
            var test = new Tuple<int>(1);
            //2 member ( 1< n <8 )
            var test2 = Tuple.Create<int, int>(1, 2);
            //8 member , the last member must be tuple type.
            var test3 = new Tuple<int, int, int, int, int, int, int, Tuple<int>>(1, 2, 3, 4, 5, 6, 7, new Tuple<int>(8));

            //
            Console.WriteLine(test.Item1);
            Console.WriteLine(test2.Item1 + test2.Item2);
            Console.WriteLine(test3.Item1 + test3.Item2 + test3.Item3 + test3.Item4 + test3.Item5 + test3.Item6 + test3.Item7 + test3.Rest.Item1);

        }

        public static void Output2()
        {
            //2 member ,the second type is the nest type tuple.
            var test4 = new Tuple<int, Tuple<int>>(1, new Tuple<int>(2));
            //10 member datatype. nest the 8 parameter type.
            var test5 = new Tuple<int, int, int, int, int, int, int, Tuple<int, int, int>>(1, 2, 3, 4, 5, 6, 7, new Tuple<int, int, int>(8, 9, 10));

            //
            Console.WriteLine(test4.Item1 + test4.Item2.Item1);
            Console.WriteLine(test5.Item1 + test5.Item2 + test5.Item3 + test5.Item4 + test5.Item5 + test5.Item6 + test5.Item7 + test5.Rest.Item1 + test5.Rest.Item2 + test5.Rest.Item3);
        }
    }
}
