using Scz.ConsoleApp.C7;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.Linq;

namespace Scz.ConsoleApp
{
    class Hospital
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Group { get; set; }
    }

    // 定义委托方法
    delegate decimal CalculateBonus(decimal sales);

    // 定义一个Employee类
    class Employee
    {
        public string name;
        public decimal sales;
        public decimal bonus;
        public CalculateBonus calculation_algorithm;
    }

    public class DynamicClass
    {
        public DynamicClass(int n1, int n2)
        {
            Num1 = n1;
            Num2 = n2;
        }

        public int Num1 { get; set; }
        public int Num2 { get; set; }
        public dynamic DynamicAction { get; set; }
    }

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

            var allHospitals = CreateHospital();

            var b = allHospitals.GroupBy(x => new
            {
                x.Id,
                x.Name
            }).Select(g => new Hospital
            {
                Id = g.Key.Id,
                Name = g.Key.Name,
                Group = string.Join(",", g.Select(x => x.Group).ToArray())
            }).ToList();

            //allHospitals.GroupBy(x => x.Id, y => y.Name).Select(x => new Hospital
            //{
            //    Id = x.Key,
            //    Group = string.Join(x.Select(y => y.Group).ToArray())
            //});

            allHospitals.Select(x => new Hospital
            {
                Id = x.Id,
                Name = x.Name,
                Group = x.Group
            });

            var ab = 0;

            string filePath = @"c:\版本日志.json";
            MyJsonReader.Read(filePath);

            var d = new A<int, string> { My = 5, Data = "1" };
            Console.Write(d.Data + d.My);


            //OracleTest.Test();
            //LinqDemo.Except3();
            //PlinqDemo2.MapReduce();
            //PlinqDemo2.ParallelEnum();
            //PlinqDemo2.WithDegree();
            //PlinqDemo2.Method();

            //TaskDemo.WaitAll();
            //TaskDemo.ContinueWith();
            //TaskDemo.Result();
            //TaskDemo.Cancel();
            //TaskDemo.Start();

            //PlinqDemo.Options();
            //PlinqDemo.Exception();
            //PlinqDemo.Break();
            //PlinqDemo.Foreach();
            //PlinqDemo.For();
            //PlinqDemo.Invoke();

            //PLINQDataSample.Main2();
            //TupleDemo.Output();
            //TupleDemo.Output2();

            //DealDouble();

            //Example();


            Console.ReadLine();

        }

        static void AopTest()
        {
            Order order = new Order() { Id = 1, Name = "lee", Count = 10, Price = 100.00, Desc = "订单测试" };
            IOrderProcessor orderprocessor = new OrderProcessorDecorator(new OrderProcessor());
            orderprocessor.Submit(order);
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

        static void Method()
        {
            // double m = Math.Pow(10, 28);
            // double n = Math.Log(m, 2);

            // Console.WriteLine(string.Format("double 转换为 decimal 前: {0}", m));
            // Console.WriteLine(string.Format("double 转换为 decimal 后: {0}",(decimal)m));
            // Console.WriteLine(string.Format("m = {0},n = {1}",m,n));

            var month = "201601";

            var dt2 = DateTime.Parse(string.Format("{0}01", month),
                new DateTimeFormatInfo { ShortDatePattern = "yyyyMMdd" });

            Console.WriteLine(dt2);

            var dt = DateTime.ParseExact(string.Format("{0}01", month), "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture);

            Console.WriteLine(dt);

            decimal sum = 123456.785M;

            decimal a = decimal.Round(sum, 2);
            Console.WriteLine(a);


            sum = decimal.Round(sum, 2, MidpointRounding.AwayFromZero);
            Console.WriteLine(sum);

            // double maxNumber = 0;
            // int num = 120;
            // double result = 0;

            // for (int i = 0; i < num; i++)
            // {
            //     maxNumber += Math.Pow(2, i);
            // }

            // result = maxNumber;

            // Console.WriteLine(result);
            // Console.Read();

            // string data = string.Empty;

            // StringBuilder builder = new StringBuilder();
            // builder.Append("1,");

            // for (int i = 0; i < 50; i++)
            // {
            //     builder.Append("中");
            // }

            // //data = builder.ToString();

            // try
            // {
            //     var len = data.Length;
            //     var array = data.Split(',');

            //     var aa = array[0];
            //     var b = array[1];
            // }
            // catch(Exception ex)
            // {
            //     throw ex;
            // }


        }

        private static List<Hospital> CreateHospital()
        {
            List<Hospital> allHospital = new List<Hospital>();

            List<string> groups = new List<string> { "机构组1", "机构组2", "机构组3" };

            for (var i = 0; i < 10000; i++)
            {
                for (var j = 0; j < groups.Count; j++)
                {
                    var group = groups[j];
                    allHospital.Add(new Hospital
                    {
                        Id = i.ToString(),
                        Name = string.Format("医院：{0}", i),
                        Group = group
                    });
                }
            }


            return allHospital;
        }


        private static void Closure()
        {
            var c7Test = new C7Test();
            var dateTimes = new List<DateTime> { DateTime.Today, DateTime.Today.AddDays(-1) };

            var dateResult = c7Test.Max_Local_Function(dateTimes);
            Console.WriteLine(dateResult);
        }

        private static void Example()
        {
            DynamicClass d = new DynamicClass(1, 2);
            d.DynamicAction = new Func<int, int, double>((x, y) => x + y);

            Console.WriteLine(d.DynamicAction.Invoke(d.Num1, d.Num2));

            dynamic t = new ExpandoObject();
            t.Name = "ServiceBoy";
            t.Action = new Func<string>(() => t.Name);
            Console.WriteLine(t.Action());

            dynamic myD = new DynamicObjectDemo();
            myD.Name = "Tom";
            Console.WriteLine(myD.Name);

            dynamic myT = new DynamicObjectDemo();
            Console.WriteLine(myT.Say("Hello"));

            dynamic integerValue = 1;
            dynamic stringValue = " a string";
            dynamic result = integerValue + stringValue;
            Console.WriteLine(result.ToString());

            ExampleDemo example = new ExampleDemo();
            Console.WriteLine(example.Add(num: 3, num2: 5));
        }

    }
}
