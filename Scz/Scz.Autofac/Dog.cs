using System;
using System.Collections.Generic;
using System.Text;

namespace Scz.Autofac
{
    class Dog : IAnimal
    {
        public string Id
        {
            get => Guid.NewGuid().ToString();
            set => throw new NotImplementedException();
        }

        public void Show(string name)
        {
            Console.WriteLine($"狗狗说:{name}");
        }
    }
}
