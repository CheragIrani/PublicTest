using System;
using Easyjet.Helper;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Easyjet.POM
{
    public class Sports
    {
        IWebDriver _driver;
        By HomeLink => By.XPath("//span[text()= 'Home']");
        By FootballLink => By.XPath("//span[text()= 'Football']");
        By CricketLink => By.XPath("//span[text()= 'Cricket']");

        public Sports(IWebDriver driver)
        {
            _driver = driver;
            Assert.IsTrue(driver.IsElementDisplayed(HomeLink) && driver.IsElementDisplayed(FootballLink) && driver.IsElementDisplayed(CricketLink));
        }

        public Football ClickFootballLink()
        {
            _driver.Click(FootballLink);
            return new Football(_driver);
        }
    }
}
