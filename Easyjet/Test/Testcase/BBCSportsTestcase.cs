using System;
using System.Collections.Generic;
using Easyjet.POM;
using Easyjet.Test.Testdata;
using Easyjet.Utilities;
using NUnit.Framework;

namespace Easyjet.Test.Testcase
{
    [TestFixture]
    public class BBCSportsTestcase : Setup
    {
        [Test, TestCaseSource(typeof(BBCSportsTestData), "testData")]
        public void RunBBCSportsTestcase(TestCaseDataModel testData )
        {
            Sports sports = new Sports(_driver);
            var football = sports.ClickFootballLink();

            var scoresFixtures = football.ClickScoresAndFixtures();
            scoresFixtures.SearchLeague(testData.LeagueName).SelectPremierLeagueOption();
            var next5FixturesForTottenham = scoresFixtures.GetFixturesForTeam(testData.FootballTeamName, testData.NumberOfFixtures);
            
            for(int i = 0; i < next5FixturesForTottenham.Count; i++)
            {
                Assert.AreEqual(next5FixturesForTottenham[i].HomeTeam, testData.Fixtures[i].HomeTeam);
                Assert.AreEqual(next5FixturesForTottenham[i].AwayTeam, testData.Fixtures[i].AwayTeam);
            }

            var premierLeagueTable = scoresFixtures.ClickTableLink();
            var teamsInBottomHalfOfpremierLeague = premierLeagueTable.GetListOfTeamsInBottomHalf();
            Assert.AreEqual(10, teamsInBottomHalfOfpremierLeague.Count);

            List<Fixture> fixturesWithTeamsInBottomHalf = new List<Fixture>();

            for(int i = 0; i < next5FixturesForTottenham.Count; i++)
            {
                for(int j = 0; j < teamsInBottomHalfOfpremierLeague.Count; j++)
                {
                    if (next5FixturesForTottenham[i].HomeTeam.ToLower() == teamsInBottomHalfOfpremierLeague[j].ToLower() || next5FixturesForTottenham[i].AwayTeam.ToLower() == teamsInBottomHalfOfpremierLeague[j].ToLower())
                    {
                        fixturesWithTeamsInBottomHalf.Add(next5FixturesForTottenham[i]);
                    }
                }
            }

            Assert.AreEqual(3, fixturesWithTeamsInBottomHalf.Count);
        }
    }
}
