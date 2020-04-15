using EasyNetQ;
using Scz.RabbitMq.Message;
using System;

namespace Scz.RabbitMq
{
    class Program
    {
        static void Main(string[] args)
        {
            var connStr = "host=127.0.0.1;virtualHost=sczVHost;username=scz;password=1";

            using (var bus = RabbitHutch.CreateBus(connStr))
            {
                var input = "";
                Console.WriteLine("Please enter a message. 'Quit' to quit.");
                while ((input = Console.ReadLine()) != "Quit")
                {
                    bus.Publish(new TextMessage
                    {
                        Text = input
                    });
                }
            }


        }

        private static void RpcTest(string connStr)
        {
            while (true)
            {
                using (var bus = RabbitHutch.CreateBus(connStr))
                {
                    bus.Respond<TestRequestMessage, TestResponseMessage>(request =>
                        new TestResponseMessage { Text = request.Text + " all done!" });
                }
            }
        }
    }
}
