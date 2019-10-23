using System;
using System.Collections.Generic;
using System.Text;

namespace Scz.ConsoleApp
{
    class StaticClassDemo
    {

    }

    public class User
    {
        static int count;
        public static int Count
        {
            get
            {
                return count;
            }
        }

        public User()
        {
            count++;
        }


        static User()
        {
            count = 0;
        }
    }

}
