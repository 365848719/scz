using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scz.DesignPattern
{
    public class AppleBoard : Board
    {
        public override void Print()
        {
            Console.WriteLine(" this is apple's Board ! ");
        }
    }
}