﻿using System;

namespace Scz.Aop
{
    public class OrderProcessorDecorator : IOrderProcessor
    {
        public IOrderProcessor OrderProcessor { get; set; }
        public OrderProcessorDecorator(IOrderProcessor orderprocessor)
        {
            OrderProcessor = orderprocessor;
        }

        public void Submit(Order order)
        {
            PreProceed(order);
            OrderProcessor.Submit(order);
            PostProceed(order);
        }

        public void PreProceed(Order order)
        {
            Console.WriteLine("提交订单前，进行订单数据校验....");
            if (order.Price < 0)
            {
                Console.WriteLine("订单总价有误，请重新核对订单。");
            }
        }

        public void PostProceed(Order order)
        {
            Console.WriteLine("提交带单后，进行订单日志记录......");
            Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "提交订单，订单名称：" + order.Name + "，订单价格：" + order.Price);
        }
    }
}