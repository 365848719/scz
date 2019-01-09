using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scz.DesignPattern
{
   public abstract class Builder
   {
       public abstract void BuildPartCpu();
       public abstract void BuildPartMainBoard();

       public abstract Computer GetComputer();
   }
}
