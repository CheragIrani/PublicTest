using System;
using System.Collections.Generic;

namespace Easyjet.Utilities
{
    public class TestCaseDataModel
    {
        public string FootballTeamName { get; set; }
        public string LeagueName { get; set; }
        public int NumberOfFixtures { get; set; }
        public List<Fixture> Fixtures { get; set; }
        public List<Fixture> FixturesWithTeamsInBottomHalf { get; set; }
    }
}
