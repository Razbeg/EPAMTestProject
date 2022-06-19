using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace EPAMTestProject.Pages
{
    public class HabrLoginPage
    {
        private const string BaseUrl = "https://habr.com/ru/all/";

        private readonly By _userIcon = By.XPath("//*[@data-test-id='menu-toggle-guest']");
        private readonly By _loginButton = By.XPath("//a[@class='tm-user-menu__auth-button']");
        private readonly By _emailInputText = By.Id("email_field");
        private readonly By _passwordInputText = By.Id("password_field");
        private readonly By _submitButton = By.Name("go");

        private IWebDriver _driver;

        public HabrLoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement CheckLogin => _driver.FindElement(By.XPath("//div[@data-test-id='menu-toggle-user']"));
        public IWebElement CheckLoginInvalid => _driver.FindElement(By.XPath("//div[@class='s-error']"));

        public void OpenPage()
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            _driver.Navigate().GoToUrl(BaseUrl);
        }

        public void Login(string email, string password)
        {
            _driver.FindElement(_userIcon).Click();
            _driver.FindElement(_loginButton).Click();

            var inputEmail = _driver.FindElement(_emailInputText);
            inputEmail.SendKeys(email);

            var passwordInput = _driver.FindElement(_passwordInputText);
            passwordInput.SendKeys(password);

            _driver.FindElement(_submitButton).Click();
        }
    }
}
