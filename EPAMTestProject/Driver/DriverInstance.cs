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
                _driver = new ChromeDriver();
                _driver.Manage().Window.Size = new System.Drawing.Size(1920, 1080);
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
