﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scz.DesignPattern
{
    public interface IBuilder
    {
        void CreateLogo();
        void CreateBody();
        void CreateWheel();
        void CreateChair();
    }
}