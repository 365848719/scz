﻿using Scz.ConsoleApp.C7;
using Scz.ConsoleApp.ClassDemo;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.Linq;

namespace Scz.ConsoleApp
{
    // 定义委托方法
    delegate decimal CalculateBonus(decimal sales);

    public class DynamicClass
    {
        public DynamicClass(int n1, int n2)
        {
            Num1 = n1;
            Num2 = n2;
        }

        public dynamic DynamicAction { get; set; }
        public int Num1 { get; set; }
        public int Num2 { get; set; }
    }

    // 定义一个Employee类
    class Employee
    {
        public decimal bonus;
        public CalculateBonus calculation_algorithm;
        public string name;
        public decimal sales;
    }

    class Hospital
    {
        public string Group { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
    }
    class Program
    {
        static void Cal2(int n)
        {
            int[] array = new int[n];
            for (int i = 0; i < n; i++)
            {
                int r;
                do
                {
                    r = new Random().Next(1000);                   
                }
                while (r % 3 == 0);

                array[i] = r;
            }

            var sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum += array[i] % 9 == 0 ? array[i] : 0;
            }

            Console.WriteLine(" 9 的倍数：" + sum);
        }

        static void Cal(int maxNumber)
        {
            var dic = new Dictionary<int, int>();

            for (int i = 1; i <= maxNumber; i++)
            {
                var leftSum = LeftCal(i);

                for (int j = i+1; j <= maxNumber; j++)
                {
                    var rightSum = RightCal(i+2, j);

                    if (leftSum == rightSum)
                    {
                        dic.Add(i+1, j);
                        break;
                    }                   
                }             
            }

            foreach (var item in dic.Keys)
            {
                Console.WriteLine(string.Format("住 {0} 号，最大门牌 {1} ",item,dic[item]));
            }


            int LeftCal(int max)
            {
                var sum = 0;
                for (int i = 1; i <= max; i++)
                {
                    sum += i;
                }

                return sum;

            }

            int RightCal(int left ,int right)
            {
                var sum = 0;
                for (int i = left; i <= right; i++)
                {
                    sum += i;    
                }

                return sum;

            }
            
        }

        private static void Closure()
        {
            C7Test();
        }

        static void C7Test() {
            var c7Test = new C7Test();
            var dateTimes = new List<DateTime> { DateTime.Today, DateTime.Today.AddDays(-1) };

            var dateResult = c7Test.Max_Local_Function(dateTimes);
            Console.WriteLine(dateResult);

        }

        static void ClassDemoTest() {
            Console.WriteLine("---------------一般初始化顺序---------------");
            var child1 = new Child1();
            Console.WriteLine("\n---------------子类静态字段初始化需要使用父类静态字段时初始化顺序---------------");
            var child2 = new Child2();
            Console.WriteLine("\n---------------子类静态构造函数中使用父类静态字段时初始化顺序---------------");
            var child3 = new Child3();

            Console.ReadKey();

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

        private static void GenericExample()
        {
            var d = new A<int, string> { My = 5, Data = "1" };
            Console.Write(d.Data + d.My);
        }

        static void Main(string[] args)
        {
            Cal(100);

            //ClassDemoTest();

            //StaticClassMethod();

            //string a = "2019年01月09日";
            //IFormatProvider culture = new CultureInfo("zh-CN", true);
            //DateTime dt = DateTime.ParseExact(a, "yyyy年MM月dd日", culture);
            //Console.WriteLine(dt);

            //Console.WriteLine(3 * 10 / 12);

            //Console.WriteLine("Hello World!");

            //var allHospitals = CreateHospital();

            //var b = allHospitals.GroupBy(x => new
            //{
            //    x.Id,
            //    x.Name
            //}).Select(g => new Hospital
            //{
            //    Id = g.Key.Id,
            //    Name = g.Key.Name,
            //    Group = string.Join(",", g.Select(x => x.Group).ToArray())
            //}).ToList();

            //allHospitals.GroupBy(x => x.Id, y => y.Name).Select(x => new Hospital
            //{
            //    Id = x.Key,
            //    Group = string.Join(x.Select(y => y.Group).ToArray())
            //});

            //allHospitals.Select(x => new Hospital
            //{
            //    Id = x.Id,
            //    Name = x.Name,
            //    Group = x.Group
            //});

            //GenericExample();


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


            Console.Read();

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

        static void StaticClassMethod()
        {
            Console.WriteLine(User.Count);// 0

            var u = new User();
            Console.WriteLine(User.Count); // 1

            var u2 = new User();
            Console.WriteLine(User.Count);// 2
        }
    }
}
