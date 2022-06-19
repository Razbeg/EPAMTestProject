using EPAMTestProject.Driver;
using EPAMTestProject.Logger;
using EPAMTestProject.Pages;
using EPAMTestProject.Properties;
using EPAMTestProject.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace EPAMTestProject.Tests
{
    [TestFixture]
    public class WebDriverTest
    {
        private IWebDriver _driver;
        private UserData _userData;

        [OneTimeSetUp]
        public void Awake()
        {
            _userData = new UserData(); 
        }
        
        [SetUp]
        public void Init()
        {
            _driver = DriverInstance.GetDriver();

            _userData.InitializeData();
        }

        [TearDown]
        public void CleanUp()
        {
            DriverInstance.CloseBrowser();
            TestLogger.LoggerShutDown();
        }

        [Test]
        public void LoginHabrValidTest()
        {
            HabrLoginPage loginPage = new HabrLoginPage(_driver);
            loginPage.OpenPage();
            loginPage.Login(_userData.ValidEmail, _userData.ValidPassword);

            Assert.IsTrue(TestUtilities.Wait.Until(e => loginPage.CheckLogin).Displayed);
        }

        [Test]
        public void LoginHabrInvalidTest()
        {
            HabrLoginPage loginPage = new HabrLoginPage(_driver);
            loginPage.OpenPage();
            loginPage.Login(_userData.InvalidEmail, _userData.InvalidPassword);

            Assert.IsTrue(TestUtilities.Wait.Until(e => loginPage.CheckLoginInvalid).Displayed);
        }

        [Test]
        public void LoginHabrEmptyTest()
        {
            HabrLoginPage loginPage = new HabrLoginPage(_driver);
            loginPage.OpenPage();
            loginPage.Login(_userData.EmptyEmail, _userData.EmptyPassword);

            Assert.IsTrue(TestUtilities.Wait.Until(e => loginPage.CheckLoginInvalid).Displayed);
        }

        [Test]
        public void SearchTextTest()
        {
            HabrSearchPage searchPage = new HabrSearchPage(_driver);
            searchPage.OpenPage();
            searchPage.Search();

            Assert.IsTrue(searchPage.CheckSearchResult);
        }

        [Test]
        public void SearchTextByTimeTest()
        {
            HabrSearchPage searchPage = new HabrSearchPage(_driver);
            searchPage.OpenPage();
            searchPage.SearchByTime();

            Assert.IsTrue(searchPage.CheckValidTime);
        }

        [Test]
        public void SearchTextByRatingTest()
        {
            HabrSearchPage searchPage = new HabrSearchPage(_driver);
            searchPage.OpenPage();
            searchPage.SearchByRating();

            Assert.IsTrue(searchPage.CheckValidRating);
        }
    }
}
