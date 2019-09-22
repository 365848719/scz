using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scz.MyConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Test();
        }

        static void Test3()
        {
            Derived b = new Derived(1, 2);
            Console.ReadLine();

            /*
                1、调用 Derived b = new Derived(1, 2);
                2、初始化Derived的静态方法：
                即：调用public int a = InitA();这时候输出：Derived.InitA()
                3、再调用public int b = InitB();输出：Derived.InitB()
                初始化构造函数，因为传过去的是两个参数，所以调用public Derived(int a, int b): this(a)
                因为该构造函数有this关键字，所以这时候调用public Derived(int a): base(a)
                因为这个构造函数有base关键子，所以调用其父类方法
                这时候初始化其父类，先初始化其静态变量再初始化非静态变量
                即：调用public int x = InitX();，这时候输出：Base.InitX()
                非静态变量出事完成，调用构造方法public Base(int x)，输出：Base.Base(int)
                接着进入public Derived(int a): base(a)的方法体，输出：Derived.Derived(int)
                再接着进入public Derived(int a, int b): this(a)的方法体，输出：Derived.Derived(int,int)
             */
        }

        static void Test2()
        {
            A a = new A();
            Console.ReadLine();

            /*
                A.InitA()
                A.InitB()
                A.InitY()
                A.InitX()
                A.A()


            可以看出程序是先初始化类中的静态字段，再初始化非静态字段。

            且初始化的顺序与其排列的顺序呈现正相关。而构造函数是最后初始化的！
             */
        }

        private static void Test()
        {
            /*
            1、首先调用构造函数A()
            2、然后呢，因为A()使用了this关键字，所以在还没有进入函数体，就调用了this("hello") 也就是A(string info)
            3、这时候A(string info)构造函数被调用，但是由于该构造函数使用了base关键字，所以在没有进入函数体就去调用它爸爸构造函数Base()咯
            4、然后调用完Base()就依次的输出结果咯，整个过程其实就是一个压栈然后取栈顶元素的过程
            */

            Demo a = new Demo();
            Console.ReadLine();

            /*
                4、爸爸的构造函数被调用啦~
                3、我是被其他构造函数调用的，它发过来字符串hello
                2、我是可以调用基类和我的其他构造函数的类
             */
        }
    }

    public class Base
    {
        public Base()
        {
            Console.WriteLine("爸爸的构造函数被调用啦~");
        }
    }

    public class Demo : Base
    {
        public Demo() : this("hello")
        {
            Console.WriteLine("我是可以调用基类和我的其他构造函数的类");
        }

        public Demo(string info) : base()
        {
            Console.WriteLine("我是被其他构造函数调用的，它发过来字符串" + info);
        }
    }

    public class A
    {
        public A()
        {
            Console.WriteLine("A.A()");
        }
        private static int InitX()
        {
            Console.WriteLine("A.InitX()");
            return 1;
        }
        private static int InitY()
        {
            Console.WriteLine("A.InitY()");
            return 2;
        }
        private static int InitA()
        {
            Console.WriteLine("A.InitA()");
            return 3;
        }
        private static int InitB()
        {
            Console.WriteLine("A.InitB()");
            return 4;
        }

        private int y = InitY();
        private int x = InitX();
        private static int a = InitA();
        private static int b = InitB();
    }

    class Base2
    {
        public Base2(int x)
        {
            Console.WriteLine("Base.Base(int)");//4
            this.x = x;
        }
        private static int InitX()
        {
            Console.WriteLine("Base.InitX()"); //3
            return 1;
        }
        public int x = InitX();
    }

    class Derived : Base2
    {
        public Derived(int a)
            : base(a)
        {
            Console.WriteLine("Derived.Derived(int)"); //5
            this.a = a;
        }

        public Derived(int a, int b)
            : this(a)
        {
            Console.WriteLine("Derived.Derived(int,int)"); //6        
            this.b = b;
        }

        private static int InitA()
        {
            Console.WriteLine("Derived.InitA()");//1
            return 3;
        }

        private static int InitB()
        {
            Console.WriteLine("Derived.InitB()");//2
            return 4;
        }

        public int a = InitA();
        public int b = InitB();

    }

}
