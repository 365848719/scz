using System;
using System.Collections.Generic;
using System.Text;

namespace Scz.ConsoleApp
{
    public class ExcuterA : IExcuter
    {
        public void Exec(string command)
        {
            System.Console.WriteLine($"员工A 开始做：{command} 的工作 ！");
        }
    }
}
