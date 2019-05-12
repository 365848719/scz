using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp
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
            var arg = "tmall";
            Console.WriteLine($"original argument:{arg}");
            Console.Read();

            //AopTest();




            // OracleTest.Test3();



            //OracleTest.Test();

            Console.Read();
        }

        

       


        private static void DealDouble()
        {
            double de = 3.1432;
            Console.WriteLine(string.Format("{0:c}", de));
            Console.WriteLine(string.Format("{0:c1}", de));
            Console.WriteLine(string.Format("{0:c3}", de));

            Console.WriteLine(string.Format("{0:f3}", de));
        }

    }
}

