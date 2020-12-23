using BoDi;
using TechTalk.SpecFlow;

namespace Shouty.Specs.Infrastructure
{
    [Binding]
    public class RegisterApi
    {
        private readonly IObjectContainer _container;

        public RegisterApi(IObjectContainer container)
        {
            _container = container;
        }

        [BeforeScenario]
        public void Register()
        {
            _container.RegisterInstanceAs<IShoutyNetwork>(new ShoutyNetwork());
        }
    }
}
