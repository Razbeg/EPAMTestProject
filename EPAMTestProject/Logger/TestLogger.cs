using System;
using System.Collections.Generic;
using System.Text;

namespace EPAMTestProject.Logger
{
    public class TestLogger
    {
        public static NLog.Logger Instance = NLog.LogManager.GetCurrentClassLogger();

        public static void LoggerShutDown()
        {
            NLog.LogManager.Shutdown();
        }
    }
}
