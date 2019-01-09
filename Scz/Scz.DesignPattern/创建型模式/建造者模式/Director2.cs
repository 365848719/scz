using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scz.DesignPattern
{
   public class Director2
    {
        public void Construct(Builder builder)
        {
            builder.BuildPartCpu();
            builder.BuildPartMainBoard();
        }
    }
}
