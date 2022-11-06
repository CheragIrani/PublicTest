using System;
using Easyjet.Helper;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Easyjet.POM
{
    public class Football
    {
        By ScoresAndFixturesLink => By.CssSelector("a[data-stat-title = 'Scores & Fixtures']");
        By TablesLink => By.CssSelector("a[data-stat-title = 'Tables']");
        By GossipLink => By.CssSelector("a[data-stat-title = 'Gossip']");

        IWebDriver _driver;

        public Football(IWebDriver driver)
        {
            _driver = driver;
            Assert.IsTrue(driver.IsElementDisplayed(ScoresAndFixturesLink) && driver.IsElementDisplayed(TablesLink) && driver.IsElementDisplayed(GossipLink));
        }

        public ScoresFixtures ClickScoresAndFixtures()
        {
            _driver.Click(ScoresAndFixturesLink);

            return new ScoresFixtures(_driver);
        }
    }
}
