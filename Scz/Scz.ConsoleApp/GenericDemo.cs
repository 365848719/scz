using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scz.ConsoleApp
{
    public class GenericDemo<T>
    {
        public T My { get; set; }
    }

    public class A<T, TU> : GenericDemo<T>
    {
        public TU Data { get; set; }
    }
}