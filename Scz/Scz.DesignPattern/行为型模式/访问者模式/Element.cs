﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scz.DesignPattern
{
    public abstract class Element
    {
       public abstract void Print();
       public abstract void Accept(IVisitor visitor);
    }
}