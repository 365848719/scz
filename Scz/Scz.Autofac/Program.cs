using System;
using System.Reflection;
using Autofac;
using Scz.Bll;
using Scz.IBll;


using Microsoft.Extensions.Configuration;

namespace Scz.Autofac
{
    class Program
    {
        static void Main(string[] args)
        {
            //Method1();
            //Method2();
            //Method3();

            Method4();

        }

        /// <summary>
        /// 最原始的方式直接new(需添加对BLL层的引用)
        /// </summary>
        static void Method1()
        {
            var userBll = new UserBll();
            var result = userBll.GetUserInfo();
            Console.WriteLine(result);
        }

        /// <summary>
        /// 面向接口编程(仍需添加对BLL层的引用)
        /// </summary>
        static void Method2()
        {
            IUserBLL userBll = new UserBll();
            var result = userBll.GetUserInfo();
            Console.WriteLine(result);
        }

        /// <summary>
        /// 接口+反射(只需将BLL层的程序集拷贝进来)
        /// </summary>
        static void Method3()
        {
            var assembly = Assembly.Load("Scz.Bll");
            var type = assembly.GetType("Scz.Bll.UserBll");

            //调用默认的无参构造函数进行对象的创建
            var userBll = Activator.CreateInstance(type);
            var _userBll = (IUserBLL)userBll;

            var result = _userBll.GetUserInfo();
            Console.WriteLine(result);
        }

        /// <summary>
        /// 手写IOC(反射+简单工厂+配置文件)【需将BLL层的程序集拷贝进来】
        /// </summary>
        static void Method4()
        {
            IUserBLL userBLL = UserSampleFactory.CreateInstance();
            var result = userBLL.GetUserInfo();
            Console.WriteLine(result);
        }


        private static void NewMethod()
        {
            var builder = new ContainerBuilder();
            var register = new DependencyRegistrar();
            register.Register(builder, null);

            var container = builder.Build();

            var animalIoc = container.Resolve<IAnimal>();
            Console.WriteLine(animalIoc.Id);

            var animalIoc2 = container.Resolve<IAnimal>();
            Console.WriteLine(animalIoc2.Id);

            Console.WriteLine("开始新的生命周期！");

            ILifetimeScope lifetimeScope = container.BeginLifetimeScope();
            var animalIoc3 = lifetimeScope.Resolve<IAnimal>();
            Console.WriteLine(animalIoc3.Id);

            var animalIoc4 = lifetimeScope.Resolve<IAnimal>();
            Console.WriteLine(animalIoc4.Id);

            Console.ReadKey();
        }
    }

    public class UserSampleFactory
    {
        private static string DllName = System.Configuration.ConfigurationManager.AppSettings["DllName"];
        private static string ClassName;

        static UserSampleFactory()
        {          
            ClassName = System.Configuration.ConfigurationManager.AppSettings["ClassName"];
        }

        public static IUserBLL CreateInstance()
        {
            Assembly ass = Assembly.Load(DllName);
            Type type = ass.GetType(ClassName);
            object obj = Activator.CreateInstance(type);
            return (IUserBLL)obj;
        }
    }

}
