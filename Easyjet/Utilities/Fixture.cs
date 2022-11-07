using System;
namespace Easyjet.Utilities
{
    public class Fixture : IEquatable<Fixture>
    {
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }

        public bool Equals(Fixture expectedFixture)
        {
            return HomeTeam == expectedFixture.HomeTeam && AwayTeam == expectedFixture.AwayTeam ;
        }
    }
}
