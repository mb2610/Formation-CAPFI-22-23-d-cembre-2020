using TechTalk.SpecFlow;

namespace Shouty.Specs.Infrastructure
{
    [Binding]
    public class LocationAdapter
    {
        [StepArgumentTransformation(@"\[(.*), (.*)]")]
        public Location Adapt(int latitude, int longitude)
        {
            return new Location(latitude, longitude);
        }
    }
}
