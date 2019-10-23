using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scz.ConsoleApp
{
    public class LinqDemo
    {
        /// <summary>
        /// 无交集
        /// </summary>
        public static void Except()
        {
            var list = Enumerable.Range(100000, 100000);
            var list2 = Enumerable.Range(1, 100000);

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var query = list.Except(list2);
            Console.WriteLine(string.Format("消耗时间：{0}",stopwatch.Elapsed.TotalSeconds));

            foreach (var i in query)
            {
                Console.WriteLine(i);
            }
            Console.ReadKey();
        }

        /// <summary>
        /// 有1个交集
        /// </summary>
        public static void Except2()
        {
            var list = new List<int> {1,200000};
            var list2 = Enumerable.Range(1, 100000);

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var query = list.Except(list2);
            Console.WriteLine(string.Format("消耗时间：{0}", stopwatch.Elapsed.TotalSeconds));

            foreach (var i in query)
            {
                Console.WriteLine(i);
            }
            Console.ReadKey();
        }

        /// <summary>
        /// 有多个交集
        /// </summary>
        public static void Except3()
        {
            var list = Enumerable.Range(1, 200000);
            var list2 = Enumerable.Range(1, 100000);

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var query = list.Except(list2);
            Console.WriteLine(string.Format("消耗时间：{0}", stopwatch.Elapsed.TotalSeconds));

            foreach (var i in query)
            {
                Console.WriteLine(i);
            }
            Console.ReadKey();
        }
    }
}
