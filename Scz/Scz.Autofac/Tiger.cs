using System;
using System.Collections.Generic;
using System.Text;

namespace Scz.Autofac
{
    public class Tiger:IAnimal
    {
        public string Id
        {
            get => Guid.NewGuid().ToString();
            set => throw new NotImplementedException();
        }

        public void Show(string name)
        {
            Console.WriteLine($"老虎说:{name}");
        }

    }
}
