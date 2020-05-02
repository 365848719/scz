using EasyNetQ;
using Scz.RabbitMq.Message;
using System;

namespace Scz.RabbitMq.Subcriber
{
    class Program
    {
        public static void Main(string[] args)
        {
            while(true)
            {
                RpcTest();
            }

            //Subscribe();

        }

        private static void Subscribe()
        {
            var connStr = "host=127.0.0.1;virtualHost=sczVHost;username=scz;password=1";

            using (var bus = RabbitHutch.CreateBus(connStr))
            {
                bus.Subscribe<TextMessage>("my_test_subscriptionid", HandleTextMessage);

                Console.WriteLine("Listening for messages. Hit <return> to quit.");
                Console.ReadLine();
            }
        }

        private static void RpcTest()
        {
            var connStr = "host=127.0.0.1;virtualHost=sczVHost;username=scz;password=1";

            var request = new TestRequestMessage { Text = "Hello from the client! " };
            using (var bus = RabbitHutch.CreateBus(connStr))
            {
                var response = bus.Request<TestRequestMessage, TestResponseMessage>(request);
                Console.WriteLine("Got response: '{0}'", response.Text);
            }
        }

        public static void HandleTextMessage(TextMessage textMessage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Got message: {0}", textMessage.Text);
            Console.ResetColor();
        }
    }
}