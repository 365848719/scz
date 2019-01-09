using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scz.DesignPattern
{
    public class Singleton
    {
        private static Singleton instance;

        // Lock synchronization object
        private static readonly object _syncLock = new object();

        private Singleton() { }

        public static Singleton Instance()
        {
            // Support multithreaded applications through
            // 'Double checked locking' pattern which (once
            // the instance exists) avoids locking each
            // time the method is invoked

            if (instance == null)
            {
                lock(_syncLock)
                {
                    if(instance ==null)
                    {
                        instance = new Singleton();

                        Console.WriteLine("Word文档打开成功，具有读写权限");
                    }
                }
            }
            else
            {
                Console.WriteLine("Word文档已经被锁定，不可写入");
            }

            return instance;
        }
    }
}