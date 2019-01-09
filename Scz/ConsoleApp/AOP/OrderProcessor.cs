using System;

namespace ConsoleApp
{
    public class OrderProcessor : IOrderProcessor
    {
        public void Submit(Order order)
        {
            Console.WriteLine("提交订单");
        }
    }
}