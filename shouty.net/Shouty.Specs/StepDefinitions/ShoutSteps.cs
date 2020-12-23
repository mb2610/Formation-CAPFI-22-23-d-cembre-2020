using NFluent;
using TechTalk.SpecFlow;

namespace Shouty.Specs.StepDefinitions
{
    [Binding]
    public class ShoutSteps
    {
        private const string ArbitraryMessage = "Hello, world";
        private readonly IShoutyNetwork _shoutyNetwork;

        public ShoutSteps(IShoutyNetwork shoutyNetwork)
        {
            _shoutyNetwork = shoutyNetwork;
        }

        [Given(@"(.*) is at (.*)")]
        public void GivenIsAt(string shouterName, Location location)
        {
            _shoutyNetwork.SetLocation(shouterName, location);
        }

        [When(@"(.*) shouts")]
        public void WhenShouts(string shouterName)
        {
            _shoutyNetwork.Shout(shouterName, ArbitraryMessage);
        }

        [Then(@"(.*) should hear (.*)")]
        public void ThenShouldHear(string shouterName, string message)
        {          
            Check.That(_shoutyNetwork.GetShoutsHeardBy(shouterName).Count)
                .IsEqualTo(message.Equals("nothing") ? 0: 1);
        }
    }
}