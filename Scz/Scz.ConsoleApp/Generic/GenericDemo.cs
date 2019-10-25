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

    delegate T PrintT<T>(T t);     //声明泛型委托，返回类型和参数列表类型都是T

    public class Myclass<T>	       //声明泛型类
    {
        public T Method(T t)       //方法的参数和返回类型与委托匹配
        {
            return t;
        }
    }



}