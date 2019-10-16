﻿using System;

namespace Scz.Aop
{
    class Program
    {

        static void Main(string[] args)
        {
            AopTest();

            Console.Read();
        }

        static void AopTest()
        {
            Order order = new Order() { Id = 1, Name = "lee", Count = 10, Price = 100.00, Desc = "订单测试" };
            IOrderProcessor orderprocessor = new OrderProcessorDecorator(new OrderProcessor());
            orderprocessor.Submit(order);
            Console.ReadLine();
        }

    }
}
