using System;
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
            foreach(var tottenhamFixture in next5FixturesForTottenham)
            {
                Console.WriteLine(tottenhamFixture.HomeTeam + "vs " + tottenhamFixture.AwayTeam);
            }

            var premierLeagueTable = scoresFixtures.ClickTableLink();
            var teamsInBottomHalfOfpremierLeague = premierLeagueTable.GetListOfTeamsInBottomHalf();
            foreach(var team in teamsInBottomHalfOfpremierLeague)
            {
                Console.WriteLine(team);
            }
        }
    }
}
