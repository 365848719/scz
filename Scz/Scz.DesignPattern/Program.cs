using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Scz.DesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            DoPrototype();

            //DoStatePattern();

            //CreatorMode();
            //StructualMode();
            //BehavioralMode();
        }

        /// <summary>
        /// 创建型模式
        /// </summary>
        public static void CreatorMode()
        {
            DoSimpleFactory();
            Console.WriteLine();

            DoMethodFactory();
            Console.WriteLine();

            DoAbstractFactory();
            Console.WriteLine();

            DoSingleton();
            Console.WriteLine();

            DoPrototype();
            Console.WriteLine();

            DoBuilder();
            Console.WriteLine();
        }

        /// <summary>
        /// 结构型模式
        /// </summary>
        public static void StructualMode()
        {
           
            DoBridge();
            Console.WriteLine();

            DoComposite();
            Console.WriteLine();

            DoDecorator();
            Console.WriteLine();


            DoFacade();
            Console.WriteLine();

        }

        /// <summary>
        /// 行为型模式
        /// </summary>
        public static void BehavioralMode()
        {
            DoVisitorPattern();
            Console.Read();

            MediatorPattern();
            Console.Read();

            ChainOfResponsibilityPattern();
            Console.Read();

            DoMementoPattern();
            Console.Read();

            ObserverPattern();
            Console.Read();

            

            DoTemplateMethod();
            Console.Read();

            DoCommand();
            Console.Read();

            //StrategyPattern();
            Console.Read();

            DoStatePattern();
            Console.Read();

            DoIteratorPattern();
            Console.Read();
        }

        /// <summary>
        /// 中介者模式
        /// </summary>
        public static void MediatorPattern()
        {
            AbstractCardPartner a = new PartnerA();
            AbstractCardPartner b = new PartnerB();

            a.Money = 20;
            b.Money = 20;

            AbstractMediator m = new MediatorPater(a, b);
            a.ChangeMoney(5, m);

            Console.WriteLine("a 现在的钱是：{0}", a.Money);// 应该是25
            Console.WriteLine("b 现在的钱是：{0}", b.Money);// 应该是15

        }

        /// <summary>
        /// 责任链模式（重要）
        /// </summary>
        public static void ChainOfResponsibilityPattern()
        {
            var groupLeader = new GroupLeader();
            var manager = new Manager();
            var boss = new Boss();

            //先设置好请假审批的先后顺序
            groupLeader.SetNextHandler(manager);
            manager.SetNextHandler(boss);

            //下面分别请假1、2、5、10天
            groupLeader.HandleRequest(1);
            groupLeader.HandleRequest(2);
            groupLeader.HandleRequest(5);
            groupLeader.HandleRequest(10);

        }

        /// <summary>
        /// 备忘录模式
        /// </summary>
        public static void DoMementoPattern()
        {
            List<ContactPerson> persons = new List<ContactPerson>()
            {
                new ContactPerson() { Name= "Learning Hard", MobileNum = "123445"},
                new ContactPerson() { Name = "Tony", MobileNum = "234565"},
                new ContactPerson() { Name = "Jock", MobileNum = "231455"}
            };

            MobileOwner mobileOwner = new MobileOwner(persons);
            mobileOwner.Show();

            // 创建备忘录并保存备忘录对象
            Caretaker caretaker = new Caretaker();
            caretaker.ContactMementoDic.Add(DateTime.Now.ToString(), mobileOwner.CreateMemento());

            // 更改发起人联系人列表
            Console.WriteLine("----移除最后一个联系人--------");
            mobileOwner.ContactPersons.RemoveAt(2);
            mobileOwner.Show();

            // 创建第二个备份
            Thread.Sleep(1000);
            caretaker.ContactMementoDic.Add(DateTime.Now.ToString(), mobileOwner.CreateMemento());

            // 恢复到原始状态
            Console.WriteLine("-------恢复联系人列表,请从以下列表选择恢复的日期------");
            var keyCollection = caretaker.ContactMementoDic.Keys;
            foreach (string k in keyCollection)
            {
                Console.WriteLine("Key = {0}", k);
            }

            while (true)
            {
                Console.Write("请输入数字,按窗口的关闭键退出:");

                int index = -1;

                try
                {
                    index = Int32.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("输入的格式错误");
                    continue;
                }

                ContactMemento contactMentor = null;
                if (index < keyCollection.Count && caretaker.ContactMementoDic.TryGetValue(keyCollection.ElementAt(index), out contactMentor))
                {
                    mobileOwner.RestoreMemento(contactMentor);
                    mobileOwner.Show();
                }
                else
                {
                    Console.WriteLine("输入的索引大于集合长度！");
                }
            }

        }

        /// <summary>
        /// 观察者模式
        /// </summary>
        public static void ObserverPattern()
        {
            Console.WriteLine("===============观察者模式=================");

            var game2 = new TenXunGame2("TenXun Game","Have a new game published........");
            var tomSubscriber = new Subscriber2("Tom");
            var liliSubscriber = new Subscriber2("lili");

            game2.AddObserver(tomSubscriber.Execute);
            game2.AddObserver(liliSubscriber.Execute);

            game2.Notify();
            Console.WriteLine();


            var cat = new Cat();
            var mouse = new Mouse(cat);
            var master = new Master(cat);
            cat.FireAway();

            cat.Action -= master.Response;
            cat.Action -= mouse.Response;
            cat.FireAway();

            Console.WriteLine();


            TenXunGame game = new TenXunGame("TenXun Game", "Have a new game published ....");
            game.AddObserver(new Subscriber("张三。。。"));
            game.AddObserver(new Subscriber("李四。。。"));

            game.Update();


        }

        /// <summary>
        /// 访问者模式
        /// </summary>
        public static void DoVisitorPattern()
        {
            ObjectStructure s = new ObjectStructure();
            foreach (var item in s.Elements)
            {
                item.Accept(new ConcreteVisitor());
            }
        }

        /// <summary>
        /// 迭代器模式
        /// </summary>
        public static void DoIteratorPattern()
        {
            Iterator iterator;
            IListCollection list = new ConcreteList();
            iterator = list.GetIterator();

            while (iterator.MoveNext())
            {
                Console.WriteLine(iterator.GetCurrent());
                iterator.Next();
            }
        }

        /// <summary>
        /// 状态模式
        /// </summary>
        public static void DoStatePattern()
        {
            // 开一个新的账户
            var account = new Account("Learning Hard");

            // 进行交易
            // 存钱
            account.Deposit(1000.0);
            account.Deposit(200.0);
            account.Deposit(600.0);

            // 付利息
            account.PayInterest();

            // 取钱
            account.Withdraw(2000.00);
            account.Withdraw(500.00);

            // 等待用户输入
            Console.ReadKey();

        }

        /// <summary>
        /// 模板方法模式
        /// </summary>
        public static void DoTemplateMethod()
        {
            var spinach = new Spinach();
            spinach.Cook();
            Console.WriteLine("==================");

            var chineseVegatable = new ChineseCabagge();
            chineseVegatable.Cook();
        }

        /// <summary>
        /// 命令模式
        /// </summary>
        public static void DoCommand()
        {
            Console.WriteLine("命令模式：把命令发出的责任和命令执行的责任分开。。。。。");

            var r = new Receiver();
            var cmd = new ConcreteCommand(r);
            var invoker = new Invoker(cmd);

            invoker.ExcuteCommand();
        }

        

        /// <summary>
        /// 组合模式
        /// </summary>
        public static void DoComposite()
        {
            ComplexGraphics graphics = new ComplexGraphics("一个复杂图形和两条线段组成的复杂图形");
            graphics.Add(new Line("线段A"));

            ComplexGraphics complexComposite = new ComplexGraphics("一个圆和一个线段");
            complexComposite.Add(new Circle("一个圆"));
            complexComposite.Add(new Line("线段B"));

            graphics.Add(complexComposite);

            Line l = new Line("线段C");
            graphics.Add(l);

            // 显示复杂图形的画法
            Console.WriteLine("复杂图形的绘制如下：");
            Console.WriteLine("---------------------");

            graphics.Draw();

            Console.WriteLine("复杂图形绘制完成");
            Console.WriteLine("---------------------");
            Console.WriteLine();


            // 移除一个组件再显示复杂图形的画法
            graphics.Remove(l);
            Console.WriteLine("移除线段C后，复杂图形的绘制如下：");
            Console.WriteLine("---------------------");
            graphics.Draw();
            Console.WriteLine("复杂图形绘制完成");
            Console.WriteLine("---------------------");
            Console.Read();
        }

        /// <summary>
        /// 简单工厂方法
        /// </summary>
        public static void DoSimpleFactory()
        {
            SenderFactory factory = new SenderFactory();
            ISender sender = factory.Product("sms");
            sender.Send();

            SenderFactory2 factory2 = new SenderFactory2();
            ISender sender2 = factory2.ProduceSms();
            sender2.Send();

            ISender sender3 = SenderFactory3.ProduceSms();
            sender3.Send();
        }

        /// <summary>
        /// 工厂方法模式
        /// </summary>
        public static void DoMethodFactory()
        {
            IMethodFactory factory = new MailFactory();
            ISender sender = factory.Produce();
            sender.Send();

            IMethodFactory f2Factory = new SmsFactory();
            ISender sender2 = f2Factory.Produce();
            sender2.Send();

        }

        /// <summary>
        /// 原型模式
        /// </summary>
        public static void DoPrototype()
        {
            ColorPicker picker = new ColorPicker(200, 1, 90);
            picker.Name = "拾色器";

            IColorDemo color = new RedColor();
            color.Red = 255;
            color.Picker = picker;
            color.Name = "红色";

            IColorDemo color1 = color.Clone();
            color1.Red = 234;
            color1.Name = "红色2";

            IColorDemo color2 = color.DeepClone() as IColorDemo;
       
            Console.WriteLine(color.Blue == color1.Blue);
            Console.WriteLine(color.Blue == color2.Blue);

            Console.WriteLine("Picker 是否：{0}", color.Picker == color2.Picker);

            Console.WriteLine("Deep Copy 的对象，是否相等：{0}", color.Picker == color2.Picker);

            Console.WriteLine("两个对象是否相等：{0}", color.Equals(color2));
            Console.ReadKey();
        }

       

         

        /// <summary>
        /// 外观模式
        /// </summary>
        public static void DoFacade()
        {
            Student s = new Student();
            s.SelectCourse();
        }

        /// <summary>
        /// 建造者模式
        /// </summary>
        public static void DoBuilder()
        {
            IBuilder builder = new BMW();
            Director director = new Director();
            director.Constructor(builder);
            Console.WriteLine();

            Director2 director2 = new Director2();
            Builder builder2 = new ConcreteBuilder1();
            director2.Construct(builder2);

            var computer = builder2.GetComputer();
            computer.Show();
        }

        /// <summary>
        /// 结构型：桥接模式
        /// </summary>
        public static void DoBridge()
        {
            MyDriverManager manager = new MyDriverManager();
            IDriver driver = new SqlServerDriver();
            manager.SetDriver(driver);
            manager.ConnectDatabase();
        }

        /// <summary>
        /// 装饰模式
        /// </summary>
        public static void DoDecorator()
        {
            Phone phone = new ApplePhone();
            var phoneWithSticker = new Sticker(phone);
            phoneWithSticker.Print();
            Console.WriteLine("----------------------\n");

            var phoneWithAccessories = new Accessories(phone);
            phoneWithAccessories.Print();
            Console.WriteLine("----------------------\n");

            var sticker = new Sticker(phone);
            var withStickerAndAccessories = new Accessories(sticker);
            withStickerAndAccessories.Print();
        }

        

        /// <summary>
        /// 抽象工厂模式
        /// </summary>
        public static void DoAbstractFactory()
        {
            AppleFactory appleFactory = new AppleFactory();
            Screen appleScreen = appleFactory.CreateScreen();
            appleScreen.Print();

            Board appleBoard = appleFactory.CreateMotherBoard();
            appleBoard.Print();
        }

        /// <summary>
        /// 单件模式
        /// </summary>
        public static void DoSingleton()
        {
            Singleton s1 = Scz.DesignPattern.Singleton.Instance();
            Singleton s2 = Scz.DesignPattern.Singleton.Instance();

            if (s1 == s2)
            {
                Console.WriteLine("对象为相同实例");
            }

            Console.ReadKey();
        }
    }
}
