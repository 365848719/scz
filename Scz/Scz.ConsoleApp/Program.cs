using System;
using System.Globalization;

namespace Scz.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string a = "2019年01月09日";
            IFormatProvider culture = new CultureInfo("zh-CN", true);
            DateTime dt = DateTime.ParseExact(a, "yyyy年MM月dd日",culture);
            Console.WriteLine(dt);

            TestExcute();

            Console.WriteLine( 3 * 10 / 12 );

            Console.WriteLine("Hello World!");
            Console.ReadLine();

        }

        public static void TestExcute()
        {
            var leader = new Leader();

            //看上去好像是我们的项目经理在干活
            //但实际干活的人是普通员工
            //这就是典型，干活是我的，功劳是你的

            leader.Exec("加密");
            leader.Exec("登录");
        }

    }
}
