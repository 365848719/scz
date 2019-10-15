using System;

namespace Scz.Aop
{
    class Program
    {
        static CoreBusiness cb = new CoreBusiness();

        static void Main(string[] args)
        {
            cb.Work_1();

            Console.Read();
        }
    }
}
