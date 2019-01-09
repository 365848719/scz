using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class TaskDemo
    {
        public static void WaitAll()
        {
            var stack = new ConcurrentStack<int>();

            //t1先串行
            var t1 = Task.Factory.StartNew(() =>
            {
                stack.Push(1);
                stack.Push(2);
            });

            //t2,t3并行执行
            var t2 = t1.ContinueWith(t =>
            {
                int result;

                stack.TryPop(out result);
            });

            //t2,t3并行执行
            var t3 = t1.ContinueWith(t =>
            {
                int result;

                stack.TryPop(out result);
            });

            //等待t2和t3执行完
            Task.WaitAll(t2, t3);


            //t4串行执行
            var t4 = Task.Factory.StartNew(() =>
            {
                stack.Push(1);
                stack.Push(2);
            });

            //t5,t6并行执行
            var t5 = t4.ContinueWith(t =>
            {
                int result;

                stack.TryPop(out result);
            });

            //t5,t6并行执行
            var t6 = t4.ContinueWith(t =>
            {
                int result;

                //只弹出，不移除
                stack.TryPeek(out result);
            });

            //临界区：等待t5，t6执行完
            Task.WaitAll(t5, t6);

            //t7串行执行
            var t7 = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("当前集合元素个数：" + stack.Count);
            });

            Console.Read();

        }

        public static void ContinueWith()
        {
            //执行task1
            var t1 = Task.Factory.StartNew(() => new List<string> { "1", "2", "4", "6" });

            var t2 = t1.ContinueWith(t=> Console.WriteLine("t1集合中返回的个数：" 
                + string.Join(",", t.Result)));

            Console.Read();

        }

        public static void Result()
        {
            var task1 = Task.Factory.StartNew(() => new List<string>{"1","2","4","6"});
            task1.Wait();

            var task2 = Task.Factory.StartNew(() => Console.WriteLine("t1集合中返回的个数：" + 
                string.Join(",", task1.Result)));

            Console.Read();

        }

        public static void Start()
        {
            var task1 = new Task(() =>
                               {
                                   Thread.Sleep(1000);
                                   Console.WriteLine("\n 我是任务1");
                               });
            var task2 = Task.Factory.StartNew(() =>
                                           {
                                               Thread.Sleep(2000); 
                                               Console.WriteLine("\n 我是任务2"); 
                                              
                                           });

            Console.WriteLine("调用start之前****************************\n");

            //调用start之前的“任务状态”
            Console.WriteLine("task1的状态:{0}", task1.Status);

            Console.WriteLine("task2的状态:{0}", task2.Status);

            task1.Start();

            Console.WriteLine("\n调用start之后****************************");

            //调用start之前的“任务状态”
            Console.WriteLine("\ntask1的状态:{0}", task1.Status);

            Console.WriteLine("task2的状态:{0}", task2.Status);

            //主线程等待任务执行完
            Task.WaitAll(task1, task2);

            Console.WriteLine("\n任务执行完后的状态****************************");

            //调用start之前的“任务状态”
            Console.WriteLine("\ntask1的状态:{0}", task1.Status);

            Console.WriteLine("task2的状态:{0}", task2.Status);

            Console.Read();

        }

        public static void Cancel()
        {
            var cts = new CancellationTokenSource();
            var ct = cts.Token;
            var task1 = new Task(() =>
                                 {
                                     ct.ThrowIfCancellationRequested();
                                     Console.WriteLine("我是任务1");

                                     Thread.Sleep(2000);

                                     ct.ThrowIfCancellationRequested();

                                     Console.WriteLine("我是任务1的第二部分信息");

                                 }, ct);

            var task2 = new Task(() => Console.WriteLine("我是任务2！"));

            try
            {
                task1.Start();
                task2.Start();

                Thread.Sleep(1000);

                cts.Cancel();

                Task.WaitAll(task1, task2);
            }
            catch (AggregateException ex)
            {
                foreach (var e in ex.InnerExceptions)
                {
                    Console.WriteLine("\nhi,我是OperationCanceledException：{0}\n", e.Message);
                }

                //task1是否取消
                Console.WriteLine("task1是不是被取消了？ {0}", task1.IsCanceled);
                Console.WriteLine("task2是不是被取消了？ {0}", task2.IsCanceled);
            }

            Console.Read();

            //①：Run1中的Console.WriteLine("我是任务1的第二部分信息"); 没有被执行。

            //②：Console.WriteLine("task1是不是被取消了？ {0}", task1.IsCanceled); 状态为True。

            //也就告诉我们Run1中途被主线程中断执行，我们coding的代码起到效果了。

        }
    }
}
