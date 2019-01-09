using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scz.ConsoleApp
{
    public class PlinqDemo2
    {
        public static void MapReduce()
        {
            var list = new List<Student>
                       {
                new Student { Id=1, Name="jack", Age=20},
                new Student { Id=1, Name="mary", Age=25},
                new Student { Id=1, Name="joe", Age=29},
                new Student { Id=1, Name="Aaron", Age=25},
            };

            //这里我们会对age建立一组键值对
            var map = list.AsParallel().ToLookup(i => i.Age, count => 1);

            //化简统计
            var reduce = from IGrouping<int, int> singleMap
                         in map.AsParallel()
                         select new
                         {
                             Age = singleMap.Key,
                             Count = singleMap.Count()
                         };

            //最后遍历
            reduce.ForAll(i => Console.WriteLine("当前Age={0}的人数有:{1}人", i.Age, i.Count));

        }

        public static void ParallelEnum()
        {
            var bag = new ConcurrentBag<int>();

            var list = ParallelEnumerable.Range(0, 10000);

            list.ForAll(bag.Add);

            Console.WriteLine("bag集合中元素个数有:{0}", bag.Count);

            Console.WriteLine("list集合中元素个数总和为:{0}", list.Sum());

            Console.WriteLine("list集合中元素最大值为:{0}", list.Max());

            Console.WriteLine("list集合中元素第一个元素为:{0}", list.FirstOrDefault());
            Console.WriteLine("list集合中元素第后个元素为:{0}", list.LastOrDefault());

            Console.Read();

        }

        public static void WithDegree()
        {
            var dic = LoadData();

            var query2 = dic.Values.AsParallel().WithDegreeOfParallelism(Environment.ProcessorCount - 1)
                .Where(n => n.Age > 20 && n.Age < 25)
                .OrderByDescending(n => n.CreateTime).ToList();

            Console.WriteLine("排序后的时间排序如下：");
            query2.Take(10).ToList().ForEach((i) => Console.WriteLine(i.CreateTime));

            Console.Read();

        }
        public static void Method()
        {
            var dic = LoadData();

            var query1 = dic.Values.AsParallel().Where(n => n.Age > 20 && n.Age < 25).ToList();

            Console.WriteLine("默认的时间排序如下：");
            query1.Take(10).ToList().ForEach((i) => Console.WriteLine(i.CreateTime));

            var query2 = dic.Values.AsParallel().Where(n => n.Age > 20 && n.Age < 25).OrderByDescending(n => n.CreateTime).ToList();

            Console.WriteLine("排序后的时间排序如下：");
            query2.Take(10).ToList().ForEach((i) => Console.WriteLine(i.CreateTime));

            Console.Read();

        }

        private static ConcurrentDictionary<int, Student> LoadData()
        {
            ConcurrentDictionary<int, Student> dic = new ConcurrentDictionary<int, Student>();

            //预加载1500w条记录
            Parallel.For(0, 150000, (i) =>
            {
                var single = new Student()
                {
                    Id = i,
                    Name = "hxc" + i,
                    Age = i % 151,
                    CreateTime = DateTime.Now.AddSeconds(i)
                };
                dic.TryAdd(i, single);
            });

            return dic;
        }
    }



    public class Student
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public DateTime CreateTime { get; set; }
    }

}
