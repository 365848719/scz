using System;

using Autofac;

namespace Scz.Autofac
{
    class Program
    {
        static void Main(string[] args)
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
}
