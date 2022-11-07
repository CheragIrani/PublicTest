using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Easyjet.Helper;
using Easyjet.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Easyjet.POM
{
    public class ScoresFixtures
    {
        IWebDriver _driver;

        By ScoresAndFixturesHeading => By.XPath("//div/h1[text() = 'Football Scores & Fixtures']");

        By TeamOrCompetitionInput => By.CssSelector("input[name = 'search']");

        By PremierLeagueOption => By.CssSelector("a[href = '/sport/football/premier-league/scores-fixtures']");

        By TableLink => By.CssSelector("a[href = '/sport/football/premier-league/table']");

        public ScoresFixtures(IWebDriver driver)
        {
            _driver = driver;
            Assert.IsTrue(driver.IsElementDisplayed(ScoresAndFixturesHeading));
        }

        public ScoresFixtures SearchLeague(string leagueName)
        {
            _driver.SendKeys(TeamOrCompetitionInput, leagueName);
            Thread.Sleep(2000);
            return this;
        }

        public void SelectPremierLeagueOption()
        {
            _driver.Click(PremierLeagueOption);
        }

        public Table ClickTableLink()
        {
            _driver.Click(TableLink);

            return new Table(_driver);
        }

        public By GetFixtureMonthElement(DateTime date)
        {
            var dateFormat = date.ToString("yyyy-MM");
            if(dateFormat == DateTime.Now.ToString("yyyy-MM"))
            {
                return By.CssSelector($"a[href = '/sport/football/premier-league/scores-fixtures/{dateFormat}?filter=fixtures']");
            }
            else
            {
                return By.CssSelector($"a[href = '/sport/football/premier-league/scores-fixtures/{dateFormat}']");
            }
            
        }

        public List<Fixture> GetFixturesFotNext3Months()
        {
            List<Fixture> fixtures = new List<Fixture>();
            
            for(int i = 0; i < 3; i++)
            {
                By fixtureMonthElement = GetFixtureMonthElement(DateTime.Now.AddMonths(i));
                _driver.Click(fixtureMonthElement);
                Thread.Sleep(2000);

                var listOfFixtures = _driver.FindElements(By.CssSelector("span[role = 'region'] ul>li"));
                
                foreach(var fixture in listOfFixtures)
                {
                    fixtures.Add(new Fixture() { HomeTeam = fixture.FindElement(By.XPath("article/div/span[1]/span/abbr")).GetAttribute("title"), AwayTeam = fixture.FindElement(By.XPath("article/div/span[3]/span/abbr")).GetAttribute("title") });
                }
            }
            return fixtures;
        }

        public List<Fixture> GetFixturesForTeam(string teamName, int numberOfFixtures)
        {
            var listOfFixturesInNext3Months = GetFixturesFotNext3Months();

            return listOfFixturesInNext3Months.Where(c => c.HomeTeam == teamName || c.AwayTeam == teamName).ToList().Take(numberOfFixtures).ToList();
        }
    }
}
