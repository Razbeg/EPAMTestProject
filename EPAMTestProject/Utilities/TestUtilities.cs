using EPAMTestProject.Driver;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace EPAMTestProject.Utilities
{
    public class TestUtilities
    {
        public static WebDriverWait Wait => new WebDriverWait(DriverInstance.GetDriver(), TimeSpan.FromSeconds(10)) { PollingInterval = TimeSpan.FromSeconds(1) };
    }
}
