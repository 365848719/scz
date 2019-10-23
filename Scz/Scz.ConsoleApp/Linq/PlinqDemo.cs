using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Scz.ConsoleApp
{
    public class PlinqDemo
    {
        public static void Options()
        {
            var bag = new ConcurrentBag<int>();

            ParallelOptions options = new ParallelOptions();

            //指定使用的硬件线程数为1
            options.MaxDegreeOfParallelism = 2;

            var watch = Stopwatch.StartNew();
            watch.Start();

            Parallel.For(0, 300000, options, bag.Add);
            watch.Stop();

            Console.WriteLine("总共耗时:{0}\n", watch.ElapsedMilliseconds);

            Console.WriteLine("并行计算：集合有:{0}", bag.Count);

            //1:25;2:20
            //默认的情况下，底层机制会尽可能多的使用硬件线程，然而我们使用手动指定的好处是
            //我们可以在2，4，8个硬件线程的情况下来进行测量加速比。
        }
        public static void Exception()
        {
            try
            {
                Parallel.Invoke(
                    () =>{
                        Thread.Sleep(3000);
                        throw new Exception("我是任务1抛出的异常");
                    }, 
                    () =>{
                       Thread.Sleep(5000);
                       throw new Exception("我是任务2抛出的异常");
                   });
            }
            catch (AggregateException ex)
            {
                foreach (var single in ex.InnerExceptions)
                {
                    Console.WriteLine(single.Message);
                }
            }

            Console.Read();
            //首先任务是并行计算的，处理过程中可能会产生n多的异常，那么如何来获取到这些异常呢？
            //普通的Exception并不能获取到异常，然而为并行诞生的AggregateExcepation就可以获取到一组异常
        }

        public static void Break()
        {
            var watch = Stopwatch.StartNew();

            watch.Start();

            var bag = new ConcurrentBag<int>();

            Parallel.For(0, 20000000, (i, state) =>
            {
                if (bag.Count == 1000)
                {
                    state.Break();
                    return;
                }
                bag.Add(i);
            });

            Console.WriteLine("当前集合有{0}个元素。", bag.Count);
            //ParallelLoopState，该实例提供了Break和Stop方法来帮我们实现。
            //Break: 当然这个是通知并行计算尽快的退出循环，比如并行计算正在迭代100，那么break后程序还会迭代所有小于100的。
            //Stop：这个就不一样了，比如正在迭代100突然遇到stop，那它啥也不管了，直接退出。

        }

        public static void Foreach()
        {
            for (int j = 1; j < 2; j++)
            {
                Console.WriteLine("\n第{0}次比较", j);

                ConcurrentBag<int> bag = new ConcurrentBag<int>();

                var watch = Stopwatch.StartNew();

                watch.Start();

                for (int i = 0; i < 3000000; i++)
                {
                    bag.Add(i);
                }

                Console.WriteLine("串行计算：集合有:{0},总共耗时：{1}", bag.Count, watch.ElapsedMilliseconds);

                GC.Collect();

                bag = new ConcurrentBag<int>();

                watch = Stopwatch.StartNew();

                watch.Start();

                Parallel.ForEach(Partitioner.Create(0, 3000000), i =>
                {
                    for (int m = i.Item1; m < i.Item2; m++)
                    {
                        bag.Add(m);
                    }
                });

                Console.WriteLine("并行计算：集合有:{0},总共耗时：{1}", bag.Count, watch.ElapsedMilliseconds);
                foreach (var i in bag)
                {
                    Console.WriteLine(i);
                }

                GC.Collect();

            }

        }
        public static void For()
        {
            for (int j = 1; j < 4; j++)
            {
                Console.WriteLine("\n第{0}次比较", j);

                ConcurrentBag<int> bag = new ConcurrentBag<int>();

                var watch = Stopwatch.StartNew();

                watch.Start();

                for (int i = 0; i < 20000000; i++)
                {
                    bag.Add(i);
                }

                Console.WriteLine("串行计算：集合有:{0},总共耗时：{1}", bag.Count, watch.ElapsedMilliseconds);

                GC.Collect();

                bag = new ConcurrentBag<int>();

                watch = Stopwatch.StartNew();

                watch.Start();

                Parallel.For(0, 20000000, i => bag.Add(i));

                Console.WriteLine("并行计算：集合有:{0},总共耗时：{1}", bag.Count, watch.ElapsedMilliseconds);

                GC.Collect();


            }

        }
        public static void Invoke()
        {
            var watch = Stopwatch.StartNew();
            watch.Start();

            Run1();

            Run2();

            Console.WriteLine("我是串行开发，总共耗时:{0}\n", watch.ElapsedMilliseconds);

            watch.Restart();
            Parallel.Invoke(Run1, Run2);
            watch.Stop();
            Console.WriteLine("我是并行开发，总共耗时:{0}", watch.ElapsedMilliseconds);

            Console.Read();

            //在这个例子中可以获取二点信息：
            //第一：一个任务是可以分解成多个任务，采用分而治之的思想。
            //第二：尽可能的避免子任务之间的依赖性，因为子任务是并行执行，所以就没有谁一定在前，谁一定在后的规定了。
        }

        static void Run1()
        {
            Console.WriteLine("我是任务一,我跑了3s");
            Thread.Sleep(3000);
        }

        static void Run2()
        {
            Console.WriteLine("我是任务二，我跑了5s");
            Thread.Sleep(5000);
        }

        public static void Method()
        {
            var source = Enumerable.Range(1, 10000);

            // Opt-in to PLINQ with AsParallel
            var evenNums = from num in source.AsParallel()
                           where Compute(num) > 0
                           select num;

            evenNums.ForAll(Console.WriteLine);
        }

        public static void AsOrdered()
        {
            var source = Enumerable.Range(1, 10000);

            var evenNums = source.AsParallel().AsOrdered().Where(num => num % 2 == 0);
            foreach (var evenNum in evenNums)
            {
                Console.WriteLine(evenNum);
            }
        }

        private static int Compute(int num)
        {
            return num % 5;
        }
    }

}
