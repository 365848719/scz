using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scz.WebApi3_1.Services
{
    public class CustomService : ICustomService
    {
        public void Call()
        {
            Console.WriteLine("service calling...");
        }
    }
}
