using EPAMTestProject.Logger;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace EPAMTestProject.Pages
{
    public class HabrSearchPage
    {
        private const string BaseUrl = "https://habr.com/ru/all/";
        private const string SearchText = "unity";

        private readonly By _searchButton = By.XPath("//a[@href='/ru/search/']");
        private readonly By _searchInput = By.XPath("//input[@name='q']");

        private readonly By _searchFilter = By.XPath("//div[@class='tm-navigation-dropdown__button-text']");
        private readonly By _searchFilterByTime = By.XPath("//div[@class='tm-layout']//li[2]");
        private readonly By _searchFilterByRating = By.XPath("//div[@class='tm-layout']//li[3]");

        private readonly string _firstArticle = "//article[1]";
        private readonly string _secondArticle = "//article[2]";

        private IWebDriver _driver;

        private bool _validTime;
        private bool _validRating;

        public HabrSearchPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public bool CheckSearchResult => _driver.FindElements(By.XPath("//em[@class='searched-item']")).Count != 0;
        public bool CheckValidTime => _validTime;
        public bool CheckValidRating => _validRating;

        public void OpenPage()
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            _driver.Navigate().GoToUrl(BaseUrl);
        }

        public void Search()
        {
            _driver.FindElement(_searchButton).Click();

            var searchInput = _driver.FindElement(_searchInput);
            searchInput.SendKeys(SearchText);
            searchInput.Submit();
        }

        public void SearchByTime()
        {
            Search();

            _driver.FindElement(_searchFilter).Click();
            _driver.FindElement(_searchFilterByTime).Click();

            var firstArticleTime = _driver.FindElement(By.XPath($"{_firstArticle}//time"));
            var firstTime = DateTime.ParseExact(firstArticleTime.GetAttribute("title"), "yyyy-MM-dd, HH:mm", null);

            var secondArticleTime = _driver.FindElement(By.XPath($"{_secondArticle}//time"));
            var secondTime = DateTime.ParseExact(secondArticleTime.GetAttribute("title"), "yyyy-MM-dd, HH:mm", null);

            _validTime = DateTime.Compare(firstTime, secondTime) > 0;
        }

        public void SearchByRating()
        {
            Search();

            _driver.FindElement(_searchFilter).Click();
            _driver.FindElement(_searchFilterByRating).Click();

            var firstArticle = _driver.FindElement(By.XPath($"{_firstArticle}//span[contains(@class, 'rating')]"));
            var firstArticleRating = int.Parse(firstArticle.Text);
            TestLogger.Instance.Info(firstArticleRating);

            var secondArticle = _driver.FindElement(By.XPath($"{_secondArticle}//span[contains(@class, 'rating')]"));
            var secondArticleRating = int.Parse(secondArticle.Text);
            TestLogger.Instance.Info(secondArticleRating);

            _validRating = firstArticleRating >= secondArticleRating;
        }
    }
}
