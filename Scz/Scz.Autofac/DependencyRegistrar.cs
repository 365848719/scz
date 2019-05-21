using System;
using System.Collections.Generic;
using System.Text;
using Autofac;

namespace Scz.Autofac
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public int Order => 0;

        public void Register(ContainerBuilder builder, ITypeFinder finder)
        {
            // InstancePerLifetimeScope 同一个Lifetime生成的对象是同一个实例
            // SingleInstance 单例模式，每次调用，都会使用同一个实例化的对象；每次都用同一个对象
            // InstancePerDependency 默认模式，每次调用，都会重新实例化对象；每次请求都创建一个新的对象
            //builder.RegisterType<Dog>().As<IAnimal>();//.PreserveExistingDefaults();

            //builder.RegisterType<Tiger>().As<IAnimal>().InstancePerLifetimeScope();
            //builder.RegisterType<Tiger>().As<IAnimal>().SingleInstance();
            builder.RegisterType<Tiger>().As<IAnimal>().InstancePerDependency();

        }
    }
}
