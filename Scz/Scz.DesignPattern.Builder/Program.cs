using System;

namespace Scz.DesignPattern.Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            IBuilder builder = new Benz();
            Director director = new Director();
            director.Constructor(builder);

            Console.Read();
        }
    }
}
