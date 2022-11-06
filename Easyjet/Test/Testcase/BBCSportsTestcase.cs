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

            List<Fixture> fixturesWithTeamsInBottomHalf = new List<Fixture>();
            foreach(var fixture in next5FixturesForTottenham)
            {
                foreach(var lowerHalfTeam in teamsInBottomHalfOfpremierLeague)
                {
                    if(fixture.HomeTeam == lowerHalfTeam || fixture.AwayTeam == lowerHalfTeam)
                    {
                        fixturesWithTeamsInBottomHalf.Add(fixture);
                    }
                }
            }
            Assert.AreEqual(fixturesWithTeamsInBottomHalf.Count, 3);
        }
    }
}
