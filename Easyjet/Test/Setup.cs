using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Easyjet.Test
{
    public class Setup
    {
        public IWebDriver _driver;

        [SetUp]
        public void SetupTest()
        {
            _driver = new ChromeDriver(".");
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("https://www.bbc.co.uk/sport");
        }
    }
}
