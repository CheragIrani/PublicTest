using System;
using System.Collections.Generic;
using Easyjet.Utilities;

namespace Easyjet.Test.Testdata
{
    public class BBCSportsTestData
    {
        public static TestCaseDataModel[] testData =
        {
            new TestCaseDataModel
            {
                FootballTeamName = "Tottenham Hotspur",
                LeagueName = "Premier League",
                NumberOfFixtures = 5,
                Fixtures = new List<Fixture>()
                {
                    new Fixture
                    {
                        HomeTeam = "Tottenham Hotspur",
                        AwayTeam = "Leeds United"
                    },
                    new Fixture
                    {
                        HomeTeam = "Brentford",
                        AwayTeam = "Tottenham Hotspur"
                    },
                    new Fixture
                    {
                        HomeTeam = "Tottenham Hotspur",
                        AwayTeam = "Aston Villa"
                    },
                    new Fixture
                    {
                        HomeTeam = "Crystal Palace",
                        AwayTeam = "Tottenham Hotspur"
                    },
                    new Fixture
                    {
                        HomeTeam = "Tottenham Hotspur",
                        AwayTeam = "Arsenal"
                    }
                }
            }
        }; 
    }
}
