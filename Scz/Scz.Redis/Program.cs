using System;

using CSRedis;

namespace Scz.Redis
{
    class Program
    {
        static void Main(string[] args)
        {          
            //prefix 代表，key 前面添加的前缀(可以为空)
            var csredis = new CSRedisClient("127.0.0.1:6379,password=123456,defaultDatabase=0,poolsize=50,ssl=false,writeBuffer=10240,prefix=");

            csredis.Set("test1", DateTime.Now, 600);
            var test1 = csredis.Get("test1");

            StringDemo(csredis);

            ListDemo(csredis);

            SetDemo(csredis);

            HSetDemo(csredis);

            HashmapDemo(csredis);

        }

        public static void StringDemo(CSRedisClient csredis)
        {
            // 添加字符串键-值对
            csredis.Set("hello", "1");
            csredis.Set("world", "2");
            csredis.Set("hello", "3");

            // 根据键获取对应的值
            csredis.Get("hello");

            // 移除元素
            csredis.Del("world");


            /*    数值操作    */
            csredis.Set("num-key", "24");

            // value += 5
            csredis.IncrBy("num-key", 5);
            // output -> 29

            // value -= 10
            csredis.IncrBy("num-key", -10);
            // output -> 19



            /*    字节串操作    */
            csredis.Set("string-key", "hello ");

            // 在指定key的value末尾追加字符串
            csredis.Append("string-key", "world");
            // output -> "hello world"

            // 获取从指定范围所有字符构成的子串（start:3,end:7）
            csredis.GetRange("string-key", 3, 7);
            // output ->  "lo wo"

            // 用新字符串从指定位置覆写原value（index:4）
            csredis.SetRange("string-key", 4, "aa");
            // output -> "hellaaword"

        }

        public static void ListDemo(CSRedisClient csredis)
        {
            // 从右端推入元素
            csredis.RPush("my-list", "item1", "item2", "item3", "item4");
            // 从右端弹出元素
            csredis.RPop("my-list");
            // 从左端推入元素
            csredis.LPush("my-list", "LeftPushItem");
            // 从左端弹出元素
            csredis.LPop("my-list");

            // 遍历链表元素（start:0,end:-1即可返回所有元素）
            foreach (var item in csredis.LRange("my-list", 0, -1))
            {
                Console.WriteLine(item);
            }
            // 按索引值获取元素（当索引值大于链表长度，返回空值，不会报错）
            Console.WriteLine($"{csredis.LIndex("my-list", 1)}");

            // 修剪指定范围内的元素（start:4,end:10）
            csredis.LTrim("my-list", 4, 10);

            // 将my-list最后一个元素弹出并压入another-list的头部
            csredis.RPopLPush("my-list", "another-list");
        }

        public static void SetDemo(CSRedisClient csredis)
        {
            // 实际上只插入了两个元素("item1","item2")
            csredis.SAdd("my-set", "item1", "item1", "item2");

            // 集合的遍历
            foreach (var member2 in csredis.SMembers("my-set"))
            {
                Console.WriteLine($"集合成员：{member2.ToString()}");
            }

            // 判断元素是否存在
            string member = "item1";
            Console.WriteLine($"{member}是否存在:{csredis.SIsMember("my-set", member)}");
            // output -> True

            // 移除元素
            csredis.SRem("my-set", member);
            Console.WriteLine($"{member}是否存在:{csredis.SIsMember("my-set", member)}");
            // output ->  False

            // 随机移除一个元素
            csredis.SPop("my-set");


            csredis.SAdd("set-a", "item1", "item2", "item3", "item4", "item5");
            csredis.SAdd("set-b", "item2", "item5", "item6", "item7");

            // 差集
            csredis.SDiff("set-a", "set-b");
            // output -> "item1", "item3","item4"

            // 交集
            csredis.SInter("set-a", "set-b");
            // output -> "item2","item5"

            // 并集
            csredis.SUnion("set-a", "set-b");
            // output -> "item1","item2","item3","item4","item5","item6","item7"

        }

        public static void HSetDemo(CSRedisClient csredis)
        {
            // 向有序集合添加元素
            csredis.ZAdd("Quiz", (79, "Math"));
            csredis.ZAdd("Quiz", (98, "English"));
            csredis.ZAdd("Quiz", (87, "Algorithm"));
            csredis.ZAdd("Quiz", (84, "Database"));
            csredis.ZAdd("Quiz", (59, "Operation System"));

            //返回集合中的元素数量
            csredis.ZCard("Quiz");

            // 获取集合中指定范围(90~100)的元素集合
            csredis.ZRangeByScore("Quiz", 90, 100);

            // 获取集合所有元素并升序排序
            csredis.ZRangeWithScores("Quiz", 0, -1);

            // 移除集合中的元素
            csredis.ZRem("Quiz", "Math");

        }


        public static void HashmapDemo(CSRedisClient csredis)
        {
            // 向散列添加元素
            csredis.HSet("ArticleID:10001", "Title", "了解简单的Redis数据结构");
            csredis.HSet("ArticleID:10001", "Author", "xscape");
            csredis.HSet("ArticleID:10001", "PublishTime", "2019-01-01");

            // 根据Key获取散列中的元素
            csredis.HGet("ArticleID:10001", "Title");

            // 获取散列中的所有元素
            foreach (var item in csredis.HGetAll("ArticleID:10001"))
            {
                Console.WriteLine(item.Value);
            }

            var keys = new string[] { "Title", "Author", "publishTime" };
            csredis.HMGet("ID:10001", keys);


        }
    }
}
