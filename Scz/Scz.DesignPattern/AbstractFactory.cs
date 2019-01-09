﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scz.DesignPattern
{
    public abstract class AbstractFactory
    {
        public abstract Screen CreateScreen();
 
        public abstract Board CreateMotherBoard();
    }
}