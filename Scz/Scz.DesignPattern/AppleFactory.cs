using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scz.DesignPattern
{
    public class AppleFactory : AbstractFactory
    {
        public override Board CreateMotherBoard()
        {
            return new AppleBoard();
        }

        public override Screen CreateScreen()
        {
            return new AppleScreen();
        }
    }
}