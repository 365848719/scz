using EasyNetQ;
using Scz.RabbitMq.Message;
using System;

namespace Scz.RabbitMq
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                RpcTest();
            }

            //Publish();

        }

        private static void Publish()
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

        private static void RpcTest()
        {
            var connStr = "host=127.0.0.1;virtualHost=sczVHost;username=scz;password=1";


            using (var bus = RabbitHutch.CreateBus(connStr))
            {
                var dispose = bus.Respond<TestRequestMessage, TestResponseMessage>((request) =>
                {
                    Console.WriteLine($"请求的信息：{request.Text}");
                    return new TestResponseMessage { Text = request.Text + " all done!" };
                });

                dispose.Dispose();
            }

        }
    }
}
