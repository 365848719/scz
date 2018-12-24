using System;
using System.Collections.Generic;
using System.Text;

namespace Scz.ConsoleApp
{
    public class ExcuterB : IExcuter
    {
        public void Exec(string command)
        {
            System.Console.WriteLine($"员工B 开始做：{command} 的工作 ！");
        }
    }
}
