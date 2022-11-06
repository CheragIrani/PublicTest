using System;
using System.Collections.Generic;
using Easyjet.Helper;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Easyjet.POM
{
    public class Table
    {
        IWebDriver _driver;

        By PremierLeagueTableHeader => By.XPath("//h1/span[contains(text(), 'Premier League')]");

        public Table(IWebDriver driver)
        {
            _driver = driver;

            Assert.IsTrue(driver.IsElementDisplayed(PremierLeagueTableHeader));
        }

        public List<string> GetListOfTeamsInBottomHalf()
        {
            List<string> teamsInBottomHalf = new List<string>();

            var numberOfTeamsInTable = _driver.FindElements(By.CssSelector("table tbody>tr"));

            for(int i = numberOfTeamsInTable.Count/2 + 1; i <= numberOfTeamsInTable.Count; i++)
            {
                teamsInBottomHalf.Add(_driver.FindElement(By.CssSelector($"table tbody>tr:nth-child({i}) a>span")).GetAttribute("data-900"));
            }

            return teamsInBottomHalf;
        }
    }
}
