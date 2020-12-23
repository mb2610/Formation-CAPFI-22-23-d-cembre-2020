using NFluent;
using NUnit.Framework;

namespace Shouty.Tests
{
    public class LocationShould
    {
        [Test]
        public void CalculatesTheDistanceFromItself()
        {
            var location = new Location(0, 0);
            Check.That(location.DistanceFrom(location)).IsEqualTo(0);
        }

        [Test]
        public void CalculatesTheDistanceFromAnotherLocationAlongLatitude()
        {
            var location = new Location(0, 0);
            var otherLocation = new Location(600, 0);
            Check.That(location.DistanceFrom(otherLocation)).IsEqualTo(600); 
        }

        [Test]
        public void CalculatesTheDistanceFromAnotherLocation()
        {
            var location = new Location(0, 0);
            var otherLocation = new Location(300, 400);
            Check.That(location.DistanceFrom(otherLocation)).IsEqualTo(500);
        }
    }
}
