using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scz.DesignPattern
{
    public abstract class Subject
    {
        public Action Action;
        public abstract void FireAway();
    }
}