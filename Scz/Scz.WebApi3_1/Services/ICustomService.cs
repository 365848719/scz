using Scz.WebApi3_1.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scz.WebApi3_1.Services
{
    public interface ICustomService
    {
        [CustomInterceptor]
        void Call();
    }
}
