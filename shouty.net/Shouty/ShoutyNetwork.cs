using System.Collections.Generic;

namespace Shouty
{
    public class ShoutyNetwork : IShoutyNetwork
    {
        private const int MessageRange = 1000;

        private readonly Dictionary<string, Location> _locationsByPersons = new Dictionary<string, Location>();
        private readonly Dictionary<string, List<string>> _shoutsByShouters = new Dictionary<string, List<string>>();

        public void SetLocation(string shouterName, Location location)
        {
            _locationsByPersons[shouterName] = location;
        }

        public void Shout(string shouterName, string messageShouted)
        {
            if (!_shoutsByShouters.ContainsKey(shouterName))
            {
                _shoutsByShouters[shouterName] = new List<string>();
            }
            _shoutsByShouters[shouterName].Add(messageShouted);
        }

        public IDictionary<string, List<string> > GetShoutsHeardBy(string listenerName)
        {
            var shoutsHeard = new Dictionary<string, List<string>>();

            foreach (var shoutByShouter in _shoutsByShouters)
            {
                var shouterName = shoutByShouter.Key;
                var shouts = shoutByShouter.Value;

                var distance = _locationsByPersons[shouterName]
                    .DistanceFrom(_locationsByPersons[listenerName]);

                if (IsInRange(distance) && IsNotMySelf(listenerName, shouterName))
                    shoutsHeard.Add(shouterName, shouts);
            }
            return shoutsHeard;
        }

        private static bool IsNotMySelf(string listenerName, string shouterName)
        {
            return !listenerName.Equals(shouterName);
        }

        private static bool IsInRange(int distance)
        {
            return distance < MessageRange;
        }
    }
}
