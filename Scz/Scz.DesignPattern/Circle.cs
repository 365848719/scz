﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scz.DesignPattern
{
    public class Circle : Graphics
    {
        public Circle(string name) : base(name)
        {

        }

        

        public override void Draw()
        {
            Console.WriteLine(string.Format("画：{0}", Name));
        }

       
    }
}