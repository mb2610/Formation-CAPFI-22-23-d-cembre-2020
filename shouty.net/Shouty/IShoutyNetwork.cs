using System.Collections.Generic;

namespace Shouty
{
    public interface IShoutyNetwork
    {
        void SetLocation(string shouterName, Location location);
        void Shout(string shouterName, string messageShouted);
        IDictionary<string, List<string> > GetShoutsHeardBy(string listenerName);
    }
}