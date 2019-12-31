using log4net;
using log4net.Config;
using log4net.Repository;
using System;
using System.IO;

namespace Scz.Log
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            OutputToFile();

            OutputToConsole();

            Console.WriteLine("Hello World!");
        }

        /// <summary>
        /// 输出到控制台
        /// </summary>
        private static void OutputToConsole()
        {
            ILoggerRepository repository = LogManager.CreateRepository("OutputToConsole");
            BasicConfigurator.Configure(repository);
            ILog log = LogManager.GetLogger(repository.Name, "NETCorelog4net");

            log.Info("NETCorelog4net log");
            log.Error("error");
            log.Warn("warn");
        }

        /// <summary>
        /// 输出日志到文件
        /// </summary>
        private static void OutputToFile()
        {
            ILoggerRepository repository = LogManager.CreateRepository("OutputToFile");
            XmlConfigurator.Configure(repository, new FileInfo("config.xml"));
            ILog log = LogManager.GetLogger(repository.Name, "NETCorelog4net");

            log.Info("NETCorelog4net log");
            log.Error("error");
            log.Warn("warn");
        }
    }
}