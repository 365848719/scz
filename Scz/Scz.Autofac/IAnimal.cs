using System;
using System.Collections.Generic;
using System.Text;

namespace Scz.Autofac
{
    public interface IAnimal
    {
        void Show(string name);
        string Id { get; set; }
    }
}
