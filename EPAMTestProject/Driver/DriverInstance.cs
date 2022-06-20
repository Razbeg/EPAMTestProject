using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace EPAMTestProject.Driver
{
    public class DriverInstance
    {
        private static IWebDriver _driver;

        private DriverInstance()
        {

        }

        public static IWebDriver GetDriver()
        {
            if (_driver == null)
            {
                var options = new ChromeOptions();
                options.AddArgument("--disable-dev-shm-usage");

                _driver = new ChromeDriver(options);
                _driver.Manage().Window.Maximize();
            }

            return _driver;
        }

        public static void CloseBrowser()
        {
            _driver.Quit();
            _driver = null;
        }
    }
}
