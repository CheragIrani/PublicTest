using System;
using Easyjet.Helper;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Easyjet.POM
{
    public class Football
    {
        By ScoresAndFixturesLink => By.LinkText("/sport/football/scores-fixtures");
        By TablesLink => By.LinkText("/sport/football/tables");
        By GossipLink => By.LinkText("/sport/football/gossip");

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
