using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using MediatR;

namespace Scz.CqrsMediatR.Models
{
    public class NewUser:INotification
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

}
