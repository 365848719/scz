using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scz.DesignPattern
{
    public interface IVisitor
    {
        void Visit(Element e);
    }
}